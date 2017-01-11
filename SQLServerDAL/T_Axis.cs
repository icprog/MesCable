
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Axis
	/// </summary>
	public partial class T_Axis:IT_Axis
	{
		public T_Axis()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AxisID", "T_Axis"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AxisID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Axis");
			strSql.Append(" where AxisID=@AxisID");
			SqlParameter[] parameters = {
					new SqlParameter("@AxisID", SqlDbType.Int,4)
			};
			parameters[0].Value = AxisID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_Axis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Axis(");
			strSql.Append("CodeNumber,Axis_No,DateTime,comment,Operator)");
			strSql.Append(" values (");
			strSql.Append("@CodeNumber,@Axis_No,@DateTime,@comment,@Operator)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@comment", SqlDbType.NVarChar,50),
					new SqlParameter("@Operator", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.CodeNumber;
			parameters[1].Value = model.Axis_No;
			parameters[2].Value = model.DateTime;
			parameters[3].Value = model.comment;
			parameters[4].Value = model.Operator;

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
		public bool Update(MesWeb.Model.T_Axis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Axis set ");
			strSql.Append("CodeNumber=@CodeNumber,");
			strSql.Append("Axis_No=@Axis_No,");
			strSql.Append("DateTime=@DateTime,");
			strSql.Append("comment=@comment,");
			strSql.Append("Operator=@Operator");
			strSql.Append(" where AxisID=@AxisID");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@comment", SqlDbType.NVarChar,50),
					new SqlParameter("@Operator", SqlDbType.NVarChar,50),
					new SqlParameter("@AxisID", SqlDbType.Int,4)};
			parameters[0].Value = model.CodeNumber;
			parameters[1].Value = model.Axis_No;
			parameters[2].Value = model.DateTime;
			parameters[3].Value = model.comment;
			parameters[4].Value = model.Operator;
			parameters[5].Value = model.AxisID;

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
		public bool Delete(int AxisID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Axis ");
			strSql.Append(" where AxisID=@AxisID");
			SqlParameter[] parameters = {
					new SqlParameter("@AxisID", SqlDbType.Int,4)
			};
			parameters[0].Value = AxisID;

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
		public bool DeleteList(string AxisIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Axis ");
			strSql.Append(" where AxisID in ("+AxisIDlist + ")  ");
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
		public MesWeb.Model.T_Axis GetModel(int AxisID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AxisID,CodeNumber,Axis_No,DateTime,comment,Operator from T_Axis ");
			strSql.Append(" where AxisID=@AxisID");
			SqlParameter[] parameters = {
					new SqlParameter("@AxisID", SqlDbType.Int,4)
			};
			parameters[0].Value = AxisID;

			MesWeb.Model.T_Axis model=new MesWeb.Model.T_Axis();
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
		public MesWeb.Model.T_Axis DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Axis model=new MesWeb.Model.T_Axis();
			if (row != null)
			{
				if(row["AxisID"]!=null && row["AxisID"].ToString()!="")
				{
					model.AxisID=int.Parse(row["AxisID"].ToString());
				}
				if(row["CodeNumber"]!=null)
				{
					model.CodeNumber=row["CodeNumber"].ToString();
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
				}
				if(row["comment"]!=null)
				{
					model.comment=row["comment"].ToString();
				}
				if(row["Operator"]!=null)
				{
					model.Operator=row["Operator"].ToString();
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
			strSql.Append("select AxisID,CodeNumber,Axis_No,DateTime,comment,Operator ");
			strSql.Append(" FROM T_Axis ");
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
			strSql.Append(" AxisID,CodeNumber,Axis_No,DateTime,comment,Operator ");
			strSql.Append(" FROM T_Axis ");
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
			strSql.Append("select count(1) FROM T_Axis ");
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
				strSql.Append("order by T.AxisID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Axis T ");
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
			parameters[0].Value = "T_Axis";
			parameters[1].Value = "AxisID";
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

