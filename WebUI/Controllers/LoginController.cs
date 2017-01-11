// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-06-2016
//
// Last Modified By : ychost
// Last Modified On : 09-06-2016
// ***********************************************************************
// <copyright file="LoginController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    /// <summary>
    /// Class LoginController.
    /// </summary>
    public class LoginController:BaseController {
        // GET: Login
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-06 00:22:22  
        /// <summary>  
        /// reponse the login page
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-06 00:22:22  
        ///  *********************cniots*************************************
        public ActionResult Index() {
            return View();
        }


        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LogoutAction() {
            var retData = new VM_Result_Data();
            //清除session
            Session[SecurityHelper.isLoginSessionId] = null;
            retData.Content = "注销成功";
            retData.Code = RESULT_CODE.OK;
            return Json(retData);

        }

        [HttpPost]
        public JsonResult Lgoin(MesWeb.Model.T_User user) {
            var isOpenVerify = false;
            var retData = new VM_Result_Data();
            var bllUser = new MesWeb.BLL.T_User();

            bool.TryParse(ConfigurationManager.AppSettings["openLoginVerify"],out isOpenVerify);
            //未开启登录验证
            if(isOpenVerify == false) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "未开启登录验证，随意登录";
                Session[SecurityHelper.isLoginSessionId] = bllUser.GetModelList("UserName = 'admin'").FirstOrDefault();
            } else {
                retData.Content = "用户名或密码错误";
                if(user != null) {
                    var secUser = bllUser.GetModelList("UserName = '" + user.UserName + "'").FirstOrDefault();

                    if(secUser != null) {
                        //允许登录
                        if(secUser.IsValidate == true) {
                            user.Password = SecurityHelper.encryptMD5Pwd(user.Password);
                            if(secUser.Password == user.Password) {
                                //设置session
                                Session[SecurityHelper.isLoginSessionId] = secUser;
                                retData.Code = RESULT_CODE.OK;
                                retData.Content = "登录成功";

                            }
                        } else {
                            retData.Content = "该用户禁止登陆，请联系管理员";
                        }

                    }

                }
            }
            return Json(retData);
        }
    }
}