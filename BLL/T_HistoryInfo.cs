using CodematicDemo.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MesWeb.BLL {
    public class T_HisData {
        private string tabName;

        public string TabName {
            get { return tabName; }
            set { tabName = value; }
        }
        public T_HisData(string tabName) {
            this.tabName = tabName;
        }
        private IT_HistoryInfo dal {
            get {
                IT_HistoryInfo historyData = new MesWeb.SQLServerDAL.T_HistoryInfo(tabName);
                return historyData;
            }
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_HisData GetModel(int historyDataID) {

            return dal.GetModel(historyDataID);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere) {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesWeb.Model.T_HisData> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesWeb.Model.T_HisData> DataTableToList(DataTable dt) {
            List<MesWeb.Model.T_HisData> modelList = new List<MesWeb.Model.T_HisData>();
            int rowsCount = dt.Rows.Count;
            if(rowsCount > 0) {
                MesWeb.Model.T_HisData model;
                for(int n = 0;n < rowsCount;n++) {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if(model != null) {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetAllList() {
            return dal.GetList("");
        }

        public List<MesWeb.Model.T_HisData> GetAllModeList() {
            return DataTableToList(GetAllList().Tables[0]);
        }
    }
}
