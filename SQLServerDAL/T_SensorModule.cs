/**  版本信息模板在安装目录下，可自行修改。
* T_SensorModule.cs
*
* 功 能： N/A
* 类 名： T_SensorModule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:24   N/A    初版
*
* Copyright (c) 2012 MES Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_SensorModule
	/// </summary>
	public partial class T_SensorModule:IT_SensorModule
	{
		public T_SensorModule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SensorModuleID", "T_SensorModule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SensorModuleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_SensorModule");
			strSql.Append(" where SensorModuleID=@SensorModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModuleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_SensorModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_SensorModule(");
			strSql.Append("MachineID,FaultModuleID,SerialNum,InstallTime,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@MachineID,@FaultModuleID,@SerialNum,@InstallTime,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4),
					new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@InstallTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.FaultModuleID;
			parameters[2].Value = model.SerialNum;
			parameters[3].Value = model.InstallTime;
			parameters[4].Value = model.UpdateTime;

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
		public bool Update(MesWeb.Model.T_SensorModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_SensorModule set ");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("FaultModuleID=@FaultModuleID,");
			strSql.Append("SerialNum=@SerialNum,");
			strSql.Append("InstallTime=@InstallTime,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where SensorModuleID=@SensorModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@FaultModuleID", SqlDbType.Int,4),
					new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@InstallTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.FaultModuleID;
			parameters[2].Value = model.SerialNum;
			parameters[3].Value = model.InstallTime;
			parameters[4].Value = model.UpdateTime;
			parameters[5].Value = model.SensorModuleID;

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
		public bool Delete(int SensorModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_SensorModule ");
			strSql.Append(" where SensorModuleID=@SensorModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModuleID;

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
		public bool DeleteList(string SensorModuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_SensorModule ");
			strSql.Append(" where SensorModuleID in ("+SensorModuleIDlist + ")  ");
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
		public MesWeb.Model.T_SensorModule GetModel(int SensorModuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SensorModuleID,MachineID,FaultModuleID,SerialNum,InstallTime,UpdateTime from T_SensorModule ");
			strSql.Append(" where SensorModuleID=@SensorModuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorModuleID", SqlDbType.Int,4)
			};
			parameters[0].Value = SensorModuleID;

			MesWeb.Model.T_SensorModule model=new MesWeb.Model.T_SensorModule();
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
		public MesWeb.Model.T_SensorModule DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_SensorModule model=new MesWeb.Model.T_SensorModule();
			if (row != null)
			{
				if(row["SensorModuleID"]!=null && row["SensorModuleID"].ToString()!="")
				{
					model.SensorModuleID=int.Parse(row["SensorModuleID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["FaultModuleID"]!=null && row["FaultModuleID"].ToString()!="")
				{
					model.FaultModuleID=int.Parse(row["FaultModuleID"].ToString());
				}
				if(row["SerialNum"]!=null)
				{
					model.SerialNum=row["SerialNum"].ToString();
				}
				if(row["InstallTime"]!=null && row["InstallTime"].ToString()!="")
				{
					model.InstallTime=DateTime.Parse(row["InstallTime"].ToString());
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
			strSql.Append("select SensorModuleID,MachineID,FaultModuleID,SerialNum,InstallTime,UpdateTime ");
			strSql.Append(" FROM T_SensorModule ");
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
			strSql.Append(" SensorModuleID,MachineID,FaultModuleID,SerialNum,InstallTime,UpdateTime ");
			strSql.Append(" FROM T_SensorModule ");
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
			strSql.Append("select count(1) FROM T_SensorModule ");
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
				strSql.Append("order by T.SensorModuleID desc");
			}
			strSql.Append(")AS Row, T.*  from T_SensorModule T ");
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
			parameters[0].Value = "T_SensorModule";
			parameters[1].Value = "SensorModuleID";
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

