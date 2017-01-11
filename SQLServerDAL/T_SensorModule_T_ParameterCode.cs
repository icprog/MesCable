
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_SensorModule_T_ParameterCode
	/// </summary>
	public partial class T_SensorModule_T_ParameterCode:IT_SensorModule_T_ParameterCode
	{
		public T_SensorModule_T_ParameterCode()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SensorModule_PARCODEID", "T_SensorModule_T_ParameterCode"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SensorModule_PARCODEID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModule_PARCODEID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModule_PARCODEID;

			int result= DbHelperSQL.RunProcedure("T_SensorModule_T_ParameterCode_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_SensorModule_T_ParameterCode model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModule_PARCODEID", SqlDbType.Int,4),
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.SensorModuleID;
			parameters[2].Value = model.ParameterCodeID;

			DbHelperSQL.RunProcedure("T_SensorModule_T_ParameterCode_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_SensorModule_T_ParameterCode model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModule_PARCODEID", SqlDbType.Int,4),
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4)};
			parameters[0].Value = model.SensorModule_PARCODEID;
			parameters[1].Value = model.SensorModuleID;
			parameters[2].Value = model.ParameterCodeID;

			DbHelperSQL.RunProcedure("T_SensorModule_T_ParameterCode_Update",parameters,out rowsAffected);
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
		public bool Delete(int SensorModule_PARCODEID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModule_PARCODEID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModule_PARCODEID;

			DbHelperSQL.RunProcedure("T_SensorModule_T_ParameterCode_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string SensorModule_PARCODEIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_SensorModule_T_ParameterCode ");
			strSql.Append(" where SensorModule_PARCODEID in ("+SensorModule_PARCODEIDlist + ")  ");
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
		public MesWeb.Model.T_SensorModule_T_ParameterCode GetModel(int SensorModule_PARCODEID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModule_PARCODEID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModule_PARCODEID;

			MesWeb.Model.T_SensorModule_T_ParameterCode model=new MesWeb.Model.T_SensorModule_T_ParameterCode();
			DataSet ds= DbHelperSQL.RunProcedure("T_SensorModule_T_ParameterCode_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_SensorModule_T_ParameterCode DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_SensorModule_T_ParameterCode model=new MesWeb.Model.T_SensorModule_T_ParameterCode();
			if (row != null)
			{
				if(row["SensorModule_PARCODEID"]!=null && row["SensorModule_PARCODEID"].ToString()!="")
				{
					model.SensorModule_PARCODEID=int.Parse(row["SensorModule_PARCODEID"].ToString());
				}
				if(row["SensorModuleID"]!=null && row["SensorModuleID"].ToString()!="")
				{
					model.SensorModuleID=int.Parse(row["SensorModuleID"].ToString());
				}
				if(row["ParameterCodeID"]!=null && row["ParameterCodeID"].ToString()!="")
				{
					model.ParameterCodeID=int.Parse(row["ParameterCodeID"].ToString());
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
			strSql.Append("select SensorModule_PARCODEID,SensorModuleID,ParameterCodeID ");
			strSql.Append(" FROM T_SensorModule_T_ParameterCode ");
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
			strSql.Append(" SensorModule_PARCODEID,SensorModuleID,ParameterCodeID ");
			strSql.Append(" FROM T_SensorModule_T_ParameterCode ");
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
			strSql.Append("select count(1) FROM T_SensorModule_T_ParameterCode ");
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
				strSql.Append("order by T.SensorModule_PARCODEID desc");
			}
			strSql.Append(")AS Row, T.*  from T_SensorModule_T_ParameterCode T ");
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
			parameters[0].Value = "T_SensorModule_T_ParameterCode";
			parameters[1].Value = "SensorModule_PARCODEID";
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

