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
	/// 数据访问类:T_QRCode
	/// </summary>
	public partial class T_QRCode:IT_QRCode
	{
		public T_QRCode()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(QRCodeID)+1 from T_QRCode";
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
		public bool Exists(int QRCodeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_QRCode_Exists");
			db.AddInParameter(dbCommand, "QRCodeID", DbType.Int32,QRCodeID);
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
		public int Add(MesWeb.Model.T_QRCode model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_QRCode_ADD");
			db.AddOutParameter(dbCommand, "QRCodeID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "QRCode", DbType.String, model.QRCode);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "QRCodeID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_QRCode model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_QRCode_Update");
			db.AddInParameter(dbCommand, "QRCodeID", DbType.Int32, model.QRCodeID);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "QRCode", DbType.String, model.QRCode);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int QRCodeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_QRCode_Delete");
			db.AddInParameter(dbCommand, "QRCodeID", DbType.Int32,QRCodeID);

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
		public bool DeleteList(string QRCodeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_QRCode ");
			strSql.Append(" where QRCodeID in ("+QRCodeIDlist + ")  ");
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
		public MesWeb.Model.T_QRCode GetModel(int QRCodeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_QRCode_GetModel");
			db.AddInParameter(dbCommand, "QRCodeID", DbType.Int32,QRCodeID);

			MesWeb.Model.T_QRCode model=null;
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
		public MesWeb.Model.T_QRCode DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_QRCode model=new MesWeb.Model.T_QRCode();
			if (row != null)
			{
				if(row["QRCodeID"]!=null && row["QRCodeID"].ToString()!="")
				{
					model.QRCodeID=int.Parse(row["QRCodeID"].ToString());
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["QRCode"]!=null)
				{
					model.QRCode=row["QRCode"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select QRCodeID,Axis_No,QRCode,DateTime,EmployeeID ");
			strSql.Append(" FROM T_QRCode ");
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
			strSql.Append(" QRCodeID,Axis_No,QRCode,DateTime,EmployeeID ");
			strSql.Append(" FROM T_QRCode ");
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
			strSql.Append("select count(1) FROM T_QRCode ");
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
				strSql.Append("order by T.QRCodeID desc");
			}
			strSql.Append(")AS Row, T.*  from T_QRCode T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_QRCode");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "QRCodeID");
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
		public List<MesWeb.Model.T_QRCode> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QRCodeID,Axis_No,QRCode,DateTime,EmployeeID ");
			strSql.Append(" FROM T_QRCode ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_QRCode> list = new List<MesWeb.Model.T_QRCode>();
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
		public MesWeb.Model.T_QRCode ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_QRCode model=new MesWeb.Model.T_QRCode();
			object ojb; 
			ojb = dataReader["QRCodeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QRCodeID=(int)ojb;
			}
			model.Axis_No=dataReader["Axis_No"].ToString();
			model.QRCode=dataReader["QRCode"].ToString();
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
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

