/**  版本信息模板在安装目录下，可自行修改。
* T_CurrentData.cs
*
* 功 能： N/A
* 类 名： T_CurrentData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 17:22:00   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
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
using MES.DBUtility;

namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_CurrentData
	/// </summary>
	public partial class T_CurrentData:IT_CurrentData
	{
		public T_CurrentData()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_CurrentData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CurrentData(");
			strSql.Append("TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode,MaterialRFID)");
			strSql.Append(" values (");
			strSql.Append("SQL2012TaskID,SQL2012SpecificationID,SQL2012MachineID,SQL2012MachineTypeID,SQL2012EmployeeID_Main,SQL2012EmployeeID_Assistant,SQL2012Start_Axis_No,SQL2012Axis_No,SQL2012Printcode,SQL2012MaterialRFID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012TaskID", SqlDbType.Int,4),
					new SqlParameter("SQL2012SpecificationID", SqlDbType.Int,4),
					new SqlParameter("SQL2012MachineID", SqlDbType.Int,4),
					new SqlParameter("SQL2012MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("SQL2012EmployeeID_Main", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012EmployeeID_Assistant", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012Start_Axis_No", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Printcode", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012MaterialRFID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TaskID;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.MachineTypeID;
			parameters[4].Value = model.EmployeeID_Main;
			parameters[5].Value = model.EmployeeID_Assistant;
			parameters[6].Value = model.Start_Axis_No;
			parameters[7].Value = model.Axis_No;
			parameters[8].Value = model.Printcode;
			parameters[9].Value = model.MaterialRFID;

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
		public bool Update(MesWeb.Model.T_CurrentData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CurrentData set ");
			strSql.Append("TaskID=SQL2012TaskID,");
			strSql.Append("SpecificationID=SQL2012SpecificationID,");
			strSql.Append("MachineID=SQL2012MachineID,");
			strSql.Append("MachineTypeID=SQL2012MachineTypeID,");
			strSql.Append("EmployeeID_Main=SQL2012EmployeeID_Main,");
			strSql.Append("EmployeeID_Assistant=SQL2012EmployeeID_Assistant,");
			strSql.Append("Start_Axis_No=SQL2012Start_Axis_No,");
			strSql.Append("Axis_No=SQL2012Axis_No,");
			strSql.Append("Printcode=SQL2012Printcode,");
			strSql.Append("MaterialRFID=SQL2012MaterialRFID");
			strSql.Append(" where CurrentDataID=SQL2012CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012TaskID", SqlDbType.Int,4),
					new SqlParameter("SQL2012SpecificationID", SqlDbType.Int,4),
					new SqlParameter("SQL2012MachineID", SqlDbType.Int,4),
					new SqlParameter("SQL2012MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("SQL2012EmployeeID_Main", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012EmployeeID_Assistant", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012Start_Axis_No", SqlDbType.NVarChar,-1),
					new SqlParameter("SQL2012Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Printcode", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012MaterialRFID", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012CurrentDataID", SqlDbType.Int,4)};
			parameters[0].Value = model.TaskID;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.MachineTypeID;
			parameters[4].Value = model.EmployeeID_Main;
			parameters[5].Value = model.EmployeeID_Assistant;
			parameters[6].Value = model.Start_Axis_No;
			parameters[7].Value = model.Axis_No;
			parameters[8].Value = model.Printcode;
			parameters[9].Value = model.MaterialRFID;
			parameters[10].Value = model.CurrentDataID;

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
		public bool Delete(int CurrentDataID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CurrentData ");
			strSql.Append(" where CurrentDataID=SQL2012CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CurrentDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrentDataID;

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
		public bool DeleteList(string CurrentDataIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CurrentData ");
			strSql.Append(" where CurrentDataID in ("+CurrentDataIDlist + ")  ");
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
		public MesWeb.Model.T_CurrentData GetModel(int CurrentDataID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode,MaterialRFID from T_CurrentData ");
			strSql.Append(" where CurrentDataID=SQL2012CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012CurrentDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrentDataID;

			MesWeb.Model.T_CurrentData model=new MesWeb.Model.T_CurrentData();
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
		public MesWeb.Model.T_CurrentData DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CurrentData model=new MesWeb.Model.T_CurrentData();
			if (row != null)
			{
				if(row["CurrentDataID"]!=null && row["CurrentDataID"].ToString()!="")
				{
					model.CurrentDataID=int.Parse(row["CurrentDataID"].ToString());
				}
				if(row["TaskID"]!=null && row["TaskID"].ToString()!="")
				{
					model.TaskID=int.Parse(row["TaskID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["MachineTypeID"]!=null && row["MachineTypeID"].ToString()!="")
				{
					model.MachineTypeID=int.Parse(row["MachineTypeID"].ToString());
				}
				if(row["EmployeeID_Main"]!=null)
				{
					model.EmployeeID_Main=row["EmployeeID_Main"].ToString();
				}
				if(row["EmployeeID_Assistant"]!=null)
				{
					model.EmployeeID_Assistant=row["EmployeeID_Assistant"].ToString();
				}
				if(row["Start_Axis_No"]!=null)
				{
					model.Start_Axis_No=row["Start_Axis_No"].ToString();
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["Printcode"]!=null)
				{
					model.Printcode=row["Printcode"].ToString();
				}
				if(row["MaterialRFID"]!=null)
				{
					model.MaterialRFID=row["MaterialRFID"].ToString();
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
			strSql.Append("select CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode,MaterialRFID ");
			strSql.Append(" FROM T_CurrentData ");
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
			strSql.Append(" CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode,MaterialRFID ");
			strSql.Append(" FROM T_CurrentData ");
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
			strSql.Append("select count(1) FROM T_CurrentData ");
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
				strSql.Append("order by T.CurrentDataID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CurrentData T ");
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
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_CurrentData";
			parameters[1].Value = "CurrentDataID";
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

