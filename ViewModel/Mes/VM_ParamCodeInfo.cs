using MesWeb.ViewModel.Ocx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    public class VM_ParamCodeInfo:MesWeb.Model.T_ParameterCode {
        private List<VM_CscDrop> paramUnitList = new List<VM_CscDrop>();

        public List<VM_CscDrop> ParamUnitList {
            get { return paramUnitList; }
            set { paramUnitList = value; }
        }

    }
}
