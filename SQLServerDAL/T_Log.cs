using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Log
	/// </summary>
	public partial class T_Log:IT_Log
	{
		public T_Log()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(LogID)+1 from T_Log";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LogID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Log_Exists");
			db.AddInParameter(dbCommand, "LogID", DbType.Int32,LogID);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
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
		public int Add(MesWeb.Model.T_Log model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Log_ADD");
			db.AddOutParameter(dbCommand, "LogID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "UserID", DbType.Int32, model.UserID);
			db.AddInParameter(dbCommand, "LogTypeID", DbType.Int32, model.LogTypeID);
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32, model.LogDetailID);
			db.AddInParameter(dbCommand, "LoginTime", DbType.DateTime, model.LoginTime);
			db.AddInParameter(dbCommand, "LoginIP", DbType.String, model.LoginIP);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "LogID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Log model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Log_Update");
			db.AddInParameter(dbCommand, "LogID", DbType.Int32, model.LogID);
			db.AddInParameter(dbCommand, "UserID", DbType.Int32, model.UserID);
			db.AddInParameter(dbCommand, "LogTypeID", DbType.Int32, model.LogTypeID);
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32, model.LogDetailID);
			db.AddInParameter(dbCommand, "LoginTime", DbType.DateTime, model.LoginTime);
			db.AddInParameter(dbCommand, "LoginIP", DbType.String, model.LoginIP);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LogID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Log_Delete");
			db.AddInParameter(dbCommand, "LogID", DbType.Int32,LogID);

			int rows=db.ExecuteNonQuery(dbCommand);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Log ");
			strSql.Append(" where LogID in ("+LogIDlist + ")  ");
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
		public MesWeb.Model.T_Log GetModel(int LogID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Log_GetModel");
			db.AddInParameter(dbCommand, "LogID", DbType.Int32,LogID);

			MesWeb.Model.T_Log model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_Log DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Log model=new MesWeb.Model.T_Log();
			if (row != null)
			{
				if(row["LogID"]!=null && row["LogID"].ToString()!="")
				{
					model.LogID=int.Parse(row["LogID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["LogTypeID"]!=null && row["LogTypeID"].ToString()!="")
				{
					model.LogTypeID=int.Parse(row["LogTypeID"].ToString());
				}
				if(row["LogDetailID"]!=null && row["LogDetailID"].ToString()!="")
				{
					model.LogDetailID=int.Parse(row["LogDetailID"].ToString());
				}
				if(row["LoginTime"]!=null && row["LoginTime"].ToString()!="")
				{
					model.LoginTime=DateTime.Parse(row["LoginTime"].ToString());
				}
				if(row["LoginIP"]!=null)
				{
					model.LoginIP=row["LoginIP"].ToString();
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
			strSql.Append("select LogID,UserID,LogTypeID,LogDetailID,LoginTime,LoginIP ");
			strSql.Append(" FROM T_Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
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
			strSql.Append(" LogID,UserID,LogTypeID,LogDetailID,LoginTime,LoginIP ");
			strSql.Append(" FROM T_Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Log ");
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
				strSql.Append("order by T.LogID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Log T ");
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
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Log");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LogID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<MesWeb.Model.T_Log> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LogID,UserID,LogTypeID,LogDetailID,LoginTime,LoginIP ");
			strSql.Append(" FROM T_Log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Log> list = new List<MesWeb.Model.T_Log>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public MesWeb.Model.T_Log ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Log model=new MesWeb.Model.T_Log();
			object ojb; 
			ojb = dataReader["LogID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LogID=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["LogTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LogTypeID=(int)ojb;
			}
			ojb = dataReader["LogDetailID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LogDetailID=(int)ojb;
			}
			ojb = dataReader["LoginTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginTime=(DateTime)ojb;
			}
			model.LoginIP=dataReader["LoginIP"].ToString();
			return model;
		}

		#endregion  Method
	}
}

