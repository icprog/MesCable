
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Menu
	/// </summary>
	public partial class T_Menu:IT_Menu
	{
		public T_Menu()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MenuID", "T_Menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MenuID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuID;

			int result= DbHelperSQL.RunProcedure("T_Menu_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_Menu model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@MenuParentID", SqlDbType.Int,4),
					new SqlParameter("@MenuLevel", SqlDbType.Int,4),
					new SqlParameter("@MenuSeq", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuICON", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuRemark", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.MenuParentID;
			parameters[2].Value = model.MenuLevel;
			parameters[3].Value = model.MenuSeq;
			parameters[4].Value = model.MenuName;
			parameters[5].Value = model.MenuUrl;
			parameters[6].Value = model.MenuICON;
			parameters[7].Value = model.MenuRemark;

			DbHelperSQL.RunProcedure("T_Menu_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_Menu model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@MenuParentID", SqlDbType.Int,4),
					new SqlParameter("@MenuLevel", SqlDbType.Int,4),
					new SqlParameter("@MenuSeq", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuICON", SqlDbType.NVarChar,50),
					new SqlParameter("@MenuRemark", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MenuID;
			parameters[1].Value = model.MenuParentID;
			parameters[2].Value = model.MenuLevel;
			parameters[3].Value = model.MenuSeq;
			parameters[4].Value = model.MenuName;
			parameters[5].Value = model.MenuUrl;
			parameters[6].Value = model.MenuICON;
			parameters[7].Value = model.MenuRemark;

			DbHelperSQL.RunProcedure("T_Menu_Update",parameters,out rowsAffected);
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
		public bool Delete(int MenuID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuID;

			DbHelperSQL.RunProcedure("T_Menu_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string MenuIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Menu ");
			strSql.Append(" where MenuID in ("+MenuIDlist + ")  ");
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
		public MesWeb.Model.T_Menu GetModel(int MenuID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuID;

			MesWeb.Model.T_Menu model=new MesWeb.Model.T_Menu();
			DataSet ds= DbHelperSQL.RunProcedure("T_Menu_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_Menu DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Menu model=new MesWeb.Model.T_Menu();
			if (row != null)
			{
				if(row["MenuID"]!=null && row["MenuID"].ToString()!="")
				{
					model.MenuID=int.Parse(row["MenuID"].ToString());
				}
				if(row["MenuParentID"]!=null && row["MenuParentID"].ToString()!="")
				{
					model.MenuParentID=int.Parse(row["MenuParentID"].ToString());
				}
				if(row["MenuLevel"]!=null && row["MenuLevel"].ToString()!="")
				{
					model.MenuLevel=int.Parse(row["MenuLevel"].ToString());
				}
				if(row["MenuSeq"]!=null && row["MenuSeq"].ToString()!="")
				{
					model.MenuSeq=int.Parse(row["MenuSeq"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
				}
				if(row["MenuICON"]!=null)
				{
					model.MenuICON=row["MenuICON"].ToString();
				}
				if(row["MenuRemark"]!=null)
				{
					model.MenuRemark=row["MenuRemark"].ToString();
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
			strSql.Append("select MenuID,MenuParentID,MenuLevel,MenuSeq,MenuName,MenuUrl,MenuICON,MenuRemark ");
			strSql.Append(" FROM T_Menu ");
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
			strSql.Append(" MenuID,MenuParentID,MenuLevel,MenuSeq,MenuName,MenuUrl,MenuICON,MenuRemark ");
			strSql.Append(" FROM T_Menu ");
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
			strSql.Append("select count(1) FROM T_Menu ");
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
				strSql.Append("order by T.MenuID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Menu T ");
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
			parameters[0].Value = "T_Menu";
			parameters[1].Value = "MenuID";
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

