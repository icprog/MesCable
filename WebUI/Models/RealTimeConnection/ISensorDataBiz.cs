using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models.RealTimeConnection {
    public interface ISensorDataBiz {
        VM_Result_Data GetSensorData(SensorData data);
    }
}
