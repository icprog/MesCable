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
	/// 数据访问类:T_MergeJobSheetStatistic
	/// </summary>
	public partial class T_MergeJobSheetStatistic:IT_MergeJobSheetStatistic
	{
		public T_MergeJobSheetStatistic()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MergeJobSheetStatisticID)+1 from T_MergeJobSheetStatistic";
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
		public bool Exists(int MergeJobSheetStatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheetStatistic_Exists");
			db.AddInParameter(dbCommand, "MergeJobSheetStatisticID", DbType.Int32,MergeJobSheetStatisticID);
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
		public int Add(MesWeb.Model.T_MergeJobSheetStatistic model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheetStatistic_ADD");
			db.AddOutParameter(dbCommand, "MergeJobSheetStatisticID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "NeedMergeJobSheetID", DbType.Int32, model.NeedMergeJobSheetID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "OperatorDateTime", DbType.DateTime, model.OperatorDateTime);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MergeJobSheetStatisticID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MergeJobSheetStatistic model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheetStatistic_Update");
			db.AddInParameter(dbCommand, "MergeJobSheetStatisticID", DbType.Int32, model.MergeJobSheetStatisticID);
			db.AddInParameter(dbCommand, "NeedMergeJobSheetID", DbType.Int32, model.NeedMergeJobSheetID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "OperatorDateTime", DbType.DateTime, model.OperatorDateTime);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MergeJobSheetStatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheetStatistic_Delete");
			db.AddInParameter(dbCommand, "MergeJobSheetStatisticID", DbType.Int32,MergeJobSheetStatisticID);

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
		public bool DeleteList(string MergeJobSheetStatisticIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MergeJobSheetStatistic ");
			strSql.Append(" where MergeJobSheetStatisticID in ("+MergeJobSheetStatisticIDlist + ")  ");
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
		public MesWeb.Model.T_MergeJobSheetStatistic GetModel(int MergeJobSheetStatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheetStatistic_GetModel");
			db.AddInParameter(dbCommand, "MergeJobSheetStatisticID", DbType.Int32,MergeJobSheetStatisticID);

			MesWeb.Model.T_MergeJobSheetStatistic model=null;
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
		public MesWeb.Model.T_MergeJobSheetStatistic DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MergeJobSheetStatistic model=new MesWeb.Model.T_MergeJobSheetStatistic();
			if (row != null)
			{
				if(row["MergeJobSheetStatisticID"]!=null && row["MergeJobSheetStatisticID"].ToString()!="")
				{
					model.MergeJobSheetStatisticID=int.Parse(row["MergeJobSheetStatisticID"].ToString());
				}
				if(row["NeedMergeJobSheetID"]!=null && row["NeedMergeJobSheetID"].ToString()!="")
				{
					model.NeedMergeJobSheetID=int.Parse(row["NeedMergeJobSheetID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["OperatorDateTime"]!=null && row["OperatorDateTime"].ToString()!="")
				{
					model.OperatorDateTime=DateTime.Parse(row["OperatorDateTime"].ToString());
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
			strSql.Append("select MergeJobSheetStatisticID,NeedMergeJobSheetID,JobSheetID,OperatorDateTime,EmployeeID ");
			strSql.Append(" FROM T_MergeJobSheetStatistic ");
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
			strSql.Append(" MergeJobSheetStatisticID,NeedMergeJobSheetID,JobSheetID,OperatorDateTime,EmployeeID ");
			strSql.Append(" FROM T_MergeJobSheetStatistic ");
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
			strSql.Append("select count(1) FROM T_MergeJobSheetStatistic ");
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
				strSql.Append("order by T.MergeJobSheetStatisticID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MergeJobSheetStatistic T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MergeJobSheetStatistic");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MergeJobSheetStatisticID");
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
		public List<MesWeb.Model.T_MergeJobSheetStatistic> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MergeJobSheetStatisticID,NeedMergeJobSheetID,JobSheetID,OperatorDateTime,EmployeeID ");
			strSql.Append(" FROM T_MergeJobSheetStatistic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MergeJobSheetStatistic> list = new List<MesWeb.Model.T_MergeJobSheetStatistic>();
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
		public MesWeb.Model.T_MergeJobSheetStatistic ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MergeJobSheetStatistic model=new MesWeb.Model.T_MergeJobSheetStatistic();
			object ojb; 
			ojb = dataReader["MergeJobSheetStatisticID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MergeJobSheetStatisticID=(int)ojb;
			}
			ojb = dataReader["NeedMergeJobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NeedMergeJobSheetID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["OperatorDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OperatorDateTime=(DateTime)ojb;
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

