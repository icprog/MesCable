using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Models.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace WebUI.Models.Sockets.Tests {
    [TestClass()]
    public class TCPListenerTests {
        [TestMethod()]
        public void TCPListenerTest() {

        }

        [TestMethod()]
        public void StartTest() {
            int port = 8001;
            TCPListener server = new TCPListener();
            TCPClient client = new TCPClient();
            server.Port = port;
            server.Start();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),port));
            client.Send(Encoding.UTF8.GetBytes("Hello"));
            bool flag = false;
             server.ReceiveCompleted += (s,e) => { Debug.WriteLine(e.Data);
                 flag = true;
                Assert.AreEqual(e.Data,"Hello");
            };
            while(!flag)
                ;
                
           
        }

        [TestMethod()]
        public void StopTest() {

        }

        [TestMethod()]
        public void GetEnumeratorTest() {

        }

        [TestMethod()]
        public void DisposeTest() {

        }
    }
}