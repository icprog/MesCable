// ***********************************************************************
// Assembly         : MesWeb.ViewModel
// Author           : ychost
// Created          : 09-10-2016
//
// Last Modified By : ychost
// Last Modified On : 09-10-2016
// ***********************************************************************
// <copyright file="VM_Menu_Conf.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.System {
    /// <summary>
    /// the SystemController/MenuConf ViewModel bind to jsTree
    /// </summary>
    public class VM_Menu_Conf {
        /// <summary>
        /// The menu viewmodel
        /// </summary>
        private VM_Menu _menu;


        private List<VM_Menu_Conf> _children = new List<VM_Menu_Conf>();
        public List<VM_Menu_Conf> children { get { return _children; } set { _children = value; } }
        public int id { get { return _menu.MenuID; } }
        public string text { get { return _menu.MenuName; } }
        private string _default_icon = "fa fa-file-code-o";
        public string icon { get { return string.IsNullOrEmpty(_menu.MenuICON)? _default_icon : _menu.MenuICON; } }
        public Menu_Conf_State state { get; set; }
        public dynamic li_attr { get; set; }
        public dynamic a_attr { get; set; }
        public VM_Menu_Conf(VM_Menu _menu) {
            this._menu = _menu;
            if(_menu.SubMenus.Count == 0) {
                return;
            }
            foreach(var  m in _menu.SubMenus) {
                var subMenu = new VM_Menu_Conf(m);
                this.children.Add(subMenu);
            }
        }
    }

    public class Menu_Conf_State {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }
}
