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
	/// 数据访问类:T_Half_Product
	/// </summary>
	public partial class T_Half_Product:IT_Half_Product
	{
		public T_Half_Product()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(Half_ProductID)+1 from T_Half_Product";
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
		public bool Exists(int Half_ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_Product_Exists");
			db.AddInParameter(dbCommand, "Half_ProductID", DbType.Int32,Half_ProductID);
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
		public int Add(MesWeb.Model.T_Half_Product model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_Product_ADD");
			db.AddOutParameter(dbCommand, "Half_ProductID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32, model.Half_ProductZoneID);
			db.AddInParameter(dbCommand, "Axis_No", DbType.Int32, model.Axis_No);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Length", DbType.Double, model.Length);
			db.AddInParameter(dbCommand, "OperatorID", DbType.Int32, model.OperatorID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "Half_ProductID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Half_Product model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_Product_Update");
			db.AddInParameter(dbCommand, "Half_ProductID", DbType.Int32, model.Half_ProductID);
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32, model.Half_ProductZoneID);
			db.AddInParameter(dbCommand, "Axis_No", DbType.Int32, model.Axis_No);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Length", DbType.Double, model.Length);
			db.AddInParameter(dbCommand, "OperatorID", DbType.Int32, model.OperatorID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Half_ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_Product_Delete");
			db.AddInParameter(dbCommand, "Half_ProductID", DbType.Int32,Half_ProductID);

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
		public bool DeleteList(string Half_ProductIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Half_Product ");
			strSql.Append(" where Half_ProductID in ("+Half_ProductIDlist + ")  ");
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
		public MesWeb.Model.T_Half_Product GetModel(int Half_ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_Product_GetModel");
			db.AddInParameter(dbCommand, "Half_ProductID", DbType.Int32,Half_ProductID);

			MesWeb.Model.T_Half_Product model=null;
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
		public MesWeb.Model.T_Half_Product DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Half_Product model=new MesWeb.Model.T_Half_Product();
			if (row != null)
			{
				if(row["Half_ProductID"]!=null && row["Half_ProductID"].ToString()!="")
				{
					model.Half_ProductID=int.Parse(row["Half_ProductID"].ToString());
				}
				if(row["Half_ProductZoneID"]!=null && row["Half_ProductZoneID"].ToString()!="")
				{
					model.Half_ProductZoneID=int.Parse(row["Half_ProductZoneID"].ToString());
				}
				if(row["Axis_No"]!=null && row["Axis_No"].ToString()!="")
				{
					model.Axis_No=int.Parse(row["Axis_No"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["Length"]!=null && row["Length"].ToString()!="")
				{
					model.Length=decimal.Parse(row["Length"].ToString());
				}
				if(row["OperatorID"]!=null && row["OperatorID"].ToString()!="")
				{
					model.OperatorID=int.Parse(row["OperatorID"].ToString());
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
			strSql.Append("select Half_ProductID,Half_ProductZoneID,Axis_No,DateTime,Length,OperatorID ");
			strSql.Append(" FROM T_Half_Product ");
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
			strSql.Append(" Half_ProductID,Half_ProductZoneID,Axis_No,DateTime,Length,OperatorID ");
			strSql.Append(" FROM T_Half_Product ");
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
			strSql.Append("select count(1) FROM T_Half_Product ");
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
				strSql.Append("order by T.Half_ProductID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Half_Product T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Half_Product");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "Half_ProductID");
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
		public List<MesWeb.Model.T_Half_Product> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Half_ProductID,Half_ProductZoneID,Axis_No,DateTime,Length,OperatorID ");
			strSql.Append(" FROM T_Half_Product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Half_Product> list = new List<MesWeb.Model.T_Half_Product>();
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
		public MesWeb.Model.T_Half_Product ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Half_Product model=new MesWeb.Model.T_Half_Product();
			object ojb; 
			ojb = dataReader["Half_ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Half_ProductID=(int)ojb;
			}
			ojb = dataReader["Half_ProductZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Half_ProductZoneID=(int)ojb;
			}
			ojb = dataReader["Axis_No"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Axis_No=(int)ojb;
			}
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			ojb = dataReader["Length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Length=(decimal)ojb;
			}
			ojb = dataReader["OperatorID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OperatorID=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

