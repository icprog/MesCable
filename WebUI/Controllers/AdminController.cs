// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-01-2016
//
// Last Modified By : ychost
// Last Modified On : 09-01-2016
// ***********************************************************************
// <copyright file="AdminController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using log4net;
using MesWeb.ViewModel.Mes;
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
    /// <summary>
    /// Class AdminController.
    /// </summary>
    public class AdminController:BaseController {
        private enum MACHINE_PARAM_CODE {
            SCREW_SPEED = 35
        }

        // GET: Admin
        /// <summary>
        /// get admin page
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index() {
            //用户未登录
            if(Session[SecurityHelper.isLoginSessionId] == null) {
                return RedirectToAction("Index","Login");
            } else {
                //用户已经登陆
                var vmRootMenu = Utils.SystemHelper.GetSystemMenu();
                return View(vmRootMenu);
            }

        }


        [HttpPost]
        public JsonResult GetUserInfoAction() {
            var retData = new MesWeb.ViewModel.Promise.VM_Result_Data();
            retData.Content = "加载用户信息失败";

            try {
                retData.Appendix = (MesWeb.Model.T_User)Session[SecurityHelper.isLoginSessionId];
                if(retData.Appendix != null) {
                    retData.Content = "加载用户信息成功";
                    retData.Code = RESULT_CODE.OK;
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error(e);
            }

            return Json(retData);
        }

        /// <summary>
        /// the default page when entry admin
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Home() {
            return View();
        }

        [HttpPost]
        public JsonResult GetMachineStats() {
            var machStats = new VM_MachineStats();
            var bllColData = new MesWeb.BLL.T_CollectedDataParameters();
            var bllMachine = new MesWeb.BLL.T_Machine();
            var speedDataList = bllColData.GetModelList("ParameterCodeID " + (int)MACHINE_PARAM_CODE.SCREW_SPEED);
            foreach(var machine in speedDataList) {
                if(int.Parse(machine.CollectedValue) > 0) {
                    ++machStats.BootStats;
                } else {
                    ++machStats.CloseStats;
                }
            }
            return Json(machStats);
        }

    }
}