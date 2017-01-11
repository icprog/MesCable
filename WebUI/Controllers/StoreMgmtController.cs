using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class StoreMgmtController:BaseController {
        // GET: StoreMgmt
        public ActionResult Index() {
            return View();
        }

        public ActionResult MaterialSearch() {
            return View();
        }

        public JsonResult SearchMaterials(VM_MaterialOutputCond cond) {
            var retData = new VM_Result_Data();
             var bllEmp = new MesWeb.BLL.T_Employee();
            var bllOuput = new MesWeb.BLL.T_MaterialOutput();
            var emp = bllEmp.GetModelList("EmployeeName = '" + cond.EmployeeName + "'").FirstOrDefault();
            if(emp != null) {
                var empId = emp.EmployeeID;
                var materials = bllOuput.GetModelList("GnerateTime > '" + cond.StartDate + "' and GnerateTime < '" + cond.EndDate + "' and EmployeeID = " + empId );
                if(materials.Count > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "查询成功";
                    var vmOutputList = new List<VM_MaterialOutputDetail>();
                    for(int i = 0;i < materials.Count;++i) {
                        vmOutputList.Add(new VM_MaterialOutputDetail(materials[i]) { Index = i + 1,EmployeeName = emp.EmployeeName});
                    }
                    retData.Appendix = vmOutputList;
                } else {
                    retData.Content = "查询失败";
                }
            } else {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("查询物料的操作人员不存在");
                retData.Content = "操作人员不存在";
            }
            return Json(retData);
        }
    }
}