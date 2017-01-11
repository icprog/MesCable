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
	/// 数据访问类:T_Dumpling
	/// </summary>
	public partial class T_Dumpling:IT_Dumpling
	{
		public T_Dumpling()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(DumplingID)+1 from T_Dumpling";
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
		public bool Exists(int DumplingID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Dumpling_Exists");
			db.AddInParameter(dbCommand, "DumplingID", DbType.Int32,DumplingID);
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
		public void Add(MesWeb.Model.T_Dumpling model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Dumpling_ADD");
			db.AddInParameter(dbCommand, "DumplingID", DbType.Int32, model.DumplingID);
			db.AddInParameter(dbCommand, "DumplingTypeID", DbType.Int32, model.DumplingTypeID);
			db.AddInParameter(dbCommand, "CheckPerson", DbType.Int32, model.CheckPerson);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "DumplingCode", DbType.String, model.DumplingCode);
			db.AddInParameter(dbCommand, "DumplingZoneID", DbType.Int32, model.DumplingZoneID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Dumpling model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Dumpling_Update");
			db.AddInParameter(dbCommand, "DumplingID", DbType.Int32, model.DumplingID);
			db.AddInParameter(dbCommand, "DumplingTypeID", DbType.Int32, model.DumplingTypeID);
			db.AddInParameter(dbCommand, "CheckPerson", DbType.Int32, model.CheckPerson);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "DumplingCode", DbType.String, model.DumplingCode);
			db.AddInParameter(dbCommand, "DumplingZoneID", DbType.Int32, model.DumplingZoneID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DumplingID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Dumpling_Delete");
			db.AddInParameter(dbCommand, "DumplingID", DbType.Int32,DumplingID);

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
		public bool DeleteList(string DumplingIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Dumpling ");
			strSql.Append(" where DumplingID in ("+DumplingIDlist + ")  ");
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
		public MesWeb.Model.T_Dumpling GetModel(int DumplingID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Dumpling_GetModel");
			db.AddInParameter(dbCommand, "DumplingID", DbType.Int32,DumplingID);

			MesWeb.Model.T_Dumpling model=null;
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
		public MesWeb.Model.T_Dumpling DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Dumpling model=new MesWeb.Model.T_Dumpling();
			if (row != null)
			{
				if(row["DumplingID"]!=null && row["DumplingID"].ToString()!="")
				{
					model.DumplingID=int.Parse(row["DumplingID"].ToString());
				}
				if(row["DumplingTypeID"]!=null && row["DumplingTypeID"].ToString()!="")
				{
					model.DumplingTypeID=int.Parse(row["DumplingTypeID"].ToString());
				}
				if(row["CheckPerson"]!=null && row["CheckPerson"].ToString()!="")
				{
					model.CheckPerson=int.Parse(row["CheckPerson"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["DumplingCode"]!=null)
				{
					model.DumplingCode=row["DumplingCode"].ToString();
				}
				if(row["DumplingZoneID"]!=null && row["DumplingZoneID"].ToString()!="")
				{
					model.DumplingZoneID=int.Parse(row["DumplingZoneID"].ToString());
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
			strSql.Append("select DumplingID,DumplingTypeID,CheckPerson,DateTime,DumplingCode,DumplingZoneID ");
			strSql.Append(" FROM T_Dumpling ");
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
			strSql.Append(" DumplingID,DumplingTypeID,CheckPerson,DateTime,DumplingCode,DumplingZoneID ");
			strSql.Append(" FROM T_Dumpling ");
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
			strSql.Append("select count(1) FROM T_Dumpling ");
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
				strSql.Append("order by T.DumplingID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Dumpling T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Dumpling");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "DumplingID");
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
		public List<MesWeb.Model.T_Dumpling> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DumplingID,DumplingTypeID,CheckPerson,DateTime,DumplingCode,DumplingZoneID ");
			strSql.Append(" FROM T_Dumpling ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Dumpling> list = new List<MesWeb.Model.T_Dumpling>();
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
		public MesWeb.Model.T_Dumpling ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Dumpling model=new MesWeb.Model.T_Dumpling();
			object ojb; 
			ojb = dataReader["DumplingID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DumplingID=(int)ojb;
			}
			ojb = dataReader["DumplingTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DumplingTypeID=(int)ojb;
			}
			ojb = dataReader["CheckPerson"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckPerson=(int)ojb;
			}
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			model.DumplingCode=dataReader["DumplingCode"].ToString();
			ojb = dataReader["DumplingZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DumplingZoneID=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

