using MesWeb.ViewModel.Promise;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebUI.Models.RealTimeConnection {
    public class SensorUpdateHub:Hub {

        private  readonly SensorUpdater sensorUpdater;
        public SensorUpdateHub() : this(SensorUpdater.Instance) {
        }
        public SensorUpdateHub(SensorUpdater sensorUpdater) {          
            this.sensorUpdater = sensorUpdater;     
        }


        /// <summary>
        /// 前端初始化连接
        /// </summary>
        /// <param name="machineID"></param>
        /// <returns></returns>
        public string InitAllSensors(int machineID) {
            //TODO 查询数据
            //return sensorUpdater.InitAllSensors(Context.ConnectionId,machineID);
            return sensorUpdater.InitAllSensors(machineID,Context.ConnectionId);

        }

        #region 前端触发事件
        /// <summary>
        /// 前端断开连接回调
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled) {           
            sensorUpdater.RemoveClient(Context.ConnectionId);
            if(sensorUpdater.GetClientsCount() <= 0) {
                //关闭与数据服务器的连接
                sensorUpdater.StopServerConnection();
                //清空缓存
                sensorUpdater.ClearCache();
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 建立与数据服务器的连接
        /// </summary>
        private void createConnection() {
            int retry = 50;
            while(sensorUpdater.IsClosed() == true && retry > 0) {
                sensorUpdater.StartServerConnection();
                --retry;
            }
           
           
        }

        /// <summary>
        /// 前端连接回调
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected() {
            createConnection();
            return base.OnConnected();
        }

        /// <summary>
        /// 前端恢复连接回调
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected() {
            createConnection();
            return base.OnReconnected();
        }
        #endregion
    }
}