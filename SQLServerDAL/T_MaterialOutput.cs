/**  版本信息模板在安装目录下，可自行修改。
* T_MaterialOutput.cs
*
* 功 能： N/A
* 类 名： T_MaterialOutput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 17:36:51   N/A    初版
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
	/// 数据访问类:T_MaterialOutput
	/// </summary>
	public partial class T_MaterialOutput:IT_MaterialOutput
	{
		public T_MaterialOutput()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_MaterialOutput model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_MaterialOutput(");
			strSql.Append("MaterialRFID,MaterialType,GnerateTime,MaterialName,Weight,Color,Certificate,ContractNo,BatchNo,SupplyCompany,workshift)");
			strSql.Append(" values (");
			strSql.Append("SQL2012MaterialRFID,SQL2012MaterialType,SQL2012GnerateTime,SQL2012MaterialName,SQL2012Weight,SQL2012Color,SQL2012Certificate,SQL2012ContractNo,SQL2012BatchNo,SQL2012SupplyCompany,SQL2012workshift)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MaterialRFID", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012MaterialType", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012GnerateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012MaterialName", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Weight", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Color", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Certificate", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012BatchNo", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012SupplyCompany", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012workshift", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MaterialRFID;
			parameters[1].Value = model.MaterialType;
			parameters[2].Value = model.GnerateTime;
			parameters[3].Value = model.MaterialName;
			parameters[4].Value = model.Weight;
			parameters[5].Value = model.Color;
			parameters[6].Value = model.Certificate;
			parameters[7].Value = model.ContractNo;
			parameters[8].Value = model.BatchNo;
			parameters[9].Value = model.SupplyCompany;
			parameters[10].Value = model.workshift;

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
		public bool Update(MesWeb.Model.T_MaterialOutput model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_MaterialOutput set ");
			strSql.Append("MaterialRFID=SQL2012MaterialRFID,");
			strSql.Append("MaterialType=SQL2012MaterialType,");
			strSql.Append("GnerateTime=SQL2012GnerateTime,");
			strSql.Append("MaterialName=SQL2012MaterialName,");
			strSql.Append("Weight=SQL2012Weight,");
			strSql.Append("Color=SQL2012Color,");
			strSql.Append("Certificate=SQL2012Certificate,");
			strSql.Append("ContractNo=SQL2012ContractNo,");
			strSql.Append("BatchNo=SQL2012BatchNo,");
			strSql.Append("SupplyCompany=SQL2012SupplyCompany,");
			strSql.Append("workshift=SQL2012workshift");
			strSql.Append(" where MaterialOutputID=SQL2012MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MaterialRFID", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012MaterialType", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012GnerateTime", SqlDbType.DateTime),
					new SqlParameter("SQL2012MaterialName", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Weight", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Color", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012Certificate", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012BatchNo", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012SupplyCompany", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012workshift", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012MaterialOutputID", SqlDbType.Int,4)};
			parameters[0].Value = model.MaterialRFID;
			parameters[1].Value = model.MaterialType;
			parameters[2].Value = model.GnerateTime;
			parameters[3].Value = model.MaterialName;
			parameters[4].Value = model.Weight;
			parameters[5].Value = model.Color;
			parameters[6].Value = model.Certificate;
			parameters[7].Value = model.ContractNo;
			parameters[8].Value = model.BatchNo;
			parameters[9].Value = model.SupplyCompany;
			parameters[10].Value = model.workshift;
			parameters[11].Value = model.MaterialOutputID;

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
		public bool Delete(int MaterialOutputID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID=SQL2012MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MaterialOutputID", SqlDbType.Int,4)
			};
			parameters[0].Value = MaterialOutputID;

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
		public bool DeleteList(string MaterialOutputIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID in ("+MaterialOutputIDlist + ")  ");
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
		public MesWeb.Model.T_MaterialOutput GetModel(int MaterialOutputID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MaterialOutputID,MaterialRFID,MaterialType,GnerateTime,MaterialName,Weight,Color,Certificate,ContractNo,BatchNo,SupplyCompany,workshift from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID=SQL2012MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012MaterialOutputID", SqlDbType.Int,4)
			};
			parameters[0].Value = MaterialOutputID;

			MesWeb.Model.T_MaterialOutput model=new MesWeb.Model.T_MaterialOutput();
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
		public MesWeb.Model.T_MaterialOutput DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MaterialOutput model=new MesWeb.Model.T_MaterialOutput();
			if (row != null)
			{
				if(row["MaterialOutputID"]!=null && row["MaterialOutputID"].ToString()!="")
				{
					model.MaterialOutputID=int.Parse(row["MaterialOutputID"].ToString());
				}
				if(row["MaterialRFID"]!=null)
				{
					model.MaterialRFID=row["MaterialRFID"].ToString();
				}
				if(row["MaterialType"]!=null)
				{
					model.MaterialType=row["MaterialType"].ToString();
				}
				if(row["GnerateTime"]!=null && row["GnerateTime"].ToString()!="")
				{
					model.GnerateTime=DateTime.Parse(row["GnerateTime"].ToString());
				}
				if(row["MaterialName"]!=null)
				{
					model.MaterialName=row["MaterialName"].ToString();
				}
				if(row["Weight"]!=null)
				{
					model.Weight=row["Weight"].ToString();
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["Certificate"]!=null)
				{
					model.Certificate=row["Certificate"].ToString();
				}
				if(row["ContractNo"]!=null)
				{
					model.ContractNo=row["ContractNo"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["SupplyCompany"]!=null)
				{
					model.SupplyCompany=row["SupplyCompany"].ToString();
				}
				if(row["workshift"]!=null)
				{
					model.workshift=row["workshift"].ToString();
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
			strSql.Append("select MaterialOutputID,MaterialRFID,MaterialType,GnerateTime,MaterialName,Weight,Color,Certificate,ContractNo,BatchNo,SupplyCompany,workshift ");
			strSql.Append(" FROM T_MaterialOutput ");
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
			strSql.Append(" MaterialOutputID,MaterialRFID,MaterialType,GnerateTime,MaterialName,Weight,Color,Certificate,ContractNo,BatchNo,SupplyCompany,workshift ");
			strSql.Append(" FROM T_MaterialOutput ");
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
			strSql.Append("select count(1) FROM T_MaterialOutput ");
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
				strSql.Append("order by T.MaterialOutputID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MaterialOutput T ");
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
			parameters[0].Value = "T_MaterialOutput";
			parameters[1].Value = "MaterialOutputID";
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

