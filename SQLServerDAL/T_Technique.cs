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
	/// 数据访问类:T_Technique
	/// </summary>
	public partial class T_Technique:IT_Technique
	{
		public T_Technique()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(TechniqueID)+1 from T_Technique";
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
		public bool Exists(int TechniqueID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Technique_Exists");
			db.AddInParameter(dbCommand, "TechniqueID", DbType.Int32,TechniqueID);
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
		public int Add(MesWeb.Model.T_Technique model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Technique_ADD");
			db.AddOutParameter(dbCommand, "TechniqueID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "CollectedParameterID", DbType.Int32, model.CollectedParameterID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "ParameterValueMin", DbType.Double, model.ParameterValueMin);
			db.AddInParameter(dbCommand, "ParameterValueMax", DbType.Double, model.ParameterValueMax);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "TechniqueID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Technique model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Technique_Update");
			db.AddInParameter(dbCommand, "TechniqueID", DbType.Int32, model.TechniqueID);
			db.AddInParameter(dbCommand, "CollectedParameterID", DbType.Int32, model.CollectedParameterID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "ParameterValueMin", DbType.Double, model.ParameterValueMin);
			db.AddInParameter(dbCommand, "ParameterValueMax", DbType.Double, model.ParameterValueMax);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TechniqueID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Technique_Delete");
			db.AddInParameter(dbCommand, "TechniqueID", DbType.Int32,TechniqueID);

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
		public bool DeleteList(string TechniqueIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Technique ");
			strSql.Append(" where TechniqueID in ("+TechniqueIDlist + ")  ");
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
		public MesWeb.Model.T_Technique GetModel(int TechniqueID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Technique_GetModel");
			db.AddInParameter(dbCommand, "TechniqueID", DbType.Int32,TechniqueID);

			MesWeb.Model.T_Technique model=null;
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
		public MesWeb.Model.T_Technique DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Technique model=new MesWeb.Model.T_Technique();
			if (row != null)
			{
				if(row["TechniqueID"]!=null && row["TechniqueID"].ToString()!="")
				{
					model.TechniqueID=int.Parse(row["TechniqueID"].ToString());
				}
				if(row["CollectedParameterID"]!=null && row["CollectedParameterID"].ToString()!="")
				{
					model.CollectedParameterID=int.Parse(row["CollectedParameterID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["ParameterValueMin"]!=null && row["ParameterValueMin"].ToString()!="")
				{
					model.ParameterValueMin=decimal.Parse(row["ParameterValueMin"].ToString());
				}
				if(row["ParameterValueMax"]!=null && row["ParameterValueMax"].ToString()!="")
				{
					model.ParameterValueMax=decimal.Parse(row["ParameterValueMax"].ToString());
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
			strSql.Append("select TechniqueID,CollectedParameterID,MachineID,SpecificationID,ParameterValueMin,ParameterValueMax ");
			strSql.Append(" FROM T_Technique ");
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
			strSql.Append(" TechniqueID,CollectedParameterID,MachineID,SpecificationID,ParameterValueMin,ParameterValueMax ");
			strSql.Append(" FROM T_Technique ");
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
			strSql.Append("select count(1) FROM T_Technique ");
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
				strSql.Append("order by T.TechniqueID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Technique T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Technique");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "TechniqueID");
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
		public List<MesWeb.Model.T_Technique> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TechniqueID,CollectedParameterID,MachineID,SpecificationID,ParameterValueMin,ParameterValueMax ");
			strSql.Append(" FROM T_Technique ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Technique> list = new List<MesWeb.Model.T_Technique>();
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
		public MesWeb.Model.T_Technique ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Technique model=new MesWeb.Model.T_Technique();
			object ojb; 
			ojb = dataReader["TechniqueID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TechniqueID=(int)ojb;
			}
			ojb = dataReader["CollectedParameterID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CollectedParameterID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			ojb = dataReader["ParameterValueMin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParameterValueMin=(decimal)ojb;
			}
			ojb = dataReader["ParameterValueMax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParameterValueMax=(decimal)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

