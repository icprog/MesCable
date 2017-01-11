using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{

    /// <summary>
    /// 数据查询
    /// </summary>
    public class DataSearchController : BaseController
    {
        // GET: DataSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee() {
            return View();
        }

        /// <summary>
        /// 通过名字查询用户
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SearchEmployeeByNameAction(string name) {     
            return Json(getEmployeeData("EmployeeName ='" + name + "'"));
        }

        private VM_Result_Data getEmployeeData(string param) {
            var retData = new VM_Result_Data();
            retData.Content = "查询失败";

            var bllEmp = new MesWeb.BLL.T_Employee();
            var bllDpt = new MesWeb.BLL.T_Department();

            var empList = bllEmp.GetModelList(param);
            try {
                if(empList.Count > 0) {
                    var vmEmpList = new List<VM_Search_Employee>();
                    foreach(var emp in empList) {
                        var vmEmp = new VM_Search_Employee(emp);
                        var dpt = bllDpt.GetModelList("DepartmentID = " + emp.DepartmentID).FirstOrDefault();
                        if(dpt != null) {
                            vmEmp.DepartmentName = dpt.DepartmentName;
                        }
                        vmEmpList.Add(vmEmp);
                    }
                    retData.Appendix = vmEmpList;
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "查询成功";
                }
            } catch(Exception) {

            }
             return (retData);
        }

        /// <summary>
        /// 通过编号查询用户
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SearchEmployeeByCodeAction(string code) {
            return Json(getEmployeeData("EmployeeCode ='" + code + "'"));

        }
    }
}