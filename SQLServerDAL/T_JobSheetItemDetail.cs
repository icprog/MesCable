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
	/// 数据访问类:T_JobSheetItemDetail
	/// </summary>
	public partial class T_JobSheetItemDetail:IT_JobSheetItemDetail
	{
		public T_JobSheetItemDetail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(JobSheetItemDetailID)+1 from T_JobSheetItemDetail";
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
		public bool Exists(int JobSheetItemDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheetItemDetail_Exists");
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32,JobSheetItemDetailID);
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
		public int Add(MesWeb.Model.T_JobSheetItemDetail model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheetItemDetail_ADD");
			db.AddOutParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "JobSheetItemID", DbType.Int32, model.JobSheetItemID);
			db.AddInParameter(dbCommand, "JobSheetDetailItem", DbType.String, model.JobSheetDetailItem);
			db.AddInParameter(dbCommand, "JobSheetDetailItemValue", DbType.String, model.JobSheetDetailItemValue);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "JobSheetItemDetailID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_JobSheetItemDetail model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheetItemDetail_Update");
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32, model.JobSheetItemDetailID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "JobSheetItemID", DbType.Int32, model.JobSheetItemID);
			db.AddInParameter(dbCommand, "JobSheetDetailItem", DbType.String, model.JobSheetDetailItem);
			db.AddInParameter(dbCommand, "JobSheetDetailItemValue", DbType.String, model.JobSheetDetailItemValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int JobSheetItemDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheetItemDetail_Delete");
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32,JobSheetItemDetailID);

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
		public bool DeleteList(string JobSheetItemDetailIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_JobSheetItemDetail ");
			strSql.Append(" where JobSheetItemDetailID in ("+JobSheetItemDetailIDlist + ")  ");
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
		public MesWeb.Model.T_JobSheetItemDetail GetModel(int JobSheetItemDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_JobSheetItemDetail_GetModel");
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32,JobSheetItemDetailID);

			MesWeb.Model.T_JobSheetItemDetail model=null;
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
		public MesWeb.Model.T_JobSheetItemDetail DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_JobSheetItemDetail model=new MesWeb.Model.T_JobSheetItemDetail();
			if (row != null)
			{
				if(row["JobSheetItemDetailID"]!=null && row["JobSheetItemDetailID"].ToString()!="")
				{
					model.JobSheetItemDetailID=int.Parse(row["JobSheetItemDetailID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["JobSheetItemID"]!=null && row["JobSheetItemID"].ToString()!="")
				{
					model.JobSheetItemID=int.Parse(row["JobSheetItemID"].ToString());
				}
				if(row["JobSheetDetailItem"]!=null)
				{
					model.JobSheetDetailItem=row["JobSheetDetailItem"].ToString();
				}
				if(row["JobSheetDetailItemValue"]!=null)
				{
					model.JobSheetDetailItemValue=row["JobSheetDetailItemValue"].ToString();
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
			strSql.Append("select JobSheetItemDetailID,SpecificationID,JobSheetItemID,JobSheetDetailItem,JobSheetDetailItemValue ");
			strSql.Append(" FROM T_JobSheetItemDetail ");
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
			strSql.Append(" JobSheetItemDetailID,SpecificationID,JobSheetItemID,JobSheetDetailItem,JobSheetDetailItemValue ");
			strSql.Append(" FROM T_JobSheetItemDetail ");
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
			strSql.Append("select count(1) FROM T_JobSheetItemDetail ");
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
				strSql.Append("order by T.JobSheetItemDetailID desc");
			}
			strSql.Append(")AS Row, T.*  from T_JobSheetItemDetail T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_JobSheetItemDetail");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "JobSheetItemDetailID");
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
		public List<MesWeb.Model.T_JobSheetItemDetail> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JobSheetItemDetailID,SpecificationID,JobSheetItemID,JobSheetDetailItem,JobSheetDetailItemValue ");
			strSql.Append(" FROM T_JobSheetItemDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_JobSheetItemDetail> list = new List<MesWeb.Model.T_JobSheetItemDetail>();
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
		public MesWeb.Model.T_JobSheetItemDetail ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_JobSheetItemDetail model=new MesWeb.Model.T_JobSheetItemDetail();
			object ojb; 
			ojb = dataReader["JobSheetItemDetailID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetItemDetailID=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			ojb = dataReader["JobSheetItemID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetItemID=(int)ojb;
			}
			model.JobSheetDetailItem=dataReader["JobSheetDetailItem"].ToString();
			model.JobSheetDetailItemValue=dataReader["JobSheetDetailItemValue"].ToString();
			return model;
		}

		#endregion  Method
	}
}

