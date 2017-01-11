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
	/// 数据访问类:T_AxisTask
	/// </summary>
	public partial class T_AxisTask:IT_AxisTask
	{
		public T_AxisTask()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AxisTaskID)+1 from T_AxisTask";
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
		public bool Exists(int AxisTaskID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_AxisTask_Exists");
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32,AxisTaskID);
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
		public int Add(MesWeb.Model.T_AxisTask model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_AxisTask_ADD");
			db.AddOutParameter(dbCommand, "AxisTaskID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32, model.JobSheetItemDetailID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "Color", DbType.String, model.Color);
			db.AddInParameter(dbCommand, "UnitLenth", DbType.Int32, model.UnitLenth);
			db.AddInParameter(dbCommand, "Num", DbType.Int32, model.Num);
			db.AddInParameter(dbCommand, "Weight", DbType.Int32, model.Weight);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "AxisTaskID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_AxisTask model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_AxisTask_Update");
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32, model.AxisTaskID);
			db.AddInParameter(dbCommand, "JobSheetItemDetailID", DbType.Int32, model.JobSheetItemDetailID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "Color", DbType.String, model.Color);
			db.AddInParameter(dbCommand, "UnitLenth", DbType.Int32, model.UnitLenth);
			db.AddInParameter(dbCommand, "Num", DbType.Int32, model.Num);
			db.AddInParameter(dbCommand, "Weight", DbType.Int32, model.Weight);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AxisTaskID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_AxisTask_Delete");
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32,AxisTaskID);

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
		public bool DeleteList(string AxisTaskIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AxisTask ");
			strSql.Append(" where AxisTaskID in ("+AxisTaskIDlist + ")  ");
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
		public MesWeb.Model.T_AxisTask GetModel(int AxisTaskID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_AxisTask_GetModel");
			db.AddInParameter(dbCommand, "AxisTaskID", DbType.Int32,AxisTaskID);

			MesWeb.Model.T_AxisTask model=null;
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
		public MesWeb.Model.T_AxisTask DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_AxisTask model=new MesWeb.Model.T_AxisTask();
			if (row != null)
			{
				if(row["AxisTaskID"]!=null && row["AxisTaskID"].ToString()!="")
				{
					model.AxisTaskID=int.Parse(row["AxisTaskID"].ToString());
				}
				if(row["JobSheetItemDetailID"]!=null && row["JobSheetItemDetailID"].ToString()!="")
				{
					model.JobSheetItemDetailID=int.Parse(row["JobSheetItemDetailID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["UnitLenth"]!=null && row["UnitLenth"].ToString()!="")
				{
					model.UnitLenth=int.Parse(row["UnitLenth"].ToString());
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
				}
				if(row["Weight"]!=null && row["Weight"].ToString()!="")
				{
					model.Weight=int.Parse(row["Weight"].ToString());
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
			strSql.Append("select AxisTaskID,JobSheetItemDetailID,SpecificationID,Color,UnitLenth,Num,Weight ");
			strSql.Append(" FROM T_AxisTask ");
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
			strSql.Append(" AxisTaskID,JobSheetItemDetailID,SpecificationID,Color,UnitLenth,Num,Weight ");
			strSql.Append(" FROM T_AxisTask ");
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
			strSql.Append("select count(1) FROM T_AxisTask ");
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
				strSql.Append("order by T.AxisTaskID desc");
			}
			strSql.Append(")AS Row, T.*  from T_AxisTask T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_AxisTask");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AxisTaskID");
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
		public List<MesWeb.Model.T_AxisTask> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AxisTaskID,JobSheetItemDetailID,SpecificationID,Color,UnitLenth,Num,Weight ");
			strSql.Append(" FROM T_AxisTask ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_AxisTask> list = new List<MesWeb.Model.T_AxisTask>();
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
		public MesWeb.Model.T_AxisTask ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_AxisTask model=new MesWeb.Model.T_AxisTask();
			object ojb; 
			ojb = dataReader["AxisTaskID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AxisTaskID=(int)ojb;
			}
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
			model.Color=dataReader["Color"].ToString();
			ojb = dataReader["UnitLenth"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UnitLenth=(int)ojb;
			}
			ojb = dataReader["Num"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Num=(int)ojb;
			}
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(int)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

