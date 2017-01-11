using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class QualityCheckAdminController : Controller
    {
        // GET: QualityCheckAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportUpload() {
            return View();
        }

        public ActionResult ReportSearch() {
            return View();
        }
    }
}