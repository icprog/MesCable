﻿
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_MapMachineAddress
	/// </summary>
	public partial class T_MapMachineAddress:IT_MapMachineAddress
	{
		public T_MapMachineAddress()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MapMachineAddressID", "T_MapMachineAddress"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MapMachineAddressID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = MapMachineAddressID;

			int result= DbHelperSQL.RunProcedure("T_MapMachineAddress_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_MapMachineAddress model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4),
					new SqlParameter("@MapRule", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.MapRule;

			DbHelperSQL.RunProcedure("T_MapMachineAddress_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_MapMachineAddress model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4),
					new SqlParameter("@MapRule", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MapMachineAddressID;
			parameters[1].Value = model.MapRule;

			DbHelperSQL.RunProcedure("T_MapMachineAddress_Update",parameters,out rowsAffected);
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
		public bool Delete(int MapMachineAddressID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = MapMachineAddressID;

			DbHelperSQL.RunProcedure("T_MapMachineAddress_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string MapMachineAddressIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MapMachineAddress ");
			strSql.Append(" where MapMachineAddressID in ("+MapMachineAddressIDlist + ")  ");
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
		public MesWeb.Model.T_MapMachineAddress GetModel(int MapMachineAddressID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = MapMachineAddressID;

			MesWeb.Model.T_MapMachineAddress model=new MesWeb.Model.T_MapMachineAddress();
			DataSet ds= DbHelperSQL.RunProcedure("T_MapMachineAddress_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_MapMachineAddress DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MapMachineAddress model=new MesWeb.Model.T_MapMachineAddress();
			if (row != null)
			{
				if(row["MapMachineAddressID"]!=null && row["MapMachineAddressID"].ToString()!="")
				{
					model.MapMachineAddressID=int.Parse(row["MapMachineAddressID"].ToString());
				}
				if(row["MapRule"]!=null)
				{
					model.MapRule=row["MapRule"].ToString();
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
			strSql.Append("select MapMachineAddressID,MapRule ");
			strSql.Append(" FROM T_MapMachineAddress ");
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
			strSql.Append(" MapMachineAddressID,MapRule ");
			strSql.Append(" FROM T_MapMachineAddress ");
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
			strSql.Append("select count(1) FROM T_MapMachineAddress ");
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
				strSql.Append("order by T.MapMachineAddressID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MapMachineAddress T ");
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
			parameters[0].Value = "T_MapMachineAddress";
			parameters[1].Value = "MapMachineAddressID";
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

