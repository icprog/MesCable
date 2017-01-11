// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-01-2016
//
// Last Modified By : ychost
// Last Modified On : 09-03-2016
// ***********************************************************************
// <copyright file="InvMgmtController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MesWeb.BLL;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using MesWeb.ViewModel.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    /// <summary>
    /// Class InvMgmtController.
    /// </summary>

    public class InvMgmtController :BaseController {
        /// <summary>
        /// The BLL layout pic
        /// </summary>
        T_LayoutPicture bllLayoutPic = new T_LayoutPicture();

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-01 20:29:50  
        /// <summary>  
        /// get the topview layout
        /// </summary>  
        /// <returns>Top layout view </returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:09:33  
        ///  *********************cniots*************************************  
        public ActionResult Index()
        {
            var retData = new VM_Result_Data();
            //get top view picture info
            var topViewLayout = bllLayoutPic.GetModelList(" LayoutTypeID = 1").FirstOrDefault();
            if(topViewLayout != null) {
                VM_LayoutPicture vmTopViewLayout = getVmLayoutView(topViewLayout);
                retData.Appendix = vmTopViewLayout;
                retData.Code = RESULT_CODE.OK;
                retData.Content = "加载成功！";
            } else {
                retData.Content = "尚未施工，请联系施工员进行施工！";
            }
            return View(retData);
           
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-01 20:29:50  
        /// <summary>  
        /// response the workshop  layout  view
        /// </summary>  
        /// <param name="ID">workshop layout picture id</param>  
        /// <returns>the work shop view</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:09:33  
        ///  *********************cniots*************************************  
        public ActionResult WorkShopView(int ID) {
            var retData = new VM_Result_Data();
            var workShopViewLayout = bllLayoutPic.GetModel(ID);
            if(workShopViewLayout != null) {
                VM_LayoutPicture vmWorkShopView = getVmLayoutView(workShopViewLayout);
                retData.Appendix = vmWorkShopView;
                retData.Code = RESULT_CODE.OK;
                retData.Content = "加载成功！";
            }
            return View(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-01 20:29:50  
        /// <summary>  
        /// response the machine layout view
        /// </summary>  
        /// <param name="ID">The identifier.</param>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:21:57  
        ///  *********************cniots*************************************
        public ActionResult MachineView(int ID) {
            var retData = new VM_Result_Data();
            var workShopViewLayout = bllLayoutPic.GetModel(ID);
            if(workShopViewLayout != null) {
                VM_LayoutPicture vmMachineView = getVmLayoutView(workShopViewLayout);
                retData.Appendix = vmMachineView;
                retData.Code = RESULT_CODE.OK;
                retData.Content = "加载成功！";
            }
            return View(retData);
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-01 20:29:50  
        /// <summary>  
        /// get layout view model by layout picture model
        /// </summary>  
        /// <param name="layoutPicture">the LayoutPicture model</param>  
        /// <returns>VM_LayoutPicture.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 11:21:07  
        ///  *********************cniots*************************************  
        private VM_LayoutPicture getVmLayoutView(MesWeb.Model.T_LayoutPicture layoutPicture) {
            var vmLayoutView = new VM_LayoutPicture(layoutPicture);
            var subSpotItems = bllLayoutPic.GetModelList("IsTop = 0 AND ParentLayoutPictureID = " + layoutPicture.LayoutPictureID);
            foreach(var item in subSpotItems) {
                var vmItem = new VM_LayoutPicture(item);
                vmLayoutView.SubSpotItems.Add(vmItem);
            }
            return vmLayoutView;
        }
    }
}