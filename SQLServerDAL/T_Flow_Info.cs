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
	/// 数据访问类:T_Flow_Info
	/// </summary>
	public partial class T_Flow_Info:IT_Flow_Info
	{
		public T_Flow_Info()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(FlowID)+1 from T_Flow_Info";
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
		public bool Exists(int FlowID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Flow_Info_Exists");
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32,FlowID);
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
		public int Add(MesWeb.Model.T_Flow_Info model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Flow_Info_ADD");
			db.AddOutParameter(dbCommand, "FlowID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "FlowName", DbType.String, model.FlowName);
			db.AddInParameter(dbCommand, "ProcID", DbType.Int32, model.ProcID);
			db.AddInParameter(dbCommand, "IsSystem", DbType.Boolean, model.IsSystem);
			db.AddInParameter(dbCommand, "SignName", DbType.String, model.SignName);
			db.AddInParameter(dbCommand, "IsAgreement", DbType.Boolean, model.IsAgreement);
			db.AddInParameter(dbCommand, "SignDate", DbType.DateTime, model.SignDate);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "FlowID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Flow_Info model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Flow_Info_Update");
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32, model.FlowID);
			db.AddInParameter(dbCommand, "FlowName", DbType.String, model.FlowName);
			db.AddInParameter(dbCommand, "ProcID", DbType.Int32, model.ProcID);
			db.AddInParameter(dbCommand, "IsSystem", DbType.Boolean, model.IsSystem);
			db.AddInParameter(dbCommand, "SignName", DbType.String, model.SignName);
			db.AddInParameter(dbCommand, "IsAgreement", DbType.Boolean, model.IsAgreement);
			db.AddInParameter(dbCommand, "SignDate", DbType.DateTime, model.SignDate);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FlowID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Flow_Info_Delete");
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32,FlowID);

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
		public bool DeleteList(string FlowIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Flow_Info ");
			strSql.Append(" where FlowID in ("+FlowIDlist + ")  ");
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
		public MesWeb.Model.T_Flow_Info GetModel(int FlowID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Flow_Info_GetModel");
			db.AddInParameter(dbCommand, "FlowID", DbType.Int32,FlowID);

			MesWeb.Model.T_Flow_Info model=null;
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
		public MesWeb.Model.T_Flow_Info DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Flow_Info model=new MesWeb.Model.T_Flow_Info();
			if (row != null)
			{
				if(row["FlowID"]!=null && row["FlowID"].ToString()!="")
				{
					model.FlowID=int.Parse(row["FlowID"].ToString());
				}
				if(row["FlowName"]!=null)
				{
					model.FlowName=row["FlowName"].ToString();
				}
				if(row["ProcID"]!=null && row["ProcID"].ToString()!="")
				{
					model.ProcID=int.Parse(row["ProcID"].ToString());
				}
				if(row["IsSystem"]!=null && row["IsSystem"].ToString()!="")
				{
					if((row["IsSystem"].ToString()=="1")||(row["IsSystem"].ToString().ToLower()=="true"))
					{
						model.IsSystem=true;
					}
					else
					{
						model.IsSystem=false;
					}
				}
				if(row["SignName"]!=null)
				{
					model.SignName=row["SignName"].ToString();
				}
				if(row["IsAgreement"]!=null && row["IsAgreement"].ToString()!="")
				{
					if((row["IsAgreement"].ToString()=="1")||(row["IsAgreement"].ToString().ToLower()=="true"))
					{
						model.IsAgreement=true;
					}
					else
					{
						model.IsAgreement=false;
					}
				}
				if(row["SignDate"]!=null && row["SignDate"].ToString()!="")
				{
					model.SignDate=DateTime.Parse(row["SignDate"].ToString());
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
			strSql.Append("select FlowID,FlowName,ProcID,IsSystem,SignName,IsAgreement,SignDate ");
			strSql.Append(" FROM T_Flow_Info ");
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
			strSql.Append(" FlowID,FlowName,ProcID,IsSystem,SignName,IsAgreement,SignDate ");
			strSql.Append(" FROM T_Flow_Info ");
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
			strSql.Append("select count(1) FROM T_Flow_Info ");
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
				strSql.Append("order by T.FlowID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Flow_Info T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Flow_Info");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "FlowID");
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
		public List<MesWeb.Model.T_Flow_Info> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FlowID,FlowName,ProcID,IsSystem,SignName,IsAgreement,SignDate ");
			strSql.Append(" FROM T_Flow_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Flow_Info> list = new List<MesWeb.Model.T_Flow_Info>();
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
		public MesWeb.Model.T_Flow_Info ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Flow_Info model=new MesWeb.Model.T_Flow_Info();
			object ojb; 
			ojb = dataReader["FlowID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FlowID=(int)ojb;
			}
			model.FlowName=dataReader["FlowName"].ToString();
			ojb = dataReader["ProcID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProcID=(int)ojb;
			}
			ojb = dataReader["IsSystem"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystem=(bool)ojb;
			}
			model.SignName=dataReader["SignName"].ToString();
			ojb = dataReader["IsAgreement"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAgreement=(bool)ojb;
			}
			ojb = dataReader["SignDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SignDate=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

