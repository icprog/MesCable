
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL {
    /// <summary>
    /// 数据访问类:T_SpotInfo
    /// </summary>
    public partial class T_SpotInfo:IT_SpotInfo {
        public T_SpotInfo() { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("Id","T_SpotInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id) {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int result = DbHelperSQL.RunProcedure("T_SpotInfo_Exists",parameters,out rowsAffected);
            if(result == 1) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(MesWeb.Model.T_SpotInfo model) {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@X", SqlDbType.Int,4),
                    new SqlParameter("@Y", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@Message", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContainDistId", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,255)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.X;
            parameters[2].Value = model.Y;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Message;
            parameters[5].Value = model.ContainDistId;
            parameters[6].Value = model.State;
            parameters[7].Value = model.Remark;

            DbHelperSQL.RunProcedure("T_SpotInfo_ADD",parameters,out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(MesWeb.Model.T_SpotInfo model) {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@X", SqlDbType.Int,4),
                    new SqlParameter("@Y", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.NVarChar,50),
                    new SqlParameter("@Message", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContainDistId", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.X;
            parameters[2].Value = model.Y;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Message;
            parameters[5].Value = model.ContainDistId;
            parameters[6].Value = model.State;
            parameters[7].Value = model.Remark;

            DbHelperSQL.RunProcedure("T_SpotInfo_Update",parameters,out rowsAffected);
            if(rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id) {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            DbHelperSQL.RunProcedure("T_SpotInfo_Delete",parameters,out rowsAffected);
            if(rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SpotInfo ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public MesWeb.Model.T_SpotInfo GetModel(int Id) {
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            MesWeb.Model.T_SpotInfo model = new MesWeb.Model.T_SpotInfo();
            DataSet ds = DbHelperSQL.RunProcedure("T_SpotInfo_GetModel",parameters,"ds");
            if(ds.Tables[0].Rows.Count > 0) {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            } else {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesWeb.Model.T_SpotInfo DataRowToModel(DataRow row) {
            MesWeb.Model.T_SpotInfo model = new MesWeb.Model.T_SpotInfo();
            if(row != null) {
                if(row["Id"] != null && row["Id"].ToString() != "") {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if(row["X"] != null && row["X"].ToString() != "") {
                    model.X = int.Parse(row["X"].ToString());
                }
                if(row["Y"] != null && row["Y"].ToString() != "") {
                    model.Y = int.Parse(row["Y"].ToString());
                }
                if(row["Title"] != null) {
                    model.Title = row["Title"].ToString();
                }
                if(row["Message"] != null) {
                    model.Message = row["Message"].ToString();
                }
                if(row["ContainDistId"] != null && row["ContainDistId"].ToString() != "") {
                    model.ContainDistId = int.Parse(row["ContainDistId"].ToString());
                }
                if(row["State"] != null) {
                    model.State = row["State"].ToString();
                }
                if(row["Remark"] != null) {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,X,Y,Title,Message,ContainDistId,State,Remark ");
            strSql.Append(" FROM T_SpotInfo ");
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
            strSql.Append(" Id,X,Y,Title,Message,ContainDistId,State,Remark ");
            strSql.Append(" FROM T_SpotInfo ");
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
            strSql.Append("select count(1) FROM T_SpotInfo ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from T_SpotInfo T ");
            if(!string.IsNullOrEmpty(strWhere.Trim())) {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}",startIndex,endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "T_SpotInfo";
			parameters[1].Value = "Id";
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

