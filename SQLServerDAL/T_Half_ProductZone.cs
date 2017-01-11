﻿using System;
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
	/// 数据访问类:T_Half_ProductZone
	/// </summary>
	public partial class T_Half_ProductZone:IT_Half_ProductZone
	{
		public T_Half_ProductZone()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(Half_ProductZoneID)+1 from T_Half_ProductZone";
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
		public bool Exists(int Half_ProductZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_ProductZone_Exists");
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32,Half_ProductZoneID);
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
		public int Add(MesWeb.Model.T_Half_ProductZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_ProductZone_ADD");
			db.AddOutParameter(dbCommand, "Half_ProductZoneID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "Half_ProductZoneName", DbType.String, model.Half_ProductZoneName);
			db.AddInParameter(dbCommand, "Half_ProductZonePicUrl", DbType.String, model.Half_ProductZonePicUrl);
			db.AddInParameter(dbCommand, "X_Position", DbType.Double, model.X_Position);
			db.AddInParameter(dbCommand, "Y_Position", DbType.Double, model.Y_Position);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "Half_ProductZoneID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Half_ProductZone model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_ProductZone_Update");
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32, model.Half_ProductZoneID);
			db.AddInParameter(dbCommand, "Half_ProductZoneName", DbType.String, model.Half_ProductZoneName);
			db.AddInParameter(dbCommand, "Half_ProductZonePicUrl", DbType.String, model.Half_ProductZonePicUrl);
			db.AddInParameter(dbCommand, "X_Position", DbType.Double, model.X_Position);
			db.AddInParameter(dbCommand, "Y_Position", DbType.Double, model.Y_Position);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Half_ProductZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_ProductZone_Delete");
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32,Half_ProductZoneID);

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
		public bool DeleteList(string Half_ProductZoneIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Half_ProductZone ");
			strSql.Append(" where Half_ProductZoneID in ("+Half_ProductZoneIDlist + ")  ");
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
		public MesWeb.Model.T_Half_ProductZone GetModel(int Half_ProductZoneID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Half_ProductZone_GetModel");
			db.AddInParameter(dbCommand, "Half_ProductZoneID", DbType.Int32,Half_ProductZoneID);

			MesWeb.Model.T_Half_ProductZone model=null;
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
		public MesWeb.Model.T_Half_ProductZone DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Half_ProductZone model=new MesWeb.Model.T_Half_ProductZone();
			if (row != null)
			{
				if(row["Half_ProductZoneID"]!=null && row["Half_ProductZoneID"].ToString()!="")
				{
					model.Half_ProductZoneID=int.Parse(row["Half_ProductZoneID"].ToString());
				}
				if(row["Half_ProductZoneName"]!=null)
				{
					model.Half_ProductZoneName=row["Half_ProductZoneName"].ToString();
				}
				if(row["Half_ProductZonePicUrl"]!=null)
				{
					model.Half_ProductZonePicUrl=row["Half_ProductZonePicUrl"].ToString();
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
			strSql.Append("select Half_ProductZoneID,Half_ProductZoneName,Half_ProductZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_Half_ProductZone ");
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
			strSql.Append(" Half_ProductZoneID,Half_ProductZoneName,Half_ProductZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_Half_ProductZone ");
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
			strSql.Append("select count(1) FROM T_Half_ProductZone ");
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
				strSql.Append("order by T.Half_ProductZoneID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Half_ProductZone T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Half_ProductZone");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "Half_ProductZoneID");
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
		public List<MesWeb.Model.T_Half_ProductZone> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Half_ProductZoneID,Half_ProductZoneName,Half_ProductZonePicUrl,X_Position,Y_Position ");
			strSql.Append(" FROM T_Half_ProductZone ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Half_ProductZone> list = new List<MesWeb.Model.T_Half_ProductZone>();
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
		public MesWeb.Model.T_Half_ProductZone ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Half_ProductZone model=new MesWeb.Model.T_Half_ProductZone();
			object ojb; 
			ojb = dataReader["Half_ProductZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Half_ProductZoneID=(int)ojb;
			}
			model.Half_ProductZoneName=dataReader["Half_ProductZoneName"].ToString();
			model.Half_ProductZonePicUrl=dataReader["Half_ProductZonePicUrl"].ToString();
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

