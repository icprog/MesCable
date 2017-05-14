using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    public class VM_ProcDetail:MesWeb.Model.T_HisMain {
        public string ID { get; set; }
        public string SpecName { get; set; }
        public string SpecColor { get; set; }
        public string ODMax { get; set; }
        public string ODMin { get; set; }
        public string CertProduct { get; set; }
        public string CertPlastic { get; set; }
        private string supplier = "中德电线公司";
        public string BatchNo { get; set; }
        public string Supplier {
            get { return supplier; }
            set { supplier = value; }
        }
        public string MachineName { get; set; }
        public string EmployeeName { get; set; }
        public string GeneratorTime { get; set; }
        /// <summary>
        /// 直通率
        /// </summary>
        public string RolledYield { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }
    }
}
