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
	/// 数据访问类:T_CheckSheet
	/// </summary>
	public partial class T_CheckSheet:IT_CheckSheet
	{
		public T_CheckSheet()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CheckSheetID)+1 from T_CheckSheet";
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
		public bool Exists(int CheckSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckSheet_Exists");
			db.AddInParameter(dbCommand, "CheckSheetID", DbType.Int32,CheckSheetID);
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
		public int Add(MesWeb.Model.T_CheckSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckSheet_ADD");
			db.AddOutParameter(dbCommand, "CheckSheetID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32, model.CheckParsRefID);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "CheckPar", DbType.String, model.CheckPar);
			db.AddInParameter(dbCommand, "CheckValue", DbType.String, model.CheckValue);
			db.AddInParameter(dbCommand, "CheckRST", DbType.String, model.CheckRST);
			db.AddInParameter(dbCommand, "CheckTime", DbType.DateTime, model.CheckTime);
			db.AddInParameter(dbCommand, "CheckPerson", DbType.String, model.CheckPerson);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "CheckSheetID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_CheckSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckSheet_Update");
			db.AddInParameter(dbCommand, "CheckSheetID", DbType.Int32, model.CheckSheetID);
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32, model.CheckParsRefID);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "CheckPar", DbType.String, model.CheckPar);
			db.AddInParameter(dbCommand, "CheckValue", DbType.String, model.CheckValue);
			db.AddInParameter(dbCommand, "CheckRST", DbType.String, model.CheckRST);
			db.AddInParameter(dbCommand, "CheckTime", DbType.DateTime, model.CheckTime);
			db.AddInParameter(dbCommand, "CheckPerson", DbType.String, model.CheckPerson);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CheckSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckSheet_Delete");
			db.AddInParameter(dbCommand, "CheckSheetID", DbType.Int32,CheckSheetID);

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
		public bool DeleteList(string CheckSheetIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CheckSheet ");
			strSql.Append(" where CheckSheetID in ("+CheckSheetIDlist + ")  ");
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
		public MesWeb.Model.T_CheckSheet GetModel(int CheckSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckSheet_GetModel");
			db.AddInParameter(dbCommand, "CheckSheetID", DbType.Int32,CheckSheetID);

			MesWeb.Model.T_CheckSheet model=null;
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
		public MesWeb.Model.T_CheckSheet DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CheckSheet model=new MesWeb.Model.T_CheckSheet();
			if (row != null)
			{
				if(row["CheckSheetID"]!=null && row["CheckSheetID"].ToString()!="")
				{
					model.CheckSheetID=int.Parse(row["CheckSheetID"].ToString());
				}
				if(row["CheckParsRefID"]!=null && row["CheckParsRefID"].ToString()!="")
				{
					model.CheckParsRefID=int.Parse(row["CheckParsRefID"].ToString());
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["CheckPar"]!=null)
				{
					model.CheckPar=row["CheckPar"].ToString();
				}
				if(row["CheckValue"]!=null)
				{
					model.CheckValue=row["CheckValue"].ToString();
				}
				if(row["CheckRST"]!=null)
				{
					model.CheckRST=row["CheckRST"].ToString();
				}
				if(row["CheckTime"]!=null && row["CheckTime"].ToString()!="")
				{
					model.CheckTime=DateTime.Parse(row["CheckTime"].ToString());
				}
				if(row["CheckPerson"]!=null)
				{
					model.CheckPerson=row["CheckPerson"].ToString();
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
			strSql.Append("select CheckSheetID,CheckParsRefID,Axis_No,CheckPar,CheckValue,CheckRST,CheckTime,CheckPerson ");
			strSql.Append(" FROM T_CheckSheet ");
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
			strSql.Append(" CheckSheetID,CheckParsRefID,Axis_No,CheckPar,CheckValue,CheckRST,CheckTime,CheckPerson ");
			strSql.Append(" FROM T_CheckSheet ");
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
			strSql.Append("select count(1) FROM T_CheckSheet ");
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
				strSql.Append("order by T.CheckSheetID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CheckSheet T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_CheckSheet");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CheckSheetID");
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
		public List<MesWeb.Model.T_CheckSheet> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CheckSheetID,CheckParsRefID,Axis_No,CheckPar,CheckValue,CheckRST,CheckTime,CheckPerson ");
			strSql.Append(" FROM T_CheckSheet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_CheckSheet> list = new List<MesWeb.Model.T_CheckSheet>();
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
		public MesWeb.Model.T_CheckSheet ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_CheckSheet model=new MesWeb.Model.T_CheckSheet();
			object ojb; 
			ojb = dataReader["CheckSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckSheetID=(int)ojb;
			}
			ojb = dataReader["CheckParsRefID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckParsRefID=(int)ojb;
			}
			model.Axis_No=dataReader["Axis_No"].ToString();
			model.CheckPar=dataReader["CheckPar"].ToString();
			model.CheckValue=dataReader["CheckValue"].ToString();
			model.CheckRST=dataReader["CheckRST"].ToString();
			ojb = dataReader["CheckTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckTime=(DateTime)ojb;
			}
			model.CheckPerson=dataReader["CheckPerson"].ToString();
			return model;
		}

		#endregion  Method
	}
}

