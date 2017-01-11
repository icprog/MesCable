using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using MesWeb.IDAL;

using MES.DBUtility;
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_EmployeeArrangement
	/// </summary>
	public partial class T_EmployeeArrangement:IT_EmployeeArrangement
	{
		public T_EmployeeArrangement()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EmployeeArrangementID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_EmployeeArrangement_Exists");
			db.AddInParameter(dbCommand, "EmployeeArrangementID", DbType.Int32,EmployeeArrangementID);
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
		public int Add(MesWeb.Model.T_EmployeeArrangement model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_EmployeeArrangement_ADD");
			db.AddOutParameter(dbCommand, "EmployeeArrangementID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "EmployeeArrangementID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_EmployeeArrangement model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_EmployeeArrangement_Update");
			db.AddInParameter(dbCommand, "EmployeeArrangementID", DbType.Int32, model.EmployeeArrangementID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int EmployeeArrangementID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_EmployeeArrangement_Delete");
			db.AddInParameter(dbCommand, "EmployeeArrangementID", DbType.Int32,EmployeeArrangementID);

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
		public bool DeleteList(string EmployeeArrangementIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_EmployeeArrangement ");
			strSql.Append(" where EmployeeArrangementID in ("+EmployeeArrangementIDlist + ")  ");
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
		public MesWeb.Model.T_EmployeeArrangement GetModel(int EmployeeArrangementID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_EmployeeArrangement_GetModel");
			db.AddInParameter(dbCommand, "EmployeeArrangementID", DbType.Int32,EmployeeArrangementID);

			MesWeb.Model.T_EmployeeArrangement model=null;
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
		public MesWeb.Model.T_EmployeeArrangement DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_EmployeeArrangement model=new MesWeb.Model.T_EmployeeArrangement();
			if (row != null)
			{
				if(row["EmployeeArrangementID"]!=null && row["EmployeeArrangementID"].ToString()!="")
				{
					model.EmployeeArrangementID=int.Parse(row["EmployeeArrangementID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
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
			strSql.Append("select EmployeeArrangementID,EmployeeID,MachineID ");
			strSql.Append(" FROM T_EmployeeArrangement ");
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
			strSql.Append(" EmployeeArrangementID,EmployeeID,MachineID ");
			strSql.Append(" FROM T_EmployeeArrangement ");
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
			strSql.Append("select count(1) FROM T_EmployeeArrangement ");
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
				strSql.Append("order by T.EmployeeArrangementID desc");
			}
			strSql.Append(")AS Row, T.*  from T_EmployeeArrangement T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_EmployeeArrangement");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "EmployeeArrangementID");
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
		public List<MesWeb.Model.T_EmployeeArrangement> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EmployeeArrangementID,EmployeeID,MachineID ");
			strSql.Append(" FROM T_EmployeeArrangement ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_EmployeeArrangement> list = new List<MesWeb.Model.T_EmployeeArrangement>();
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
		public MesWeb.Model.T_EmployeeArrangement ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_EmployeeArrangement model=new MesWeb.Model.T_EmployeeArrangement();
			object ojb; 
			ojb = dataReader["EmployeeArrangementID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeArrangementID=(int)ojb;
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
			return model;
		}

		#endregion  Method
	}
}

