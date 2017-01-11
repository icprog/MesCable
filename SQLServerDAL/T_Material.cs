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
	/// 数据访问类:T_Material
	/// </summary>
	public partial class T_Material:IT_Material
	{
		public T_Material()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MaterialID)+1 from T_Material";
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
		public bool Exists(int MaterialID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Material_Exists");
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32,MaterialID);
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
		public int Add(MesWeb.Model.T_Material model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Material_ADD");
			db.AddOutParameter(dbCommand, "MaterialID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "MaterialTypeID", DbType.Int32, model.MaterialTypeID);
			db.AddInParameter(dbCommand, "MaterialCode", DbType.String, model.MaterialCode);
			db.AddInParameter(dbCommand, "MaterialZoneID", DbType.Int32, model.MaterialZoneID);
			db.AddInParameter(dbCommand, "MaterialNum", DbType.Double, model.MaterialNum);
			db.AddInParameter(dbCommand, "MaterialInputTime", DbType.DateTime, model.MaterialInputTime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "MaterialID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Material model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Material_Update");
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, model.MaterialID);
			db.AddInParameter(dbCommand, "MaterialTypeID", DbType.Int32, model.MaterialTypeID);
			db.AddInParameter(dbCommand, "MaterialCode", DbType.String, model.MaterialCode);
			db.AddInParameter(dbCommand, "MaterialZoneID", DbType.Int32, model.MaterialZoneID);
			db.AddInParameter(dbCommand, "MaterialNum", DbType.Double, model.MaterialNum);
			db.AddInParameter(dbCommand, "MaterialInputTime", DbType.DateTime, model.MaterialInputTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MaterialID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Material_Delete");
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32,MaterialID);

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
		public bool DeleteList(string MaterialIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Material ");
			strSql.Append(" where MaterialID in ("+MaterialIDlist + ")  ");
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
		public MesWeb.Model.T_Material GetModel(int MaterialID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Material_GetModel");
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32,MaterialID);

			MesWeb.Model.T_Material model=null;
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
		public MesWeb.Model.T_Material DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Material model=new MesWeb.Model.T_Material();
			if (row != null)
			{
				if(row["MaterialID"]!=null && row["MaterialID"].ToString()!="")
				{
					model.MaterialID=int.Parse(row["MaterialID"].ToString());
				}
				if(row["MaterialTypeID"]!=null && row["MaterialTypeID"].ToString()!="")
				{
					model.MaterialTypeID=int.Parse(row["MaterialTypeID"].ToString());
				}
				if(row["MaterialCode"]!=null)
				{
					model.MaterialCode=row["MaterialCode"].ToString();
				}
				if(row["MaterialZoneID"]!=null && row["MaterialZoneID"].ToString()!="")
				{
					model.MaterialZoneID=int.Parse(row["MaterialZoneID"].ToString());
				}
				if(row["MaterialNum"]!=null && row["MaterialNum"].ToString()!="")
				{
					model.MaterialNum=decimal.Parse(row["MaterialNum"].ToString());
				}
				if(row["MaterialInputTime"]!=null && row["MaterialInputTime"].ToString()!="")
				{
					model.MaterialInputTime=DateTime.Parse(row["MaterialInputTime"].ToString());
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
			strSql.Append("select MaterialID,MaterialTypeID,MaterialCode,MaterialZoneID,MaterialNum,MaterialInputTime ");
			strSql.Append(" FROM T_Material ");
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
			strSql.Append(" MaterialID,MaterialTypeID,MaterialCode,MaterialZoneID,MaterialNum,MaterialInputTime ");
			strSql.Append(" FROM T_Material ");
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
			strSql.Append("select count(1) FROM T_Material ");
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
				strSql.Append("order by T.MaterialID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Material T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Material");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MaterialID");
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
		public List<MesWeb.Model.T_Material> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MaterialID,MaterialTypeID,MaterialCode,MaterialZoneID,MaterialNum,MaterialInputTime ");
			strSql.Append(" FROM T_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Material> list = new List<MesWeb.Model.T_Material>();
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
		public MesWeb.Model.T_Material ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Material model=new MesWeb.Model.T_Material();
			object ojb; 
			ojb = dataReader["MaterialID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialID=(int)ojb;
			}
			ojb = dataReader["MaterialTypeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialTypeID=(int)ojb;
			}
			model.MaterialCode=dataReader["MaterialCode"].ToString();
			ojb = dataReader["MaterialZoneID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialZoneID=(int)ojb;
			}
			ojb = dataReader["MaterialNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialNum=(decimal)ojb;
			}
			ojb = dataReader["MaterialInputTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaterialInputTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

