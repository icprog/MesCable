using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Models.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebUI.Models.Sockets.Tests {
    [TestClass()]
    public class TCPClientTests {
        [TestMethod()]
        public void TCPClientTest() {

        }

        [TestMethod()]
        public void SendTest() {
            TCPClient tcpClient = new TCPClient();
            tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),8000));
            var sendData = "Hello World";
            tcpClient.Send(Encoding.UTF8.GetBytes(sendData));
            

        }

        [TestMethod()]
        public void SendAsyncTest() {

        }

        [TestMethod()]
        public void DisconnectTest() {

        }

        [TestMethod()]
        public void DisconnectAsyncTest() {

        }

        [TestMethod()]
        public void ConnectTest() {

        }

        [TestMethod()]
        public void ConnectAsyncTest() {

        }

        [TestMethod()]
        public void DisposeTest() {

        }
    }
}