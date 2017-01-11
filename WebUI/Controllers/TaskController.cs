// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-04-2016
//
// Last Modified By : ychost
// Last Modified On : 09-04-2016
// ***********************************************************************
// <copyright file="TaskController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers {
    /// <summary>
    /// Class TaskController.
    /// </summary>
    public class TaskController:BaseController {
        // GET: Task
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-04 22:39:48  
        /// <summary>  
        /// Indexes this instance.
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-04 22:39:48  
        ///  *********************cniots*************************************
        public ActionResult Index() {
            return View();
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-04 22:39:48  
        /// <summary>  
        /// response the completed task time line page
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-04 22:39:48  
        ///  *********************cniots*************************************
        public ActionResult TaskComplete() {
            return View();
        }
    }
}