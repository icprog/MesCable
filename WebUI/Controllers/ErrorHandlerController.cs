// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-01-2016
//
// Last Modified By : ychost
// Last Modified On : 09-01-2016
// ***********************************************************************
// <copyright file="ErrorHandlerController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    /// <summary>
    /// Class ErrorHandlerController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ErrorHandlerController : Controller
    {

        /// <summary>
        /// Defaults this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// Forbids this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Forbid() {
            return View();
        }

        /// <summary>
        /// Not page the found.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult NotFound() {
            return View();
        }

        public ActionResult SystemError(string ErrorMessage,string Title,string ReturnUrl,string ReturnName) {
            var errorInfo = new VM_Error_Info { ErrorMessage = ErrorMessage,Title = Title,ReturnName = ReturnName,ReturnUrl = ReturnUrl };
            return View(errorInfo);
        }
    }
}