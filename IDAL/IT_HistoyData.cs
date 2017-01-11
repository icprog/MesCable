using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

 namespace MesWeb.IDAL {
    public interface IT_HistoryData {
        #region  成员方法
  
    
        /// 得到一个对象实体
        /// </summary>
        MesWeb.Model.T_HisMain GetModel(int historyID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        MesWeb.Model.T_HisMain DataRowToModel(DataRow row);
            #endregion  成员方法
            #region  MethodEx

            #endregion  MethodEx
        }
}
