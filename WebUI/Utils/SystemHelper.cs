// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-10-2016
//
// Last Modified By : ychost
// Last Modified On : 09-10-2016
// ***********************************************************************
// <copyright file="System.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MesWeb.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Utils {
    /// <summary>
    /// Class System.
    /// </summary>
    public static class SystemHelper {
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:35:33  
        /// <summary>  
        /// Get the system's root menu
        /// </summary>  
        /// <returns>MesWeb.ViewModel.System.VM_Menu.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-10 20:37:10  
        ///  *********************cniots*************************************
        public static VM_Menu GetSystemMenu() {
            var bllMenu = new MesWeb.BLL.T_Menu();
            var mdRootMenu = bllMenu.GetModelList("MenuLevel = 0").FirstOrDefault();
            var vmRootMenu = new VM_Menu(mdRootMenu);
            var mdfirstMenus = bllMenu.GetModelList("MenuLevel = 1 order by MenuSeq");
            var mdsecondMenus = bllMenu.GetModelList("MenuLevel =2 order by MenuSeq");
            var mdthirdMenus = bllMenu.GetModelList("MenuLevel = 3 order by MenuSeq");

            //generate three level menu tree
            foreach(var menu1 in mdfirstMenus) {
                var vmFirstMenu = new VM_Menu(menu1);
                vmRootMenu.SubMenus.Add(vmFirstMenu);
                foreach(var menu2 in mdsecondMenus) {
                    var menu1ID = vmFirstMenu.MenuID;
                    if(menu2.MenuParentID == menu1ID) {
                        var vmSecondMenu = new VM_Menu(menu2);
                        vmFirstMenu.SubMenus.Add(vmSecondMenu);
                        foreach(var menu3 in mdthirdMenus) {
                            var menu2ID = vmSecondMenu.MenuID;
                            if(menu3.MenuParentID == menu2ID) {
                                var vmThirdMenu = new VM_Menu(menu3);
                                vmSecondMenu.SubMenus.Add(vmThirdMenu);
                            }
                        }
                    }

                }
            }
            return vmRootMenu;
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:35:33  
        /// <summary>  
        /// Gets the system menu by identifier.
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns>VM_Menu.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 12:58:18  
        ///  *********************cniots*************************************
        public static VM_Menu GetSystemMenuById(int id) {
            var bllMenu = new MesWeb.BLL.T_Menu();
            var menu = bllMenu.GetModel(id);
            var vmMenu = new VM_Menu(menu);
            return vmMenu;
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:35:33  
        /// <summary>  
        /// Gets the parent system menu.
        /// </summary>  
        /// <param name="vmMenu">The vm menu.</param>  
        /// <returns>VM_Menu.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 12:57:20  
        ///  *********************cniots*************************************
        public static VM_Menu GetParentSystemMenu(VM_Menu vmMenu) {
            return GetSystemMenuById((int)vmMenu.MenuParentID);
        }


        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:35:33  
        /// <summary>  
        /// Gets the sub system menu list.
        /// </summary>  
        /// <param name="vmMenu">The vm menu.</param>  
        /// <returns>List&lt;VM_Menu&gt;.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 13:00:38  
        ///  *********************cniots*************************************
        public static List<VM_Menu> GetSubSystemMenuList(VM_Menu vmMenu) {
            var bllMenu = new MesWeb.BLL.T_Menu();
            var vmSubMenus = bllMenu.GetModelList("MenuParentID=" + vmMenu.MenuID + " order by MenuSeq ");
            foreach(var item in vmSubMenus) {
                vmMenu.SubMenus.Add(new VM_Menu(item));
            }
            return vmMenu.SubMenus;
        }
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-10 20:35:33  
        /// <summary>  
        /// Gets the sub system menu list.
        /// </summary>  
        /// <param name="Id">The identifier.</param>  
        /// <returns>List&lt;VM_Menu&gt;.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-11 13:02:41  
        ///  *********************cniots*************************************
        public static List<VM_Menu> GetSubSystemMenuList(int Id) {
            var vmMenu = GetSystemMenuById(Id);
            return GetSubSystemMenuList(vmMenu);
        }

    
    }
}