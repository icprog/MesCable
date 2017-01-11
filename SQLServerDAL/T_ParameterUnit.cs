
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_ParameterUnit
	/// </summary>
	public partial class T_ParameterUnit:IT_ParameterUnit
	{
		public T_ParameterUnit()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ParameterUnitID", "T_ParameterUnit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ParameterUnitID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterUnitID;

			int result= DbHelperSQL.RunProcedure("T_ParameterUnit_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_ParameterUnit model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4),
					new SqlParameter("@ParameterUnitName", SqlDbType.VarChar,50),
					new SqlParameter("@ParameterUnitSymbol", SqlDbType.VarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.ParameterUnitName;
			parameters[2].Value = model.ParameterUnitSymbol;

			DbHelperSQL.RunProcedure("T_ParameterUnit_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_ParameterUnit model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4),
					new SqlParameter("@ParameterUnitName", SqlDbType.VarChar,50),
					new SqlParameter("@ParameterUnitSymbol", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ParameterUnitID;
			parameters[1].Value = model.ParameterUnitName;
			parameters[2].Value = model.ParameterUnitSymbol;

			DbHelperSQL.RunProcedure("T_ParameterUnit_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
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
		public bool Delete(int ParameterUnitID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterUnitID;

			DbHelperSQL.RunProcedure("T_ParameterUnit_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
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
		public bool DeleteList(string ParameterUnitIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ParameterUnit ");
			strSql.Append(" where ParameterUnitID in ("+ParameterUnitIDlist + ")  ");
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
		public MesWeb.Model.T_ParameterUnit GetModel(int ParameterUnitID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterUnitID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParameterUnitID;

			MesWeb.Model.T_ParameterUnit model=new MesWeb.Model.T_ParameterUnit();
			DataSet ds= DbHelperSQL.RunProcedure("T_ParameterUnit_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_ParameterUnit DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ParameterUnit model=new MesWeb.Model.T_ParameterUnit();
			if (row != null)
			{
				if(row["ParameterUnitID"]!=null && row["ParameterUnitID"].ToString()!="")
				{
					model.ParameterUnitID=int.Parse(row["ParameterUnitID"].ToString());
				}
				if(row["ParameterUnitName"]!=null)
				{
					model.ParameterUnitName=row["ParameterUnitName"].ToString();
				}
				if(row["ParameterUnitSymbol"]!=null)
				{
					model.ParameterUnitSymbol=row["ParameterUnitSymbol"].ToString();
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
			strSql.Append("select ParameterUnitID,ParameterUnitName,ParameterUnitSymbol ");
			strSql.Append(" FROM T_ParameterUnit ");
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
			strSql.Append(" ParameterUnitID,ParameterUnitName,ParameterUnitSymbol ");
			strSql.Append(" FROM T_ParameterUnit ");
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
			strSql.Append("select count(1) FROM T_ParameterUnit ");
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
				strSql.Append("order by T.ParameterUnitID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ParameterUnit T ");
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
			parameters[0].Value = "T_ParameterUnit";
			parameters[1].Value = "ParameterUnitID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

