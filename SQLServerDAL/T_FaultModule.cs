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
	/// 数据访问类:T_FaultModule
	/// </summary>
	public partial class T_FaultModule:IT_FaultModule
	{
		public T_FaultModule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FaultModuleID", "T_FaultModule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FaultModuleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FaultModule");
			strSql.Append(" where FaultModuleID=@FaultModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = FaultModuleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_FaultModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_FaultModule(");
			strSql.Append("MachineID,State,SerialNum,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@MachineID,@State,@SerialNum,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.NVarChar,50),
					new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.State;
			parameters[2].Value = model.SerialNum;
			parameters[3].Value = model.UpdateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_FaultModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FaultModule set ");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("State=@State,");
			strSql.Append("SerialNum=@SerialNum,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where FaultModuleID=@FaultModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.NVarChar,50),
					new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.State;
			parameters[2].Value = model.SerialNum;
			parameters[3].Value = model.UpdateTime;
			parameters[4].Value = model.FaultModuleID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FaultModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FaultModule ");
			strSql.Append(" where FaultModuleID=@FaultModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = FaultModuleID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string FaultModuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FaultModule ");
			strSql.Append(" where FaultModuleID in ("+FaultModuleIDlist + ")  ");
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
		public MesWeb.Model.T_FaultModule GetModel(int FaultModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FaultModuleID,MachineID,State,SerialNum,UpdateTime from T_FaultModule ");
			strSql.Append(" where FaultModuleID=@FaultModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = FaultModuleID;

			MesWeb.Model.T_FaultModule model=new MesWeb.Model.T_FaultModule();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public MesWeb.Model.T_FaultModule DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_FaultModule model=new MesWeb.Model.T_FaultModule();
			if (row != null)
			{
				if(row["FaultModuleID"]!=null && row["FaultModuleID"].ToString()!="")
				{
					model.FaultModuleID=int.Parse(row["FaultModuleID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["SerialNum"]!=null)
				{
					model.SerialNum=row["SerialNum"].ToString();
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
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
			strSql.Append("select FaultModuleID,MachineID,State,SerialNum,UpdateTime ");
			strSql.Append(" FROM T_FaultModule ");
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
			strSql.Append(" FaultModuleID,MachineID,State,SerialNum,UpdateTime ");
			strSql.Append(" FROM T_FaultModule ");
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
			strSql.Append("select count(1) FROM T_FaultModule ");
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
				strSql.Append("order by T.FaultModuleID desc");
			}
			strSql.Append(")AS Row, T.*  from T_FaultModule T ");
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
			parameters[0].Value = "T_FaultModule";
			parameters[1].Value = "FaultModuleID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

