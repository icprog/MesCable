// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-13-2016
//
// Last Modified By : ychost
// Last Modified On : 09-13-2016
// ***********************************************************************
// <copyright file="BaseController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary>  </summary>
// ***********************************************************************
using log4net;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    /// <summary>
    /// this is the base controller that all controller should implement it
    /// </summary>
    public class BaseController:Controller {
        /// <summary>
        /// The the logger object 
        /// </summary>
        protected LogHelper log;

    }
}