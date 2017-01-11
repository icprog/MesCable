/**  版本信息模板在安装目录下，可自行修改。
* T_CollectedDataParameters.cs
*
* 功 能： N/A
* 类 名： T_CollectedDataParameters
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:21   N/A    初版
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
	/// 数据访问类:T_CollectedDataParameters
	/// </summary>
	public partial class T_CollectedDataParameters:IT_CollectedDataParameters
	{
		public T_CollectedDataParameters()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CollectedDataParametersID", "T_CollectedDataParameters"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CollectedDataParametersID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CollectedDataParameters");
			strSql.Append(" where CollectedDataParametersID=@CollectedDataParametersID");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedDataParametersID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedDataParametersID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_CollectedDataParameters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CollectedDataParameters(");
			strSql.Append("CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No)");
			strSql.Append(" values (");
			strSql.Append("@CollectedValue,@CollectedTime,@ParameterCodeID,@MachineID,@Axis_No)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedValue", SqlDbType.NVarChar,50),
					new SqlParameter("@CollectedTime", SqlDbType.DateTime),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.CollectedValue;
			parameters[1].Value = model.CollectedTime;
			parameters[2].Value = model.ParameterCodeID;
			parameters[3].Value = model.MachineID;
			parameters[4].Value = model.Axis_No;

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
		public bool Update(MesWeb.Model.T_CollectedDataParameters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CollectedDataParameters set ");
			strSql.Append("CollectedValue=@CollectedValue,");
			strSql.Append("CollectedTime=@CollectedTime,");
			strSql.Append("ParameterCodeID=@ParameterCodeID,");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("Axis_No=@Axis_No");
			strSql.Append(" where CollectedDataParametersID=@CollectedDataParametersID");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedValue", SqlDbType.NVarChar,50),
					new SqlParameter("@CollectedTime", SqlDbType.DateTime),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@CollectedDataParametersID", SqlDbType.Int,4)};
			parameters[0].Value = model.CollectedValue;
			parameters[1].Value = model.CollectedTime;
			parameters[2].Value = model.ParameterCodeID;
			parameters[3].Value = model.MachineID;
			parameters[4].Value = model.Axis_No;
			parameters[5].Value = model.CollectedDataParametersID;

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
		public bool Delete(int CollectedDataParametersID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CollectedDataParameters ");
			strSql.Append(" where CollectedDataParametersID=@CollectedDataParametersID");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedDataParametersID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedDataParametersID;

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
		public bool DeleteList(string CollectedDataParametersIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CollectedDataParameters ");
			strSql.Append(" where CollectedDataParametersID in ("+CollectedDataParametersIDlist + ")  ");
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
		public MesWeb.Model.T_CollectedDataParameters GetModel(int CollectedDataParametersID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No from T_CollectedDataParameters ");
			strSql.Append(" where CollectedDataParametersID=@CollectedDataParametersID");
			SqlParameter[] parameters = {
					new SqlParameter("@CollectedDataParametersID", SqlDbType.Int,4)
			};
			parameters[0].Value = CollectedDataParametersID;

			MesWeb.Model.T_CollectedDataParameters model=new MesWeb.Model.T_CollectedDataParameters();
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
		public MesWeb.Model.T_CollectedDataParameters DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CollectedDataParameters model=new MesWeb.Model.T_CollectedDataParameters();
			if (row != null)
			{
				if(row["CollectedDataParametersID"]!=null && row["CollectedDataParametersID"].ToString()!="")
				{
					model.CollectedDataParametersID=int.Parse(row["CollectedDataParametersID"].ToString());
				}
				if(row["CollectedValue"]!=null)
				{
					model.CollectedValue=row["CollectedValue"].ToString();
				}
				if(row["CollectedTime"]!=null && row["CollectedTime"].ToString()!="")
				{
					model.CollectedTime=DateTime.Parse(row["CollectedTime"].ToString());
				}
				if(row["ParameterCodeID"]!=null && row["ParameterCodeID"].ToString()!="")
				{
					model.ParameterCodeID=int.Parse(row["ParameterCodeID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
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
			strSql.Append("select CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No ");
			strSql.Append(" FROM T_CollectedDataParameters ");
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
			strSql.Append(" CollectedDataParametersID,CollectedValue,CollectedTime,ParameterCodeID,MachineID,Axis_No ");
			strSql.Append(" FROM T_CollectedDataParameters ");
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
			strSql.Append("select count(1) FROM T_CollectedDataParameters ");
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
				strSql.Append("order by T.CollectedDataParametersID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CollectedDataParameters T ");
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
			parameters[0].Value = "T_CollectedDataParameters";
			parameters[1].Value = "CollectedDataParametersID";
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

