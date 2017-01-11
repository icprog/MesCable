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
	/// 数据访问类:T_CheckParsRef
	/// </summary>
	public partial class T_CheckParsRef:IT_CheckParsRef
	{
		public T_CheckParsRef()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CheckParsRefID)+1 from T_CheckParsRef";
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
		public bool Exists(int CheckParsRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckParsRef_Exists");
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32,CheckParsRefID);
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
		public int Add(MesWeb.Model.T_CheckParsRef model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckParsRef_ADD");
			db.AddOutParameter(dbCommand, "CheckParsRefID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32, model.CheckTypeID);
			db.AddInParameter(dbCommand, "UpperValue", DbType.Double, model.UpperValue);
			db.AddInParameter(dbCommand, "Lower", DbType.Double, model.Lower);
			db.AddInParameter(dbCommand, "OtherStandard", DbType.String, model.OtherStandard);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "CheckParsRefID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_CheckParsRef model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckParsRef_Update");
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32, model.CheckParsRefID);
			db.AddInParameter(dbCommand, "CheckTypeID", DbType.Int32, model.CheckTypeID);
			db.AddInParameter(dbCommand, "UpperValue", DbType.Double, model.UpperValue);
			db.AddInParameter(dbCommand, "Lower", DbType.Double, model.Lower);
			db.AddInParameter(dbCommand, "OtherStandard", DbType.String, model.OtherStandard);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CheckParsRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckParsRef_Delete");
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32,CheckParsRefID);

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
		public bool DeleteList(string CheckParsRefIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CheckParsRef ");
			strSql.Append(" where CheckParsRefID in ("+CheckParsRefIDlist + ")  ");
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
		public MesWeb.Model.T_CheckParsRef GetModel(int CheckParsRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_CheckParsRef_GetModel");
			db.AddInParameter(dbCommand, "CheckParsRefID", DbType.Int32,CheckParsRefID);

			MesWeb.Model.T_CheckParsRef model=null;
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
		public MesWeb.Model.T_CheckParsRef DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CheckParsRef model=new MesWeb.Model.T_CheckParsRef();
			if (row != null)
			{
				if(row["CheckParsRefID"]!=null && row["CheckParsRefID"].ToString()!="")
				{
					model.CheckParsRefID=int.Parse(row["CheckParsRefID"].ToString());
				}
				if(row["CheckTypeID"]!=null && row["CheckTypeID"].ToString()!="")
				{
					model.CheckTypeID=int.Parse(row["CheckTypeID"].ToString());
				}
				if(row["UpperValue"]!=null && row["UpperValue"].ToString()!="")
				{
					model.UpperValue=decimal.Parse(row["UpperValue"].ToString());
				}
				if(row["Lower"]!=null && row["Lower"].ToString()!="")
				{
					model.Lower=decimal.Parse(row["Lower"].ToString());
				}
				if(row["OtherStandard"]!=null)
				{
					model.OtherStandard=row["OtherStandard"].ToString();
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
			strSql.Append("select CheckParsRefID,CheckTypeID,UpperValue,Lower,OtherStandard ");
			strSql.Append(" FROM T_CheckParsRef ");
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
			strSql.Append(" CheckParsRefID,CheckTypeID,UpperValue,Lower,OtherStandard ");
			strSql.Append(" FROM T_CheckParsRef ");
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
			strSql.Append("select count(1) FROM T_CheckParsRef ");
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
				strSql.Append("order by T.CheckParsRefID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CheckParsRef T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_CheckParsRef");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CheckParsRefID");
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
		public List<MesWeb.Model.T_CheckParsRef> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CheckParsRefID,CheckTypeID,UpperValue,Lower,OtherStandard ");
			strSql.Append(" FROM T_CheckParsRef ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_CheckParsRef> list = new List<MesWeb.Model.T_CheckParsRef>();
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
		public MesWeb.Model.T_CheckParsRef ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_CheckParsRef model=new MesWeb.Model.T_CheckParsRef();
			object ojb; 
			ojb = dataReader["CheckParsRefID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckParsRefID=(int)ojb;
			}
			ojb = dataReader["CheckTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckTypeID=(int)ojb;
			}
			ojb = dataReader["UpperValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpperValue=(decimal)ojb;
			}
			ojb = dataReader["Lower"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Lower=(decimal)ojb;
			}
			model.OtherStandard=dataReader["OtherStandard"].ToString();
			return model;
		}

		#endregion  Method
	}
}

