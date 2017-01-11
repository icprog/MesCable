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
	/// 数据访问类:T_Salary
	/// </summary>
	public partial class T_Salary:IT_Salary
	{
		public T_Salary()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SalaryID)+1 from T_Salary";
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
		public bool Exists(int SalaryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Salary_Exists");
			db.AddInParameter(dbCommand, "SalaryID", DbType.Int32,SalaryID);
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
		public int Add(MesWeb.Model.T_Salary model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Salary_ADD");
			db.AddOutParameter(dbCommand, "SalaryID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "Basic_Salary", DbType.Decimal, model.Basic_Salary);
			db.AddInParameter(dbCommand, "Man_Hour_Salary", DbType.Decimal, model.Man_Hour_Salary);
			db.AddInParameter(dbCommand, "OverTime_Salary", DbType.Decimal, model.OverTime_Salary);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "SalaryID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Salary model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Salary_Update");
			db.AddInParameter(dbCommand, "SalaryID", DbType.Int32, model.SalaryID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "Basic_Salary", DbType.Decimal, model.Basic_Salary);
			db.AddInParameter(dbCommand, "Man_Hour_Salary", DbType.Decimal, model.Man_Hour_Salary);
			db.AddInParameter(dbCommand, "OverTime_Salary", DbType.Decimal, model.OverTime_Salary);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SalaryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Salary_Delete");
			db.AddInParameter(dbCommand, "SalaryID", DbType.Int32,SalaryID);

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
		public bool DeleteList(string SalaryIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Salary ");
			strSql.Append(" where SalaryID in ("+SalaryIDlist + ")  ");
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
		public MesWeb.Model.T_Salary GetModel(int SalaryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Salary_GetModel");
			db.AddInParameter(dbCommand, "SalaryID", DbType.Int32,SalaryID);

			MesWeb.Model.T_Salary model=null;
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
		public MesWeb.Model.T_Salary DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Salary model=new MesWeb.Model.T_Salary();
			if (row != null)
			{
				if(row["SalaryID"]!=null && row["SalaryID"].ToString()!="")
				{
					model.SalaryID=int.Parse(row["SalaryID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["Basic_Salary"]!=null && row["Basic_Salary"].ToString()!="")
				{
					model.Basic_Salary=decimal.Parse(row["Basic_Salary"].ToString());
				}
				if(row["Man_Hour_Salary"]!=null && row["Man_Hour_Salary"].ToString()!="")
				{
					model.Man_Hour_Salary=decimal.Parse(row["Man_Hour_Salary"].ToString());
				}
				if(row["OverTime_Salary"]!=null && row["OverTime_Salary"].ToString()!="")
				{
					model.OverTime_Salary=decimal.Parse(row["OverTime_Salary"].ToString());
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
			strSql.Append("select SalaryID,EmployeeID,Basic_Salary,Man_Hour_Salary,OverTime_Salary ");
			strSql.Append(" FROM T_Salary ");
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
			strSql.Append(" SalaryID,EmployeeID,Basic_Salary,Man_Hour_Salary,OverTime_Salary ");
			strSql.Append(" FROM T_Salary ");
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
			strSql.Append("select count(1) FROM T_Salary ");
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
				strSql.Append("order by T.SalaryID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Salary T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Salary");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "SalaryID");
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
		public List<MesWeb.Model.T_Salary> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SalaryID,EmployeeID,Basic_Salary,Man_Hour_Salary,OverTime_Salary ");
			strSql.Append(" FROM T_Salary ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Salary> list = new List<MesWeb.Model.T_Salary>();
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
		public MesWeb.Model.T_Salary ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Salary model=new MesWeb.Model.T_Salary();
			object ojb; 
			ojb = dataReader["SalaryID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SalaryID=(int)ojb;
			}
			ojb = dataReader["EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeID=(int)ojb;
			}
			ojb = dataReader["Basic_Salary"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Basic_Salary=(decimal)ojb;
			}
			ojb = dataReader["Man_Hour_Salary"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Man_Hour_Salary=(decimal)ojb;
			}
			ojb = dataReader["OverTime_Salary"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OverTime_Salary=(decimal)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

