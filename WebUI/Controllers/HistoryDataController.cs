using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class HistoryDataController:LayoutBaseController {
        //参数值映射，服务器发送的是 Type ,我用的是 ID
        //T_ParamCode.Type -----> T_ParamCode.ParamCodeId

        ConcurrentDictionary<int,int> ParamCodeDic {
            get {
                if(paramCodeDic != null) {
                    return paramCodeDic;
                }
                paramCodeDic = new ConcurrentDictionary<int,int>();
                var bllParam = new MesWeb.BLL.T_ParameterCode();
                var paramList = bllParam.GetModelList("");
                foreach(var param in paramList) {
                    paramCodeDic.TryAdd(param.Type.Value,param.ParameterCodeID);
                }
                return paramCodeDic;
            }
        }
        ConcurrentDictionary<int,int> paramCodeDic;
        /// <summary>
        /// 初始化参数映射字典
        /// </summary>


        public ActionResult Index() {


            return View();
        }



        /// <summary>
        /// 通过轴号获取机台历史数据
        /// </summary>
        /// <param name="axisNumStr">轴号</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetHistoryData(string axisNumStr) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            if(HisMain.IsAxisNum(axisNumStr)) {
                var axisNum = new HisData(axisNumStr);

                var bllHisData = new MesWeb.BLL.T_HisData(axisNum.TableName);
                try {
                    var hisDataList = bllHisData.GetModelList("machineID = " + axisNum.MachineId);
                    var sensorDataList = new List<VM_Sensor_Online>();

                    foreach(var item in ParamCodeDic) {
                        //找出映射的数据
                        var data = (from s in hisDataList where s.ParameterCodeID == item.Key select s).ToList();
                        if(data.Count > 0) {
                            //生成传感器的数据结构
                            var sensorData = new  VM_Sensor_Online { ParamCodeId = item.Value };
                            sensorData.SeriesData = new List<VM_Sensor_Data>();
                            foreach(var d in data) {
                                try {
                                    var seriesData = new VM_Sensor_Data { X = ((DateTime)(d.CollectedTime)).AddHours(8).ToUniversalTime().ToString(),Y = float.Parse(d.CollectedValue) };
                                    sensorData.SeriesData.Add(seriesData);

                                } catch(Exception e) {
                                    log.Error(e);
                                    continue;
                                }
                            }
                            sensorDataList.Add(sensorData);
                        }
                    }


                    retData.Appendix = sensorDataList;
                    retData.Content = "加载机台历史数据成功";
                    retData.Code = RESULT_CODE.OK;
                } catch(Exception e) {
                    log.Error(e);
                    retData.Content = "加载机台历史数据失败";
                }
            }
            return Json(retData);
        }
        public ActionResult MachineLayout(int Id) {

            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var bllMachine = new MesWeb.BLL.T_Machine();
            var machine = bllMachine.GetModel(Id);
            try {
                if(machine != null) {
                    var machineLayout = bllLayout.GetModelList("LayoutTypeID = " + (int)LAYOUT_TPYE.MACHINE + " AND " + " TableRowID = " + Id).FirstOrDefault();
                    if(machineLayout != null) {
                        //取出轴号
                        string axisNumStr = (string)TempData[QualityTraceController.SERACH_ASIX];
                        TempData[QualityTraceController.SERACH_ASIX] = axisNumStr;
                        //TODO 临时将备注替换为轴号
                        machineLayout.Remark = axisNumStr;
                        var layoutInfo = new VM_LayoutPicture(machineLayout);
                        if(!string.IsNullOrEmpty(machineLayout.PicUrl)) {
                            layoutInfo = new VM_LayoutPicture(machineLayout);
                            layoutInfo = GetLayoutInfo(machineLayout);
                        } else {
                            log.Error("机台信息为空");
                            VM_Error_Info info = new VM_Error_Info { Title = "施工错误",ErrorMessage = "机台信息为空，请联系管理人员",ReturnUrl = "/Admin/Home",ReturnName = "主页" };
                            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,info);
                        }
                        return View(layoutInfo);
                    }
                }
            } catch(Exception e) {
                log.Error("车间未施工,请联系施工人员",e);
            }
            log.Error("车间未施工,请联系施工人员");
            var errorInfo = new VM_Error_Info { Title = "施工错误",ErrorMessage = "车间未施工，请联系施工人员" };
            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,errorInfo);
        }
    }
}