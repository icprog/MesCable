using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using static WebUI.Models.Sockets.TCPClient;

namespace WebUI.Models.Sockets {
    public class TCPListenerClient:SocketBase {
        internal TCPListenerClient(TCPListener listener,Socket socket)
            : base(socket,listener.Handler) {
            data = new Dictionary<string,object>();

            this["RemoteEndPoint"] = socket.RemoteEndPoint;
            //创建Socket网络流
            Stream = new NetworkStream(socket);
            //设置服务器
            Listener = listener;

            //开始异步接收数据
            SocketAsyncState state = new SocketAsyncState();
            Handler.BeginReceive(Stream,EndReceive,state);
        }

        public TCPListener Listener { get; private set; }


        private Dictionary<string,object> data;

        public object this[string key] {
            get {
                key = key.ToLower();
                if(data.ContainsKey(key))
                    return data[key];
                return null;
            }
            set {

                key = key.ToLower();
                if(value == null) {
                    if(data.ContainsKey(key))
                        data.Remove(key);
                    return;
                }
                if(data.ContainsKey(key))
                    data[key] = value;
                else
                    data.Add(key,value);
            }
        }
    }
}