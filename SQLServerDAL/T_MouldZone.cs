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
	/// 数据访问类:T_MouldZone
	/// </summary>
	public partial class T_MouldZone:IT_MouldZone
	{
		public T_MouldZone()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MouldZoneID)+1 from T_MouldZone";
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
		public bool Exists(int MouldZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldZone_Exists");
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32,MouldZoneID);
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
		public int Add(MesWeb.Model.T_MouldZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldZone_ADD");
			db.AddOutParameter(dbCommand, "MouldZoneID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MouldZoneName", DbType.String, model.MouldZoneName);
			db.AddInParameter(dbCommand, "MouldZonePicUrl", DbType.String, model.MouldZonePicUrl);
			db.AddInParameter(dbCommand, "X_Position", DbType.Double, model.X_Position);
			db.AddInParameter(dbCommand, "Y_Position", DbType.Double, model.Y_Position);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MouldZoneID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_MouldZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldZone_Update");
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32, model.MouldZoneID);
			db.AddInParameter(dbCommand, "MouldZoneName", DbType.String, model.MouldZoneName);
			db.AddInParameter(dbCommand, "MouldZonePicUrl", DbType.String, model.MouldZonePicUrl);
			db.AddInParameter(dbCommand, "X_Position", DbType.Double, model.X_Position);
			db.AddInParameter(dbCommand, "Y_Position", DbType.Double, model.Y_Position);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MouldZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldZone_Delete");
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32,MouldZoneID);

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
		public bool DeleteList(string MouldZoneIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MouldZone ");
			strSql.Append(" where MouldZoneID in ("+MouldZoneIDlist + ")  ");
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
		public MesWeb.Model.T_MouldZone GetModel(int MouldZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_MouldZone_GetModel");
			db.AddInParameter(dbCommand, "MouldZoneID", DbType.Int32,MouldZoneID);

			MesWeb.Model.T_MouldZone model=null;
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
		public MesWeb.Model.T_MouldZone DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MouldZone model=new MesWeb.Model.T_MouldZone();
			if (row != null)
			{
				if(row["MouldZoneID"]!=null && row["MouldZoneID"].ToString()!="")
				{
					model.MouldZoneID=int.Parse(row["MouldZoneID"].ToString());
				}
				if(row["MouldZoneName"]!=null)
				{
					model.MouldZoneName=row["MouldZoneName"].ToString();
				}
				if(row["MouldZonePicUrl"]!=null)
				{
					model.MouldZonePicUrl=row["MouldZonePicUrl"].ToString();
				}
				if(row["X_Position"]!=null && row["X_Position"].ToString()!="")
				{
					model.X_Position=decimal.Parse(row["X_Position"].ToString());
				}
				if(row["Y_Position"]!=null && row["Y_Position"].ToString()!="")
				{
					model.Y_Position=decimal.Parse(row["Y_Position"].ToString());
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
			strSql.Append("select MouldZoneID,MouldZoneName,MouldZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_MouldZone ");
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
			strSql.Append(" MouldZoneID,MouldZoneName,MouldZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_MouldZone ");
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
			strSql.Append("select count(1) FROM T_MouldZone ");
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
				strSql.Append("order by T.MouldZoneID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MouldZone T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_MouldZone");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MouldZoneID");
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
		public List<MesWeb.Model.T_MouldZone> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MouldZoneID,MouldZoneName,MouldZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_MouldZone ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_MouldZone> list = new List<MesWeb.Model.T_MouldZone>();
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
		public MesWeb.Model.T_MouldZone ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_MouldZone model=new MesWeb.Model.T_MouldZone();
			object ojb; 
			ojb = dataReader["MouldZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldZoneID=(int)ojb;
			}
			model.MouldZoneName=dataReader["MouldZoneName"].ToString();
			model.MouldZonePicUrl=dataReader["MouldZonePicUrl"].ToString();
			ojb = dataReader["X_Position"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.X_Position=(decimal)ojb;
			}
			ojb = dataReader["Y_Position"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Y_Position=(decimal)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

