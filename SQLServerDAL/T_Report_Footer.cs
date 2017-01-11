
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Report_Footer
	/// </summary>
	public partial class T_Report_Footer:IT_Report_Footer
	{
		public T_Report_Footer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_Report_Footer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Footer");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_Report_Footer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Footer(");
			strSql.Append("ICPReporter,ZDEnvTestResult,PassNum,DefectNum,DefectCode,VerifyResult,Inspector,Auditer,Approver)");
			strSql.Append(" values (");
			strSql.Append("@ICPReporter,@ZDEnvTestResult,@PassNum,@DefectNum,@DefectCode,@VerifyResult,@Inspector,@Auditer,@Approver)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ICPReporter", SqlDbType.Int,4),
					new SqlParameter("@ZDEnvTestResult", SqlDbType.Int,4),
					new SqlParameter("@PassNum", SqlDbType.NVarChar,50),
					new SqlParameter("@DefectNum", SqlDbType.NVarChar,50),
					new SqlParameter("@DefectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@VerifyResult", SqlDbType.Int,4),
					new SqlParameter("@Inspector", SqlDbType.NVarChar,50),
					new SqlParameter("@Auditer", SqlDbType.NVarChar,50),
					new SqlParameter("@Approver", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ICPReporter;
			parameters[1].Value = model.ZDEnvTestResult;
			parameters[2].Value = model.PassNum;
			parameters[3].Value = model.DefectNum;
			parameters[4].Value = model.DefectCode;
			parameters[5].Value = model.VerifyResult;
			parameters[6].Value = model.Inspector;
			parameters[7].Value = model.Auditer;
			parameters[8].Value = model.Approver;

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
		public bool Update(MesWeb.Model.T_Report_Footer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Footer set ");
			strSql.Append("ICPReporter=@ICPReporter,");
			strSql.Append("ZDEnvTestResult=@ZDEnvTestResult,");
			strSql.Append("PassNum=@PassNum,");
			strSql.Append("DefectNum=@DefectNum,");
			strSql.Append("DefectCode=@DefectCode,");
			strSql.Append("VerifyResult=@VerifyResult,");
			strSql.Append("Inspector=@Inspector,");
			strSql.Append("Auditer=@Auditer,");
			strSql.Append("Approver=@Approver");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ICPReporter", SqlDbType.Int,4),
					new SqlParameter("@ZDEnvTestResult", SqlDbType.Int,4),
					new SqlParameter("@PassNum", SqlDbType.NVarChar,50),
					new SqlParameter("@DefectNum", SqlDbType.NVarChar,50),
					new SqlParameter("@DefectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@VerifyResult", SqlDbType.Int,4),
					new SqlParameter("@Inspector", SqlDbType.NVarChar,50),
					new SqlParameter("@Auditer", SqlDbType.NVarChar,50),
					new SqlParameter("@Approver", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ICPReporter;
			parameters[1].Value = model.ZDEnvTestResult;
			parameters[2].Value = model.PassNum;
			parameters[3].Value = model.DefectNum;
			parameters[4].Value = model.DefectCode;
			parameters[5].Value = model.VerifyResult;
			parameters[6].Value = model.Inspector;
			parameters[7].Value = model.Auditer;
			parameters[8].Value = model.Approver;
			parameters[9].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Report_Footer ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Report_Footer ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public MesWeb.Model.T_Report_Footer GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ICPReporter,ZDEnvTestResult,PassNum,DefectNum,DefectCode,VerifyResult,Inspector,Auditer,Approver from T_Report_Footer ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MesWeb.Model.T_Report_Footer model=new MesWeb.Model.T_Report_Footer();
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
		public MesWeb.Model.T_Report_Footer DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Report_Footer model=new MesWeb.Model.T_Report_Footer();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ICPReporter"]!=null && row["ICPReporter"].ToString()!="")
				{
					model.ICPReporter=int.Parse(row["ICPReporter"].ToString());
				}
				if(row["ZDEnvTestResult"]!=null && row["ZDEnvTestResult"].ToString()!="")
				{
					model.ZDEnvTestResult=int.Parse(row["ZDEnvTestResult"].ToString());
				}
				if(row["PassNum"]!=null)
				{
					model.PassNum=row["PassNum"].ToString();
				}
				if(row["DefectNum"]!=null)
				{
					model.DefectNum=row["DefectNum"].ToString();
				}
				if(row["DefectCode"]!=null)
				{
					model.DefectCode=row["DefectCode"].ToString();
				}
				if(row["VerifyResult"]!=null && row["VerifyResult"].ToString()!="")
				{
					model.VerifyResult=int.Parse(row["VerifyResult"].ToString());
				}
				if(row["Inspector"]!=null)
				{
					model.Inspector=row["Inspector"].ToString();
				}
				if(row["Auditer"]!=null)
				{
					model.Auditer=row["Auditer"].ToString();
				}
				if(row["Approver"]!=null)
				{
					model.Approver=row["Approver"].ToString();
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
			strSql.Append("select Id,ICPReporter,ZDEnvTestResult,PassNum,DefectNum,DefectCode,VerifyResult,Inspector,Auditer,Approver ");
			strSql.Append(" FROM T_Report_Footer ");
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
			strSql.Append(" Id,ICPReporter,ZDEnvTestResult,PassNum,DefectNum,DefectCode,VerifyResult,Inspector,Auditer,Approver ");
			strSql.Append(" FROM T_Report_Footer ");
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
			strSql.Append("select count(1) FROM T_Report_Footer ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from T_Report_Footer T ");
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
			parameters[0].Value = "T_Report_Footer";
			parameters[1].Value = "Id";
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

