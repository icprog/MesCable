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
	/// 数据访问类:T_OEE
	/// </summary>
	public partial class T_OEE:IT_OEE
	{
		public T_OEE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(OEEID)+1 from T_OEE";
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
		public bool Exists(int OEEID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OEE_Exists");
			db.AddInParameter(dbCommand, "OEEID", DbType.Int32,OEEID);
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
		public int Add(MesWeb.Model.T_OEE model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OEE_ADD");
			db.AddOutParameter(dbCommand, "OEEID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int32, model.TaskID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "MachineTypeID", DbType.Int32, model.MachineTypeID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "PR", DbType.Double, model.PR);
			db.AddInParameter(dbCommand, "ORR", DbType.Double, model.ORR);
			db.AddInParameter(dbCommand, "OEE", DbType.String, model.OEE);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "OEEID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_OEE model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OEE_Update");
			db.AddInParameter(dbCommand, "OEEID", DbType.Int32, model.OEEID);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int32, model.TaskID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "MachineTypeID", DbType.Int32, model.MachineTypeID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "PR", DbType.Double, model.PR);
			db.AddInParameter(dbCommand, "ORR", DbType.Double, model.ORR);
			db.AddInParameter(dbCommand, "OEE", DbType.String, model.OEE);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OEEID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OEE_Delete");
			db.AddInParameter(dbCommand, "OEEID", DbType.Int32,OEEID);

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
		public bool DeleteList(string OEEIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OEE ");
			strSql.Append(" where OEEID in ("+OEEIDlist + ")  ");
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
		public MesWeb.Model.T_OEE GetModel(int OEEID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OEE_GetModel");
			db.AddInParameter(dbCommand, "OEEID", DbType.Int32,OEEID);

			MesWeb.Model.T_OEE model=null;
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
		public MesWeb.Model.T_OEE DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_OEE model=new MesWeb.Model.T_OEE();
			if (row != null)
			{
				if(row["OEEID"]!=null && row["OEEID"].ToString()!="")
				{
					model.OEEID=int.Parse(row["OEEID"].ToString());
				}
				if(row["TaskID"]!=null && row["TaskID"].ToString()!="")
				{
					model.TaskID=int.Parse(row["TaskID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["MachineTypeID"]!=null && row["MachineTypeID"].ToString()!="")
				{
					model.MachineTypeID=int.Parse(row["MachineTypeID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["PR"]!=null && row["PR"].ToString()!="")
				{
					model.PR=decimal.Parse(row["PR"].ToString());
				}
				if(row["ORR"]!=null && row["ORR"].ToString()!="")
				{
					model.ORR=decimal.Parse(row["ORR"].ToString());
				}
				if(row["OEE"]!=null)
				{
					model.OEE=row["OEE"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select OEEID,TaskID,EmployeeID,MachineID,MachineTypeID,JobSheetID,PR,ORR,OEE,DateTime ");
			strSql.Append(" FROM T_OEE ");
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
			strSql.Append(" OEEID,TaskID,EmployeeID,MachineID,MachineTypeID,JobSheetID,PR,ORR,OEE,DateTime ");
			strSql.Append(" FROM T_OEE ");
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
			strSql.Append("select count(1) FROM T_OEE ");
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
				strSql.Append("order by T.OEEID desc");
			}
			strSql.Append(")AS Row, T.*  from T_OEE T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_OEE");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "OEEID");
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
		public List<MesWeb.Model.T_OEE> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OEEID,TaskID,EmployeeID,MachineID,MachineTypeID,JobSheetID,PR,ORR,OEE,DateTime ");
			strSql.Append(" FROM T_OEE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_OEE> list = new List<MesWeb.Model.T_OEE>();
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
		public MesWeb.Model.T_OEE ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_OEE model=new MesWeb.Model.T_OEE();
			object ojb; 
			ojb = dataReader["OEEID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OEEID=(int)ojb;
			}
			ojb = dataReader["TaskID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaskID=(int)ojb;
			}
			ojb = dataReader["EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["MachineTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineTypeID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["PR"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PR=(decimal)ojb;
			}
			ojb = dataReader["ORR"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ORR=(decimal)ojb;
			}
			model.OEE=dataReader["OEE"].ToString();
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

