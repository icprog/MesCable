using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using System.Text;
using DataDisplay;
using System.Diagnostics;

namespace WebUI.Models.RealTimeConnection {
    public class TCPConnection2:IConnection {
        #region client 参数
        private Socket m_clientSocket;
        private byte[] m_receiveBuffer = new byte[1024 * 1024 * 2];
        public delegate void TxDelegate();
        public event TxDelegate ReconnectionStart;
        private int _reconnectMax = 500;//当连接断开时是否重连,0为不重连,默认重连三次;
        private int _outTime = 30000;//登录超时时间
        private bool outtimebool = false;//超时用到的临时变量
        private bool reconnectOn = false;//有没有在重连的临时变量
        private bool _engineStart = false;
        private Thread StartThread = null;
        private int centerport = 7788;
        #endregion
        private ProcessDataDelegate ProcessData;

        ProcessDataDelegate IConnection.ProcessData {
            get {
                return ProcessData;
            }
            set {
                ProcessData = value;
            }
        }
        bool isClosed = true;
        public bool IsClosed() {
            Sendmess("122");
            return isClosed;
        }

        public void StartConnection() {
            if(!_engineStart) {
                starteng();
            } else {
                recon = true;
                StartThread.Abort();
                StartThread = null;
                reconnect();
            }

            isClosed = false;
        }

        public void StopConnection() {
            Disconnect_Client();
            isClosed = true;
        }
        #region TCPclient的方法

        void starteng() {
            if(_engineStart)
                return;
            StartThread = null;
            Thread.Sleep(2);
            StartThread = new Thread(clientwork);
            StartThread.IsBackground = true;
            StartThread.Start();

        }
        bool recon = false;
        void clientwork() {
            recon = false;
            if(reconnectOn)//如果是重连的延迟10秒
                Thread.Sleep(10000);
            string serverIP = ConfigurationManager.AppSettings["ServerIP"];
            int serverPort = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);
            if(m_clientSocket == null || m_clientSocket.Connected == false) {
                m_clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP),serverPort);
                try {
                    m_clientSocket.Connect(remoteEndPoint);
                    if(m_clientSocket.Connected) {
                        m_clientSocket.BeginReceive(m_receiveBuffer,0,m_receiveBuffer.Length,0,new AsyncCallback(ReceiveCallBack),null);

                        //MyTestDelegate2 dlg2 = new MyTestDelegate2(AddRunningInfo);


                        _engineStart = true;

                        recon = false;
                    }
                    loginTimeout(m_clientSocket);
                    recon = false;
                } catch(Exception) {
                    if(!reconnectOn) {
                        //MyTestDelegate2 dlg2 = new MyTestDelegate2(AddRunningInfo);


                    }

                    if(m_clientSocket != null)
                        m_clientSocket.Close();
                    m_clientSocket = null;
                    ///this.i((Action)delegate () {
                    //MyTestDelegate2 dlg2 = new MyTestDelegate2(AddRunningInfo);

                    //dlg2(">> " + DateTime.Now.ToString() + " 正在与中心服务器连接...");

                    if(!recon) {
                        recon = true;
                        StartThread.Abort();
                        StartThread = null;
                        reconnect();
                    }
                    // });
                }
            }

        }

        private void loginTimeout(Socket socket) {
            DateTime time1 = DateTime.Now;
            outtimebool = false;
            while(true) {

                if(_engineStart == true || outtimebool == true)
                    break;
                if((int)(DateTime.Now - time1).TotalSeconds > _outTime) {
                    Thread.Sleep(1);
                    if(!recon) {
                        outtimebool = true;
                        socket.Close();

                        recon = false;
                        //StartThread.Abort();
                        //StartThread = null;
                        //reconnect();
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        private void Disconnect_Client() {
            if(m_clientSocket != null) {
                m_clientSocket.Close();
                //btnConnect.Enabled = true;
                //btnDisconnect.Enabled = false;
                //btnSend.Enabled = false;
                // MyTestDelegate2 dlg2 = new MyTestDelegate2(AddRunningInfo);

                //  AddRunningInfo(">> " + DateTime.Now.ToString() + " 中心服务器断开.");

            }
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        private void Sendmess(string Str_Msg) {
            try {

                if(Str_Msg == null)
                    return;
                byte[] sendBuffer = new byte[1024 * 100];
                sendBuffer = Encoding.UTF8.GetBytes(Str_Msg);
                if(m_clientSocket != null && m_clientSocket.Connected) {

                    m_clientSocket.Send(sendBuffer);
                    Thread.Sleep(10);
                    m_clientSocket.Send(sendBuffer);
                } else {
                    Thread.Sleep(3);
                    if(!recon) {
                        if(m_clientSocket != null)
                            m_clientSocket.Close();
                        recon = true;
                        StartThread.Abort();
                        StartThread = null;
                        reconnect();
                    }
                }
            } catch { }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="Str_Msg"></param>
        /// 
        //List<byte[]> lstBuff = new List<byte[]>();
        //List<byte[]> lstBuffT = new List<byte[]>();
        int kx = 0;
        private void SendmesDb(byte[] sendBuffer) {

            if(sendBuffer.Length < 2)
                return;
            //lock (this){ 
            //lstBuff.Add(sendBuff);

            //lstBuff.ForEach(i => lstBuffT.Add(i)); }

            if(m_clientSocket != null && m_clientSocket.Connected) {
                byte[] sendBuf = new byte[sendBuffer.Length + 4];
                byte[] sendkey1 = System.BitConverter.GetBytes(543215);
                sendBuffer.CopyTo(sendBuf,0);
                sendkey1.CopyTo(sendBuf,sendBuffer.Length);

                //foreach (byte[] sendBuffer in lstBuffT)
                //{ 
                int n = m_clientSocket.Send(sendBuf,sendBuf.Length,0);

                if(n < 1)
                    n = m_clientSocket.Send(sendBuf,sendBuf.Length,0);
                if(n < 1)
                    n = m_clientSocket.Send(sendBuf,sendBuf.Length,0);

                kx++;
                // m_clientSocket.Send(sendBuffer);
                // m_clientSocket.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, new AsyncCallback(BeginSendDataCallBack), m_clientSocket);

                //}
                //lstBuffT.Clear();
            } else {

                if(!recon) {
                    if(m_clientSocket != null)
                        m_clientSocket.Close();
                    recon = true;
                    StartThread.Abort();
                    StartThread = null;
                    reconnect();
                }
            }

        }
        private void Sendheart(byte[] byts) {

            if(byts.Length < 1)
                return;

            if(m_clientSocket != null && m_clientSocket.Connected) {

                // m_clientSocket.Send(byts);
                int n = m_clientSocket.Send(byts);
                Thread.Sleep(1);
                n = m_clientSocket.Send(byts);
                if(n < 1)
                    n = m_clientSocket.Send(byts);
                if(n < 1)
                    n = m_clientSocket.Send(byts);

                //  m_clientSocket.BeginSend(byts, 0, byts.Length, SocketFlags.None, new AsyncCallback(BeginHeartbeatCallBack),  m_clientSocket);
            } else {
                Thread.Sleep(1);
                if(!recon) {
                    if(m_clientSocket != null)
                        m_clientSocket.Close();
                    recon = true;
                    StartThread.Abort();
                    StartThread = null;
                    reconnect();
                }
            }
        }
        private void BeginHeartbeatCallBack(IAsyncResult ar) {
            Socket tCleint = ar as Socket;
            if(null != tCleint)
                tCleint.EndSend(ar);
        }
        private void BeginSendDataCallBack(IAsyncResult ar) {
            Socket tCleint = ar as Socket;
            if(null != tCleint)
                tCleint.EndSend(ar);
            //通知调用端发送完毕
        }
        byte[] s2 = new byte[0];
        private List<byte[]> execDataStick(byte[] s1) {


            List<byte[]> listrst = new List<byte[]>();
            List<byte> lsb = new List<byte>();
            lsb.Clear();
            byte[] sendkey1 = System.BitConverter.GetBytes(543215);
            string sendkey2Str = ConfigurationManager.AppSettings["Sendkey2"];
            byte[] sendkey2 = System.BitConverter.GetBytes(int.Parse(sendkey2Str));

            int kx = 0;
            bool nst = false;

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
                        if(s3[i] == sendkey2[0] && s3[i + 1] == sendkey2[1] && s3[i + 2] == sendkey2[2] && s3[i + 3] == sendkey2[3]) {
                            i = i + 3;
                        } else {
                            lsb.Add(s3[i]);
                            kx = i;
                        }

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
        private void ReceiveCallBack(IAsyncResult ar) {
            try {

                int REnd = m_clientSocket.EndReceive(ar);
                //string strReceiveData = Encoding.Unicode.GetString(m_receiveBuffer,0,REnd);


                SerializationUnit seru = new DataDisplay.SerializationUnit();
                StructData ms = new StructData();
                byte[] destinationArray = new byte[REnd];
                Array.Copy(m_receiveBuffer,destinationArray,REnd);
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
                        s2 = new byte[0];
                    }
                }

                //    byte[] destinationArray = new byte[REnd];

                //    //  byte[] destinationArray1 = new byte[length];

                //    Array.Copy(m_receiveBuffer, destinationArray, REnd);
                //this.Invoke((Action)delegate ()
                //{
                //    lstBuff.Remove(destinationArray);
                //}
                //);


                m_clientSocket.BeginReceive(m_receiveBuffer,0,m_receiveBuffer.Length,0,new AsyncCallback(ReceiveCallBack),null);

            } catch(Exception ex) {



            }
        }
        /// <summary>
        /// 处理接收到的数据
        /// </summary>
        /// 

        private void reconnect() {


            if(m_clientSocket != null) {

                m_clientSocket.Close();
                m_clientSocket = null;
            }
            if(reconnectOn == false) {
                try {
                    reconnectOn = true;
                    if(ReconnectionStart != null)

                        eventInvoket(() => { ReconnectionStart(); });
                } catch { }
            }

            _engineStart = false;
            starteng();

        }
        void eventInvoket(Action func) {
            func();
        }
        private void HandleMessage(string message) {
            message = message.Replace("/0","");
            if(!string.IsNullOrEmpty(message)) {

            }
        }

        #endregion
    }
}