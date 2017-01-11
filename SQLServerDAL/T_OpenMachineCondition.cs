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
	/// 数据访问类:T_OpenMachineCondition
	/// </summary>
	public partial class T_OpenMachineCondition:IT_OpenMachineCondition
	{
		public T_OpenMachineCondition()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(OpenMachineConditionID)+1 from T_OpenMachineCondition";
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
		public bool Exists(int OpenMachineConditionID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OpenMachineCondition_Exists");
			db.AddInParameter(dbCommand, "OpenMachineConditionID", DbType.Int32,OpenMachineConditionID);
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
		public int Add(MesWeb.Model.T_OpenMachineCondition model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OpenMachineCondition_ADD");
			db.AddOutParameter(dbCommand, "OpenMachineConditionID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "IsMaterialIOK", DbType.Boolean, model.IsMaterialIOK);
			db.AddInParameter(dbCommand, "IsMoudOK", DbType.Boolean, model.IsMoudOK);
			db.AddInParameter(dbCommand, "IsMachineFree", DbType.Boolean, model.IsMachineFree);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "OpenMachineConditionID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_OpenMachineCondition model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OpenMachineCondition_Update");
			db.AddInParameter(dbCommand, "OpenMachineConditionID", DbType.Int32, model.OpenMachineConditionID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "IsMaterialIOK", DbType.Boolean, model.IsMaterialIOK);
			db.AddInParameter(dbCommand, "IsMoudOK", DbType.Boolean, model.IsMoudOK);
			db.AddInParameter(dbCommand, "IsMachineFree", DbType.Boolean, model.IsMachineFree);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OpenMachineConditionID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OpenMachineCondition_Delete");
			db.AddInParameter(dbCommand, "OpenMachineConditionID", DbType.Int32,OpenMachineConditionID);

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
		public bool DeleteList(string OpenMachineConditionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_OpenMachineCondition ");
			strSql.Append(" where OpenMachineConditionID in ("+OpenMachineConditionIDlist + ")  ");
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
		public MesWeb.Model.T_OpenMachineCondition GetModel(int OpenMachineConditionID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_OpenMachineCondition_GetModel");
			db.AddInParameter(dbCommand, "OpenMachineConditionID", DbType.Int32,OpenMachineConditionID);

			MesWeb.Model.T_OpenMachineCondition model=null;
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
		public MesWeb.Model.T_OpenMachineCondition DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_OpenMachineCondition model=new MesWeb.Model.T_OpenMachineCondition();
			if (row != null)
			{
				if(row["OpenMachineConditionID"]!=null && row["OpenMachineConditionID"].ToString()!="")
				{
					model.OpenMachineConditionID=int.Parse(row["OpenMachineConditionID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["IsMaterialIOK"]!=null && row["IsMaterialIOK"].ToString()!="")
				{
					if((row["IsMaterialIOK"].ToString()=="1")||(row["IsMaterialIOK"].ToString().ToLower()=="true"))
					{
						model.IsMaterialIOK=true;
					}
					else
					{
						model.IsMaterialIOK=false;
					}
				}
				if(row["IsMoudOK"]!=null && row["IsMoudOK"].ToString()!="")
				{
					if((row["IsMoudOK"].ToString()=="1")||(row["IsMoudOK"].ToString().ToLower()=="true"))
					{
						model.IsMoudOK=true;
					}
					else
					{
						model.IsMoudOK=false;
					}
				}
				if(row["IsMachineFree"]!=null && row["IsMachineFree"].ToString()!="")
				{
					if((row["IsMachineFree"].ToString()=="1")||(row["IsMachineFree"].ToString().ToLower()=="true"))
					{
						model.IsMachineFree=true;
					}
					else
					{
						model.IsMachineFree=false;
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
			strSql.Append("select OpenMachineConditionID,MachineID,IsMaterialIOK,IsMoudOK,IsMachineFree ");
			strSql.Append(" FROM T_OpenMachineCondition ");
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
			strSql.Append(" OpenMachineConditionID,MachineID,IsMaterialIOK,IsMoudOK,IsMachineFree ");
			strSql.Append(" FROM T_OpenMachineCondition ");
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
			strSql.Append("select count(1) FROM T_OpenMachineCondition ");
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
				strSql.Append("order by T.OpenMachineConditionID desc");
			}
			strSql.Append(")AS Row, T.*  from T_OpenMachineCondition T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_OpenMachineCondition");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "OpenMachineConditionID");
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
		public List<MesWeb.Model.T_OpenMachineCondition> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OpenMachineConditionID,MachineID,IsMaterialIOK,IsMoudOK,IsMachineFree ");
			strSql.Append(" FROM T_OpenMachineCondition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_OpenMachineCondition> list = new List<MesWeb.Model.T_OpenMachineCondition>();
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
		public MesWeb.Model.T_OpenMachineCondition ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_OpenMachineCondition model=new MesWeb.Model.T_OpenMachineCondition();
			object ojb; 
			ojb = dataReader["OpenMachineConditionID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpenMachineConditionID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["IsMaterialIOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMaterialIOK=(bool)ojb;
			}
			ojb = dataReader["IsMoudOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMoudOK=(bool)ojb;
			}
			ojb = dataReader["IsMachineFree"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMachineFree=(bool)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

