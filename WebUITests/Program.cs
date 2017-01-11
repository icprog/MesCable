using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models.Sockets;

namespace WebUITests {
    class Program {
        static TCPClient client;
        static void Main(string[] args) {
            client = new TCPClient();
            client.ReceiveCompleted += Receive;
            client.Connect(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"),8686));
            byte[] data = Encoding.UTF8.GetBytes("hello");

            client.SendAsync(data);

            Console.ReadLine();
        }

        private static void Receive(object sender,SocketEventArgs e) {
            Console.WriteLine(e.Data);

            byte[] data = BitConverter.GetBytes(DateTime.Now.TimeOfDay.TotalMilliseconds);
            client.SendAsync(data);
        }
    }
}

