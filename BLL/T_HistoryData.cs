using MesWeb.DALFactory;
using MesWeb.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MesWeb.BLL {
    public class T_HisMain {
        private string tabName;

        public string TabName {
            get { return tabName; }
            set { tabName = value; }
        }

        public T_HisMain(string tabName) {
            this.tabName = tabName;
        }
        private  IT_HistoryData dal {
            get {

                IT_HistoryData historyData = new MesWeb.SQLServerDAL.T_HistoryData(tabName);
                return historyData;

            }
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_HisMain GetModel(int historyDataID) {

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
        public List<MesWeb.Model.T_HisMain> GetModelList(string strWhere) {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesWeb.Model.T_HisMain> DataTableToList(DataTable dt) {
            List<MesWeb.Model.T_HisMain> modelList = new List<MesWeb.Model.T_HisMain>();
            int rowsCount = dt.Rows.Count;
            if(rowsCount > 0) {
                MesWeb.Model.T_HisMain model;
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

        public List<MesWeb.Model.T_HisMain> GetAllModeList() {
            return DataTableToList(GetAllList().Tables[0]);
        }
    }
}
