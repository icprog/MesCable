using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    public class VM_Trace_Search_Cond {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string SpecNum { get; set; }
        public string PrintCode { get; set; }
        public string AxisNum { get; set; }
        public string MachineType { get; set; }
    }

    public class VM_Trace_Bref {
        public string Date { get; set; }
        public string Axis_No{ get; set; }
        public string PrintCode { get; set; }
        public string Detail { get; set; }
        public string SpecNum { get; set; }
    }

    public class MahineHistoryQueryCond {
        public string axisNum { get; set;}
        public string machineId { get; set; }
    }
}
