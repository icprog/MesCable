using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Ocx {
    public class VM_JSMind {
        private List<JSMind_Data> _data = new List<JSMind_Data>();

        public List<JSMind_Data> data {
            get { return _data; }
            set { _data = value; }
        }

    }

   public class JSMind_Data {
        public string id { get; set; }
        public object data { get; set; }
        public bool isroot { get; set; }
        public string parentid { get; set; }
        public string topic { get; set; }
        public string direction { get; set; }
        public JSMind_Data(string id,string parentid,string topic,object data,bool isroot = false,string direction = "left") {
            this.id = id;
            this.parentid = parentid;
            this.topic = topic;
            this.data = data;
            this.isroot = isroot;
            this.direction = direction;
        }
        public JSMind_Data() {

        }
    }
}
