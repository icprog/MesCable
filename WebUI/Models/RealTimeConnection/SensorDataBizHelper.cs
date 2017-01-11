using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.RealTimeConnection {
    public class SensorDataBizHelper {
        public static ISensorDataBiz GetSensorDataBiz() {
            return new SensorDataBiz();
        }
    }
}