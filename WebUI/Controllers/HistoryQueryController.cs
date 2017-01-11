using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class HistoryQueryController:LayoutBaseController {
        // GET: HistoryQuery
        public ActionResult Index() {
            return View();
        }
        public ActionResult ProdReached() {
            return View();
        }

        public static VM_HistoryMachine HisMachInfo = new VM_HistoryMachine();
        public ActionResult HistoryMachine(string Id) {
            var axisNumStr = Id.Split(',')[1];
            var tabStr = Id.Split(',')[0];
            string tabName = "HISDATA" + tabStr;
            HisData historyInfo = new HisData(Id);

            var bllHistoryInfo = new MesWeb.BLL.T_HisData(tabName);
            var histories = bllHistoryInfo.GetModelList("Axis_No = '" + axisNumStr + "'");

            if(histories.FirstOrDefault().MachineID.HasValue) {            
                var machineID = histories.FirstOrDefault().MachineID.Value;

                HisMachInfo.MachindID = machineID.ToString();
                HisMachInfo.AxisNumStr = axisNumStr;
                HisMachInfo.HisDataTabName = tabName;

               var machineLayout = bllLayout.GetModelList("TableRowID = " + machineID + "AND LayoutTypeID=" + (int)LAYOUT_TPYE.MACHINE).FirstOrDefault();
                var layoutInfo = new VM_LayoutPicture(machineLayout);
                if(!string.IsNullOrEmpty(machineLayout.PicUrl)) {
                    layoutInfo = new VM_LayoutPicture(machineLayout);
                    layoutInfo = GetLayoutInfo(machineLayout);

                } else {
                    log.Error("机台信息为空");
                    var infoNotFound = new VM_Error_Info { Title = "施工错误",ErrorMessage = "机台信息为空，请联系管理人员",ReturnUrl = "/Admin/Home",ReturnName = "主页" };
                    return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,infoNotFound);

                }
                return View(layoutInfo);

            }
            VM_Error_Info infoError = new VM_Error_Info { Title = "系统错误",ErrorMessage = "未找到该轴号的机台",ReturnUrl = "/Admin/Home",ReturnName = "主页" };
            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController);
        }

        public ActionResult MachineLayout(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var machineLayout = bllLayout.GetModel(Id);
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

        public JsonResult GetAxisDetailAction(string axisNumStr) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var procDetailList = new List<VM_ProcDetail>();
            var hisData = new VM_ProcDetail();
            axisNumStr = axisNumStr.Trim();
            HisMain axisNum = new HisMain(axisNumStr);
            var tabName = axisNum.GetHisDataTableName();
            if(string.IsNullOrEmpty(tabName)) {
                retData.Content = "轴号有误";
                return Json(retData);
            }
            try {
                var bllHisData = new MesWeb.BLL.T_HisMain(tabName);
                var findData = bllHisData.GetModelList("Axis_No = '" + axisNumStr + "'").FirstOrDefault();
                hisData = new VM_ProcDetail {
                    Axis_No = findData.Axis_No,
                    CurrentDataID = findData.CurrentDataID,
                    SpecificationID = findData.SpecificationID,
                    MachineID = findData.MachineID,
                    MachineTypeID = findData.MachineTypeID,
                    EmployeeID_Main = findData.EmployeeID_Main,
                    EmployeeID_Assistant = findData.EmployeeID_Assistant,
                    Start_Axis_No = findData.Start_Axis_No,
                    Printcode = findData.Printcode
                };

                var specID = hisData.SpecificationID;
                var bllMachine = new MesWeb.BLL.T_Machine();
                var bllEmp = new MesWeb.BLL.T_Employee();
                var bllSpec = new MesWeb.BLL.T_Specification();
                var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
                var bllLayout = new MesWeb.BLL.T_LayoutPicture();
                var spec = bllSpec.GetModel((int)specID);
                hisData.SpecName = spec.SpecificationName;
                hisData.ODMax = spec.ODMax.ToString();
                hisData.ODMin = spec.ODMin.ToString();
                hisData.SpecColor = spec.SpecificationColor;
                hisData.RolledYield = "100%";

                hisData.GeneratorTime = bllCodeUsed.GetModelList("Axis_No = '" + hisData.Axis_No + "'").FirstOrDefault().GeneratorTime.Value.ToShortDateString();
                var machine = bllMachine.GetModel((int)hisData.MachineID);
                var machineLayout = bllLayout.GetModelList("LayoutTypeID = " + 1).Find(s => { return s.TableRowID == machine.MachineID; });
                //   hisData.EmployeeName = bllEmp.GetModel((int)hisData.EmployeeID_Main).EmployeeName;
                hisData.EmployeeName = hisData.EmployeeID_Main;
                var tableName = axisNum.Year + axisNum.Month + ((int)(machine.MachineTypeID)).ToString("00");
                hisData.MachineName = "<a href='/HistoryQuery/HistoryMachine/" + tableName + "," + axisNumStr + "'>" + machine.MachineName + "</a>";
                retData.Code = RESULT_CODE.OK;
            } catch(Exception e) {
                log.Error("查询轴号信息失败",e);
                retData.Content = "查询失败，请联系管理员";
            }
            procDetailList.Add(hisData);
            retData.Appendix = procDetailList;
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetSensorChartAction(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var vmLineChart = new List<VM_Fusioncharts_Line>();
            var vmMSLineChart = new List<VM_Fusioncharts_MSLine>();
            var vmChartList = new List<Object>();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var bllSensor_ParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
            if(bllLayout.GetModel(Id).LayoutTypeID != (int)LAYOUT_TPYE.SENSOR_MODULE) {
                log.Error("施工数据出错，误请求！");
                retData.Content = "施工数据出错，误请求！";
                return Json(retData);
            }
            try {
                var sensorID = getTableRowID(Id);
                var machineID = getTableRowID(GetParentLayout(Id).LayoutPictureID);
                var paramCodeIDList = bllSensor_ParamCode.GetModelList("SensorModuleID = " + sensorID);
                foreach(var code in paramCodeIDList) {
                    var paramCode = bllParamCode.GetModel((int)code.ParameterCodeID);
                    if(paramCode == null) {
                        log.Error("施工数据出错，误请求！");
                        retData.Content = "施工数据出错，误请求！";
                        return Json(retData);
                    }
                    //获取多曲线视图
                    //带 CPK 
                    if(Enum.IsDefined(typeof(SPEC_PARAM_CODE),paramCode.ParameterCodeID)) {
                        vmMSLineChart.Add(getMachineCPKMSLineData(machineID,paramCode.ParameterCodeID));

                        //获取单曲线视图           
                    } else if(paramCode.ParameterType == (int)PARAM_TYPE.CHART_MACHINE ||
                        paramCode.ParameterType == (int)PARAM_TYPE.CHART_SITE) {
                        vmLineChart.Add(getSensorLineChart<MesWeb.BLL.T_CollectedDataParameters>(machineID,(int)code.ParameterCodeID));
                    }
                }

            } catch(Exception e) {
                log.Error("获取实时曲线数据失败！",e);
                retData.Content = "获取曲线数据失败!";

            }
            retData.Content = 0;
            if(vmLineChart.Count > 0) {
                vmChartList.Add(vmLineChart);
                retData.Code = RESULT_CODE.OK;
                retData.Content = RESULT_CHART_TYPE.LINE;
            }
            if(vmMSLineChart.Count > 0) {
                vmChartList.Add(vmMSLineChart);
                retData.Code = RESULT_CODE.OK;
                retData.Content = RESULT_CHART_TYPE.MSLINE + (int)retData.Content;
            }
            retData.Appendix = vmChartList;
            return Json(retData);
        }

    }
}