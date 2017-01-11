using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models.RealTimeConnection {
    public delegate void ProcessDataDelegate(DataDisplay.StructData getData);

    /// <summary>
    /// 获取实时连接接口
    /// </summary>
    public interface IConnection {
        /// <summary>
        /// 处理获取的数据
        /// </summary>
        /// <value>获取的数据</value>
        ProcessDataDelegate ProcessData { get; set; }

        /// <summary>
        /// 开启连接
        /// </summary>
        void StartConnection();
        /// <summary>
        /// 关闭连接
        /// </summary>
        void StopConnection();

        /// <summary>
        /// 检查是否关闭
        /// </summary>
        /// <returns></returns>
        bool IsClosed();

 
    }
}
