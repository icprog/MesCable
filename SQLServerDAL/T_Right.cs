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
	/// 数据访问类:T_Right
	/// </summary>
	public partial class T_Right:IT_Right
	{
		public T_Right()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(RightID)+1 from T_Right";
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
		public bool Exists(int RightID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Right_Exists");
			db.AddInParameter(dbCommand, "RightID", DbType.Int32,RightID);
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
		public int Add(MesWeb.Model.T_Right model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Right_ADD");
			db.AddOutParameter(dbCommand, "RightID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "AuthenticID", DbType.Int32, model.AuthenticID);
			db.AddInParameter(dbCommand, "MenuID", DbType.Int32, model.MenuID);
			db.AddInParameter(dbCommand, "MenuOrder", DbType.Int32, model.MenuOrder);
			db.AddInParameter(dbCommand, "IsVisible", DbType.Boolean, model.IsVisible);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "RightID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Right model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Right_Update");
			db.AddInParameter(dbCommand, "RightID", DbType.Int32, model.RightID);
			db.AddInParameter(dbCommand, "AuthenticID", DbType.Int32, model.AuthenticID);
			db.AddInParameter(dbCommand, "MenuID", DbType.Int32, model.MenuID);
			db.AddInParameter(dbCommand, "MenuOrder", DbType.Int32, model.MenuOrder);
			db.AddInParameter(dbCommand, "IsVisible", DbType.Boolean, model.IsVisible);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RightID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Right_Delete");
			db.AddInParameter(dbCommand, "RightID", DbType.Int32,RightID);

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
		public bool DeleteList(string RightIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Right ");
			strSql.Append(" where RightID in ("+RightIDlist + ")  ");
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
		public MesWeb.Model.T_Right GetModel(int RightID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Right_GetModel");
			db.AddInParameter(dbCommand, "RightID", DbType.Int32,RightID);

			MesWeb.Model.T_Right model=null;
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
		public MesWeb.Model.T_Right DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Right model=new MesWeb.Model.T_Right();
			if (row != null)
			{
				if(row["RightID"]!=null && row["RightID"].ToString()!="")
				{
					model.RightID=int.Parse(row["RightID"].ToString());
				}
				if(row["AuthenticID"]!=null && row["AuthenticID"].ToString()!="")
				{
					model.AuthenticID=int.Parse(row["AuthenticID"].ToString());
				}
				if(row["MenuID"]!=null && row["MenuID"].ToString()!="")
				{
					model.MenuID=int.Parse(row["MenuID"].ToString());
				}
				if(row["MenuOrder"]!=null && row["MenuOrder"].ToString()!="")
				{
					model.MenuOrder=int.Parse(row["MenuOrder"].ToString());
				}
				if(row["IsVisible"]!=null && row["IsVisible"].ToString()!="")
				{
					if((row["IsVisible"].ToString()=="1")||(row["IsVisible"].ToString().ToLower()=="true"))
					{
						model.IsVisible=true;
					}
					else
					{
						model.IsVisible=false;
					}
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
			strSql.Append("select RightID,AuthenticID,MenuID,MenuOrder,IsVisible ");
			strSql.Append(" FROM T_Right ");
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
			strSql.Append(" RightID,AuthenticID,MenuID,MenuOrder,IsVisible ");
			strSql.Append(" FROM T_Right ");
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
			strSql.Append("select count(1) FROM T_Right ");
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
				strSql.Append("order by T.RightID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Right T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Right");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "RightID");
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
		public List<MesWeb.Model.T_Right> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RightID,AuthenticID,MenuID,MenuOrder,IsVisible ");
			strSql.Append(" FROM T_Right ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Right> list = new List<MesWeb.Model.T_Right>();
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
		public MesWeb.Model.T_Right ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Right model=new MesWeb.Model.T_Right();
			object ojb; 
			ojb = dataReader["RightID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RightID=(int)ojb;
			}
			ojb = dataReader["AuthenticID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuthenticID=(int)ojb;
			}
			ojb = dataReader["MenuID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MenuID=(int)ojb;
			}
			ojb = dataReader["MenuOrder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MenuOrder=(int)ojb;
			}
			ojb = dataReader["IsVisible"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsVisible=(bool)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

