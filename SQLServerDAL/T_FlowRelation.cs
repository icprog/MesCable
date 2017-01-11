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
	/// 数据访问类:T_FlowRelation
	/// </summary>
	public partial class T_FlowRelation:IT_FlowRelation
	{
		public T_FlowRelation()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(FlowRelationID)+1 from T_FlowRelation";
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
		public bool Exists(int FlowRelationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_FlowRelation_Exists");
			db.AddInParameter(dbCommand, "FlowRelationID", DbType.Int32,FlowRelationID);
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
		public int Add(MesWeb.Model.T_FlowRelation model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_FlowRelation_ADD");
			db.AddOutParameter(dbCommand, "FlowRelationID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "AuthenticID", DbType.Int32, model.AuthenticID);
			db.AddInParameter(dbCommand, "ApplicationItemID", DbType.Int32, model.ApplicationItemID);
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32, model.FlowID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "FlowRelationID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_FlowRelation model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_FlowRelation_Update");
			db.AddInParameter(dbCommand, "FlowRelationID", DbType.Int32, model.FlowRelationID);
			db.AddInParameter(dbCommand, "AuthenticID", DbType.Int32, model.AuthenticID);
			db.AddInParameter(dbCommand, "ApplicationItemID", DbType.Int32, model.ApplicationItemID);
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32, model.FlowID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FlowRelationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_FlowRelation_Delete");
			db.AddInParameter(dbCommand, "FlowRelationID", DbType.Int32,FlowRelationID);

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
		public bool DeleteList(string FlowRelationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FlowRelation ");
			strSql.Append(" where FlowRelationID in ("+FlowRelationIDlist + ")  ");
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
		public MesWeb.Model.T_FlowRelation GetModel(int FlowRelationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_FlowRelation_GetModel");
			db.AddInParameter(dbCommand, "FlowRelationID", DbType.Int32,FlowRelationID);

			MesWeb.Model.T_FlowRelation model=null;
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
		public MesWeb.Model.T_FlowRelation DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_FlowRelation model=new MesWeb.Model.T_FlowRelation();
			if (row != null)
			{
				if(row["FlowRelationID"]!=null && row["FlowRelationID"].ToString()!="")
				{
					model.FlowRelationID=int.Parse(row["FlowRelationID"].ToString());
				}
				if(row["AuthenticID"]!=null && row["AuthenticID"].ToString()!="")
				{
					model.AuthenticID=int.Parse(row["AuthenticID"].ToString());
				}
				if(row["ApplicationItemID"]!=null && row["ApplicationItemID"].ToString()!="")
				{
					model.ApplicationItemID=int.Parse(row["ApplicationItemID"].ToString());
				}
				if(row["FlowID"]!=null && row["FlowID"].ToString()!="")
				{
					model.FlowID=int.Parse(row["FlowID"].ToString());
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
			strSql.Append("select FlowRelationID,AuthenticID,ApplicationItemID,FlowID ");
			strSql.Append(" FROM T_FlowRelation ");
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
			strSql.Append(" FlowRelationID,AuthenticID,ApplicationItemID,FlowID ");
			strSql.Append(" FROM T_FlowRelation ");
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
			strSql.Append("select count(1) FROM T_FlowRelation ");
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
				strSql.Append("order by T.FlowRelationID desc");
			}
			strSql.Append(")AS Row, T.*  from T_FlowRelation T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_FlowRelation");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "FlowRelationID");
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
		public List<MesWeb.Model.T_FlowRelation> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FlowRelationID,AuthenticID,ApplicationItemID,FlowID ");
			strSql.Append(" FROM T_FlowRelation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_FlowRelation> list = new List<MesWeb.Model.T_FlowRelation>();
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
		public MesWeb.Model.T_FlowRelation ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_FlowRelation model=new MesWeb.Model.T_FlowRelation();
			object ojb; 
			ojb = dataReader["FlowRelationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FlowRelationID=(int)ojb;
			}
			ojb = dataReader["AuthenticID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuthenticID=(int)ojb;
			}
			ojb = dataReader["ApplicationItemID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ApplicationItemID=(int)ojb;
			}
			ojb = dataReader["FlowID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FlowID=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

