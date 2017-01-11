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
	/// 数据访问类:T_ElectricityPrice
	/// </summary>
	public partial class T_ElectricityPrice:IT_ElectricityPrice
	{
		public T_ElectricityPrice()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ElectricityPriceID)+1 from T_ElectricityPrice";
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
		public bool Exists(int ElectricityPriceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ElectricityPrice_Exists");
			db.AddInParameter(dbCommand, "ElectricityPriceID", DbType.Int32,ElectricityPriceID);
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
		public int Add(MesWeb.Model.T_ElectricityPrice model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ElectricityPrice_ADD");
			db.AddOutParameter(dbCommand, "ElectricityPriceID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "ElectricityPrice", DbType.String, model.ElectricityPrice);
			db.AddInParameter(dbCommand, "ElectricityStartTime", DbType.DateTime, model.ElectricityStartTime);
			db.AddInParameter(dbCommand, "ElectricityEndTime", DbType.DateTime, model.ElectricityEndTime);
			db.AddInParameter(dbCommand, "GenerateStartTime", DbType.DateTime, model.GenerateStartTime);
			db.AddInParameter(dbCommand, "GenerateEndTime", DbType.DateTime, model.GenerateEndTime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "ElectricityPriceID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_ElectricityPrice model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ElectricityPrice_Update");
			db.AddInParameter(dbCommand, "ElectricityPriceID", DbType.Int32, model.ElectricityPriceID);
			db.AddInParameter(dbCommand, "ElectricityPrice", DbType.String, model.ElectricityPrice);
			db.AddInParameter(dbCommand, "ElectricityStartTime", DbType.DateTime, model.ElectricityStartTime);
			db.AddInParameter(dbCommand, "ElectricityEndTime", DbType.DateTime, model.ElectricityEndTime);
			db.AddInParameter(dbCommand, "GenerateStartTime", DbType.DateTime, model.GenerateStartTime);
			db.AddInParameter(dbCommand, "GenerateEndTime", DbType.DateTime, model.GenerateEndTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ElectricityPriceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ElectricityPrice_Delete");
			db.AddInParameter(dbCommand, "ElectricityPriceID", DbType.Int32,ElectricityPriceID);

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
		public bool DeleteList(string ElectricityPriceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ElectricityPrice ");
			strSql.Append(" where ElectricityPriceID in ("+ElectricityPriceIDlist + ")  ");
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
		public MesWeb.Model.T_ElectricityPrice GetModel(int ElectricityPriceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ElectricityPrice_GetModel");
			db.AddInParameter(dbCommand, "ElectricityPriceID", DbType.Int32,ElectricityPriceID);

			MesWeb.Model.T_ElectricityPrice model=null;
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
		public MesWeb.Model.T_ElectricityPrice DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ElectricityPrice model=new MesWeb.Model.T_ElectricityPrice();
			if (row != null)
			{
				if(row["ElectricityPriceID"]!=null && row["ElectricityPriceID"].ToString()!="")
				{
					model.ElectricityPriceID=int.Parse(row["ElectricityPriceID"].ToString());
				}
				if(row["ElectricityPrice"]!=null)
				{
					model.ElectricityPrice=row["ElectricityPrice"].ToString();
				}
				if(row["ElectricityStartTime"]!=null && row["ElectricityStartTime"].ToString()!="")
				{
					model.ElectricityStartTime=DateTime.Parse(row["ElectricityStartTime"].ToString());
				}
				if(row["ElectricityEndTime"]!=null && row["ElectricityEndTime"].ToString()!="")
				{
					model.ElectricityEndTime=DateTime.Parse(row["ElectricityEndTime"].ToString());
				}
				if(row["GenerateStartTime"]!=null && row["GenerateStartTime"].ToString()!="")
				{
					model.GenerateStartTime=DateTime.Parse(row["GenerateStartTime"].ToString());
				}
				if(row["GenerateEndTime"]!=null && row["GenerateEndTime"].ToString()!="")
				{
					model.GenerateEndTime=DateTime.Parse(row["GenerateEndTime"].ToString());
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
			strSql.Append("select ElectricityPriceID,ElectricityPrice,ElectricityStartTime,ElectricityEndTime,GenerateStartTime,GenerateEndTime ");
			strSql.Append(" FROM T_ElectricityPrice ");
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
			strSql.Append(" ElectricityPriceID,ElectricityPrice,ElectricityStartTime,ElectricityEndTime,GenerateStartTime,GenerateEndTime ");
			strSql.Append(" FROM T_ElectricityPrice ");
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
			strSql.Append("select count(1) FROM T_ElectricityPrice ");
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
				strSql.Append("order by T.ElectricityPriceID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ElectricityPrice T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_ElectricityPrice");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ElectricityPriceID");
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
		public List<MesWeb.Model.T_ElectricityPrice> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ElectricityPriceID,ElectricityPrice,ElectricityStartTime,ElectricityEndTime,GenerateStartTime,GenerateEndTime ");
			strSql.Append(" FROM T_ElectricityPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_ElectricityPrice> list = new List<MesWeb.Model.T_ElectricityPrice>();
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
		public MesWeb.Model.T_ElectricityPrice ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_ElectricityPrice model=new MesWeb.Model.T_ElectricityPrice();
			object ojb; 
			ojb = dataReader["ElectricityPriceID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ElectricityPriceID=(int)ojb;
			}
			model.ElectricityPrice=dataReader["ElectricityPrice"].ToString();
			ojb = dataReader["ElectricityStartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ElectricityStartTime=(DateTime)ojb;
			}
			ojb = dataReader["ElectricityEndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ElectricityEndTime=(DateTime)ojb;
			}
			ojb = dataReader["GenerateStartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GenerateStartTime=(DateTime)ojb;
			}
			ojb = dataReader["GenerateEndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GenerateEndTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

