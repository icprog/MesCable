
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Report_Value
	/// </summary>
	public partial class T_Report_Value:IT_Report_Value
	{
		public T_Report_Value()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_Report_Value"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Value");
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
		public int Add(MesWeb.Model.T_Report_Value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Value(");
			strSql.Append("Unit,Standard,Actual1,Actual2,Actual3,Actual4,Actual5,Result)");
			strSql.Append(" values (");
			strSql.Append("@Unit,@Standard,@Actual1,@Actual2,@Actual3,@Actual4,@Actual5,@Result)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual1", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual2", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual3", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual4", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual5", SqlDbType.NVarChar,50),
					new SqlParameter("@Result", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Unit;
			parameters[1].Value = model.Standard;
			parameters[2].Value = model.Actual1;
			parameters[3].Value = model.Actual2;
			parameters[4].Value = model.Actual3;
			parameters[5].Value = model.Actual4;
			parameters[6].Value = model.Actual5;
			parameters[7].Value = model.Result;

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
		public bool Update(MesWeb.Model.T_Report_Value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Value set ");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Standard=@Standard,");
			strSql.Append("Actual1=@Actual1,");
			strSql.Append("Actual2=@Actual2,");
			strSql.Append("Actual3=@Actual3,");
			strSql.Append("Actual4=@Actual4,");
			strSql.Append("Actual5=@Actual5,");
			strSql.Append("Result=@Result");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual1", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual2", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual3", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual4", SqlDbType.NVarChar,50),
					new SqlParameter("@Actual5", SqlDbType.NVarChar,50),
					new SqlParameter("@Result", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Unit;
			parameters[1].Value = model.Standard;
			parameters[2].Value = model.Actual1;
			parameters[3].Value = model.Actual2;
			parameters[4].Value = model.Actual3;
			parameters[5].Value = model.Actual4;
			parameters[6].Value = model.Actual5;
			parameters[7].Value = model.Result;
			parameters[8].Value = model.Id;

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
			strSql.Append("delete from T_Report_Value ");
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
			strSql.Append("delete from T_Report_Value ");
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
		public MesWeb.Model.T_Report_Value GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Unit,Standard,Actual1,Actual2,Actual3,Actual4,Actual5,Result from T_Report_Value ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MesWeb.Model.T_Report_Value model=new MesWeb.Model.T_Report_Value();
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
		public MesWeb.Model.T_Report_Value DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Report_Value model=new MesWeb.Model.T_Report_Value();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Standard"]!=null)
				{
					model.Standard=row["Standard"].ToString();
				}
				if(row["Actual1"]!=null)
				{
					model.Actual1=row["Actual1"].ToString();
				}
				if(row["Actual2"]!=null)
				{
					model.Actual2=row["Actual2"].ToString();
				}
				if(row["Actual3"]!=null)
				{
					model.Actual3=row["Actual3"].ToString();
				}
				if(row["Actual4"]!=null)
				{
					model.Actual4=row["Actual4"].ToString();
				}
				if(row["Actual5"]!=null)
				{
					model.Actual5=row["Actual5"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
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
			strSql.Append("select Id,Unit,Standard,Actual1,Actual2,Actual3,Actual4,Actual5,Result ");
			strSql.Append(" FROM T_Report_Value ");
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
			strSql.Append(" Id,Unit,Standard,Actual1,Actual2,Actual3,Actual4,Actual5,Result ");
			strSql.Append(" FROM T_Report_Value ");
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
			strSql.Append("select count(1) FROM T_Report_Value ");
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
			strSql.Append(")AS Row, T.*  from T_Report_Value T ");
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
			parameters[0].Value = "T_Report_Value";
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

