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
	/// 数据访问类:T_MachineZone
	/// </summary>
	public partial class T_MachineZone:IT_MachineZone
	{
		public T_MachineZone()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MachineZoneID)+1 from T_MachineZone";
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
		public bool Exists(int MachineZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineZone_Exists");
			db.AddInParameter(dbCommand, "MachineZoneID", DbType.Int32,MachineZoneID);
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
		public int Add(MesWeb.Model.T_MachineZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineZone_ADD");
			db.AddOutParameter(dbCommand, "MachineZoneID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MachineZone", DbType.String, model.MachineZone);
			db.AddInParameter(dbCommand, "MachineZonePicUrl", DbType.String, model.MachineZonePicUrl);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MachineZoneID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MachineZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineZone_Update");
			db.AddInParameter(dbCommand, "MachineZoneID", DbType.Int32, model.MachineZoneID);
			db.AddInParameter(dbCommand, "MachineZone", DbType.String, model.MachineZone);
			db.AddInParameter(dbCommand, "MachineZonePicUrl", DbType.String, model.MachineZonePicUrl);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MachineZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineZone_Delete");
			db.AddInParameter(dbCommand, "MachineZoneID", DbType.Int32,MachineZoneID);

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
		public bool DeleteList(string MachineZoneIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MachineZone ");
			strSql.Append(" where MachineZoneID in ("+MachineZoneIDlist + ")  ");
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
		public MesWeb.Model.T_MachineZone GetModel(int MachineZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MachineZone_GetModel");
			db.AddInParameter(dbCommand, "MachineZoneID", DbType.Int32,MachineZoneID);

			MesWeb.Model.T_MachineZone model=null;
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
		public MesWeb.Model.T_MachineZone DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MachineZone model=new MesWeb.Model.T_MachineZone();
			if (row != null)
			{
				if(row["MachineZoneID"]!=null && row["MachineZoneID"].ToString()!="")
				{
					model.MachineZoneID=int.Parse(row["MachineZoneID"].ToString());
				}
				if(row["MachineZone"]!=null)
				{
					model.MachineZone=row["MachineZone"].ToString();
				}
				if(row["MachineZonePicUrl"]!=null)
				{
					model.MachineZonePicUrl=row["MachineZonePicUrl"].ToString();
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
			strSql.Append("select MachineZoneID,MachineZone,MachineZonePicUrl ");
			strSql.Append(" FROM T_MachineZone ");
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
			strSql.Append(" MachineZoneID,MachineZone,MachineZonePicUrl ");
			strSql.Append(" FROM T_MachineZone ");
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
			strSql.Append("select count(1) FROM T_MachineZone ");
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
				strSql.Append("order by T.MachineZoneID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MachineZone T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MachineZone");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MachineZoneID");
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
		public List<MesWeb.Model.T_MachineZone> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MachineZoneID,MachineZone,MachineZonePicUrl ");
			strSql.Append(" FROM T_MachineZone ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MachineZone> list = new List<MesWeb.Model.T_MachineZone>();
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
		public MesWeb.Model.T_MachineZone ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MachineZone model=new MesWeb.Model.T_MachineZone();
			object ojb; 
			ojb = dataReader["MachineZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineZoneID=(int)ojb;
			}
			model.MachineZone=dataReader["MachineZone"].ToString();
			model.MachineZonePicUrl=dataReader["MachineZonePicUrl"].ToString();
			return model;
		}

		#endregion  Method
	}
}

