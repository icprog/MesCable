using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
   public class VM_MaterialOutputDetail {
        private T_MaterialOutput materialOutput;
        private static string certificateFoler = ConfigurationManager.AppSettings["CertificateFolder"];
        public VM_MaterialOutputDetail(T_MaterialOutput materialOutput) {
            this.materialOutput = materialOutput;
        }
        public string MaterialOutputID {
            get { return materialOutput.MaterialOutputID.ToString(); }
        }
        public string MaterialNum {
            get { return materialOutput.MaterialNum.ToString(); }
        }
        public string GenerateTime {
            get { return materialOutput.GnerateTime.ToString(); }
        }
        public string Weight {
            get { return materialOutput.Weight.ToString(); }
        }
        public string Color {
            get { return materialOutput.Color.ToString(); }
        }
        public string Certificate {
            get { return "<a href='" + certificateFoler + materialOutput.Certificate.ToString() + "'>" + materialOutput.Certificate.ToString() + "</a>"; }
        }
        public string EmployeeName {
            get; set;
        }
        public int Index { get; set; }

    }
}
