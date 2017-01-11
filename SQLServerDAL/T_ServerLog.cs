
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_ServerLog
	/// </summary>
	public partial class T_ServerLog:IT_ServerLog
	{
		public T_ServerLog()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ServerLogID", "T_ServerLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ServerLogID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ServerLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = ServerLogID;

			int result= DbHelperSQL.RunProcedure("T_ServerLog_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_ServerLog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ServerLogID", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.NVarChar,50),
					new SqlParameter("@Logger", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar,4000),
					new SqlParameter("@Thread", SqlDbType.NVarChar,50),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Exception", SqlDbType.NVarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.Level;
			parameters[2].Value = model.Logger;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.Thread;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Exception;

			DbHelperSQL.RunProcedure("T_ServerLog_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_ServerLog model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ServerLogID", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.NVarChar,50),
					new SqlParameter("@Logger", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar,4000),
					new SqlParameter("@Thread", SqlDbType.NVarChar,50),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@Exception", SqlDbType.NVarChar,2000)};
			parameters[0].Value = model.ServerLogID;
			parameters[1].Value = model.Level;
			parameters[2].Value = model.Logger;
			parameters[3].Value = model.Message;
			parameters[4].Value = model.Thread;
			parameters[5].Value = model.Date;
			parameters[6].Value = model.Exception;

			DbHelperSQL.RunProcedure("T_ServerLog_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ServerLogID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ServerLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = ServerLogID;

			DbHelperSQL.RunProcedure("T_ServerLog_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ServerLogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ServerLog ");
			strSql.Append(" where ServerLogID in ("+ServerLogIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_ServerLog GetModel(int ServerLogID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ServerLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = ServerLogID;

			MesWeb.Model.T_ServerLog model=new MesWeb.Model.T_ServerLog();
			DataSet ds= DbHelperSQL.RunProcedure("T_ServerLog_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_ServerLog DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ServerLog model=new MesWeb.Model.T_ServerLog();
			if (row != null)
			{
				if(row["ServerLogID"]!=null && row["ServerLogID"].ToString()!="")
				{
					model.ServerLogID=int.Parse(row["ServerLogID"].ToString());
				}
				if(row["Level"]!=null)
				{
					model.Level=row["Level"].ToString();
				}
				if(row["Logger"]!=null)
				{
					model.Logger=row["Logger"].ToString();
				}
				if(row["Message"]!=null)
				{
					model.Message=row["Message"].ToString();
				}
				if(row["Thread"]!=null)
				{
					model.Thread=row["Thread"].ToString();
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
				}
				if(row["Exception"]!=null)
				{
					model.Exception=row["Exception"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ServerLogID,Level,Logger,Message,Thread,Date,Exception ");
			strSql.Append(" FROM T_ServerLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ServerLogID,Level,Logger,Message,Thread,Date,Exception ");
			strSql.Append(" FROM T_ServerLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_ServerLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ServerLogID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ServerLog T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "T_ServerLog";
			parameters[1].Value = "ServerLogID";
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

