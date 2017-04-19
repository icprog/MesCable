
using MES.DBUtility;
using MesWeb.IDAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MesWeb.Model;

namespace MesWeb.SQLServerDAL {
  public partial class T_HistoryData:IT_HistoryData {
        private string tabName;

        public string TabName {
            get { return tabName; }
            set { tabName = value; }
        }

        public T_HistoryData(string tabName) {
            this.tabName = tabName;
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.T_HisMain GetModel(int CurrentDataID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode,MaterialRFID from "+ TabName);
            strSql.Append(" where CurrentDataID=@CurrentDataID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CurrentDataID", SqlDbType.Int,4)
            };
            parameters[0].Value = CurrentDataID;

            MesWeb.Model.T_CurrentData model = new MesWeb.Model.T_CurrentData();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM  "+TabName);
            if(strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.T_HisMain DataRowToModel(DataRow row) {
            MesWeb.Model.T_HisMain model = new MesWeb.Model.T_HisMain();
            if(row != null) {
                if(row["CurrentDataID"] != null && row["CurrentDataID"].ToString() != "") {
                    model.CurrentDataID = int.Parse(row["CurrentDataID"].ToString());
                }
                if(row["TaskID"] != null && row["TaskID"].ToString() != "") {
                    model.TaskID = int.Parse(row["TaskID"].ToString());
                }
                if(row["SpecificationID"] != null && row["SpecificationID"].ToString() != "") {
                    model.SpecificationID = int.Parse(row["SpecificationID"].ToString());
                }
                if(row["MachineID"] != null && row["MachineID"].ToString() != "") {
                    model.MachineID = int.Parse(row["MachineID"].ToString());
                }
                if(row["MachineTypeID"] != null && row["MachineTypeID"].ToString() != "") {
                    model.MachineTypeID = int.Parse(row["MachineTypeID"].ToString());
                }
                if(row["EmployeeID_Main"] != null) {
                    model.EmployeeID_Main = row["EmployeeID_Main"].ToString();
                }
                if(row["EmployeeID_Assistant"] != null) {
                    model.EmployeeID_Assistant = row["EmployeeID_Assistant"].ToString();
                }
                if(row["Start_Axis_No"] != null) {
                    model.Start_Axis_No = row["Start_Axis_No"].ToString();
                }
                if(row["Axis_No"] != null) {
                    model.Axis_No = row["Axis_No"].ToString();
                }
                if(row["Printcode"] != null) {
                    model.Printcode = row["Printcode"].ToString();
                }
                try {
                    if(row["MaterialRFID"] != null) {
                        model.MaterialRFID = row["MaterialRFID"].ToString();
                    }
                } catch {

                }
            }
            return model;
        }

    }
}
