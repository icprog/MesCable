using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
  public  class VM_Search_Employee {
        private T_Employee employee;
        public string EmployeeName { get { return employee.EmployeeName; } }
        public string EmployeeCode { get { return employee.EmployeeCode; } }
        public string EmployeeAge { get { return employee.EmployeeAge.ToString(); } }
        public string EmployeeSex { get { return employee.EmployeeSex; } }
        public string EmployeeTel { get { return employee.EmployeeTel; } }
        public string DepartmentName { get; set; }
        public string GeneratorTime { get { return employee.GeneratorTime.ToString(); } }
        public long EmployeeID { get { return employee.EmployeeID; } }



        public VM_Search_Employee(MesWeb.Model.T_Employee employee) {
            this.employee = employee;
        }
    }
}
