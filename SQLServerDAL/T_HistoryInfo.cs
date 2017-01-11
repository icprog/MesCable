using CodematicDemo.IDAL;
using MES.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MesWeb.SQLServerDAL {
    public class T_HistoryInfo :IT_HistoryInfo {
        private string tabName;

        public string TabName {
            get { return tabName; }
            set { tabName = value; }
        }

        public T_HistoryInfo(string tabName) {
            this.tabName = tabName;
        }
        /// <summary>
		/// 得到一个对象实体`
		/// </summary>
		public MesWeb.Model.T_HisData GetModel(int CollectedDataParametersID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No from  "+tabName);
            strSql.Append(" where CollectedDataParametersID=@CollectedDataParametersID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CollectedDataParametersID", SqlDbType.Int,4)
            };
            parameters[0].Value = CollectedDataParametersID;

            MesWeb.Model.T_HisData model = new MesWeb.Model.T_HisData();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.T_HisData DataRowToModel(DataRow row) {
            MesWeb.Model.T_HisData model = new MesWeb.Model.T_HisData();
            if(row != null) {
                if(row["CollectedDataParametersID"] != null && row["CollectedDataParametersID"].ToString() != "") {
                    model.CollectedDataParametersID = int.Parse(row["CollectedDataParametersID"].ToString());
                }
                if(row["CollectedValue"] != null) {
                    model.CollectedValue = row["CollectedValue"].ToString();
                }
                if(row["CollectedTime"] != null && row["CollectedTime"].ToString() != "") {
                    model.CollectedTime = DateTime.Parse(row["CollectedTime"].ToString());
                }
                if(row["ParameterCodeID"] != null && row["ParameterCodeID"].ToString() != "") {
                    model.ParameterCodeID = int.Parse(row["ParameterCodeID"].ToString());
                }
                if(row["MachineID"] != null && row["MachineID"].ToString() != "") {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                if(row["Axis_No"] != null) {
                    model.Axis_No = row["Axis_No"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No ");
            strSql.Append(" FROM  "+tabName);
            if(strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if(Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No ");
            strSql.Append(" FROM  "+tabName);
            if(strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
