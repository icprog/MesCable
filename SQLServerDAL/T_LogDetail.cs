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
	/// 数据访问类:T_LogDetail
	/// </summary>
	public partial class T_LogDetail:IT_LogDetail
	{
		public T_LogDetail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(LogDetailID)+1 from T_LogDetail";
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
		public bool Exists(int LogDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LogDetail_Exists");
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32,LogDetailID);
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
		public int Add(MesWeb.Model.T_LogDetail model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LogDetail_ADD");
			db.AddOutParameter(dbCommand, "LogDetailID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "OriginName", DbType.String, model.OriginName);
			db.AddInParameter(dbCommand, "OriginContent", DbType.String, model.OriginContent);
			db.AddInParameter(dbCommand, "CurrentName", DbType.String, model.CurrentName);
			db.AddInParameter(dbCommand, "CurrentContent", DbType.String, model.CurrentContent);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "LogDetailID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_LogDetail model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LogDetail_Update");
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32, model.LogDetailID);
			db.AddInParameter(dbCommand, "OriginName", DbType.String, model.OriginName);
			db.AddInParameter(dbCommand, "OriginContent", DbType.String, model.OriginContent);
			db.AddInParameter(dbCommand, "CurrentName", DbType.String, model.CurrentName);
			db.AddInParameter(dbCommand, "CurrentContent", DbType.String, model.CurrentContent);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LogDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LogDetail_Delete");
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32,LogDetailID);

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
		public bool DeleteList(string LogDetailIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LogDetail ");
			strSql.Append(" where LogDetailID in ("+LogDetailIDlist + ")  ");
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
		public MesWeb.Model.T_LogDetail GetModel(int LogDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LogDetail_GetModel");
			db.AddInParameter(dbCommand, "LogDetailID", DbType.Int32,LogDetailID);

			MesWeb.Model.T_LogDetail model=null;
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
		public MesWeb.Model.T_LogDetail DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_LogDetail model=new MesWeb.Model.T_LogDetail();
			if (row != null)
			{
				if(row["LogDetailID"]!=null && row["LogDetailID"].ToString()!="")
				{
					model.LogDetailID=int.Parse(row["LogDetailID"].ToString());
				}
				if(row["OriginName"]!=null)
				{
					model.OriginName=row["OriginName"].ToString();
				}
				if(row["OriginContent"]!=null)
				{
					model.OriginContent=row["OriginContent"].ToString();
				}
				if(row["CurrentName"]!=null)
				{
					model.CurrentName=row["CurrentName"].ToString();
				}
				if(row["CurrentContent"]!=null)
				{
					model.CurrentContent=row["CurrentContent"].ToString();
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
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
			strSql.Append("select LogDetailID,OriginName,OriginContent,CurrentName,CurrentContent,Comment ");
			strSql.Append(" FROM T_LogDetail ");
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
			strSql.Append(" LogDetailID,OriginName,OriginContent,CurrentName,CurrentContent,Comment ");
			strSql.Append(" FROM T_LogDetail ");
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
			strSql.Append("select count(1) FROM T_LogDetail ");
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
				strSql.Append("order by T.LogDetailID desc");
			}
			strSql.Append(")AS Row, T.*  from T_LogDetail T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_LogDetail");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LogDetailID");
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
		public List<MesWeb.Model.T_LogDetail> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LogDetailID,OriginName,OriginContent,CurrentName,CurrentContent,Comment ");
			strSql.Append(" FROM T_LogDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_LogDetail> list = new List<MesWeb.Model.T_LogDetail>();
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
		public MesWeb.Model.T_LogDetail ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_LogDetail model=new MesWeb.Model.T_LogDetail();
			object ojb; 
			ojb = dataReader["LogDetailID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LogDetailID=(int)ojb;
			}
			model.OriginName=dataReader["OriginName"].ToString();
			model.OriginContent=dataReader["OriginContent"].ToString();
			model.CurrentName=dataReader["CurrentName"].ToString();
			model.CurrentContent=dataReader["CurrentContent"].ToString();
			model.Comment=dataReader["Comment"].ToString();
			return model;
		}

		#endregion  Method
	}
}

