// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-10-2016
//
// Last Modified By : ychost
// Last Modified On : 09-10-2016
// ***********************************************************************
// <copyright file="SystemController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class SystemController:BaseController {
        // GET: System
        public ActionResult Index() {
            return View();
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// response the configuration page of menu
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-10 20:08:02  
        ///  *********************cniots*************************************  
        public ActionResult MenuConf() {
            var vmSystemMenu = Utils.SystemHelper.GetSystemMenu();
            MesWeb.ViewModel.System.VM_Menu_Conf vmSystemConf = new MesWeb.ViewModel.System.VM_Menu_Conf(vmSystemMenu);

            return View(vmSystemConf);
        }


        /// <summary>
        /// 用户配置
        /// </summary>
        /// <returns></returns>
        public ActionResult UserConf() {
            var vmJstreeList = new List<VM_JSTree>();
            var bllDept = new MesWeb.BLL.T_Department();
            var bllEmp = new MesWeb.BLL.T_Employee();
            var deptList = bllDept.GetModelList("");
            var bllUser = new MesWeb.BLL.T_User();
            var userList = bllUser.GetModelList("");
            foreach(var dept in deptList) {
                var deptTree = new VM_JSTree { text = dept.DepartmentName,id = "dept_" + dept.DepartmentID.ToString() };
                deptTree.children = new List<VM_JSTree>();
                foreach(var user in userList) {
                    if(!user.EmployeeID.HasValue) {
                        continue;
                    }
                    var emp = bllEmp.GetModel(user.EmployeeID.Value);
                    if(emp != null) {
                        if(emp.DepartmentID == dept.DepartmentID) {
                            deptTree.children.Add(new VM_JSTree { text = user.UserName,id = "user_" + user.UserID.ToString() });
                            //  userList.Remove(user);

                        }
                    }
                }
                vmJstreeList.Add(deptTree);
            }
            return View(vmJstreeList);
        }




        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Gets the menu parent list.
        /// </summary>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 13:08:52  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult GetMenuParentList(int Id) {
            var vmSystemMenu = Utils.SystemHelper.GetSystemMenu();

            List<VM_CscDrop> pms = new List<VM_CscDrop>();
            var rootPm = new VM_CscDrop { value = vmSystemMenu.MenuID.ToString(),label = vmSystemMenu.MenuName,selected = true };
            pms.Add(rootPm);
            foreach(var m in vmSystemMenu.SubMenus) {
                var cscdrop = new VM_CscDrop { value = m.MenuID.ToString(),label = m.MenuName };
                if(m.MenuID == Id) {
                    cscdrop.selected = true;
                    rootPm.selected = false;
                }
                pms.Add(cscdrop);
            }

            return Json(pms);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Gets the menu seq list.
        /// </summary>  
        /// <param name="menuParentID">The menu parent identifier.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 13:12:09  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult GetMenuSeqList(int Id,int menuParentID) {
            var subMenus = Utils.SystemHelper.GetSubSystemMenuList(menuParentID);
            var cscOpts = new List<VM_CscDrop>();
            var count = subMenus.Count + 1;
            //for add menu
            if(Id == -1) {
                for(int i = 1;i <= count;i++) {
                    var cscdrop = new VM_CscDrop { value = i.ToString(),label = i.ToString() };
                    if(i == count) {
                        cscdrop.label = "最后";

                        cscdrop.selected = true;
                    }
                    cscOpts.Add(cscdrop);
                }
                //for edit menu
            } else {
                for(int i = 1;i < count;i++) {
                    var cscdrop = new VM_CscDrop { value = i.ToString(),label = i.ToString() };
                    if(Id == i) {
                        cscdrop.selected = true;
                    }
                    cscOpts.Add(cscdrop);
                }
            }
            return Json(cscOpts);

        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Creates the menu.
        /// </summary>  
        /// <param name="menu">The menu.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 14:54:16  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult CreateMenu(MesWeb.Model.T_Menu menu) {
            var retData = new VM_Result_Data();
            var bllMenu = new MesWeb.BLL.T_Menu();
            if(menu.MenuParentID == null || menu.MenuSeq == null || menu.MenuName == null) {
                return Json(retData);
            }
            var parentMenu = Utils.SystemHelper.GetParentSystemMenu(new MesWeb.ViewModel.System.VM_Menu(menu));
            menu.MenuLevel = parentMenu.MenuLevel + 1;
            int isAddOk = bllMenu.Add(menu);
            if(isAddOk != 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "添加成功";
            }
            return Json(retData);
        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Deletes the menu.
        /// </summary>  
        /// <param name="menu">The menu.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 15:07:46  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult DeleteMenu(MesWeb.Model.T_Menu menu) {
            var retData = new VM_Result_Data();
            var bllMenu = new MesWeb.BLL.T_Menu();
            var subMenus = Utils.SystemHelper.GetSubSystemMenuList(new MesWeb.ViewModel.System.VM_Menu(menu));
            bool isDelOk = false;
            foreach(var item in subMenus) {
                isDelOk = bllMenu.Delete(item.MenuID);
                if(isDelOk == false) {
                    return Json(retData);
                }
            }
            isDelOk = bllMenu.Delete(menu.MenuID);
            if(isDelOk == true) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "删除成功！";
            }
            return Json(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Edits the menu.
        /// </summary>  
        /// <param name="menu">The menu.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 14:32:05  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult EditMenu(MesWeb.Model.T_Menu menu) {
            var bllMenu = new MesWeb.BLL.T_Menu();
            var retData = new VM_Result_Data();
            var isExist = bllMenu.Exists(menu.MenuID);
            if(isExist == false) {
                retData.Content = "该项不存在!";
                return Json(retData);
            }
            var isUpdated = bllMenu.Update(menu);
            if(isUpdated == true) {
                retData.Content = "更新成功！";
                retData.Code = RESULT_CODE.OK;
            } else {
                retData.Content = "系统错误！";
            }
            return Json(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:05:32  
        /// <summary>  
        /// Gets the menu by identifier.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 15:43:43  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult GetMenuById(int Id) {
            var retData = new VM_Result_Data();
            var bllMenu = new MesWeb.BLL.T_Menu();
            retData.Content = bllMenu.GetModel(Id);
            if(retData.Content != null) {
                retData.Code = RESULT_CODE.OK;
            }
            return Json(retData);
        }



        [HttpPost]
        public JsonResult AddUserAction(MesWeb.Model.T_User user) {
            var retData = new VM_Result_Data();

            if(!string.IsNullOrEmpty(user.UserName) && user.EmployeeID.Value > 0) {
                try {
                    var bllUser = new MesWeb.BLL.T_User();
                    user.Password = SecurityHelper.encryptPlainPwd("123456");
                    if(bllUser.Add(user) > 0) {
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "添加用户成功";
                    }
                } catch(Exception e) {
                    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                    log.Error("添加用户失败！",e);

                }
            } else {
                retData.Content = "名称或绑定员工不能为空";
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetEmployeeAction() {
            return new BasicDataController().GetEmployeeAction();
        }

        [HttpPost]
        public JsonResult GetSelEmployeeAction(int Id) {
            var bllUser = new MesWeb.BLL.T_User();
            var user = bllUser.GetModel(Id);
            if(user != null) {
                var bllEmp = new MesWeb.BLL.T_Employee();
                var empId = bllEmp.GetModel(user.EmployeeID.Value).EmployeeID;
                if(empId > 0) {
                    return new BasicDataController().GetSelEmployeeAction(empId);
                }
            }
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            log.Error("获取员工信息失败！");
            return null;
        }

        [HttpPost]
        public JsonResult DeleteUser(int UserId) {
            var retData = new VM_Result_Data();
            var bllUser = new MesWeb.BLL.T_User();
            try {
                if(bllUser.Delete(UserId)) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "删除用户成功！";
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("删除用户失败！",e);
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetUserInfoAction(int userId) {
            var retData = new VM_Result_Data();
            var bllUser = new MesWeb.BLL.T_User();
            var user = bllUser.GetModel(userId);
            if(user != null) {
                var retUser = new MesWeb.Model.T_User();
                retUser.UserName = user.UserName;
                retUser.UserID = user.UserID;
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = retUser;
                retData.Content = "加载用户成功";
            } else {
                retData.Content = "加载用户失败";
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("加载用户失败！");
            }
            return Json(retData);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">更新的用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateUserAction(MesWeb.Model.T_User user) {
            var retData = new VM_Result_Data();
            var bllUser = new MesWeb.BLL.T_User();
            retData.Content = "更新用户失败";
            if(user != null) {
                var oldUser = bllUser.GetModel(user.UserID);
                if(oldUser != null) {
                    //如果用户没有输入密码，则使用原来的密码
                    if(string.IsNullOrEmpty(user.Password)) {
                        user.Password = oldUser.Password;
                    }else {
                        //对用户的密码进行第二次加密
                        user.Password = SecurityHelper.encryptMD5Pwd(user.Password);
                    }
                    try {
                        if(bllUser.Update(user)) {
                            retData.Code = RESULT_CODE.OK;
                            retData.Content = "更新用户成功";
                        }

                    } catch(Exception e) {

                        log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                        log.Error("更新用户失败！",e);
                    }
                }
                
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetSelUserValidAction(int Id) {

            var vmCscDropList = new List<VM_CscDrop>();
            var bllUser = new MesWeb.BLL.T_User();
            var user = bllUser.GetModel(Id);
            vmCscDropList.Add(new VM_CscDrop { label = "是",value = "1" });
            vmCscDropList.Add(new VM_CscDrop { label = "否",value = "0" });
            if(user.IsValidate) {
                vmCscDropList[0].selected = true;
            } else {
                vmCscDropList[1].selected = true;
            }
            return Json(vmCscDropList);
        }

        [HttpPost]
        public JsonResult GetUserPasswdAction(int userId) {
            var retData = new VM_Result_Data();
            var bllUser = new MesWeb.BLL.T_User();
            var user = bllUser.GetModel(userId);
            if(user != null) {
                retData.Appendix = user;
                user.Password = "";
                retData.Code = RESULT_CODE.OK;
                retData.Content = "加载账号密码成功";
            } else {
                retData.Content = "加载账号密码失败";
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("加载账号密码失败！");
            }
            return Json(retData);
        }
    }
}