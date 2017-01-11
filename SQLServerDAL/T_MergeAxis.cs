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
	/// 数据访问类:T_MergeAxis
	/// </summary>
	public partial class T_MergeAxis:IT_MergeAxis
	{
		public T_MergeAxis()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MergeAxisID)+1 from T_MergeAxis";
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
		public bool Exists(int MergeAxisID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeAxis_Exists");
			db.AddInParameter(dbCommand, "MergeAxisID", DbType.Int32,MergeAxisID);
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
		public int Add(MesWeb.Model.T_MergeAxis model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeAxis_ADD");
			db.AddOutParameter(dbCommand, "MergeAxisID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32, model.AxisTaskID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "Task", DbType.Int32, model.Task);
			db.AddInParameter(dbCommand, "Meters", DbType.Int32, model.Meters);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MergeAxisID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MergeAxis model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeAxis_Update");
			db.AddInParameter(dbCommand, "MergeAxisID", DbType.Int32, model.MergeAxisID);
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32, model.AxisTaskID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "Task", DbType.Int32, model.Task);
			db.AddInParameter(dbCommand, "Meters", DbType.Int32, model.Meters);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MergeAxisID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeAxis_Delete");
			db.AddInParameter(dbCommand, "MergeAxisID", DbType.Int32,MergeAxisID);

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
		public bool DeleteList(string MergeAxisIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MergeAxis ");
			strSql.Append(" where MergeAxisID in ("+MergeAxisIDlist + ")  ");
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
		public MesWeb.Model.T_MergeAxis GetModel(int MergeAxisID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MergeAxis_GetModel");
			db.AddInParameter(dbCommand, "MergeAxisID", DbType.Int32,MergeAxisID);

			MesWeb.Model.T_MergeAxis model=null;
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
		public MesWeb.Model.T_MergeAxis DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MergeAxis model=new MesWeb.Model.T_MergeAxis();
			if (row != null)
			{
				if(row["MergeAxisID"]!=null && row["MergeAxisID"].ToString()!="")
				{
					model.MergeAxisID=int.Parse(row["MergeAxisID"].ToString());
				}
				if(row["AxisTaskID"]!=null && row["AxisTaskID"].ToString()!="")
				{
					model.AxisTaskID=int.Parse(row["AxisTaskID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["Task"]!=null && row["Task"].ToString()!="")
				{
					model.Task=int.Parse(row["Task"].ToString());
				}
				if(row["Meters"]!=null && row["Meters"].ToString()!="")
				{
					model.Meters=int.Parse(row["Meters"].ToString());
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
			strSql.Append("select MergeAxisID,AxisTaskID,SpecificationID,Task,Meters ");
			strSql.Append(" FROM T_MergeAxis ");
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
			strSql.Append(" MergeAxisID,AxisTaskID,SpecificationID,Task,Meters ");
			strSql.Append(" FROM T_MergeAxis ");
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
			strSql.Append("select count(1) FROM T_MergeAxis ");
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
				strSql.Append("order by T.MergeAxisID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MergeAxis T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MergeAxis");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MergeAxisID");
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
		public List<MesWeb.Model.T_MergeAxis> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MergeAxisID,AxisTaskID,SpecificationID,Task,Meters ");
			strSql.Append(" FROM T_MergeAxis ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MergeAxis> list = new List<MesWeb.Model.T_MergeAxis>();
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
		public MesWeb.Model.T_MergeAxis ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MergeAxis model=new MesWeb.Model.T_MergeAxis();
			object ojb; 
			ojb = dataReader["MergeAxisID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MergeAxisID=(int)ojb;
			}
			ojb = dataReader["AxisTaskID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AxisTaskID=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			ojb = dataReader["Task"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Task=(int)ojb;
			}
			ojb = dataReader["Meters"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Meters=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

