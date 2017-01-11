using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.System {
   public class VM_Menu {
        private T_Menu menu;

        public VM_Menu(T_Menu menu) {
            this.menu = menu;
        }
        public VM_Menu() {

        }

        private List<VM_Menu> subMenus = new List<VM_Menu>();
        public List<VM_Menu> SubMenus {
            get { return subMenus; }
            set { subMenus = value; }
        }


        public int MenuID { get { return menu.MenuID; } }
        public int? MenuParentID { get { return menu.MenuParentID; } }
        public int MenuLevel { get { return menu.MenuLevel; } }
        public string MenuName { get { return menu.MenuName; } }
        public string MenuUrl { get { return menu.MenuUrl; } }
        public string MenuICON { get { return menu.MenuICON; } }
        public string MenuRemark { get { return menu.MenuRemark; } }
    }
}
