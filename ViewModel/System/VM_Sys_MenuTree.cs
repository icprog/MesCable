using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.System {
    public class VM_Sys_MenuTree {
        private Sys_App _sys_app;
        private Sys_Menu _sys_menu;
        private List<VM_Sys_MenuTree> _children = new List<VM_Sys_MenuTree>();
        public List<VM_Sys_MenuTree> children {
            get {
                return _children;
            }set {
                _children = value;
            }
        }
        private string _text;

        public string text {
            get { return _text; }
            set { _text = value; }
        }

        public VM_Sys_MenuTree() {
                
        }
        public VM_Sys_MenuTree(List<Sys_Menu> sys_menus,List<Sys_App> sys_apps) {
            InitTrees(sys_menus,sys_apps);
        }

        public void InitTrees(List<Sys_Menu> sys_menus,List<Sys_App> sys_apps) {
            _children = new List<VM_Sys_MenuTree>();
            foreach(var app in sys_apps) {
                var oneMenuTree = new VM_Sys_MenuTree(app);
                _children.Add(oneMenuTree);
                var secMenus = sys_menus.FindAll(sm => sm.App_id == app.id && sm.parentid == 0);
                foreach(var secMenu in secMenus) {
                    var threeMenus = sys_menus.FindAll(tm => tm.App_id == app.id && tm.parentid == secMenu.Menu_id);
                    var secMenuTree = new VM_Sys_MenuTree(secMenu);
                    oneMenuTree.children.Add(secMenuTree);
                    foreach(var threeMenu in threeMenus) {
                        var threeMenuTree = new VM_Sys_MenuTree(threeMenu);
                        secMenuTree.children.Add(threeMenuTree);
                    }
                }
            }
        }


      
        public VM_Sys_MenuTree(Sys_App app) {
            _text = app.App_name;
            _sys_app = app;
        }

        public VM_Sys_MenuTree(Sys_Menu menu) {
            _text = menu.Menu_name;
            _sys_menu = menu;
        }

        public Sys_App sys_app {
            get {
                return _sys_app;
            } set {
                _sys_app = value;
            }
        }

        public Sys_Menu sys_menu {
            get {
                return _sys_menu;
            }set {
                _sys_menu = value;
            }
        }


    }
}
