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
	/// 数据访问类:T_Mould
	/// </summary>
	public partial class T_Mould:IT_Mould
	{
		public T_Mould()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MouldID)+1 from T_Mould";
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
		public bool Exists(int MouldID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Mould_Exists");
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32,MouldID);
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
		public int Add(MesWeb.Model.T_Mould model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Mould_ADD");
			db.AddOutParameter(dbCommand, "MouldID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32, model.MouldZoneID);
			db.AddInParameter(dbCommand, "MouldTypeID", DbType.Int32, model.MouldTypeID);
			db.AddInParameter(dbCommand, "MouldName", DbType.String, model.MouldName);
			db.AddInParameter(dbCommand, "MouldNumber", DbType.Int32, model.MouldNumber);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MouldID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Mould model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Mould_Update");
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32, model.MouldZoneID);
			db.AddInParameter(dbCommand, "MouldTypeID", DbType.Int32, model.MouldTypeID);
			db.AddInParameter(dbCommand, "MouldName", DbType.String, model.MouldName);
			db.AddInParameter(dbCommand, "MouldNumber", DbType.Int32, model.MouldNumber);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MouldID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Mould_Delete");
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32,MouldID);

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
		public bool DeleteList(string MouldIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Mould ");
			strSql.Append(" where MouldID in ("+MouldIDlist + ")  ");
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
		public MesWeb.Model.T_Mould GetModel(int MouldID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Mould_GetModel");
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32,MouldID);

			MesWeb.Model.T_Mould model=null;
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
		public MesWeb.Model.T_Mould DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Mould model=new MesWeb.Model.T_Mould();
			if (row != null)
			{
				if(row["MouldID"]!=null && row["MouldID"].ToString()!="")
				{
					model.MouldID=int.Parse(row["MouldID"].ToString());
				}
				if(row["MouldZoneID"]!=null && row["MouldZoneID"].ToString()!="")
				{
					model.MouldZoneID=int.Parse(row["MouldZoneID"].ToString());
				}
				if(row["MouldTypeID"]!=null && row["MouldTypeID"].ToString()!="")
				{
					model.MouldTypeID=int.Parse(row["MouldTypeID"].ToString());
				}
				if(row["MouldName"]!=null)
				{
					model.MouldName=row["MouldName"].ToString();
				}
				if(row["MouldNumber"]!=null && row["MouldNumber"].ToString()!="")
				{
					model.MouldNumber=int.Parse(row["MouldNumber"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
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
			strSql.Append("select MouldID,MouldZoneID,MouldTypeID,MouldName,MouldNumber,EmployeeID ");
			strSql.Append(" FROM T_Mould ");
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
			strSql.Append(" MouldID,MouldZoneID,MouldTypeID,MouldName,MouldNumber,EmployeeID ");
			strSql.Append(" FROM T_Mould ");
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
			strSql.Append("select count(1) FROM T_Mould ");
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
				strSql.Append("order by T.MouldID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Mould T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Mould");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MouldID");
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
		public List<MesWeb.Model.T_Mould> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MouldID,MouldZoneID,MouldTypeID,MouldName,MouldNumber,EmployeeID ");
			strSql.Append(" FROM T_Mould ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Mould> list = new List<MesWeb.Model.T_Mould>();
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
		public MesWeb.Model.T_Mould ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Mould model=new MesWeb.Model.T_Mould();
			object ojb; 
			ojb = dataReader["MouldID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldID=(int)ojb;
			}
			ojb = dataReader["MouldZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldZoneID=(int)ojb;
			}
			ojb = dataReader["MouldTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldTypeID=(int)ojb;
			}
			model.MouldName=dataReader["MouldName"].ToString();
			ojb = dataReader["MouldNumber"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldNumber=(int)ojb;
			}
			ojb = dataReader["EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeID=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

