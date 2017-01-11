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
	/// 数据访问类:T_Application
	/// </summary>
	public partial class T_Application:IT_Application
	{
		public T_Application()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ApplicationID)+1 from T_Application";
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
		public bool Exists(int ApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Application_Exists");
			db.AddInParameter(dbCommand, "ApplicationID", DbType.Int32,ApplicationID);
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
		public int Add(MesWeb.Model.T_Application model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Application_ADD");
			db.AddOutParameter(dbCommand, "ApplicationID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "Aplication_EmployeeID", DbType.Int32, model.Aplication_EmployeeID);
			db.AddInParameter(dbCommand, "ProblemDetail", DbType.String, model.ProblemDetail);
			db.AddInParameter(dbCommand, "ApplicationDateTime", DbType.DateTime, model.ApplicationDateTime);
			db.AddInParameter(dbCommand, "ApplicationState", DbType.String, model.ApplicationState);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "ApplicationID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Application model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Application_Update");
			db.AddInParameter(dbCommand, "ApplicationID", DbType.Int32, model.ApplicationID);
			db.AddInParameter(dbCommand, "Aplication_EmployeeID", DbType.Int32, model.Aplication_EmployeeID);
			db.AddInParameter(dbCommand, "ProblemDetail", DbType.String, model.ProblemDetail);
			db.AddInParameter(dbCommand, "ApplicationDateTime", DbType.DateTime, model.ApplicationDateTime);
			db.AddInParameter(dbCommand, "ApplicationState", DbType.String, model.ApplicationState);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Application_Delete");
			db.AddInParameter(dbCommand, "ApplicationID", DbType.Int32,ApplicationID);

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
		public bool DeleteList(string ApplicationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Application ");
			strSql.Append(" where ApplicationID in ("+ApplicationIDlist + ")  ");
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
		public MesWeb.Model.T_Application GetModel(int ApplicationID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Application_GetModel");
			db.AddInParameter(dbCommand, "ApplicationID", DbType.Int32,ApplicationID);

			MesWeb.Model.T_Application model=null;
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
		public MesWeb.Model.T_Application DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Application model=new MesWeb.Model.T_Application();
			if (row != null)
			{
				if(row["ApplicationID"]!=null && row["ApplicationID"].ToString()!="")
				{
					model.ApplicationID=int.Parse(row["ApplicationID"].ToString());
				}
				if(row["Aplication_EmployeeID"]!=null && row["Aplication_EmployeeID"].ToString()!="")
				{
					model.Aplication_EmployeeID=int.Parse(row["Aplication_EmployeeID"].ToString());
				}
				if(row["ProblemDetail"]!=null)
				{
					model.ProblemDetail=row["ProblemDetail"].ToString();
				}
				if(row["ApplicationDateTime"]!=null && row["ApplicationDateTime"].ToString()!="")
				{
					model.ApplicationDateTime=DateTime.Parse(row["ApplicationDateTime"].ToString());
				}
				if(row["ApplicationState"]!=null)
				{
					model.ApplicationState=row["ApplicationState"].ToString();
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
			strSql.Append("select ApplicationID,Aplication_EmployeeID,ProblemDetail,ApplicationDateTime,ApplicationState ");
			strSql.Append(" FROM T_Application ");
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
			strSql.Append(" ApplicationID,Aplication_EmployeeID,ProblemDetail,ApplicationDateTime,ApplicationState ");
			strSql.Append(" FROM T_Application ");
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
			strSql.Append("select count(1) FROM T_Application ");
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
				strSql.Append("order by T.ApplicationID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Application T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Application");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ApplicationID");
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
		public List<MesWeb.Model.T_Application> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ApplicationID,Aplication_EmployeeID,ProblemDetail,ApplicationDateTime,ApplicationState ");
			strSql.Append(" FROM T_Application ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Application> list = new List<MesWeb.Model.T_Application>();
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
		public MesWeb.Model.T_Application ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Application model=new MesWeb.Model.T_Application();
			object ojb; 
			ojb = dataReader["ApplicationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ApplicationID=(int)ojb;
			}
			ojb = dataReader["Aplication_EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Aplication_EmployeeID=(int)ojb;
			}
			model.ProblemDetail=dataReader["ProblemDetail"].ToString();
			ojb = dataReader["ApplicationDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ApplicationDateTime=(DateTime)ojb;
			}
			model.ApplicationState=dataReader["ApplicationState"].ToString();
			return model;
		}

		#endregion  Method
	}
}

