
using System;
namespace MesWeb.Model {
    /// <summary>
    /// T_SpotInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_SpotInfo {
        public T_SpotInfo() { }
        #region Model
        private int _id;
        private int? _x;
        private int? _y;
        private string _title;
        private string _message;
        private int? _containdistid;
        private string _state;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int Id {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? X {
            set { _x = value; }
            get { return _x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Y {
            set { _y = value; }
            get { return _y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ContainDistId {
            set { _containdistid = value; }
            get { return _containdistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string State {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

