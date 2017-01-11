using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    public static class ErrorManager {
        public static string SystemError {
            get { return "SystemError"; }
        }
        public static string ErrorController {
            get {
                return "ErrorHandler";
            }
        }
    }
}