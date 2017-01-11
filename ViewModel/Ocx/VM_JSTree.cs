using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Ocx {
    public class VM_JSTree {

        public string id { get; set; }
        public string text { get; set; }
        private string _icon= "fa fa-file-code-o";

        public string icon {
            get { return _icon; }
            set { _icon = value; }
        }

        private JSTreeState _state = new JSTreeState();

        public JSTreeState state {
            get { return _state; }
            set { _state = value; }
        }

        public dynamic li_attr { get; set; }
        public dynamic a_attr { get; set; }
        private List<VM_JSTree> _children ;

        public List<VM_JSTree> children {
            get { return _children; }
            set { _children = value; }
        }
    }

    public class JSTreeState {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }
}
