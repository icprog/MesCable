using System.Text;
using System.Data;
using MesWeb.IDAL;
using System.Data.SqlClient;
using System;
using MES.DBUtility;

namespace MesWeb.SQLServerDAL {
    /// <summary>
    /// 数据访问类:Sys_App
    /// </summary>
    public partial class Sys_App:ISys_App {
        public Sys_App() { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("id","Sys_App");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id) {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            int result = DbHelperSQL.RunProcedure("Sys_App_Exists",parameters,out rowsAffected);
            if(result == 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(MesWeb.Model.Sys_App model) {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@App_name", SqlDbType.VarChar,100),
                    new SqlParameter("@App_order", SqlDbType.Int,4),
                    new SqlParameter("@App_url", SqlDbType.VarChar,250),
                    new SqlParameter("@App_handler", SqlDbType.VarChar,250),
                    new SqlParameter("@App_type", SqlDbType.VarChar,50),
                    new SqlParameter("@App_icon", SqlDbType.VarChar,250)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.App_name;
            parameters[2].Value = model.App_order;
            parameters[3].Value = model.App_url;
            parameters[4].Value = model.App_handler;
            parameters[5].Value = model.App_type;
            parameters[6].Value = model.App_icon;

            DbHelperSQL.RunProcedure("Sys_App_ADD",parameters,out rowsAffected);
            if(rowsAffected > 0) {
                return 1;
            } else {
                return 0;
            }
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(MesWeb.Model.Sys_App model) {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@App_name", SqlDbType.VarChar,100),
                    new SqlParameter("@App_order", SqlDbType.Int,4),
                    new SqlParameter("@App_url", SqlDbType.VarChar,250),
                    new SqlParameter("@App_handler", SqlDbType.VarChar,250),
                    new SqlParameter("@App_type", SqlDbType.VarChar,50),
                    new SqlParameter("@App_icon", SqlDbType.VarChar,250)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.App_name;
            parameters[2].Value = model.App_order;
            parameters[3].Value = model.App_url;
            parameters[4].Value = model.App_handler;
            parameters[5].Value = model.App_type;
            parameters[6].Value = model.App_icon;

            DbHelperSQL.RunProcedure("Sys_App_Update",parameters,out rowsAffected);
            if(rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id) {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            DbHelperSQL.RunProcedure("Sys_App_Delete",parameters,out rowsAffected);
            if(rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_App ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.Sys_App GetModel(int id) {
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            MesWeb.Model.Sys_App model = new MesWeb.Model.Sys_App();
            DataSet ds = DbHelperSQL.RunProcedure("Sys_App_GetModel",parameters,"ds");
            if(ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.Sys_App DataRowToModel(DataRow row) {
            MesWeb.Model.Sys_App model = new MesWeb.Model.Sys_App();
            if(row != null) {
                if(row["id"] != null && row["id"].ToString() != "") {
                    model.id = int.Parse(row["id"].ToString());
                }
                if(row["App_name"] != null) {
                    model.App_name = row["App_name"].ToString();
                }
                if(row["App_order"] != null && row["App_order"].ToString() != "") {
                    model.App_order = int.Parse(row["App_order"].ToString());
                }
                if(row["App_url"] != null) {
                    model.App_url = row["App_url"].ToString();
                }
                if(row["App_handler"] != null) {
                    model.App_handler = row["App_handler"].ToString();
                }
                if(row["App_type"] != null) {
                    model.App_type = row["App_type"].ToString();
                }
                if(row["App_icon"] != null) {
                    model.App_icon = row["App_icon"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,App_name,App_order,App_url,App_handler,App_type,App_icon ");
            strSql.Append(" FROM Sys_App ");
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
            strSql.Append(" id,App_name,App_order,App_url,App_handler,App_type,App_icon ");
            strSql.Append(" FROM Sys_App ");
            if(strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Sys_App ");
            if(strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if(obj == null) {
                return 0;
            } else {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere,string orderby,int startIndex,int endIndex) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if(!string.IsNullOrEmpty(orderby.Trim())) {
                strSql.Append("order by T." + orderby);
            } else {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_App T ");
            if(!string.IsNullOrEmpty(strWhere.Trim())) {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}",startIndex,endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool DeleteAll() {
            string sqlStr = "delete from Sys_App where 1=1";
            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Sys_App";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

