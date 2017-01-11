
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_CollectedParameter
	/// </summary>
	public partial class T_CollectedParameter:IT_CollectedParameter
	{
		public T_CollectedParameter()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CollectedParameterID", "T_CollectedParameter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CollectedParameterID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedParameterID;

			int result= DbHelperSQL.RunProcedure("T_CollectedParameter_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_CollectedParameter model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4),
					new SqlParameter("@CollectedParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@CollectedParameterBit", SqlDbType.Int,4),
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.CollectedParameterName;
			parameters[2].Value = model.CollectedParameterBit;
			parameters[3].Value = model.ParameterUnitID;

			DbHelperSQL.RunProcedure("T_CollectedParameter_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_CollectedParameter model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4),
					new SqlParameter("@CollectedParameterName", SqlDbType.NVarChar,50),
					new SqlParameter("@CollectedParameterBit", SqlDbType.Int,4),
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4)};
			parameters[0].Value = model.CollectedParameterID;
			parameters[1].Value = model.CollectedParameterName;
			parameters[2].Value = model.CollectedParameterBit;
			parameters[3].Value = model.ParameterUnitID;

			DbHelperSQL.RunProcedure("T_CollectedParameter_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CollectedParameterID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedParameterID;

			DbHelperSQL.RunProcedure("T_CollectedParameter_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
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
		public bool DeleteList(string CollectedParameterIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CollectedParameter ");
			strSql.Append(" where CollectedParameterID in ("+CollectedParameterIDlist + ")  ");
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
		public MesWeb.Model.T_CollectedParameter GetModel(int CollectedParameterID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedParameterID;

			MesWeb.Model.T_CollectedParameter model=new MesWeb.Model.T_CollectedParameter();
			DataSet ds= DbHelperSQL.RunProcedure("T_CollectedParameter_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_CollectedParameter DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CollectedParameter model=new MesWeb.Model.T_CollectedParameter();
			if (row != null)
			{
				if(row["CollectedParameterID"]!=null && row["CollectedParameterID"].ToString()!="")
				{
					model.CollectedParameterID=int.Parse(row["CollectedParameterID"].ToString());
				}
				if(row["CollectedParameterName"]!=null)
				{
					model.CollectedParameterName=row["CollectedParameterName"].ToString();
				}
				if(row["CollectedParameterBit"]!=null && row["CollectedParameterBit"].ToString()!="")
				{
					model.CollectedParameterBit=int.Parse(row["CollectedParameterBit"].ToString());
				}
				if(row["ParameterUnitID"]!=null && row["ParameterUnitID"].ToString()!="")
				{
					model.ParameterUnitID=int.Parse(row["ParameterUnitID"].ToString());
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
			strSql.Append("select CollectedParameterID,CollectedParameterName,CollectedParameterBit,ParameterUnitID ");
			strSql.Append(" FROM T_CollectedParameter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" CollectedParameterID,CollectedParameterName,CollectedParameterBit,ParameterUnitID ");
			strSql.Append(" FROM T_CollectedParameter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_CollectedParameter ");
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
				strSql.Append("order by T.CollectedParameterID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CollectedParameter T ");
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
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_CollectedParameter";
			parameters[1].Value = "CollectedParameterID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

