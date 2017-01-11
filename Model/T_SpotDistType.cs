
using System;
namespace MesWeb.Model {
    /// <summary>
    /// T_SpotDistType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_SpotDistType {
        public T_SpotDistType() { }
        #region Model
        private int _id;
        private string _type;
        private string _tabname;
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
        public string Type {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TabName {
            set { _tabname = value; }
            get { return _tabname; }
        }
        #endregion Model

    }
}

