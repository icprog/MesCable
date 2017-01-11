using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.RealTimeConnection {
    public class ConnectionHelper {
        public static IConnection  GetConnection() {
            return new TCPConnection2();
        }
        public static IConnection GetConnection(string ipAddr,int port) {
            return new TCPConnection(ipAddr,port);
        }
    }
}