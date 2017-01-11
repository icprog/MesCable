using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MesWeb.ViewModel.Promise;
using System.Net;
using System.Net.Sockets;

namespace WebUI.Models.RealTimeConnection {
    public class UDPConnection:IConnection {
        public ProcessDataDelegate ProcessData {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public string GetSensorData(string allData,int mahineID) {
            throw new NotImplementedException();
        }

        public bool IsClosed() {
            throw new NotImplementedException();
        }

        public void StartConnection() {
            throw new NotImplementedException();
        }

        public void StopConnection() {
            throw new NotImplementedException();
        }

    }

}