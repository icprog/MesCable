using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Promise {
    public class VM_Error_Info {
        private string title = "系统错误";

        public string Title {
            get { return title; }
            set { title = value; }
        }

        private string returnName = "主页";

        public string ReturnName {
            get { return returnName; }
            set { returnName = value; }
        }

        private string returnUrl = "/Admin/Home";

        public string ReturnUrl {
            get { return returnUrl; }
            set { returnUrl = value; }
        }

        private string errorMessage;

        public string ErrorMessage {
            get { return errorMessage; }
            set { errorMessage = value; }
        }


    }
}
