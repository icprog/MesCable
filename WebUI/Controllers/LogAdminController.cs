using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesWeb.Model;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class LogAdminController : Controller
    {
        // GET: LogAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServerLog() {
            return View();
        }

        [HttpPost]
        public string GetServerLog() {
            var retData = new VM_Result_Data();
            var bllServerLog = new MesWeb.BLL.T_ServerLog();
            var serLogList =bllServerLog.DataTableToList(bllServerLog.GetAllList().Tables[0]);

            return JsonConvert.SerializeObject(serLogList);
        }

      
    }
}