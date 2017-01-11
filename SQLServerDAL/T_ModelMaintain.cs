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
	/// 数据访问类:T_ModelMaintain
	/// </summary>
	public partial class T_ModelMaintain:IT_ModelMaintain
	{
		public T_ModelMaintain()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(MouldMaintainID)+1 from T_ModelMaintain";
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
		public bool Exists(int MouldMaintainID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ModelMaintain_Exists");
			db.AddInParameter(dbCommand, "MouldMaintainID", DbType.Int32,MouldMaintainID);
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
		public bool Add(MesWeb.Model.T_ModelMaintain model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ModelMaintain_ADD");
			db.AddInParameter(dbCommand, "MouldMaintainID", DbType.Int32, model.MouldMaintainID);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldMaintainNumber", DbType.Int32, model.MouldMaintainNumber);
			db.AddInParameter(dbCommand, "MouldMaintainPersonID", DbType.Int32, model.MouldMaintainPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "IsMaintained", DbType.Boolean, model.IsMaintained);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
            return true;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_ModelMaintain model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ModelMaintain_Update");
			db.AddInParameter(dbCommand, "MouldMaintainID", DbType.Int32, model.MouldMaintainID);
			db.AddInParameter(dbCommand, "MouldID", DbType.Int32, model.MouldID);
			db.AddInParameter(dbCommand, "MouldMaintainNumber", DbType.Int32, model.MouldMaintainNumber);
			db.AddInParameter(dbCommand, "MouldMaintainPersonID", DbType.Int32, model.MouldMaintainPersonID);
			db.AddInParameter(dbCommand, "DateTime", DbType.DateTime, model.DateTime);
			db.AddInParameter(dbCommand, "IsMaintained", DbType.Boolean, model.IsMaintained);
			db.AddInParameter(dbCommand, "Comment", DbType.String, model.Comment);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MouldMaintainID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ModelMaintain_Delete");
			db.AddInParameter(dbCommand, "MouldMaintainID", DbType.Int32,MouldMaintainID);

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
		public bool DeleteList(string MouldMaintainIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ModelMaintain ");
			strSql.Append(" where MouldMaintainID in ("+MouldMaintainIDlist + ")  ");
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
		public MesWeb.Model.T_ModelMaintain GetModel(int MouldMaintainID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_ModelMaintain_GetModel");
			db.AddInParameter(dbCommand, "MouldMaintainID", DbType.Int32,MouldMaintainID);

			MesWeb.Model.T_ModelMaintain model=null;
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
		public MesWeb.Model.T_ModelMaintain DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ModelMaintain model=new MesWeb.Model.T_ModelMaintain();
			if (row != null)
			{
				if(row["MouldMaintainID"]!=null && row["MouldMaintainID"].ToString()!="")
				{
					model.MouldMaintainID=int.Parse(row["MouldMaintainID"].ToString());
				}
				if(row["MouldID"]!=null && row["MouldID"].ToString()!="")
				{
					model.MouldID=int.Parse(row["MouldID"].ToString());
				}
				if(row["MouldMaintainNumber"]!=null && row["MouldMaintainNumber"].ToString()!="")
				{
					model.MouldMaintainNumber=int.Parse(row["MouldMaintainNumber"].ToString());
				}
				if(row["MouldMaintainPersonID"]!=null && row["MouldMaintainPersonID"].ToString()!="")
				{
					model.MouldMaintainPersonID=int.Parse(row["MouldMaintainPersonID"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["IsMaintained"]!=null && row["IsMaintained"].ToString()!="")
				{
					if((row["IsMaintained"].ToString()=="1")||(row["IsMaintained"].ToString().ToLower()=="true"))
					{
						model.IsMaintained=true;
					}
					else
					{
						model.IsMaintained=false;
					}
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
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
			strSql.Append("select MouldMaintainID,MouldID,MouldMaintainNumber,MouldMaintainPersonID,DateTime,IsMaintained,Comment ");
			strSql.Append(" FROM T_ModelMaintain ");
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
			strSql.Append(" MouldMaintainID,MouldID,MouldMaintainNumber,MouldMaintainPersonID,DateTime,IsMaintained,Comment ");
			strSql.Append(" FROM T_ModelMaintain ");
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
			strSql.Append("select count(1) FROM T_ModelMaintain ");
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
				strSql.Append("order by T.MouldMaintainID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ModelMaintain T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_ModelMaintain");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MouldMaintainID");
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
		public List<MesWeb.Model.T_ModelMaintain> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MouldMaintainID,MouldID,MouldMaintainNumber,MouldMaintainPersonID,DateTime,IsMaintained,Comment ");
			strSql.Append(" FROM T_ModelMaintain ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_ModelMaintain> list = new List<MesWeb.Model.T_ModelMaintain>();
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
		public MesWeb.Model.T_ModelMaintain ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_ModelMaintain model=new MesWeb.Model.T_ModelMaintain();
			object ojb; 
			ojb = dataReader["MouldMaintainID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldMaintainID=(int)ojb;
			}
			ojb = dataReader["MouldID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldID=(int)ojb;
			}
			ojb = dataReader["MouldMaintainNumber"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldMaintainNumber=(int)ojb;
			}
			ojb = dataReader["MouldMaintainPersonID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MouldMaintainPersonID=(int)ojb;
			}
			ojb = dataReader["DateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateTime=(DateTime)ojb;
			}
			ojb = dataReader["IsMaintained"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMaintained=(bool)ojb;
			}
			model.Comment=dataReader["Comment"].ToString();
			return model;
		}

		#endregion  Method
	}
}

