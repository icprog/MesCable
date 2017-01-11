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
	/// 数据访问类:T_LeaveApplication
	/// </summary>
	public partial class T_LeaveApplication:IT_LeaveApplication
	{
		public T_LeaveApplication()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(LeaveApplicationID)+1 from T_LeaveApplication";
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
		public bool Exists(int LeaveApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LeaveApplication_Exists");
			db.AddInParameter(dbCommand, "LeaveApplicationID", DbType.Int32,LeaveApplicationID);
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
		public int Add(MesWeb.Model.T_LeaveApplication model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LeaveApplication_ADD");
			db.AddOutParameter(dbCommand, "LeaveApplicationID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32, model.FlowID);
			db.AddInParameter(dbCommand, "LeaveApplicationTypeID", DbType.Int32, model.LeaveApplicationTypeID);
			db.AddInParameter(dbCommand, "LeaveApplicationDate", DbType.DateTime, model.LeaveApplicationDate);
			db.AddInParameter(dbCommand, "LeaveApplicationDays", DbType.Double, model.LeaveApplicationDays);
			db.AddInParameter(dbCommand, "State", DbType.String, model.State);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "LeaveApplicationID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_LeaveApplication model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LeaveApplication_Update");
			db.AddInParameter(dbCommand, "LeaveApplicationID", DbType.Int32, model.LeaveApplicationID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32, model.FlowID);
			db.AddInParameter(dbCommand, "LeaveApplicationTypeID", DbType.Int32, model.LeaveApplicationTypeID);
			db.AddInParameter(dbCommand, "LeaveApplicationDate", DbType.DateTime, model.LeaveApplicationDate);
			db.AddInParameter(dbCommand, "LeaveApplicationDays", DbType.Double, model.LeaveApplicationDays);
			db.AddInParameter(dbCommand, "State", DbType.String, model.State);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LeaveApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LeaveApplication_Delete");
			db.AddInParameter(dbCommand, "LeaveApplicationID", DbType.Int32,LeaveApplicationID);

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
		public bool DeleteList(string LeaveApplicationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LeaveApplication ");
			strSql.Append(" where LeaveApplicationID in ("+LeaveApplicationIDlist + ")  ");
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
		public MesWeb.Model.T_LeaveApplication GetModel(int LeaveApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_LeaveApplication_GetModel");
			db.AddInParameter(dbCommand, "LeaveApplicationID", DbType.Int32,LeaveApplicationID);

			MesWeb.Model.T_LeaveApplication model=null;
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
		public MesWeb.Model.T_LeaveApplication DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_LeaveApplication model=new MesWeb.Model.T_LeaveApplication();
			if (row != null)
			{
				if(row["LeaveApplicationID"]!=null && row["LeaveApplicationID"].ToString()!="")
				{
					model.LeaveApplicationID=int.Parse(row["LeaveApplicationID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["FlowID"]!=null && row["FlowID"].ToString()!="")
				{
					model.FlowID=int.Parse(row["FlowID"].ToString());
				}
				if(row["LeaveApplicationTypeID"]!=null && row["LeaveApplicationTypeID"].ToString()!="")
				{
					model.LeaveApplicationTypeID=int.Parse(row["LeaveApplicationTypeID"].ToString());
				}
				if(row["LeaveApplicationDate"]!=null && row["LeaveApplicationDate"].ToString()!="")
				{
					model.LeaveApplicationDate=DateTime.Parse(row["LeaveApplicationDate"].ToString());
				}
				if(row["LeaveApplicationDays"]!=null && row["LeaveApplicationDays"].ToString()!="")
				{
					model.LeaveApplicationDays=decimal.Parse(row["LeaveApplicationDays"].ToString());
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
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
			strSql.Append("select LeaveApplicationID,EmployeeID,FlowID,LeaveApplicationTypeID,LeaveApplicationDate,LeaveApplicationDays,State ");
			strSql.Append(" FROM T_LeaveApplication ");
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
			strSql.Append(" LeaveApplicationID,EmployeeID,FlowID,LeaveApplicationTypeID,LeaveApplicationDate,LeaveApplicationDays,State ");
			strSql.Append(" FROM T_LeaveApplication ");
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
			strSql.Append("select count(1) FROM T_LeaveApplication ");
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
				strSql.Append("order by T.LeaveApplicationID desc");
			}
			strSql.Append(")AS Row, T.*  from T_LeaveApplication T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_LeaveApplication");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LeaveApplicationID");
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
		public List<MesWeb.Model.T_LeaveApplication> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LeaveApplicationID,EmployeeID,FlowID,LeaveApplicationTypeID,LeaveApplicationDate,LeaveApplicationDays,State ");
			strSql.Append(" FROM T_LeaveApplication ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_LeaveApplication> list = new List<MesWeb.Model.T_LeaveApplication>();
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
		public MesWeb.Model.T_LeaveApplication ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_LeaveApplication model=new MesWeb.Model.T_LeaveApplication();
			object ojb; 
			ojb = dataReader["LeaveApplicationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LeaveApplicationID=(int)ojb;
			}
			ojb = dataReader["EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeID=(int)ojb;
			}
			ojb = dataReader["FlowID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FlowID=(int)ojb;
			}
			ojb = dataReader["LeaveApplicationTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LeaveApplicationTypeID=(int)ojb;
			}
			ojb = dataReader["LeaveApplicationDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LeaveApplicationDate=(DateTime)ojb;
			}
			ojb = dataReader["LeaveApplicationDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LeaveApplicationDays=(decimal)ojb;
			}
			model.State=dataReader["State"].ToString();
			return model;
		}

		#endregion  Method
	}
}

