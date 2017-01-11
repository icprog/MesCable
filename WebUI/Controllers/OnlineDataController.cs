using MesWeb.Model;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Models;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class OnlineDataController:LayoutBaseController {

        // GET: OnlineData
        public ActionResult Index() {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var workshopLayout = bllLayout.GetModelList("IsTop = 1").FirstOrDefault();
            if(workshopLayout == null) {
                log.Error("车间未施工,请联系施工人员");
            } else {
                TempData["workshopLayout"] = workshopLayout;

                return RedirectToAction("WorkshopLayout");
            }
            var errorInfo = new VM_Error_Info { Title = "施工错误",ErrorMessage = "车间未施工，请联系施工人员" };
            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,errorInfo);
        }

        public ActionResult WorkshopLayout() {
            updateLayoutState();
            MesWeb.Model.T_LayoutPicture workshopLayout = (MesWeb.Model.T_LayoutPicture)TempData["workshopLayout"];
            return View(GetLayoutInfo(workshopLayout));
        }

        public ActionResult AreaDetail(int Id) {
            updateLayoutState();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var layout = bllLayout.GetModel(Id);
            if(layout.LayoutTypeID != null) {
                var bllLayoutType = new MesWeb.BLL.T_LayoutType();
                var layoutType = bllLayoutType.GetModel((int)layout.LayoutTypeID);
                if(layoutType.TableName == AreaIdentity.WorkArea) {
                    return RedirectToAction("ProcedureLayout",new { Id = Id });
                } else if(layoutType.TableName == AreaIdentity.StoreArea) {
                    return RedirectToAction("StoreLayout",new { Id = Id });
                } else if(layoutType.TableName == AreaIdentity.ExtraSensor) {
                    return RedirectToAction("ExtraSensorLayout",new { Id = Id });
                }
            }
            log.Error("未指定该标记的类别");
            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,new { errorMessage = "系统错误" });


        }

        public ActionResult ProcedureLayout(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var procedure = bllLayout.GetModel(Id);

            VM_LayoutPicture layoutInfo = new VM_LayoutPicture(procedure);
            if(procedure != null) {
                layoutInfo = GetLayoutInfo(procedure);
            }
            return View(layoutInfo);

        }

        public ActionResult StoreLayout(int Id) {
            return View();
        }

        public ActionResult ExtraSensorLayout(int Id) {
            return View(Id);
        }

        public string GetExtraSensorData(int Id) {
            var sensorLayout = bllLayout.GetModel(Id);
            var retData = new VM_Result_Data();
            List<VM_Fusioncharts_Line> vmChartList = new List<VM_Fusioncharts_Line>();
            try {
                if(sensorLayout != null) {
                    if(sensorLayout.LayoutTypeID == (int)LAYOUT_TPYE.EXTRA_SENSOR) {
                        vmChartList = getSensorLineChartList((int)sensorLayout.TableRowID,(int)VIRTUAL_LAYOUT.VIRTUAL_MACHINE);
                        if(vmChartList[0].data.Count > 0) {
                            retData.Code = RESULT_CODE.OK;
                            retData.Content = "加载成功";
                            retData.Appendix = vmChartList;
                        } else {
                            retData.Content = "加载传感器数据失败！";
                            log.Error("加载传感器失败");
                        }
                    }
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                retData.Content = "系统错误";
                log.Error("查找传感器数据失败",e);
            }
            return JsonConvert.SerializeObject(retData);
        }
        public JsonResult GetCPKData(int Id) {
            var retData = new VM_Result_Data();

            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetODCPKChartDataAction(int layoutID) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            VM_Fusioncharts_MSLine vmCharts = new VM_Fusioncharts_MSLine();
            int machineID = 0;
            try {
                machineID = getTableRowID(layoutID);
                if(machineID == 0) {
                    retData.Content = "机台号出错";
                    log.Warning("机台号出错");
                } else {
                    vmCharts = getMachineCPKMSLineData(machineID,(int)SPEC_PARAM_CODE.OUTTER_OD);
                }
            } catch(Exception e) {
                log.Error("OD的CPK出错",e);
                retData.Content = "OD值CPK计算出错";
            }
            if(vmCharts.dataset.Count > 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "加载OD CPK成功";
                retData.Appendix = vmCharts;
                // retData.Appendix.CPK = cpk;
            }
            return Json(retData);

        }

        [HttpPost]
        public JsonResult GetTensionCPKChartDataAction(int machineID) {
            var cpk = GetCPKValue((int)SPEC_PARAM_CODE.TESSION,machineID);

            return Json(cpk);
        }
        [HttpPost]
        public JsonResult GetRPMCPKChartDataAcion(int machineID) {
            var cpk = GetCPKValue((int)SPEC_PARAM_CODE.RPM,machineID);

            return Json(cpk);
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

        public JsonResult GetMachineLayout(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var machineLayout = bllLayout.GetModel(Id);
            var layoutInfo = new VM_LayoutPicture(machineLayout);
            if(!string.IsNullOrEmpty(machineLayout.PicUrl)) {
                layoutInfo = new VM_LayoutPicture(machineLayout);
                layoutInfo = GetLayoutInfo(machineLayout);
            } else {
                log.Error("机台信息为空");
            }
            return Json(layoutInfo);
        }

        [HttpPost]
        [Obsolete("use method GetSensorChartAction(int Id)")]
        public string GetSensorDataAction(int Id) {
            var sensorLayout = bllLayout.GetModel(Id);
            var retData = new VM_Result_Data();
            List<VM_Fusioncharts_Line> vmChartList = new List<VM_Fusioncharts_Line>();
            try {
                var machineLayout = GetParentLayout(Id);
                if(sensorLayout != null && machineLayout != null) {
                    vmChartList = getSensorLineChartList(
                        (int)sensorLayout.TableRowID,(int)machineLayout.TableRowID);

                }

                if(vmChartList.Count > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "加载成功";
                    retData.Appendix = vmChartList;
                } else {
                    retData.Content = "加载传感器数据失败！";
                    log.Error("加载传感器失败");
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                retData.Content = "系统错误";
                log.Error("查找传感器数据失败",e);
            }
            return JsonConvert.SerializeObject(retData);
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
                        vmLineChart.Add(getSensorLineChart<MesWeb.BLL.T_CollectedDataParameters>(machineID,(int)code.ParameterCodeID,12));
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

        [HttpPost]
        public JsonResult GetMachinePropertyAction(int Id) {
            var retData = new VM_Result_Data();
            var machPty = GetMachineProperty(Id);
            if(machPty != null) {
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = machPty;
            } else {
                retData.Content = "加载机台信息失败";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetSelParamIds(int layoutId) {
            var retData = new VM_Result_Data();
            try {
                var layout = bllLayout.GetModel(layoutId);
                var bllParamCode_Sensor = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
                var bllSensor = new MesWeb.BLL.T_SensorModule();
                var sensor = bllSensor.GetModel((int)layout.TableRowID);
                var paramCode_SensorList = bllParamCode_Sensor.GetModelList("SensorModuleID = " + sensor.SensorModuleID);
                var paramCodeIds = new List<int?>();
                foreach(var item in paramCode_SensorList) {
                    paramCodeIds.Add(item.ParameterCodeID);
                }
                if(paramCodeIds.Count > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Appendix = paramCodeIds;
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("获取模块参数失败！",e);
                retData.Content = "获取模块参数失败！";
            }
            return Json(retData);

        }



        /// <summary>
        /// 更新布局状态 
        /// </summary>
        private void updateLayoutState() {
            updateMachineState();
            updateProcState();
        }


        /// <summary>
        /// 更新机台状态
        /// </summary>
        private void updateMachineState() {
            var bllFault = new MesWeb.BLL.T_FaultModule();
            var machLayoutList = bllLayout.GetModelList("LayoutTypeID = " + (int)LAYOUT_TPYE.MACHINE);
            foreach(var mach in machLayoutList) {
                if(mach.TableRowID.HasValue) {
                    var fault = bllFault.GetModelList("MachineID = " + mach.TableRowID).FirstOrDefault();
                    if(fault != null) {
                        var faultCode = fault.State;
                        char splitChar = '-';
                        //取得错误信息
                        var faultMessage = faultMapMessage(faultCode,splitChar);
                        // if(!string.IsNullOrEmpty(faultMessage)) {
                        //更新机台的状态信息
                        mach.Message = faultMessage;
                        // }
                        mach.State = (int)faultMapState(faultCode,splitChar);
                    } else {
                        mach.Message = "状态数据为空";
                        mach.State = (int)LAYOUT_STATE.ERROR;
                    }

                    bllLayout.Update(mach);

                }
            }
        }

        private string mapStateMeaning(int state) {
            switch(state) {
                case -1:
                return "离线";
                case 1:
                return "正常";
                case 2:
                return "警告";
                case 3:
                return "错误";
            }
            return "系统错误";
        }

        /// <summary>
        /// 更新工序状态
        /// </summary>
        private void updateProcState() {
            var procLayoutList = bllLayout.GetModelList("LayoutTypeID = " + (int)LAYOUT_TPYE.WORK_AREA);
            var bllMachine = new MesWeb.BLL.T_Machine();
            foreach(var procLayout in procLayoutList) {
                var machLayoutList = bllLayout.GetModelList("ParentLayoutPictureID = " + procLayout.LayoutPictureID + " AND " + "LayoutTypeID = " + (int)LAYOUT_TPYE.MACHINE);
                procLayout.Message = "";
                foreach(var machLayout in machLayoutList) {
                    var machine = bllMachine.GetModel(machLayout.TableRowID.Value);
                    procLayout.Message += machine.MachineName + ":" + mapStateMeaning(machLayout.State.Value) + "<br/>";

                    if(machine == null) {
                        continue;
                    }
                    //procLayout.Message += machine.MachineName + ":" + machLayout.State;
                    //有机台错误状态
                    if(machLayout.State == (int)LAYOUT_STATE.ERROR) {
                        procLayout.State = (int)LAYOUT_STATE.ERROR;

                        break;
                    }
                    //有机台离线状态
                    else if(machLayout.State == (int)LAYOUT_STATE.OFFLINE) {
                        procLayout.State = (int)LAYOUT_STATE.OFFLINE;
                        continue;

                    }
                    //有机台警告状态
                    else if(machLayout.State == (int)LAYOUT_STATE.WARNING && procLayout.State != (int)LAYOUT_STATE.OFFLINE) {
                        procLayout.State = (int)LAYOUT_STATE.WARNING;
                        continue;
                        //正常状态
                    } else if(procLayout.State != (int)LAYOUT_STATE.WARNING) {
                        procLayout.State = (int)LAYOUT_STATE.NORMAL;
                    }

                }
                bllLayout.Update(procLayout);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        private string faultMapMessage(string code,char splitChar) {
            var faultCodes = code.Split(splitChar);
            if(faultCodes.Length != 5) {
                return null;
            }
            string message = "485: " + map485(faultCodes[0]) + "<br/> 读卡：" + mapReadCD(faultCodes[1])
                + "<br/> 转动： " + mapTurn(faultCodes[2]);

            return message;
        }

        enum LAYOUT_STATE {
            OFFLINE = -1,
            NORMAL = 0,
            WARNING = 2,
            ERROR = 3,
            SYSTEM_FAULT = 4
        }

        struct CODE_MAP_STATE {
            private const string NO_CHECK_PARAM = "255";

            /// <summary>
            /// 485正常
            /// </summary>
            public const string RS485_OK = "0";

            /// <summary>
            /// 485故障
            /// </summary>
            public const string RS485_ERROR = "1";

            /// <summary>
            /// 读到两张卡
            /// </summary>
            public const string ReadCD_2_CD = "0";

            /// <summary>
            /// 读卡确认中
            /// </summary>
            public const string ReadCD_CHECKING = "1";

            /// <summary>
            /// 每一组读到卡
            /// </summary>
            public const string ReadCD_NO_CD = "6";

            /// <summary>
            /// 读到1张卡
            /// </summary>
            public const string ReadCD_1_CD = "7";

            /// <summary>
            /// 没有检查到读卡参数
            /// </summary>
            public const string ReadCD_NO_CHECK_PARAM = NO_CHECK_PARAM;


            /// <summary>
            /// 没有转动
            /// </summary>
            public const string Turn_NO_TURN = "0";


            /// <summary>
            /// 正在转动
            /// </summary>
            public const string Turn_TURNING = "1";


            /// <summary>
            /// 没有检测到转动参数
            /// </summary>
            public const string Turn_NO_CHECK_PARAM = NO_CHECK_PARAM;
        }

        /// <summary>
        /// code转layout的State
        /// </summary>
        /// <param name="faultCode"></param>
        /// <returns></returns>
        private LAYOUT_STATE faultMapState(string faultCode,char splitChar) {
            var faultCodes = faultCode.Split(splitChar);
            if(faultCodes.Length != 5) {
                return LAYOUT_STATE.ERROR;
            }
            if(faultCodes[0] != CODE_MAP_STATE.RS485_OK) {
                return LAYOUT_STATE.ERROR;
            }
            if(faultCodes[1] != CODE_MAP_STATE.ReadCD_NO_CD) {
                return LAYOUT_STATE.ERROR;
            }
            return LAYOUT_STATE.NORMAL;
        }

        /// <summary>
        /// 485状态
        /// </summary>
        /// <param name="code">状态值</param>
        /// <returns></returns>
        private string map485(string code) {
            switch(code) {
                case CODE_MAP_STATE.RS485_OK:
                return "正常";
                case CODE_MAP_STATE.RS485_ERROR:
                return "故障";
                default:
                return "协议出错";
            }
        }

        /// <summary>
        /// 读卡映射
        /// </summary>
        /// <param name="code">状态值</param>
        /// <returns></returns>
        private string mapReadCD(string code) {
            switch(code) {
                case CODE_MAP_STATE.ReadCD_2_CD:
                return "2张卡";
                case CODE_MAP_STATE.ReadCD_CHECKING:
                return "正在确认";
                case CODE_MAP_STATE.ReadCD_1_CD:
                return "1张卡";
                case CODE_MAP_STATE.ReadCD_NO_CHECK_PARAM:
                return "未检测到参数";
                default:
                return "协议出错";
            }
        }

        /// <summary>
        /// 转动映射
        /// </summary>
        /// <param name="code">状态值</param>
        /// <returns></returns>
        private string mapTurn(string code) {
            switch(code) {
                case CODE_MAP_STATE.Turn_NO_TURN:
                return "没有转动";
                case CODE_MAP_STATE.Turn_TURNING:
                return "在转动";
                case CODE_MAP_STATE.Turn_NO_CHECK_PARAM:
                return "未检测到参数";
                default:
                return "协议出错";

            }
        }

        /// <summary>
        /// 获取参数曲线的基本属性
        /// </summary>
        /// <param name="layoutId">sensor 的 layoutID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetParamChartProperties(int layoutId) {
            var retData = new VM_Result_Data();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var properties = new List<VM_Highcharts_Property>();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var bllSensor_ParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
            var bllSensor = new MesWeb.BLL.T_SensorModule();
            var bllUnit = new MesWeb.BLL.T_ParameterUnit();
            var bllParamCol = new MesWeb.BLL.T_ParametersCol();

            try {
                var sensroLayout = bllLayout.GetModel(layoutId);
                if(sensroLayout.LayoutTypeID != (int)LAYOUT_TPYE.SENSOR_MODULE) {
                    retData.Content = "施工有误，请联系管理员";
                    log.Error("传感器模块参数错误");
                    return Json(retData);
                }
                var machLayout = GetParentLayout(layoutId);
                var machineId = machLayout.TableRowID.Value;
                var sensor = bllSensor.GetModel(sensroLayout.TableRowID.Value);
                var sensor_codes = bllSensor_ParamCode.GetModelList("SensorModuleID = " + sensor.SensorModuleID);
                foreach(var sc in sensor_codes) {

                    var property = new VM_Highcharts_Property();
                    //获取参数
                    var code = bllParamCode.GetModel(sc.ParameterCodeID.Value);
                    //是否能够画曲线
                    property.CanDrawChart = canDrawChart(code.ParameterCodeID);
                    //曲线类型，将drawType为一样的曲线画在同一图上
                    property.drawType = code.ParameterType;
                    property.Title = code.ParameterName;
                    property.ParamCodeId = code.ParameterCodeID;
                
                    //获取参数单位
                    if(code.ParameterUnitID.HasValue) {
                        var unit = bllUnit.GetModel(code.ParameterUnitID.Value);
                        if(unit != null) {
                            property.Symbol = unit.ParameterUnitSymbol;
                        }
                    }else {
                        property.Symbol = "未设置";
                    }
                    //获取参数最值
                    var paramCol = bllParamCol.GetModelList("ParameterCodeID = " + code.ParameterCodeID + "AND MachineID = " + machineId).FirstOrDefault();
                    if(paramCol != null) {
                        property.MaxValue = float.Parse(paramCol.ParametersColMaxiumValue);
                        property.MinValue = float.Parse(paramCol.ParametersColMiniumValue);
                    }

                    //是否带有 CPK 
                    if(Enum.IsDefined(typeof(CPK_PARAM_CODE),sc.ParameterCodeID)) {
                        property.IsCPK = true;
                    } else {
                        property.IsCPK = false;
                    }
                    properties.Add(property);
                }

                if(properties.Count > 0) {
                    retData.Code = RESULT_CODE.OK;
                    //每参数曲线基本值(最值，标题，单位等等)
                    //每个模块有多个参数，所以这里是一个properties集合
                    retData.Appendix = properties;
                    //给每个模块绑定传感器编号，便于接受485报警
                    retData.Content = sensor.SerialNum;
                }

            } catch(Exception e) {
                log.Error("获取模块参数失败",e);
                retData.Content = "获取模块参数失败";
            }
            return Json(retData);
        }

        /// <summary>
        /// 获取特殊参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSpecParam() {

            return Json(new SPEC_PARAM());
        }

        public class SPEC_PARAM {
            public int InnerOD {
                get { return (int)SPEC_PARAM_CODE.INNER_OD; }
            }
            public int OutterOD { get { return (int)SPEC_PARAM_CODE.OUTTER_OD; } }
        }

        /// <summary>
        /// 参数是否能够画曲线
        /// </summary>
        /// <param name="paramCodeId">参数ID</param>
        /// <returns></returns>
        private bool canDrawChart(int paramCodeId) {
            var bllParam = new MesWeb.BLL.T_ParameterCode();
            var paramList = bllParam.GetModelList("");
            foreach(var param in paramList) {
                if(param.ParameterCodeID == paramCodeId) {
                    //所有 paramType 大于0的才具有画图资格
                    if(param.ParameterType.Value > 0) {
                        return true;
                    } else {
                        return false;
                    }
                }
            }
            return false;

        }


    }
}