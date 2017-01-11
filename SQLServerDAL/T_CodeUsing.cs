
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_CodeUsing
	/// </summary>
	public partial class T_CodeUsing:IT_CodeUsing
	{
		public T_CodeUsing()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CodeID", "T_CodeUsing"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CodeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CodeUsing");
			strSql.Append(" where CodeID=@CodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = CodeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_CodeUsing model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CodeUsing(");
			strSql.Append("CodeNumber,Axis_No,GeneratorTime,MachineID)");
			strSql.Append(" values (");
			strSql.Append("@CodeNumber,@Axis_No,@GeneratorTime,@MachineID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@GeneratorTime", SqlDbType.DateTime),
					new SqlParameter("@MachineID", SqlDbType.Int,4)};
			parameters[0].Value = model.CodeNumber;
			parameters[1].Value = model.Axis_No;
			parameters[2].Value = model.GeneratorTime;
			parameters[3].Value = model.MachineID;

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
		public bool Update(MesWeb.Model.T_CodeUsing model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CodeUsing set ");
			strSql.Append("CodeNumber=@CodeNumber,");
			strSql.Append("Axis_No=@Axis_No,");
			strSql.Append("GeneratorTime=@GeneratorTime,");
			strSql.Append("MachineID=@MachineID");
			strSql.Append(" where CodeID=@CodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@GeneratorTime", SqlDbType.DateTime),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@CodeID", SqlDbType.Int,4)};
			parameters[0].Value = model.CodeNumber;
			parameters[1].Value = model.Axis_No;
			parameters[2].Value = model.GeneratorTime;
			parameters[3].Value = model.MachineID;
			parameters[4].Value = model.CodeID;

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
		public bool Delete(int CodeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CodeUsing ");
			strSql.Append(" where CodeID=@CodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = CodeID;

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
		public bool DeleteList(string CodeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CodeUsing ");
			strSql.Append(" where CodeID in ("+CodeIDlist + ")  ");
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
		public MesWeb.Model.T_CodeUsing GetModel(int CodeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CodeID,CodeNumber,Axis_No,GeneratorTime,MachineID from T_CodeUsing ");
			strSql.Append(" where CodeID=@CodeID");
			SqlParameter[] parameters = {
					new SqlParameter("@CodeID", SqlDbType.Int,4)
			};
			parameters[0].Value = CodeID;

			MesWeb.Model.T_CodeUsing model=new MesWeb.Model.T_CodeUsing();
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
		public MesWeb.Model.T_CodeUsing DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CodeUsing model=new MesWeb.Model.T_CodeUsing();
			if (row != null)
			{
				if(row["CodeID"]!=null && row["CodeID"].ToString()!="")
				{
					model.CodeID=int.Parse(row["CodeID"].ToString());
				}
				if(row["CodeNumber"]!=null)
				{
					model.CodeNumber=row["CodeNumber"].ToString();
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["GeneratorTime"]!=null && row["GeneratorTime"].ToString()!="")
				{
					model.GeneratorTime=DateTime.Parse(row["GeneratorTime"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
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
			strSql.Append("select CodeID,CodeNumber,Axis_No,GeneratorTime,MachineID ");
			strSql.Append(" FROM T_CodeUsing ");
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
			strSql.Append(" CodeID,CodeNumber,Axis_No,GeneratorTime,MachineID ");
			strSql.Append(" FROM T_CodeUsing ");
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
			strSql.Append("select count(1) FROM T_CodeUsing ");
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
				strSql.Append("order by T.CodeID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CodeUsing T ");
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
			parameters[0].Value = "T_CodeUsing";
			parameters[1].Value = "CodeID";
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

