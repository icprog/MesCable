using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MesWeb.ViewModel.Promise;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WebUI.Utils;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using DataDisplay;
using System.Data;

namespace WebUI.Models.RealTimeConnection {
    /// <summary>
    /// 基于 TCP 协议的实时数据获取
    /// </summary>
    /// <seealso cref="WebUI.Models.RealTimeConnection.IConnection" />
    public class TCPConnection:IConnection {
        protected LogHelper log;

        private ProcessDataDelegate ProcessData;
        private Socket tcpClient;
        private readonly IPEndPoint serverIP;
        ProcessDataDelegate IConnection.ProcessData {
            get {
                return ProcessData;
            }
            set {
                ProcessData = value;
            }
        }


        public TCPConnection(string ipAddr,int port) {
            serverIP = new IPEndPoint(IPAddress.Parse(ipAddr),port);
            StartConnection();
        }
        public TCPConnection() :
            this(ConfigurationManager.AppSettings["ServerIP"],
                int.Parse(ConfigurationManager.AppSettings["ServerPort"])) {

        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-10-08 13:24:45  
        /// <summary>  
        /// 异步获取实时数据
        /// </summary>  
        /// <param name="tcpClient">tcp客户端</param>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-10-08 14:58:10  
        ///  *********************cniots*************************************
        private void asyncReceive(Socket tcpClient) {
            byte[] data = new byte[1024*1024*2];
            try {
                tcpClient.BeginReceive(data,0,data.Length,SocketFlags.None,asyncResult => {
                    //如果关闭了连接则停止异步接收
                    if(tcpClient.Connected == false) {
                        return;
                    }
                    try {
                        int length = tcpClient.EndReceive(asyncResult);
                        execDataProc(data,length);
                    } catch {
                        return;
                    }

                    asyncReceive(tcpClient);
                },null);
            } catch(Exception e) {
                Debug.Write(e.ToString());
            }
        }

        int recIndex = 0;
        /// <summary>
        /// 执行数据解析处理
        /// </summary>
        /// <param name="arrMsgRec">接收到的数组</param>
        /// <param name="length">数组有效长度</param>
        private void execDataProc(byte[] arrMsgRec,int length) {

            //if(++recIndex == 20) {
            //    ProcessData(null);
            //    recIndex = 0;               

            //}
            //return;
            SerializationUnit seru = new DataDisplay.SerializationUnit();
            StructData ms = new StructData();
            byte[] destinationArray = new byte[length];
            Array.Copy(arrMsgRec,destinationArray,length);
            List<byte[]> lstrec = execDataStick(destinationArray);
            foreach(byte[] destinationArr in lstrec) {
                try {
                    StructData mst = (StructData)seru.DeserializeObject(destinationArr);
                    if(mst.datamain != null) {
                        if(mst.datamain.Length > 0) {
                            //对获取的数据进行逻辑处理
                            ProcessData(mst);
                        }
                    }
                } catch(Exception e) {
                    Debug.Write(e.Message);
                    Array.Clear(s2,0,s2.Length);
                }
            }
        }

        byte[] s2 = new byte[0];
        /// <summary>
        /// 接收的数据进行粘包处理
        /// </summary>
        /// <param name="s1"></param>
        /// <returns>处理后数据</returns>
        private List<byte[]> execDataStick(byte[] s1) {
            List<byte[]> listrst = new List<byte[]>();
            List<byte> lsb = new List<byte>();
            lsb.Clear();
            byte[] sendkey1 = System.BitConverter.GetBytes(543215);
            int kx = 0;
            int rsidlen = 0;
            if(s2.Length > 0)
                rsidlen = s2.Length;
            byte[] s3 = new byte[s1.Length + rsidlen];
            if(s2.Length > 0)
                s2.CopyTo(s3,0);
            s1.CopyTo(s3,rsidlen);
            Array.Clear(s2,0,s2.Length);
            listrst.Clear();
            for(int i = 0;i < s3.Length;i++) {
                if(i < s3.Length - 3) {
                    if(s3[i] == sendkey1[0] && s3[i + 1] == sendkey1[1] && s3[i + 2] == sendkey1[2] && s3[i + 3] == sendkey1[3]) {
                        listrst.Add(lsb.ToArray());
                        lsb.Clear();
                        i = i + 3;

                    } else {
                        lsb.Add(s3[i]);
                        kx = i;

                    }
                } else {
                    if(s3.Length - kx > 4)
                        lsb.Add(s3[i]);
                }


            }
            if(lsb.Count > 5 && lsb.Count < 10004) {
                s2 = new byte[lsb.Count];
                lsb.ToArray().CopyTo(s2,0);
            }


            lsb.Clear();
            return listrst;

        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-10-08 13:24:45  
        /// <summary>  
        /// 字符串转字节数组
        /// </summary>  
        /// <param name="str">待转换的字符串/param>  
        /// <param name="encoder">编码方式，默认"GB2312"</param>  
        /// <returns>转换后的字符串</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-10-08 14:59:02  
        ///  *********************cniots*************************************
        public static byte[] Str2Bytes(string str,string encoder = "GB2312") {
            return Encoding.GetEncoding(encoder).GetBytes(str);
        }
        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-10-08 13:24:45  
        /// <summary>  
        /// 字节数组转字符串
        /// </summary>  
        /// <param name="bytes">待转换的字节数组</param>  
        /// <param name="start">起始位置</param>  
        /// <param name="length">长度</param>  
        /// <param name="encoder">编码方式，默认"GB2312"</param>  
        /// <returns>转换后的数组</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-10-08 14:59:57  
        ///  *********************cniots*************************************
        public static string Bytes2Str(byte[] bytes,int start,int length,string encoder = "GB2312") {
            var subBytes = new byte[length];
            Array.Copy(bytes,start,subBytes,0,length);
            return Encoding.GetEncoding(encoder).GetString(subBytes);
        }


        /// <summary>
        /// 开启与数据服务器的连接
        /// </summary>
        /// *********************cniots*************************************
        /// Author           : ychost
        /// Created          : 2016-10-08 13:24:45
        /// Last Modified By : ychost
        /// Last Modified On : 2016-10-08 16:04:28
        /// *********************cniots*************************************
        public void StartConnection() {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            if(IsClosed()) {
                try {
                    tcpClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                    tcpClient.BeginConnect(serverIP,asyncResult => {
                        try {
                            tcpClient.EndConnect(asyncResult);
                        } catch(Exception e) {
                            log.Error("连接数据服务器失败，请检查IP和端口",e);
                        }
                        asyncReceive(tcpClient);
                    },null);
                } catch(Exception e) {
                    Debug.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// 关闭与数据服务器的连接
        /// </summary>
        public void StopConnection() {
            if(IsClosed()) {
                return;
            }

            tcpClient.Shutdown(SocketShutdown.Both);
            byte[] buffer = new byte[1024];
            try {
                int read = 0;
                while((read = tcpClient.Receive(buffer)) > 0) { }
            } catch {
                //ignore
            }
            tcpClient.Close();
            tcpClient = null;

            
        }

        /// <summary>
        /// 检查是否关闭
        /// </summary>
        /// <returns><c>true</c> if this instance is closed; otherwise, <c>false</c>.</returns>
        public bool IsClosed() {
            if(tcpClient == null || tcpClient.Connected == false) {
                return true;
            } else {
                return false;
            }
        }


    }

}