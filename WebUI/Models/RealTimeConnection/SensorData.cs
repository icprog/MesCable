using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.RealTimeConnection {
    public class SensorData {
        public List<T_CodeUsing> CodeUsing { get; set; }
        public List<T_CollectedDataParameters> CollectedData { get; set; }
        public T_FaultModule Fault { get; set; }
    }
}