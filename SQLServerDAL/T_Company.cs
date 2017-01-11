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
	/// 数据访问类:T_Company
	/// </summary>
	public partial class T_Company:IT_Company
	{
		public T_Company()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CompanyID)+1 from T_Company";
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
		public bool Exists(int CompanyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Company_Exists");
			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32,CompanyID);
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
		public int Add(MesWeb.Model.T_Company model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Company_ADD");
			db.AddOutParameter(dbCommand, "CompanyID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "CompanyName", DbType.String, model.CompanyName);
			db.AddInParameter(dbCommand, "CompanyInfo", DbType.String, model.CompanyInfo);
			db.AddInParameter(dbCommand, "CompanyAddress", DbType.String, model.CompanyAddress);
			db.AddInParameter(dbCommand, "CompanyContactPerson", DbType.String, model.CompanyContactPerson);
			db.AddInParameter(dbCommand, "CompanyContactTel", DbType.String, model.CompanyContactTel);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "CompanyID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Company model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Company_Update");
			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, model.CompanyID);
			db.AddInParameter(dbCommand, "CompanyName", DbType.String, model.CompanyName);
			db.AddInParameter(dbCommand, "CompanyInfo", DbType.String, model.CompanyInfo);
			db.AddInParameter(dbCommand, "CompanyAddress", DbType.String, model.CompanyAddress);
			db.AddInParameter(dbCommand, "CompanyContactPerson", DbType.String, model.CompanyContactPerson);
			db.AddInParameter(dbCommand, "CompanyContactTel", DbType.String, model.CompanyContactTel);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CompanyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Company_Delete");
			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32,CompanyID);

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
		public bool DeleteList(string CompanyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Company ");
			strSql.Append(" where CompanyID in ("+CompanyIDlist + ")  ");
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
		public MesWeb.Model.T_Company GetModel(int CompanyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Company_GetModel");
			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32,CompanyID);

			MesWeb.Model.T_Company model=null;
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
		public MesWeb.Model.T_Company DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Company model=new MesWeb.Model.T_Company();
			if (row != null)
			{
				if(row["CompanyID"]!=null && row["CompanyID"].ToString()!="")
				{
					model.CompanyID=int.Parse(row["CompanyID"].ToString());
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["CompanyInfo"]!=null)
				{
					model.CompanyInfo=row["CompanyInfo"].ToString();
				}
				if(row["CompanyAddress"]!=null)
				{
					model.CompanyAddress=row["CompanyAddress"].ToString();
				}
				if(row["CompanyContactPerson"]!=null)
				{
					model.CompanyContactPerson=row["CompanyContactPerson"].ToString();
				}
				if(row["CompanyContactTel"]!=null)
				{
					model.CompanyContactTel=row["CompanyContactTel"].ToString();
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
			strSql.Append("select CompanyID,CompanyName,CompanyInfo,CompanyAddress,CompanyContactPerson,CompanyContactTel ");
			strSql.Append(" FROM T_Company ");
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
			strSql.Append(" CompanyID,CompanyName,CompanyInfo,CompanyAddress,CompanyContactPerson,CompanyContactTel ");
			strSql.Append(" FROM T_Company ");
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
			strSql.Append("select count(1) FROM T_Company ");
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
				strSql.Append("order by T.CompanyID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Company T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Company");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CompanyID");
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
		public List<MesWeb.Model.T_Company> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CompanyID,CompanyName,CompanyInfo,CompanyAddress,CompanyContactPerson,CompanyContactTel ");
			strSql.Append(" FROM T_Company ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Company> list = new List<MesWeb.Model.T_Company>();
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
		public MesWeb.Model.T_Company ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Company model=new MesWeb.Model.T_Company();
			object ojb; 
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
			model.CompanyName=dataReader["CompanyName"].ToString();
			model.CompanyInfo=dataReader["CompanyInfo"].ToString();
			model.CompanyAddress=dataReader["CompanyAddress"].ToString();
			model.CompanyContactPerson=dataReader["CompanyContactPerson"].ToString();
			model.CompanyContactTel=dataReader["CompanyContactTel"].ToString();
			return model;
		}

		#endregion  Method
	}
}

