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
	/// 数据访问类:T_ProdictAblity
	/// </summary>
	public partial class T_ProdictAblity:IT_ProdictAblity
	{
		public T_ProdictAblity()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProdictAblityID)+1 from T_ProdictAblity";
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
		public bool Exists(int ProdictAblityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ProdictAblity_Exists");
			db.AddInParameter(dbCommand, "ProdictAblityID", DbType.Int32,ProdictAblityID);
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
		public int Add(MesWeb.Model.T_ProdictAblity model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ProdictAblity_ADD");
			db.AddOutParameter(dbCommand, "ProdictAblityID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "FinishedTime", DbType.DateTime, model.FinishedTime);
			db.AddInParameter(dbCommand, "Totalfee", DbType.Decimal, model.Totalfee);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "ProdictAblityID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_ProdictAblity model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ProdictAblity_Update");
			db.AddInParameter(dbCommand, "ProdictAblityID", DbType.Int32, model.ProdictAblityID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "FinishedTime", DbType.DateTime, model.FinishedTime);
			db.AddInParameter(dbCommand, "Totalfee", DbType.Decimal, model.Totalfee);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProdictAblityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ProdictAblity_Delete");
			db.AddInParameter(dbCommand, "ProdictAblityID", DbType.Int32,ProdictAblityID);

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
		public bool DeleteList(string ProdictAblityIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ProdictAblity ");
			strSql.Append(" where ProdictAblityID in ("+ProdictAblityIDlist + ")  ");
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
		public MesWeb.Model.T_ProdictAblity GetModel(int ProdictAblityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ProdictAblity_GetModel");
			db.AddInParameter(dbCommand, "ProdictAblityID", DbType.Int32,ProdictAblityID);

			MesWeb.Model.T_ProdictAblity model=null;
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
		public MesWeb.Model.T_ProdictAblity DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ProdictAblity model=new MesWeb.Model.T_ProdictAblity();
			if (row != null)
			{
				if(row["ProdictAblityID"]!=null && row["ProdictAblityID"].ToString()!="")
				{
					model.ProdictAblityID=int.Parse(row["ProdictAblityID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["FinishedTime"]!=null && row["FinishedTime"].ToString()!="")
				{
					model.FinishedTime=DateTime.Parse(row["FinishedTime"].ToString());
				}
				if(row["Totalfee"]!=null && row["Totalfee"].ToString()!="")
				{
					model.Totalfee=decimal.Parse(row["Totalfee"].ToString());
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
			strSql.Append("select ProdictAblityID,JobSheetID,FinishedTime,Totalfee ");
			strSql.Append(" FROM T_ProdictAblity ");
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
			strSql.Append(" ProdictAblityID,JobSheetID,FinishedTime,Totalfee ");
			strSql.Append(" FROM T_ProdictAblity ");
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
			strSql.Append("select count(1) FROM T_ProdictAblity ");
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
				strSql.Append("order by T.ProdictAblityID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ProdictAblity T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_ProdictAblity");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ProdictAblityID");
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
		public List<MesWeb.Model.T_ProdictAblity> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProdictAblityID,JobSheetID,FinishedTime,Totalfee ");
			strSql.Append(" FROM T_ProdictAblity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_ProdictAblity> list = new List<MesWeb.Model.T_ProdictAblity>();
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
		public MesWeb.Model.T_ProdictAblity ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_ProdictAblity model=new MesWeb.Model.T_ProdictAblity();
			object ojb; 
			ojb = dataReader["ProdictAblityID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProdictAblityID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["FinishedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FinishedTime=(DateTime)ojb;
			}
			ojb = dataReader["Totalfee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Totalfee=(decimal)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

