using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class BasicDataController:BaseController {
        MesWeb.BLL.T_Employee bllEmp = new MesWeb.BLL.T_Employee();
        MesWeb.BLL.T_Department bllDept = new MesWeb.BLL.T_Department();

        public ActionResult Employee() {
            return View();
        }

        public ActionResult Machine() {
            var bllMachine = new MesWeb.BLL.T_Machine();
            var machineList = bllMachine.GetModelList("");
            var bllParam = new MesWeb.BLL.T_ParameterCode();
            var bllSensor = new MesWeb.BLL.T_SensorModule();
            var bllSensor_Param = new MesWeb.BLL.T_SensorModule_T_ParameterCode();

            //机台参数树状结构
            var vmJSTree = new List<VM_JSTree>();
            //遍历机台
            foreach(var machine in machineList) {
                var machineTreeId = "mach_" + machine.MachineID.ToString();
                var machTree = new VM_JSTree { text = machine.MachineName,id = machineTreeId };
                var sensorList = bllSensor.GetModelList("MachineID = " + machine.MachineID);
                machTree.children = new List<VM_JSTree>();
                foreach(var sensor in sensorList) {
                    var spList = bllSensor_Param.GetModelList("SensorModuleID = " + sensor.SensorModuleID);
                    //遍历参数
                    foreach(var sp in spList) {
                        var param = bllParam.GetModel(sp.ParameterCodeID.Value);
                        machTree.children.Add(
                            new VM_JSTree {
                                text = param.ParameterName,
                                id = machineTreeId+"_param_" + param.ParameterCodeID.ToString()
                            });
                    }
                }
                vmJSTree.Add(machTree);
            }
            return View(vmJSTree);
        }

        [HttpPost]
        public JsonResult GetDepartmentAction() {
            var vmCscDropList = new List<VM_CscDrop>();
            var deptList = bllDept.DataTableToList(bllDept.GetAllList().Tables[0]);
            bool selected = true;
            foreach(var dept in deptList) {
                vmCscDropList.Add(new VM_CscDrop { label = dept.DepartmentName,value = dept.DepartmentID.ToString(),selected = selected });
                selected = false;
            }
            return Json(vmCscDropList);
        }

        [HttpPost]
        public JsonResult GetSelDepartmentAction(int Id) {
            var vmCscDropList = new List<VM_CscDrop>();
            var deptList = bllDept.GetModelList("");
            bool selected = false;
            foreach(var dept in deptList) {
                if(dept.DepartmentID == Id) {
                    selected = true;
                }
                vmCscDropList.Add(new VM_CscDrop { label = dept.DepartmentName,value = dept.DepartmentID.ToString(),selected = selected });
                selected = false;
            }
            return Json(vmCscDropList);
        }

        [HttpPost]
        public JsonResult GetSelEmployeeAction(long Id) {
            var empCscList = getEmployeeCscList(Id);
            return Json(empCscList);
        }

        [HttpPost]
        public JsonResult GetEmployeeAction() {
            var empCscList = getEmployeeCscList(1);
            return Json(empCscList);
        }

        private List<VM_CscDrop> getEmployeeCscList(long selId) {
            var vmCscDropList = new List<VM_CscDrop>();
            var empList = bllEmp.GetModelList("");
            bool selected = false;
            foreach(var emp in empList) {
                if(emp.EmployeeID == selId) {
                    selected = true;
                }
                vmCscDropList.Add(new VM_CscDrop { label = emp.EmployeeName,value = emp.EmployeeID.ToString(),selected = selected });
                selected = false;
            }
            return vmCscDropList;
        }


        [HttpPost]
        public JsonResult AddDepartment(MesWeb.Model.T_Department dept) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            if(!string.IsNullOrEmpty(dept.DepartmentName)) {
                var allDeptList = bllDept.DataTableToList(bllDept.GetAllList().Tables[0]);
                foreach(var findDept in allDeptList) {
                    if(findDept.DepartmentName.Trim() == dept.DepartmentName.Trim()) {
                        retData.Content = "该部门已存在";
                        return Json(retData);
                    }
                }
                try {
                    if(bllDept.Add(dept) > 0) {
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "添加部门成功";
                    } else {
                        retData.Content = "添加部门失败";
                    }
                } catch(Exception e) {
                    retData.Content = "系统错误";
                    log.Error("添加部门时，数据库发生错误",e);
                }
            } else {
                retData.Content = "字段验证失败";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult AddEmployee(MesWeb.Model.T_Employee emp) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            if(!string.IsNullOrEmpty(emp.EmployeeName)) {
                try {
                    if(bllEmp.Add(emp) > 0) {
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "添加职工成功";
                    } else {
                        retData.Content = "添加职工失败，请联系管理员";
                    }
                } catch(Exception e) {
                    log.Error("添加职工数据库出错",e);
                }
            }
            return Json(retData);
        }

        public ActionResult ParamCol() {

            return View();
        }


        public ActionResult ParamCode() {
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var codeList = bllParamCode.DataTableToList(bllParamCode.GetAllList().Tables[0]);
            var vmJSTree = new List<VM_JSTree>();
            foreach(var code in codeList) {
                vmJSTree.Add(new VM_JSTree { text = code.ParameterName,id = code.ParameterCodeID.ToString() });
            }
            return View(vmJSTree);
        }

        public ActionResult Specification() {
            return View();
        }


        public ActionResult ParamUnit() {
            var vmJsreeList = new List<VM_JSTree>();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var paramUnitList = bllParamUnit.GetModelList("");
            foreach(var paramUnit in paramUnitList) {
                vmJsreeList.Add(new VM_JSTree { id = paramUnit.ParameterUnitID.ToString(),text = paramUnit.ParameterUnitName.ToString() });
            }
            return View(vmJsreeList);
        }

        [HttpPost]
        public JsonResult GetParamUnitListAction() {
            var cscDropList = new List<VM_CscDrop>();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var unitList = bllParamUnit.DataTableToList(bllParamUnit.GetAllList().Tables[0]);
            foreach(var unit in unitList) {
                cscDropList.Add(new VM_CscDrop { label = unit.ParameterUnitName,value = unit.ParameterUnitID.ToString() });
            }
            return Json(cscDropList);
        }

        [HttpPost]
        public JsonResult AddParamCodeAction(MesWeb.Model.T_ParameterCode code) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            try {
                if(bllParamCode.Add(code) > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "加载成功";
                } else {
                    retData.Content = "添加参数失败";
                    log.Error("添加参数失败");
                }
            } catch(Exception e) {
                log.Fatal("添加参数异常",e);
                retData.Content = "添加参数异常";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult DeleteParamCodeAction(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            try {
                if(bllParamCode.Delete(Id)) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "删除成功！";

                } else {
                    log.Error("删除参数失败");
                    retData.Content = "删除参数失败";
                }
            } catch(Exception e) {
                log.Fatal("删除参数异常",e);
                retData.Content = "删除参数异常，请联系管理员";

            }

            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetParamCodeInfoAction(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var paramCode = bllParamCode.GetModel(Id);
            if(paramCode == null) {
                log.Error("获取参数类型失败，参数ID " + Id);
                retData.Content = "获取参数类型失败";
                return Json(retData);
            }

            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var paramUnitList = bllParamUnit.DataTableToList(bllParamUnit.GetAllList().Tables[0]);
            int selId = 0;
            if(paramCode.ParameterUnitID == null) {
                paramCode.ParameterUnitID = 1;
            }
            selId = (int)paramCode.ParameterUnitID.Value;

            var vmParamCodeInfo = new VM_ParamCodeInfo() {
                ParameterBit = paramCode.ParameterBit,
                ParameterName = paramCode.ParameterName,
                ParameterType = paramCode.ParameterType,
                ParameterCode = paramCode.ParameterCode,
                ParameterUnitID = paramCode.ParameterUnitID,
                ParameterCodeID = paramCode.ParameterCodeID,
                Type = paramCode.Type
            };

            var isSel = false;
            foreach(var unit in paramUnitList) {
                if(unit.ParameterUnitID == selId) {
                    isSel = true;
                } else {
                    isSel = false;
                }
                vmParamCodeInfo.ParamUnitList.Add(new VM_CscDrop { label = unit.ParameterUnitName,value = unit.ParameterUnitID.ToString(),selected = isSel });
            }
            if(!string.IsNullOrEmpty(vmParamCodeInfo.ParameterName)) {
                retData.Code = RESULT_CODE.OK;
            }
            retData.Appendix = vmParamCodeInfo;
            return Json(retData);
        }

        [HttpPost]
        public JsonResult EditParamCode(MesWeb.Model.T_ParameterCode code) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var retData = new VM_Result_Data();
            try {
                if(bllParamCode.Update(code)) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "更新成功";
                } else {
                    retData.Content = "更新失败";
                    log.Error("更新参数失败");
                }
            } catch(Exception e) {
                log.Fatal("更新参数类型发生异常",e);
            }

            return Json(retData);
        }


        [HttpPost]
        public JsonResult GetParamTypeListAction(int Id) {
            return Json(GetParamTypeCscDropList(Id));
        }

        private List<VM_CscDrop> GetParamTypeCscDropList(int Id = 0) {
            var cscDropList = new List<VM_CscDrop>();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var paramCodeList = bllParamCode.GetModelList("");
            var selCode = bllParamCode.GetModel(Id);
            foreach(var code in paramCodeList) {
                var type = code.Type;
                //选中值
                if(selCode != null) {
                    if(selCode.Type.HasValue) {
                        if(selCode.Type.Value == code.ParameterCodeID) {
                            cscDropList.Add(new VM_CscDrop { label = code.ParameterCodeID.ToString(),value = code.ParameterCodeID.ToString(),selected = true });
                            selCode = null;
                            continue;
                        }
                    }
                }

                cscDropList.Add(new VM_CscDrop { label = code.ParameterCodeID.ToString(),value = code.ParameterCodeID.ToString(),selected = false });
                if(type.HasValue) {
                    var findCode = from c in cscDropList where c.value == type.Value.ToString() select c;
                    foreach(var item in findCode.ToList()) {
                        cscDropList.Remove(item);
                    }
                }


            }
            return cscDropList;
        }


        [HttpPost]
        public JsonResult AddParamUnitAction(MesWeb.Model.T_ParameterUnit unit) {
            var retData = new VM_Result_Data();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            if(bllParamUnit.Add(unit) > 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "添加单位成功！";
            } else {
                retData.Content = "添加单位失败";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult EditParamUnitAction(MesWeb.Model.T_ParameterUnit unit) {
            var retData = new VM_Result_Data();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            if(bllParamUnit.Update(unit)) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "添加单位成功！";
            } else {
                retData.Content = "添加单位失败";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetParamUnitInfoAction(int Id) {
            var retData = new VM_Result_Data();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var paramUnit = bllParamUnit.GetModel(Id);
            if(paramUnit != null) {
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = paramUnit;
            } else {
                retData.Content = "获取参数类型失败";
            }
            return Json(retData);
        }

        /// <summary>
        /// 获取参数设定值
        /// </summary>
        /// <param name="machineId">机台ID</param>
        /// <param name="paramCodeId">参数ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetParamSetting(int machineId,int paramCodeId) {
            var retData = new VM_Result_Data();
            var bllParamSet = new MesWeb.BLL.T_ParametersCol();
          
            //获取设定值
            var paramSet = bllParamSet.GetModelList("MachineID = " + machineId + " AND ParameterCodeID = " + paramCodeId).FirstOrDefault();
            if(paramSet == null){
                paramSet = new MesWeb.Model.T_ParametersCol();
                paramSet.MachineID = machineId;
                paramSet.ParameterCodeID = paramCodeId;
            }
            retData.Code = RESULT_CODE.OK;
            retData.Appendix = paramSet;
            retData.Content = "获取参数设定值成功";
            return Json(retData);
        }

        /// <summary>
        /// 保存参数设定值
        /// </summary>
        /// <param name="paramSet">设定值对象</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveParamSetting(MesWeb.Model.T_ParametersCol paramSet) {
            var retData = new VM_Result_Data();
            var bllParamSet = new MesWeb.BLL.T_ParametersCol();
            try {
                if(paramSet.ParameterCodeID.HasValue) {
                    //数据存在于表中则更新
                    if(bllParamSet.Exists(paramSet.ParametersColID)) {
                        bllParamSet.Update(paramSet);
                    } else {
                        //数据不存在于表中则添加
                        bllParamSet.Add(paramSet);
                    }
                } else {
                    //数据不存在于表中则添加
                    bllParamSet.Add(paramSet);
                }
                retData.Content = "设置参数设定值成功";
                retData.Code = RESULT_CODE.OK;
     
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("保存参数设定值失败！",e);
                retData.Content = "保存参数设定值失败";
            }
            return Json(retData);
        }

    }


}