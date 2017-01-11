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
	/// 数据访问类:T_ParametersRef
	/// </summary>
	public partial class T_ParametersRef:IT_ParametersRef
	{
		public T_ParametersRef()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ParametersRefID)+1 from T_ParametersRef";
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
		public bool Exists(int ParametersRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ParametersRef_Exists");
			db.AddInParameter(dbCommand, "ParametersRefID", DbType.Int32,ParametersRefID);
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
		public int Add(MesWeb.Model.T_ParametersRef model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ParametersRef_ADD");
			db.AddOutParameter(dbCommand, "ParametersRefID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "CollectedParameterID", DbType.Int32, model.CollectedParameterID);
			db.AddInParameter(dbCommand, "SettingValue", DbType.Double, model.SettingValue);
			db.AddInParameter(dbCommand, "MaxiumValue", DbType.Double, model.MaxiumValue);
			db.AddInParameter(dbCommand, "MiniumValue", DbType.Double, model.MiniumValue);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "ParametersRefID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_ParametersRef model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ParametersRef_Update");
			db.AddInParameter(dbCommand, "ParametersRefID", DbType.Int32, model.ParametersRefID);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "CollectedParameterID", DbType.Int32, model.CollectedParameterID);
			db.AddInParameter(dbCommand, "SettingValue", DbType.Double, model.SettingValue);
			db.AddInParameter(dbCommand, "MaxiumValue", DbType.Double, model.MaxiumValue);
			db.AddInParameter(dbCommand, "MiniumValue", DbType.Double, model.MiniumValue);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ParametersRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ParametersRef_Delete");
			db.AddInParameter(dbCommand, "ParametersRefID", DbType.Int32,ParametersRefID);

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
		public bool DeleteList(string ParametersRefIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ParametersRef ");
			strSql.Append(" where ParametersRefID in ("+ParametersRefIDlist + ")  ");
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
		public MesWeb.Model.T_ParametersRef GetModel(int ParametersRefID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ParametersRef_GetModel");
			db.AddInParameter(dbCommand, "ParametersRefID", DbType.Int32,ParametersRefID);

			MesWeb.Model.T_ParametersRef model=null;
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
		public MesWeb.Model.T_ParametersRef DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ParametersRef model=new MesWeb.Model.T_ParametersRef();
			if (row != null)
			{
				if(row["ParametersRefID"]!=null && row["ParametersRefID"].ToString()!="")
				{
					model.ParametersRefID=int.Parse(row["ParametersRefID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["CollectedParameterID"]!=null && row["CollectedParameterID"].ToString()!="")
				{
					model.CollectedParameterID=int.Parse(row["CollectedParameterID"].ToString());
				}
				if(row["SettingValue"]!=null && row["SettingValue"].ToString()!="")
				{
					model.SettingValue=decimal.Parse(row["SettingValue"].ToString());
				}
				if(row["MaxiumValue"]!=null && row["MaxiumValue"].ToString()!="")
				{
					model.MaxiumValue=decimal.Parse(row["MaxiumValue"].ToString());
				}
				if(row["MiniumValue"]!=null && row["MiniumValue"].ToString()!="")
				{
					model.MiniumValue=decimal.Parse(row["MiniumValue"].ToString());
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
			strSql.Append("select ParametersRefID,SpecificationID,MachineID,CollectedParameterID,SettingValue,MaxiumValue,MiniumValue,DateTime ");
			strSql.Append(" FROM T_ParametersRef ");
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
			strSql.Append(" ParametersRefID,SpecificationID,MachineID,CollectedParameterID,SettingValue,MaxiumValue,MiniumValue,DateTime ");
			strSql.Append(" FROM T_ParametersRef ");
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
			strSql.Append("select count(1) FROM T_ParametersRef ");
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
				strSql.Append("order by T.ParametersRefID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ParametersRef T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_ParametersRef");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ParametersRefID");
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
		public List<MesWeb.Model.T_ParametersRef> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ParametersRefID,SpecificationID,MachineID,CollectedParameterID,SettingValue,MaxiumValue,MiniumValue,DateTime ");
			strSql.Append(" FROM T_ParametersRef ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_ParametersRef> list = new List<MesWeb.Model.T_ParametersRef>();
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
		public MesWeb.Model.T_ParametersRef ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_ParametersRef model=new MesWeb.Model.T_ParametersRef();
			object ojb; 
			ojb = dataReader["ParametersRefID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParametersRefID=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["CollectedParameterID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CollectedParameterID=(int)ojb;
			}
			ojb = dataReader["SettingValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SettingValue=(decimal)ojb;
			}
			ojb = dataReader["MaxiumValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaxiumValue=(decimal)ojb;
			}
			ojb = dataReader["MiniumValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MiniumValue=(decimal)ojb;
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

