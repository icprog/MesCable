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
	/// 数据访问类:T_MouldUsed
	/// </summary>
	public partial class T_MouldUsed:IT_MouldUsed
	{
		public T_MouldUsed()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MouldUsedID)+1 from T_MouldUsed";
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
		public bool Exists(int MouldUsedID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldUsed_Exists");
			db.AddInParameter(dbCommand, "MouldUsedID", DbType.Int32,MouldUsedID);
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
		public bool Add(MesWeb.Model.T_MouldUsed model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldUsed_ADD");
			db.AddInParameter(dbCommand, "MouldUsedID", DbType.Int32, model.MouldUsedID);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldUsedNumber", DbType.Int32, model.MouldUsedNumber);
			db.AddInParameter(dbCommand, "MouldUsedPersonID", DbType.Int32, model.MouldUsedPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
            return true;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MouldUsed model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldUsed_Update");
			db.AddInParameter(dbCommand, "MouldUsedID", DbType.Int32, model.MouldUsedID);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldUsedNumber", DbType.Int32, model.MouldUsedNumber);
			db.AddInParameter(dbCommand, "MouldUsedPersonID", DbType.Int32, model.MouldUsedPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MouldUsedID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldUsed_Delete");
			db.AddInParameter(dbCommand, "MouldUsedID", DbType.Int32,MouldUsedID);

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
		public bool DeleteList(string MouldUsedIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MouldUsed ");
			strSql.Append(" where MouldUsedID in ("+MouldUsedIDlist + ")  ");
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
		public MesWeb.Model.T_MouldUsed GetModel(int MouldUsedID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldUsed_GetModel");
			db.AddInParameter(dbCommand, "MouldUsedID", DbType.Int32,MouldUsedID);

			MesWeb.Model.T_MouldUsed model=null;
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
		public MesWeb.Model.T_MouldUsed DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MouldUsed model=new MesWeb.Model.T_MouldUsed();
			if (row != null)
			{
				if(row["MouldUsedID"]!=null && row["MouldUsedID"].ToString()!="")
				{
					model.MouldUsedID=int.Parse(row["MouldUsedID"].ToString());
				}
				if(row["MouldID"]!=null && row["MouldID"].ToString()!="")
				{
					model.MouldID=int.Parse(row["MouldID"].ToString());
				}
				if(row["MouldUsedNumber"]!=null && row["MouldUsedNumber"].ToString()!="")
				{
					model.MouldUsedNumber=int.Parse(row["MouldUsedNumber"].ToString());
				}
				if(row["MouldUsedPersonID"]!=null && row["MouldUsedPersonID"].ToString()!="")
				{
					model.MouldUsedPersonID=int.Parse(row["MouldUsedPersonID"].ToString());
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
			strSql.Append("select MouldUsedID,MouldID,MouldUsedNumber,MouldUsedPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldUsed ");
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
			strSql.Append(" MouldUsedID,MouldID,MouldUsedNumber,MouldUsedPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldUsed ");
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
			strSql.Append("select count(1) FROM T_MouldUsed ");
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
				strSql.Append("order by T.MouldUsedID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MouldUsed T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MouldUsed");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MouldUsedID");
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
		public List<MesWeb.Model.T_MouldUsed> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MouldUsedID,MouldID,MouldUsedNumber,MouldUsedPersonID,DateTime,Comment ");
			strSql.Append(" FROM T_MouldUsed ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MouldUsed> list = new List<MesWeb.Model.T_MouldUsed>();
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
		public MesWeb.Model.T_MouldUsed ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MouldUsed model=new MesWeb.Model.T_MouldUsed();
			object ojb; 
			ojb = dataReader["MouldUsedID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldUsedID=(int)ojb;
			}
			ojb = dataReader["MouldID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldID=(int)ojb;
			}
			ojb = dataReader["MouldUsedNumber"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldUsedNumber=(int)ojb;
			}
			ojb = dataReader["MouldUsedPersonID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldUsedPersonID=(int)ojb;
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

