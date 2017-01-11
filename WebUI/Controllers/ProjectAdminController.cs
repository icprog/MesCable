// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-11-2016
//
// Last Modified By : ychost
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="ProjectAdminController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary>this is a project construction management controller</summary>
// ***********************************************************************
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class ProjectAdminController:LayoutBaseController {
        /*########################################Response View###########################################################*/
        /// <exclude />
        public ActionResult Index() {
            var topLayout = bllLayout.GetModelList("IsTop = 1").FirstOrDefault();
            if(topLayout != null) {
                return RedirectToAction("WorkshopLayoutAdmin");
            }
            // if adminer doesn't upload the layout image
            return RedirectToAction("UploadWorkshopLayout");


        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Workshops the layout admin.
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 20:16:57  
        ///  *********************cniots*************************************
        public ActionResult WorkshopLayoutAdmin() {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var topLayout = bllLayout.GetModelList("IsTop = 1").FirstOrDefault();
            VM_LayoutPicture layoutAdminVM = new VM_LayoutPicture(topLayout);

            if(topLayout == null) {
                log.Fatal("车间总体布局图不存在，不应该进入该界面的");
            } else {
                layoutAdminVM = GetLayoutInfo(topLayout);
            }
            return View(layoutAdminVM);
        }


        public ActionResult AreaDetailAdmin(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var layout = bllLayout.GetModel(Id);
            if(layout.LayoutTypeID != null) {
                var bllLayoutType = new MesWeb.BLL.T_LayoutType();
                var layoutType = bllLayoutType.GetModel((int)layout.LayoutTypeID);
                if(layoutType.TableName == AreaIdentity.WorkArea) {
                    return RedirectToAction("ProcedureLayoutAdmin",new { Id = Id });
                } else if(layoutType.TableName == AreaIdentity.StoreArea) {
                    return RedirectToAction("StoreLayoutAdmin",new { Id = Id });
                }
            }
            log.Error("未指定该标记的类别");
            return View();
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Procedures the layout admin.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 20:29:52  
        ///  *********************cniots*************************************
        public ActionResult ProcedureLayoutAdmin(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var procedureLayout = bllLayout.GetModel(Id);
            if(string.IsNullOrEmpty(procedureLayout.PicUrl)) {
                var um = getUploadLayoutVM("上传工序分布图",procedureLayout.Title + "工序分布","/ProjectAdmin/ProcedureLayoutAdmin/" + Id,"/ProjectAdmin/CreateProcedureLayoutAction/" + Id);

                return View("UploadImage",um);
            }
            VM_LayoutPicture layoutAdminVM = new VM_LayoutPicture(procedureLayout);
            if(procedureLayout != null) {
                layoutAdminVM = GetLayoutInfo(procedureLayout);
            }
            return View(layoutAdminVM);
        }




        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Stores the layout admin.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 20:31:54  
        ///  *********************cniots*************************************
        public ActionResult StoreLayoutAdmin(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var storeLayout = bllLayout.GetModel(Id);
            if(string.IsNullOrEmpty(storeLayout.PicUrl)) {
                var um = getUploadLayoutVM("上传存储区域图",storeLayout.Title + "储存区","/ProjectAdmin/StoreLayoutAdmin/" + Id,"/ProjectAdmin/CreateStoreLayoutAction/" + Id);

                return View("UploadImage",um);
            }
            VM_LayoutPicture layoutAdminVM = new VM_LayoutPicture(storeLayout);
            if(storeLayout != null) {
                layoutAdminVM = GetLayoutInfo(storeLayout);
            }
            return View(layoutAdminVM);
        }



        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Machines the layout admin.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 20:35:31  
        ///  *********************cniots*************************************
        public ActionResult MachineLayoutAdmin(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var machineLayout = bllLayout.GetModel(Id);
            if(string.IsNullOrEmpty(machineLayout.PicUrl)) {
                var um = getUploadLayoutVM("上传机台图",machineLayout.Title + "机台详情","/ProjectAdmin/MachineLayoutAdmin/" + Id,"/ProjectAdmin/CreateMachineLayoutAction/" + Id);

                return View("UploadImage",um);
            }
            VM_LayoutPicture layoutAdminVM = new VM_LayoutPicture(machineLayout);
            if(machineLayout != null) {
                layoutAdminVM = GetLayoutInfo(machineLayout);
            }
            return View(layoutAdminVM);
        }




        /*########################################Response HttpPost Action###########################################################*/

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Creates the Workshop layout.
        /// </summary>  
        /// <param name="layout">The layout.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-13 21:43:33  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult CreateWorkshopLayoutAction(MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            if(layout == null) {
                retData.Content = "上传内容为空";
                log.Error("上传总体布局图为空");
                return Json(retData);
            }
            var topLayout = bllLayout.GetModelList("IsTop = 1").FirstOrDefault();
            if(topLayout == null) {
                layout.IsTop = true;
                if(bllLayout.Add(layout) > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "上传成功！";
                } else {
                    retData.Content = "系统错误!";
                    log.Error("写入数据库时发生错误");
                }
            } else {
                retData.Content = "布局图已经存在！";
                log.Fatal("总体布局图已经存在，但是还有人上传");
            }
            return Json(retData);
        }



        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Creates the procedure layout action.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <param name="layout">The layout.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 21:06:23  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult CreateProcedureLayoutAction(int Id,MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var findLayout = bllLayout.GetModel(Id);
            if(layout == null || findLayout == null) {
                retData.Content = "上传内容为空";
                log.Error("上传工序布局图为空或者该工序节点不存在");
                return Json(retData);
            }

            findLayout.PicUrl = layout.PicUrl;
        

            var isUpdated = bllLayout.Update(findLayout);
            if(isUpdated == true) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "上传成功！";
            } else {
                retData.Content = "上传失败！";
                log.Error("上传工序图往数据库写入失败");
            }
            return Json(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Creates the store layout action.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <param name="layout">The layout.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-15 01:06:44  
        ///  *********************cniots*************************************
        [HttpPost]
        public ActionResult CreateStoreLayoutAction(int Id,MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = createSubLayout(Id,layout);
            if(retData.Code == RESULT_CODE.ERROR) {
                log.Error(retData.Appendix);
            }
            return Json(retData);
        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Creates the machine layout action.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <param name="layout">The layout.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 22:15:37  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult CreateMachineLayoutAction(int Id,MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = createSubLayout(Id,layout);
            if(retData.Code == RESULT_CODE.ERROR) {
                log.Error(retData.Appendix);
            }
            return Json(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Gets the category list.
        /// </summary>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 22:29:34  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult GetAreaCategoryList() {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var bllLayoutType = new MesWeb.BLL.T_LayoutType();
            List<VM_CscDrop> vmCatList = new List<VM_CscDrop>();
            var layoutTypeList = bllLayoutType.GetModelList("Type = 'Area'");
            if(layoutTypeList.Count > 0) {
                for(int i = 0;i < layoutTypeList.Count;i++) {
                    var lt = layoutTypeList[i];
                    var cscdrop = new VM_CscDrop { label = lt.AliasName,value = lt.LayoutTtypeID.ToString() };
                    if(i == 0) {
                        cscdrop.selected = true;
                    }
                    vmCatList.Add(cscdrop);

                }

            } else {
                log.Error("还未建立布局与数据库之间的关系");
            }
            return Json(vmCatList);
        }

        /// <summary>  
        /// Gets the detail list.
        ///   
        /// </summary>
        /// <param name="LayoutTypeID">The layout type identifier.</param>
        /// <returns>System.Web.Mvc.JsonResult.</returns>
        //[HttpPost]
        //public JsonResult GetDetailList(int LayoutTypeID) {
        //    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

        //    List<VM_CscDrop> vmDetailList = new List<VM_CscDrop>();
        //    var bllLayoutType = new MesWeb.BLL.T_LayoutType();
        //    var tableName = bllLayoutType.GetModel(LayoutTypeID).TableName;

        //    if(tableName != null) {
        //        try {

        //            //get bll class by reflection 

        //        } catch(Exception e) {
        //            log.Error("获取表数据 " + tableName + " 失败",e);
        //        }
        //    }
        //    return Json(vmDetailList);
        //}

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Adds the layout action.
        /// </summary>  
        /// <param name="layout">The layout.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 20:48:09  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult AddLayoutAction(MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            try {
                var isAdded = bllLayout.Add(layout);
                if(isAdded != 0) {
                    retData.Content = "添加成功！";
                    retData.Code = RESULT_CODE.OK;
                } else {
                    log.Error("添加布局节点失败！");
                }
            } catch(Exception e) {
                retData.Content = "系统错误！";
                log.Error("系统错误",e);
            }
            return Json(retData);

        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Adds the machine layout action.
        /// </summary>  
        /// <param name="machineAdmin">The layout.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-15 11:35:08  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult AddMachineLayoutAction(VM_AddMachineAdmin machineAdmin) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();

            var machine = machineAdmin.Machine;
            var machineLayout = machineAdmin.MachineLayout;
            if(machine.MachineName != null) {
                try {
                    var bllLayoutType = new MesWeb.BLL.T_LayoutType();
                    var layoutType = bllLayoutType.GetModelList("TableName = 'T_Machine'").FirstOrDefault();
                    if(layoutType.LayoutTtypeID > 0) {
                        var bllMachine = new MesWeb.BLL.T_Machine();
                        var machindID = bllMachine.Add(machine);

                        //若工序有几台图片，则共用
                        var sameProcMach = bllLayout.GetModelList("ParentLayoutPictureID = " + machineLayout.ParentLayoutPictureID);
                        if(sameProcMach != null) {
                            var containPicMach = (from m in sameProcMach where m.PicUrl != null select m).FirstOrDefault();
                            if(containPicMach != null) {
                                machineLayout.PicUrl = containPicMach.PicUrl;
                                machineLayout.PicHeight = containPicMach.PicHeight;
                                machineLayout.PicWidth = containPicMach.PicWidth;
                            }
                          
                        }

                        machineLayout.LayoutTypeID = layoutType.LayoutTtypeID;
                        machineLayout.TableRowID = machindID;
                        


                        bllLayout.Add(machineLayout);
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "添加机台成功！";
                    } else {
                        log.Error("未找到布局关系 T_Machine ");
                    }

                } catch(Exception e) {
                    log.Fatal("数据库发生错误!",e);
                }
            } else {
                log.Warning("添加机台名称不能为空");
                retData.Content = "添加机台名称不能为空";
            }


            return Json(retData);
        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Gets the col parameter catgory list.
        /// </summary>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-15 14:18:45  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult GetColParamCatgoryList() {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var bllColParam = new MesWeb.BLL.T_CollectedParameter();
            List<VM_CscDrop> vmCatList = new List<VM_CscDrop>();
            var colParamList = bllColParam.DataTableToList(bllColParam.GetAllList().Tables[0]);
            if(colParamList.Count > 0) {
                for(int i = 0;i < colParamList.Count;i++) {
                    var lt = colParamList[i];
                    var cscdrop = new VM_CscDrop { label = lt.CollectedParameterName,value = lt.CollectedParameterID.ToString() };
                    if(i == 0) {
                        cscdrop.selected = true;
                    }
                    vmCatList.Add(cscdrop);

                }

            } else {
                log.Error("还未建立布局与数据库之间的关系");
            }
            return Json(vmCatList);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Adds the sensor action.
        /// </summary>  
        /// <param name="sensorAdmin">The sensor.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-15 14:21:35  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult AddSensorAction(VM_AddSensorAdmin sensorAdmin) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();

            var sensorModule = sensorAdmin.SensorModule;
            var sensorLayout = sensorAdmin.SensorLayout;
            if(sensorModule.SerialNum != null && sensorAdmin.ParentLayoutPictureID != null && sensorAdmin.ParameterCodeIDs.Count > 0) {
                try {
                    var bllMachine = new MesWeb.BLL.T_Machine();
                    var machineLayout = bllLayout.GetModel((int)sensorLayout.ParentLayoutPictureID);
                    var bllSensor = new MesWeb.BLL.T_SensorModule();
                    var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
                    sensorModule.MachineID = bllMachine.GetModel((int)machineLayout.TableRowID).MachineID;
                    sensorLayout.LayoutTypeID = (int)LAYOUT_TPYE.SENSOR_MODULE;

                    //add sensor
                    sensorLayout.TableRowID = bllSensor.Add(sensorModule);
                    //build sensor and parametercode relationship
                    foreach(var param in sensorAdmin.ParameterCodeIDs) {
                        bllSensorParamCode.Add(new MesWeb.Model.T_SensorModule_T_ParameterCode {
                            SensorModuleID = sensorLayout.TableRowID,
                            ParameterCodeID = int.Parse(param)
                        });
                    }
                    //add sensor layout 
                    bllLayout.Add(sensorLayout);

                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "添加模块成功！";
                } catch(Exception e) {
                    log.Fatal("往数据库写入数据失败",e);
                }
            } else {
                log.Warning("字段校验失败");
                retData.Content = "字段校验失败";
            }
            return Json(retData);
        }



        [HttpPost]
        public JsonResult GetExtraSensorParameterType() {
            var retData = new VM_Result_Data();
            var vmList = getSensorParameterType(PARAMETER_CODE_TYPE.SENSOR_SITE);
            if(vmList.Count > 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = vmList;
            } else {
                retData.Content = "加载失败！";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult AddExtraSensorAction(VM_AddSensorAdmin sensorAdmin) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            var sensorModule = sensorAdmin.SensorModule;
            var sensorLayout = sensorAdmin.SensorLayout;
            if(sensorModule.SerialNum != null && sensorAdmin.ParentLayoutPictureID != null && sensorAdmin.ParameterCodeIDs.Count > 0) {
                try {
                    var bllSensor = new MesWeb.BLL.T_SensorModule();
                    var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();

                    sensorLayout.LayoutTypeID = (int)LAYOUT_TPYE.EXTRA_SENSOR;

                    //add sensor
                    sensorModule.MachineID = (int)VIRTUAL_LAYOUT.VIRTUAL_MACHINE;
                    sensorLayout.TableRowID = bllSensor.Add(sensorModule);
                    //build sensor and parametercode relationship
                    foreach(var param in sensorAdmin.ParameterCodeIDs) {
                        bllSensorParamCode.Add(new MesWeb.Model.T_SensorModule_T_ParameterCode {
                            SensorModuleID = sensorLayout.TableRowID,
                            ParameterCodeID = int.Parse(param)
                        });
                    }
                    //add sensor layout 
                    bllLayout.Add(sensorLayout);
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "添加模块成功！";
                } catch(Exception e) {
                    log.Fatal("往数据库写入数据失败",e);
                }
            } else {
                log.Warning("字段校验失败");
                retData.Content = "字段校验失败";
            }
            return Json(retData);
        }

        private bool deleteLayout(MesWeb.Model.T_LayoutPicture layout) {
            var findLayout = bllLayout.GetModel(layout.LayoutPictureID);
            if(findLayout.Equals(layout)) {
                if(bllLayout.Delete(findLayout.LayoutPictureID)) {
                    return true;
                }
            }

            return false;
        }


        [HttpPost]
        public JsonResult DeleteProcOrStoreLayout(int Id) {
            var retData = new VM_Result_Data();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            bool isDel = false;
            var layout = bllLayout.GetModel(Id);
            if(layout != null) {
                if(layout.LayoutTypeID == (int)LAYOUT_TPYE.WORK_AREA) {
                    isDel = deleteProcLayout(Id);

                } else if(layout.LayoutTypeID == (int)LAYOUT_TPYE.STORE_AREA) {
                    isDel = deleteStoreLayout(Id);
                }
            } else {
                log.Error("删除数据为空");
                retData.Content = "系统错误";
            }
            if(isDel == true) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "删除成功!";
            }
            return Json(retData);
        }

      
        [HttpPost]
        public JsonResult DeleteSensorLayoutAction(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            var layout = bllLayout.GetModel(Id);
            try {
                if(deleteLayout(layout)) {
                    var bllSensor = new MesWeb.BLL.T_SensorModule();
                    var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
                    var sensorParamCodeList = bllSensorParamCode.GetModelList("SensorModuleID=" + layout.TableRowID);
                    var deleteList = new StringBuilder();
                    for(int i = 0;i < sensorParamCodeList.Count;i++) {
                        deleteList.Append(sensorParamCodeList[i].SensorModule_PARCODEID.ToString());
                        if(i != sensorParamCodeList.Count - 1) {
                            deleteList.Append(",");
                        }
                    }
                    if(bllSensorParamCode.DeleteList(deleteList.ToString())) {
                        if(bllSensor.Delete((int)layout.TableRowID)) {
                            retData.Code = RESULT_CODE.OK;
                            retData.Content = "删除成功";
                        } else {
                            log.Error("删除传感器失败");
                            retData.Content = "删除传感器失败";
                        }
                    } else {
                        log.Error("删除关系失败");
                        retData.Content = "删除传感器失败";
                    }

                } else {
                    log.Error("删除传感器布局失败");
                    retData.Content = "删除失败!";
                }
            } catch(Exception e) {
                retData.Content = "系统错误";
                log.Fatal("系统错误",e);
            }

            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetSensorParameterType() {
            var retData = new VM_Result_Data();
            var vmList = getSensorParameterType(PARAMETER_CODE_TYPE.SENSOR_MACHINE);
            if(vmList.Count > 0) {
                retData.Appendix = vmList;
                retData.Code = RESULT_CODE.OK;
            } else {
                retData.Content = "数据为空，请联系管理员";
            }
            return Json(retData);
        }
        [HttpPost]
        public JsonResult DeleteMachineLayoutAction(int Id) {
            var retData = new VM_Result_Data();
            if(bllLayout.Delete(Id)) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "删除成功！";
            } else {
                retData.Content = "删除失败";
            }
            return Json(retData);
        }



        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Uploads the image.
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-13 20:34:24  
        ///  *********************cniots*************************************
        public ActionResult UploadImage() {

            var errorInfo = new VM_Error_Info { Title = "禁止进入",ErrorMessage = "非施工人员，禁止进入" };
            return RedirectToAction(ErrorManager.SystemError,ErrorManager.ErrorController,errorInfo);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Uploads the Workshop layout.
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 14:48:54  
        ///  *********************cniots*************************************
        public ActionResult UploadWorkshopLayout() {
            var um = getUploadLayoutVM("上传车间总体布局图","车间布局图","/ProjectAdmin/Index","/ProjectAdmin/CreateWorkshopLayoutAction");
            return View("UploadImage",um);
        }


        [HttpPost]
        public JsonResult GetMachieTypeListAction() {
            var vmCscList = new List<VM_CscDrop>();
            var bllMachType = new MesWeb.BLL.T_MachineType();
            var machTypeList = bllMachType.DataTableToList(bllMachType.GetAllList().Tables[0]);
            if(machTypeList != null) {
                foreach(var item in machTypeList) {
                    vmCscList.Add(new VM_CscDrop { label = item.MachineType,value = item.MachineTypeID.ToString() });
                }
            }
            return Json(vmCscList);
        }



        /*#############################################Helper Method######################################################*/

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-11 20:29:42  
        /// <summary>  
        /// Gens the upload layout vm.
        /// </summary>  
        /// <param name="title">The title.</param>  
        /// <param name="successActionName">Name of the success action.</param>  
        /// <param name="successActionUrl">The success action URL.</param>  
        /// <param name="SendFileUrl">The send file URL.</param>  
        /// <returns>VM_IUploadFile.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-14 15:09:39  
        ///  *********************cniots*************************************
        private static VM_IUploadFile getUploadLayoutVM(string title,string successActionName,string successActionUrl,string SendFileUrl) {
            VM_IUploadFile um = new VM_UploadImage();
            um.Title = title;
            um.SuccessActionName = successActionName;
            um.SuccessActionUrl = successActionUrl;
            um.SendFileUrl = SendFileUrl;
            return um;

        }

        private bool deleteStoreLayout(int layoutID) {
            bool isDel = false;
            isDel = bllLayout.Delete(layoutID);
            return isDel;
        }

        private bool deleteProcLayout(int layoutID) {
            return bllLayout.Delete(layoutID);
            bool isDel = false;
            var procLayout = bllLayout.GetModel(layoutID);
            var procLayoutInfo = GetLayoutInfo(procLayout);
            try {
                var bllMachine = new MesWeb.BLL.T_Machine();
                foreach(var machineItem in procLayoutInfo.SubSpotItems) {
                    if(machineItem.LayoutTypeID == (int)LAYOUT_TPYE.MACHINE) {
                        foreach(var sensorItem in GetLayoutInfo(machineItem.LayoutPictureID).SubSpotItems) {
                            if(sensorItem.LayoutTypeID == (int?)LAYOUT_TPYE.SENSOR_MODULE) {
                                isDel = deleteSensorOnly(sensorItem.LayoutPictureID);
                            }
                        }
                        isDel = deleteMachineOnly(machineItem.LayoutPictureID);
                    }

                    isDel = deleteProcOnly(layoutID);
                }
            } catch(Exception e) {
                isDel = false;
                throw e;
            }
            return isDel;
        }

        private bool deleteProcOnly(int layotuID) {
            bool isDel = false;
            isDel = bllLayout.Delete(layotuID);
            return isDel;
        }

        private bool deleteMachineOnly(int layoutID) {
            bool isDel = false;
            isDel = bllLayout.Delete(layoutID);

            return isDel;
        }

        private bool deleteSensorOnly(int layotuID) {
            bool isDel = false;
            isDel = bllLayout.Delete(layotuID);
            return isDel;
        }



        private List<VM_Dropdown> getSensorParameterType(params int[] types) {
            var bllPramCode = new MesWeb.BLL.T_ParameterCode();
            var vmParamList = new List<VM_Dropdown>();

            foreach(var type in types) {
                var paramSiteList = bllPramCode.GetModelList("1=1");
                if(paramSiteList.Count > 0) {
                    foreach(var param in paramSiteList) {
                        vmParamList.Add(new VM_Dropdown { label = param.ParameterName,value = param.ParameterCodeID });
                    }
                }
            }

            return vmParamList;
        }

        private VM_Result_Data createSubLayout(int Id,MesWeb.Model.T_LayoutPicture layout) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var retData = new VM_Result_Data();
            var findLayout = bllLayout.GetModel(Id);
            if(layout == null || findLayout == null) {
                retData.Content = "上传内容为空";
                retData.Appendix = "上传布局局图为空或者该节点不存在";
                return retData;
            }

            findLayout.PicUrl = layout.PicUrl;
        
            var isUpdated = bllLayout.Update(findLayout);
            if(isUpdated == true) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "上传成功！";
            } else {
                retData.Content = "上传失败！";
                retData.Appendix = "上传布局图往数据库写入失败";
            }
            return retData;
        }
    }
}