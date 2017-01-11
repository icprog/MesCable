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
	/// 数据访问类:T_CodeRule
	/// </summary>
	public partial class T_CodeRule:IT_CodeRule
	{
		public T_CodeRule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CodeRuleID)+1 from T_CodeRule";
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
		public bool Exists(int CodeRuleID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CodeRule_Exists");
			db.AddInParameter(dbCommand, "CodeRuleID", DbType.Int32,CodeRuleID);
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
		public int Add(MesWeb.Model.T_CodeRule model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CodeRule_ADD");
			db.AddOutParameter(dbCommand, "CodeRuleID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "CodeTypeID", DbType.Int32, model.CodeTypeID);
			db.AddInParameter(dbCommand, "Rank", DbType.Int32, model.Rank);
			db.AddInParameter(dbCommand, "RankLen", DbType.Int32, model.RankLen);
			db.AddInParameter(dbCommand, "RankMean", DbType.String, model.RankMean);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "CodeRuleID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_CodeRule model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CodeRule_Update");
			db.AddInParameter(dbCommand, "CodeRuleID", DbType.Int32, model.CodeRuleID);
			db.AddInParameter(dbCommand, "CodeTypeID", DbType.Int32, model.CodeTypeID);
			db.AddInParameter(dbCommand, "Rank", DbType.Int32, model.Rank);
			db.AddInParameter(dbCommand, "RankLen", DbType.Int32, model.RankLen);
			db.AddInParameter(dbCommand, "RankMean", DbType.String, model.RankMean);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CodeRuleID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CodeRule_Delete");
			db.AddInParameter(dbCommand, "CodeRuleID", DbType.Int32,CodeRuleID);

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
		public bool DeleteList(string CodeRuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CodeRule ");
			strSql.Append(" where CodeRuleID in ("+CodeRuleIDlist + ")  ");
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
		public MesWeb.Model.T_CodeRule GetModel(int CodeRuleID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CodeRule_GetModel");
			db.AddInParameter(dbCommand, "CodeRuleID", DbType.Int32,CodeRuleID);

			MesWeb.Model.T_CodeRule model=null;
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
		public MesWeb.Model.T_CodeRule DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CodeRule model=new MesWeb.Model.T_CodeRule();
			if (row != null)
			{
				if(row["CodeRuleID"]!=null && row["CodeRuleID"].ToString()!="")
				{
					model.CodeRuleID=int.Parse(row["CodeRuleID"].ToString());
				}
				if(row["CodeTypeID"]!=null && row["CodeTypeID"].ToString()!="")
				{
					model.CodeTypeID=int.Parse(row["CodeTypeID"].ToString());
				}
				if(row["Rank"]!=null && row["Rank"].ToString()!="")
				{
					model.Rank=int.Parse(row["Rank"].ToString());
				}
				if(row["RankLen"]!=null && row["RankLen"].ToString()!="")
				{
					model.RankLen=int.Parse(row["RankLen"].ToString());
				}
				if(row["RankMean"]!=null)
				{
					model.RankMean=row["RankMean"].ToString();
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
			strSql.Append("select CodeRuleID,CodeTypeID,Rank,RankLen,RankMean ");
			strSql.Append(" FROM T_CodeRule ");
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
			strSql.Append(" CodeRuleID,CodeTypeID,Rank,RankLen,RankMean ");
			strSql.Append(" FROM T_CodeRule ");
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
			strSql.Append("select count(1) FROM T_CodeRule ");
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
				strSql.Append("order by T.CodeRuleID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CodeRule T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_CodeRule");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CodeRuleID");
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
		public List<MesWeb.Model.T_CodeRule> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CodeRuleID,CodeTypeID,Rank,RankLen,RankMean ");
			strSql.Append(" FROM T_CodeRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_CodeRule> list = new List<MesWeb.Model.T_CodeRule>();
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
		public MesWeb.Model.T_CodeRule ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_CodeRule model=new MesWeb.Model.T_CodeRule();
			object ojb; 
			ojb = dataReader["CodeRuleID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CodeRuleID=(int)ojb;
			}
			ojb = dataReader["CodeTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CodeTypeID=(int)ojb;
			}
			ojb = dataReader["Rank"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rank=(int)ojb;
			}
			ojb = dataReader["RankLen"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RankLen=(int)ojb;
			}
			model.RankMean=dataReader["RankMean"].ToString();
			return model;
		}

		#endregion  Method
	}
}

