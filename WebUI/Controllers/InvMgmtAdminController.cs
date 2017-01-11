// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-02-2016
//
// Last Modified By : ychost
// Last Modified On : 09-03-2016
// ***********************************************************************
// <copyright file="InvMgmtAdminController.cs" company="cniots">
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
    /// Class InvMgmtAdminController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class InvMgmtAdminController : BaseController
    {
        /// <summary>
        /// The BLL layout picture
        /// </summary>
        MesWeb.BLL.T_LayoutPicture bllLayoutPic = new MesWeb.BLL.T_LayoutPicture();
        // GET: InvMgmtAdmin
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-02 16:46:27  
        /// <summary>  
        /// Indexes this instance.
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:05:19  
        ///  *********************cniots*************************************
        public ActionResult Index()
        {
            return View();
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-02 16:46:27  
        /// <summary>  
        /// Add the layout view.
        /// </summary>  
        /// <param name="layout">The layout pic.</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:05:19  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult AddLayoutView(MesWeb.Model.T_LayoutPicture layout) {
            var retData = new VM_Result_Data();
            try {
                var isAdded = bllLayoutPic.Add(layout);
                if(isAdded != 0) {
                    retData.Content = "添加成功！";
                    retData.Code = RESULT_CODE.OK;
                }
            } catch(Exception e) {
                retData.Content = "系统错误！";
                log.Error("系统错误",e);
            }
            return Json(retData);
        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-02 16:46:27  
        /// <summary>  
        /// Deletes the layout view.
        /// </summary>  
        /// <param name="delayoutPic">The delete layoutpicture object</param>  
        /// <returns>JsonResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:30:05  
        ///  *********************cniots*************************************
        [HttpPost]
        public JsonResult DeleteLayoutView(MesWeb.Model.T_LayoutPicture delayoutPic) {
            var retData = new VM_Result_Data();
            if(delayoutPic != null) {
                var findLayoutPic = bllLayoutPic.GetModel(delayoutPic.LayoutPictureID);
                
            }
            return Json(retData);
        }
    }
}