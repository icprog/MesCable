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
	/// 数据访问类:T_MachineMaintainPlan
	/// </summary>
	public partial class T_MachineMaintainPlan:IT_MachineMaintainPlan
	{
		public T_MachineMaintainPlan()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MachineMaintainPlanID)+1 from T_MachineMaintainPlan";
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
		public bool Exists(int MachineMaintainPlanID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineMaintainPlan_Exists");
			db.AddInParameter(dbCommand, "MachineMaintainPlanID", DbType.Int32,MachineMaintainPlanID);
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
		public int Add(MesWeb.Model.T_MachineMaintainPlan model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineMaintainPlan_ADD");
			db.AddOutParameter(dbCommand, "MachineMaintainPlanID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "MaintainEmployeeID", DbType.Int32, model.MaintainEmployeeID);
			db.AddInParameter(dbCommand, "MaintainContent", DbType.String, model.MaintainContent);
			db.AddInParameter(dbCommand, "MaintainPlanDateTime", DbType.DateTime, model.MaintainPlanDateTime);
			db.AddInParameter(dbCommand, "MaintainState", DbType.AnsiString, model.MaintainState);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MachineMaintainPlanID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MachineMaintainPlan model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineMaintainPlan_Update");
			db.AddInParameter(dbCommand, "MachineMaintainPlanID", DbType.Int32, model.MachineMaintainPlanID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "MaintainEmployeeID", DbType.Int32, model.MaintainEmployeeID);
			db.AddInParameter(dbCommand, "MaintainContent", DbType.String, model.MaintainContent);
			db.AddInParameter(dbCommand, "MaintainPlanDateTime", DbType.DateTime, model.MaintainPlanDateTime);
			db.AddInParameter(dbCommand, "MaintainState", DbType.AnsiString, model.MaintainState);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MachineMaintainPlanID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineMaintainPlan_Delete");
			db.AddInParameter(dbCommand, "MachineMaintainPlanID", DbType.Int32,MachineMaintainPlanID);

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
		public bool DeleteList(string MachineMaintainPlanIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MachineMaintainPlan ");
			strSql.Append(" where MachineMaintainPlanID in ("+MachineMaintainPlanIDlist + ")  ");
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
		public MesWeb.Model.T_MachineMaintainPlan GetModel(int MachineMaintainPlanID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineMaintainPlan_GetModel");
			db.AddInParameter(dbCommand, "MachineMaintainPlanID", DbType.Int32,MachineMaintainPlanID);

			MesWeb.Model.T_MachineMaintainPlan model=null;
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
		public MesWeb.Model.T_MachineMaintainPlan DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MachineMaintainPlan model=new MesWeb.Model.T_MachineMaintainPlan();
			if (row != null)
			{
				if(row["MachineMaintainPlanID"]!=null && row["MachineMaintainPlanID"].ToString()!="")
				{
					model.MachineMaintainPlanID=int.Parse(row["MachineMaintainPlanID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["MaintainEmployeeID"]!=null && row["MaintainEmployeeID"].ToString()!="")
				{
					model.MaintainEmployeeID=int.Parse(row["MaintainEmployeeID"].ToString());
				}
				if(row["MaintainContent"]!=null)
				{
					model.MaintainContent=row["MaintainContent"].ToString();
				}
				if(row["MaintainPlanDateTime"]!=null && row["MaintainPlanDateTime"].ToString()!="")
				{
					model.MaintainPlanDateTime=DateTime.Parse(row["MaintainPlanDateTime"].ToString());
				}
				if(row["MaintainState"]!=null)
				{
					model.MaintainState=row["MaintainState"].ToString();
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
			strSql.Append("select MachineMaintainPlanID,MachineID,MaintainEmployeeID,MaintainContent,MaintainPlanDateTime,MaintainState ");
			strSql.Append(" FROM T_MachineMaintainPlan ");
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
			strSql.Append(" MachineMaintainPlanID,MachineID,MaintainEmployeeID,MaintainContent,MaintainPlanDateTime,MaintainState ");
			strSql.Append(" FROM T_MachineMaintainPlan ");
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
			strSql.Append("select count(1) FROM T_MachineMaintainPlan ");
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
				strSql.Append("order by T.MachineMaintainPlanID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MachineMaintainPlan T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MachineMaintainPlan");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MachineMaintainPlanID");
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
		public List<MesWeb.Model.T_MachineMaintainPlan> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MachineMaintainPlanID,MachineID,MaintainEmployeeID,MaintainContent,MaintainPlanDateTime,MaintainState ");
			strSql.Append(" FROM T_MachineMaintainPlan ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MachineMaintainPlan> list = new List<MesWeb.Model.T_MachineMaintainPlan>();
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
		public MesWeb.Model.T_MachineMaintainPlan ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MachineMaintainPlan model=new MesWeb.Model.T_MachineMaintainPlan();
			object ojb; 
			ojb = dataReader["MachineMaintainPlanID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineMaintainPlanID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["MaintainEmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaintainEmployeeID=(int)ojb;
			}
			model.MaintainContent=dataReader["MaintainContent"].ToString();
			ojb = dataReader["MaintainPlanDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaintainPlanDateTime=(DateTime)ojb;
			}
			model.MaintainState=dataReader["MaintainState"].ToString();
			return model;
		}

		#endregion  Method
	}
}

