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
	/// 数据访问类:T_MergeJobSheet
	/// </summary>
	public partial class T_MergeJobSheet:IT_MergeJobSheet
	{
		public T_MergeJobSheet()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MergeJobSheetID)+1 from T_MergeJobSheet";
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
		public bool Exists(int MergeJobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheet_Exists");
			db.AddInParameter(dbCommand, "MergeJobSheetID", DbType.Int32,MergeJobSheetID);
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
		public bool Add(MesWeb.Model.T_MergeJobSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheet_ADD");
			db.AddInParameter(dbCommand, "MergeJobSheetID", DbType.Int32, model.MergeJobSheetID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "NeedMergeJobSheetID", DbType.Int32, model.NeedMergeJobSheetID);
			db.AddInParameter(dbCommand, "IsFinished", DbType.Boolean, model.IsFinished);
			db.ExecuteNonQuery(dbCommand);
            return true;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MergeJobSheet model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheet_Update");
			db.AddInParameter(dbCommand, "MergeJobSheetID", DbType.Int32, model.MergeJobSheetID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "NeedMergeJobSheetID", DbType.Int32, model.NeedMergeJobSheetID);
			db.AddInParameter(dbCommand, "IsFinished", DbType.Boolean, model.IsFinished);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MergeJobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheet_Delete");
			db.AddInParameter(dbCommand, "MergeJobSheetID", DbType.Int32,MergeJobSheetID);

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
		public bool DeleteList(string MergeJobSheetIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MergeJobSheet ");
			strSql.Append(" where MergeJobSheetID in ("+MergeJobSheetIDlist + ")  ");
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
		public MesWeb.Model.T_MergeJobSheet GetModel(int MergeJobSheetID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeJobSheet_GetModel");
			db.AddInParameter(dbCommand, "MergeJobSheetID", DbType.Int32,MergeJobSheetID);

			MesWeb.Model.T_MergeJobSheet model=null;
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
		public MesWeb.Model.T_MergeJobSheet DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MergeJobSheet model=new MesWeb.Model.T_MergeJobSheet();
			if (row != null)
			{
				if(row["MergeJobSheetID"]!=null && row["MergeJobSheetID"].ToString()!="")
				{
					model.MergeJobSheetID=int.Parse(row["MergeJobSheetID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["NeedMergeJobSheetID"]!=null && row["NeedMergeJobSheetID"].ToString()!="")
				{
					model.NeedMergeJobSheetID=int.Parse(row["NeedMergeJobSheetID"].ToString());
				}
				if(row["IsFinished"]!=null && row["IsFinished"].ToString()!="")
				{
					if((row["IsFinished"].ToString()=="1")||(row["IsFinished"].ToString().ToLower()=="true"))
					{
						model.IsFinished=true;
					}
					else
					{
						model.IsFinished=false;
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
			strSql.Append("select MergeJobSheetID,JobSheetID,NeedMergeJobSheetID,IsFinished ");
			strSql.Append(" FROM T_MergeJobSheet ");
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
			strSql.Append(" MergeJobSheetID,JobSheetID,NeedMergeJobSheetID,IsFinished ");
			strSql.Append(" FROM T_MergeJobSheet ");
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
			strSql.Append("select count(1) FROM T_MergeJobSheet ");
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
				strSql.Append("order by T.MergeJobSheetID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MergeJobSheet T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MergeJobSheet");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MergeJobSheetID");
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
		public List<MesWeb.Model.T_MergeJobSheet> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MergeJobSheetID,JobSheetID,NeedMergeJobSheetID,IsFinished ");
			strSql.Append(" FROM T_MergeJobSheet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MergeJobSheet> list = new List<MesWeb.Model.T_MergeJobSheet>();
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
		public MesWeb.Model.T_MergeJobSheet ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MergeJobSheet model=new MesWeb.Model.T_MergeJobSheet();
			object ojb; 
			ojb = dataReader["MergeJobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MergeJobSheetID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["NeedMergeJobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NeedMergeJobSheetID=(int)ojb;
			}
			ojb = dataReader["IsFinished"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsFinished=(bool)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

