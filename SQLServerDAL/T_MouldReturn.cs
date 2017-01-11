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
	/// 数据访问类:T_MouldReturn
	/// </summary>
	public partial class T_MouldReturn:IT_MouldReturn
	{
		public T_MouldReturn()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MouldReturnID)+1 from T_MouldReturn";
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
		public bool Exists(int MouldReturnID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldReturn_Exists");
			db.AddInParameter(dbCommand, "MouldReturnID", DbType.Int32,MouldReturnID);
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
		public int Add(MesWeb.Model.T_MouldReturn model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldReturn_ADD");
			db.AddOutParameter(dbCommand, "MouldReturnID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldReturnNumber", DbType.Int32, model.MouldReturnNumber);
			db.AddInParameter(dbCommand, "MouldReturnPersonID", DbType.Int32, model.MouldReturnPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MouldReturnID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MouldReturn model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldReturn_Update");
			db.AddInParameter(dbCommand, "MouldReturnID", DbType.Int32, model.MouldReturnID);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldReturnNumber", DbType.Int32, model.MouldReturnNumber);
			db.AddInParameter(dbCommand, "MouldReturnPersonID", DbType.Int32, model.MouldReturnPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MouldReturnID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldReturn_Delete");
			db.AddInParameter(dbCommand, "MouldReturnID", DbType.Int32,MouldReturnID);

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
		public bool DeleteList(string MouldReturnIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MouldReturn ");
			strSql.Append(" where MouldReturnID in ("+MouldReturnIDlist + ")  ");
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
		public MesWeb.Model.T_MouldReturn GetModel(int MouldReturnID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldReturn_GetModel");
			db.AddInParameter(dbCommand, "MouldReturnID", DbType.Int32,MouldReturnID);

			MesWeb.Model.T_MouldReturn model=null;
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
		public MesWeb.Model.T_MouldReturn DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MouldReturn model=new MesWeb.Model.T_MouldReturn();
			if (row != null)
			{
				if(row["MouldReturnID"]!=null && row["MouldReturnID"].ToString()!="")
				{
					model.MouldReturnID=int.Parse(row["MouldReturnID"].ToString());
				}
				if(row["MouldID"]!=null && row["MouldID"].ToString()!="")
				{
					model.MouldID=int.Parse(row["MouldID"].ToString());
				}
				if(row["MouldReturnNumber"]!=null && row["MouldReturnNumber"].ToString()!="")
				{
					model.MouldReturnNumber=int.Parse(row["MouldReturnNumber"].ToString());
				}
				if(row["MouldReturnPersonID"]!=null && row["MouldReturnPersonID"].ToString()!="")
				{
					model.MouldReturnPersonID=int.Parse(row["MouldReturnPersonID"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
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
			strSql.Append("select MouldReturnID,MouldID,MouldReturnNumber,MouldReturnPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldReturn ");
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
			strSql.Append(" MouldReturnID,MouldID,MouldReturnNumber,MouldReturnPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldReturn ");
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
			strSql.Append("select count(1) FROM T_MouldReturn ");
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
				strSql.Append("order by T.MouldReturnID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MouldReturn T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MouldReturn");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MouldReturnID");
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
		public List<MesWeb.Model.T_MouldReturn> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MouldReturnID,MouldID,MouldReturnNumber,MouldReturnPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldReturn ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MouldReturn> list = new List<MesWeb.Model.T_MouldReturn>();
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
		public MesWeb.Model.T_MouldReturn ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MouldReturn model=new MesWeb.Model.T_MouldReturn();
			object ojb; 
			ojb = dataReader["MouldReturnID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldReturnID=(int)ojb;
			}
			ojb = dataReader["MouldID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldID=(int)ojb;
			}
			ojb = dataReader["MouldReturnNumber"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldReturnNumber=(int)ojb;
			}
			ojb = dataReader["MouldReturnPersonID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldReturnPersonID=(int)ojb;
			}
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			model.Comment=dataReader["Comment"].ToString();
			return model;
		}

		#endregion  Method
	}
}

