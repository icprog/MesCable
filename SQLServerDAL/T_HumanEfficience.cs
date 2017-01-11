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
	/// 数据访问类:T_HumanEfficience
	/// </summary>
	public partial class T_HumanEfficience:IT_HumanEfficience
	{
		public T_HumanEfficience()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(HumanEfficienceID)+1 from T_HumanEfficience";
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
		public bool Exists(int HumanEfficienceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_HumanEfficience_Exists");
			db.AddInParameter(dbCommand, "HumanEfficienceID", DbType.Int32,HumanEfficienceID);
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
		public int Add(MesWeb.Model.T_HumanEfficience model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_HumanEfficience_ADD");
			db.AddOutParameter(dbCommand, "HumanEfficienceID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "EmplouyeeID", DbType.Int32, model.EmplouyeeID);
			db.AddInParameter(dbCommand, "EfficienceValue", DbType.Int32, model.EfficienceValue);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "HumanEfficienceID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_HumanEfficience model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_HumanEfficience_Update");
			db.AddInParameter(dbCommand, "HumanEfficienceID", DbType.Int32, model.HumanEfficienceID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "EmplouyeeID", DbType.Int32, model.EmplouyeeID);
			db.AddInParameter(dbCommand, "EfficienceValue", DbType.Int32, model.EfficienceValue);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int HumanEfficienceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_HumanEfficience_Delete");
			db.AddInParameter(dbCommand, "HumanEfficienceID", DbType.Int32,HumanEfficienceID);

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
		public bool DeleteList(string HumanEfficienceIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_HumanEfficience ");
			strSql.Append(" where HumanEfficienceID in ("+HumanEfficienceIDlist + ")  ");
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
		public MesWeb.Model.T_HumanEfficience GetModel(int HumanEfficienceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_HumanEfficience_GetModel");
			db.AddInParameter(dbCommand, "HumanEfficienceID", DbType.Int32,HumanEfficienceID);

			MesWeb.Model.T_HumanEfficience model=null;
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
		public MesWeb.Model.T_HumanEfficience DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_HumanEfficience model=new MesWeb.Model.T_HumanEfficience();
			if (row != null)
			{
				if(row["HumanEfficienceID"]!=null && row["HumanEfficienceID"].ToString()!="")
				{
					model.HumanEfficienceID=int.Parse(row["HumanEfficienceID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["EmplouyeeID"]!=null && row["EmplouyeeID"].ToString()!="")
				{
					model.EmplouyeeID=int.Parse(row["EmplouyeeID"].ToString());
				}
				if(row["EfficienceValue"]!=null && row["EfficienceValue"].ToString()!="")
				{
					model.EfficienceValue=int.Parse(row["EfficienceValue"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select HumanEfficienceID,JobSheetID,MachineID,EmplouyeeID,EfficienceValue,DateTime ");
			strSql.Append(" FROM T_HumanEfficience ");
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
			strSql.Append(" HumanEfficienceID,JobSheetID,MachineID,EmplouyeeID,EfficienceValue,DateTime ");
			strSql.Append(" FROM T_HumanEfficience ");
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
			strSql.Append("select count(1) FROM T_HumanEfficience ");
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
				strSql.Append("order by T.HumanEfficienceID desc");
			}
			strSql.Append(")AS Row, T.*  from T_HumanEfficience T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_HumanEfficience");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "HumanEfficienceID");
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
		public List<MesWeb.Model.T_HumanEfficience> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HumanEfficienceID,JobSheetID,MachineID,EmplouyeeID,EfficienceValue,DateTime ");
			strSql.Append(" FROM T_HumanEfficience ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_HumanEfficience> list = new List<MesWeb.Model.T_HumanEfficience>();
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
		public MesWeb.Model.T_HumanEfficience ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_HumanEfficience model=new MesWeb.Model.T_HumanEfficience();
			object ojb; 
			ojb = dataReader["HumanEfficienceID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.HumanEfficienceID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["EmplouyeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmplouyeeID=(int)ojb;
			}
			ojb = dataReader["EfficienceValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EfficienceValue=(int)ojb;
			}
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

