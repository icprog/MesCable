using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    public class VM_Sensor_Online {
        public int? ParamCodeId { get; set; }
        public List<VM_Sensor_Data> SeriesData { get; set; }
        public string Message { get; set; }
        public string FaultState { get; set; }
    }

    public class VM_Sensor_Data {
        //横坐标时间
        public string X { get; set; }
        //纵坐标参数值
        public float Y { get; set; }
    }
}
