
//using MesWeb.Model;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MesWeb.ViewModel.System {
//    public class VM_Sys_App {
//        public List<Item> items { get; set; }
//        public VM_Sys_App() {
//            items = new List<Item>();
//        }
//    }

//    public class Item {
//        private readonly Sys_App app;
//        public Item(Sys_App app) {
//            this.app = app;
//        }

//        public string type {
//            get { return ! String.IsNullOrWhiteSpace(app.App_type) ? app.App_type:"buton"; }
//        }

//        public string text {
//            get { return app.App_name; }
//        }

//        public string icon {
//            get { return app.App_icon; }
//        }

//        private bool _dislabe = true;
//        public bool disable {
//            get { return _dislabe; }
//            set {
//                _dislabe = value;
//            }
//        }

//        private JRaw _click;

//        public JRaw click {
//            get {
//                return
//                      new JRaw("function(){f_according(" + app.id + ");}");
//                    }
//            set { _click = value; }
//        }

     
//    }




//}
