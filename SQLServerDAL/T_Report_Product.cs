
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Report_Product
	/// </summary>
	public partial class T_Report_Product:IT_Report_Product
	{
		public T_Report_Product()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_Report_Product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Product");
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
		public int Add(MesWeb.Model.T_Report_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Product(");
			strSql.Append("Code,VolNum,SpecNum,Num,StandardId,ActualId,Appearance,CheckResult,InputDate,Supplier)");
			strSql.Append(" values (");
			strSql.Append("@Code,@VolNum,@SpecNum,@Num,@StandardId,@ActualId,@Appearance,@CheckResult,@InputDate,@Supplier)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@VolNum", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Num", SqlDbType.NVarChar,50),
					new SqlParameter("@StandardId", SqlDbType.Int,4),
					new SqlParameter("@ActualId", SqlDbType.Int,4),
					new SqlParameter("@Appearance", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckResult", SqlDbType.NVarChar,50),
					new SqlParameter("@InputDate", SqlDbType.DateTime),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.VolNum;
			parameters[2].Value = model.SpecNum;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.StandardId;
			parameters[5].Value = model.ActualId;
			parameters[6].Value = model.Appearance;
			parameters[7].Value = model.CheckResult;
			parameters[8].Value = model.InputDate;
			parameters[9].Value = model.Supplier;

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
		public bool Update(MesWeb.Model.T_Report_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Product set ");
			strSql.Append("Code=@Code,");
			strSql.Append("VolNum=@VolNum,");
			strSql.Append("SpecNum=@SpecNum,");
			strSql.Append("Num=@Num,");
			strSql.Append("StandardId=@StandardId,");
			strSql.Append("ActualId=@ActualId,");
			strSql.Append("Appearance=@Appearance,");
			strSql.Append("CheckResult=@CheckResult,");
			strSql.Append("InputDate=@InputDate,");
			strSql.Append("Supplier=@Supplier");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@VolNum", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Num", SqlDbType.NVarChar,50),
					new SqlParameter("@StandardId", SqlDbType.Int,4),
					new SqlParameter("@ActualId", SqlDbType.Int,4),
					new SqlParameter("@Appearance", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckResult", SqlDbType.NVarChar,50),
					new SqlParameter("@InputDate", SqlDbType.DateTime),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.VolNum;
			parameters[2].Value = model.SpecNum;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.StandardId;
			parameters[5].Value = model.ActualId;
			parameters[6].Value = model.Appearance;
			parameters[7].Value = model.CheckResult;
			parameters[8].Value = model.InputDate;
			parameters[9].Value = model.Supplier;
			parameters[10].Value = model.Id;

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
			strSql.Append("delete from T_Report_Product ");
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
			strSql.Append("delete from T_Report_Product ");
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
		public MesWeb.Model.T_Report_Product GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Code,VolNum,SpecNum,Num,StandardId,ActualId,Appearance,CheckResult,InputDate,Supplier from T_Report_Product ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MesWeb.Model.T_Report_Product model=new MesWeb.Model.T_Report_Product();
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
		public MesWeb.Model.T_Report_Product DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Report_Product model=new MesWeb.Model.T_Report_Product();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["VolNum"]!=null)
				{
					model.VolNum=row["VolNum"].ToString();
				}
				if(row["SpecNum"]!=null)
				{
					model.SpecNum=row["SpecNum"].ToString();
				}
				if(row["Num"]!=null)
				{
					model.Num=row["Num"].ToString();
				}
				if(row["StandardId"]!=null && row["StandardId"].ToString()!="")
				{
					model.StandardId=int.Parse(row["StandardId"].ToString());
				}
				if(row["ActualId"]!=null && row["ActualId"].ToString()!="")
				{
					model.ActualId=int.Parse(row["ActualId"].ToString());
				}
				if(row["Appearance"]!=null)
				{
					model.Appearance=row["Appearance"].ToString();
				}
				if(row["CheckResult"]!=null)
				{
					model.CheckResult=row["CheckResult"].ToString();
				}
				if(row["InputDate"]!=null && row["InputDate"].ToString()!="")
				{
					model.InputDate=DateTime.Parse(row["InputDate"].ToString());
				}
				if(row["Supplier"]!=null)
				{
					model.Supplier=row["Supplier"].ToString();
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
			strSql.Append("select Id,Code,VolNum,SpecNum,Num,StandardId,ActualId,Appearance,CheckResult,InputDate,Supplier ");
			strSql.Append(" FROM T_Report_Product ");
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
			strSql.Append(" Id,Code,VolNum,SpecNum,Num,StandardId,ActualId,Appearance,CheckResult,InputDate,Supplier ");
			strSql.Append(" FROM T_Report_Product ");
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
			strSql.Append("select count(1) FROM T_Report_Product ");
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
			strSql.Append(")AS Row, T.*  from T_Report_Product T ");
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
			parameters[0].Value = "T_Report_Product";
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

