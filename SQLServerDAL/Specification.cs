/**  版本信息模板在安装目录下，可自行修改。
* Specification.cs
*
* 功 能： N/A
* 类 名： Specification
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/15 19:43:35   N/A    初版
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
	/// 数据访问类:Specification
	/// </summary>
	public partial class Specification:ISpecification
	{
		public Specification()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Specification"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Specification");
			strSql.Append(" where id=SQL2012id");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.Specification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Specification(");
			strSql.Append("productId,procedureId,paramTypeId,upper,lower,suffix)");
			strSql.Append(" values (");
			strSql.Append("SQL2012productId,SQL2012procedureId,SQL2012paramTypeId,SQL2012upper,SQL2012lower,SQL2012suffix)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012productId", SqlDbType.Int,4),
					new SqlParameter("SQL2012procedureId", SqlDbType.Int,4),
					new SqlParameter("SQL2012paramTypeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012upper", SqlDbType.Float,8),
					new SqlParameter("SQL2012lower", SqlDbType.Float,8),
					new SqlParameter("SQL2012suffix", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.procedureId;
			parameters[2].Value = model.paramTypeId;
			parameters[3].Value = model.upper;
			parameters[4].Value = model.lower;
			parameters[5].Value = model.suffix;

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
		public bool Update(MesWeb.Model.Specification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Specification set ");
			strSql.Append("productId=SQL2012productId,");
			strSql.Append("procedureId=SQL2012procedureId,");
			strSql.Append("paramTypeId=SQL2012paramTypeId,");
			strSql.Append("upper=SQL2012upper,");
			strSql.Append("lower=SQL2012lower,");
			strSql.Append("suffix=SQL2012suffix");
			strSql.Append(" where id=SQL2012id");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012productId", SqlDbType.Int,4),
					new SqlParameter("SQL2012procedureId", SqlDbType.Int,4),
					new SqlParameter("SQL2012paramTypeId", SqlDbType.Int,4),
					new SqlParameter("SQL2012upper", SqlDbType.Float,8),
					new SqlParameter("SQL2012lower", SqlDbType.Float,8),
					new SqlParameter("SQL2012suffix", SqlDbType.NVarChar,10),
					new SqlParameter("SQL2012id", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.procedureId;
			parameters[2].Value = model.paramTypeId;
			parameters[3].Value = model.upper;
			parameters[4].Value = model.lower;
			parameters[5].Value = model.suffix;
			parameters[6].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Specification ");
			strSql.Append(" where id=SQL2012id");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Specification ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public MesWeb.Model.Specification GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,productId,procedureId,paramTypeId,upper,lower,suffix from Specification ");
			strSql.Append(" where id=SQL2012id");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MesWeb.Model.Specification model=new MesWeb.Model.Specification();
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
		public MesWeb.Model.Specification DataRowToModel(DataRow row)
		{
			MesWeb.Model.Specification model=new MesWeb.Model.Specification();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId=int.Parse(row["productId"].ToString());
				}
				if(row["procedureId"]!=null && row["procedureId"].ToString()!="")
				{
					model.procedureId=int.Parse(row["procedureId"].ToString());
				}
				if(row["paramTypeId"]!=null && row["paramTypeId"].ToString()!="")
				{
					model.paramTypeId=int.Parse(row["paramTypeId"].ToString());
				}
				if(row["upper"]!=null && row["upper"].ToString()!="")
				{
					model.upper=decimal.Parse(row["upper"].ToString());
				}
				if(row["lower"]!=null && row["lower"].ToString()!="")
				{
					model.lower=decimal.Parse(row["lower"].ToString());
				}
				if(row["suffix"]!=null)
				{
					model.suffix=row["suffix"].ToString();
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
			strSql.Append("select id,productId,procedureId,paramTypeId,upper,lower,suffix ");
			strSql.Append(" FROM Specification ");
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
			strSql.Append(" id,productId,procedureId,paramTypeId,upper,lower,suffix ");
			strSql.Append(" FROM Specification ");
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
			strSql.Append("select count(1) FROM Specification ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from Specification T ");
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
			parameters[0].Value = "Specification";
			parameters[1].Value = "id";
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

