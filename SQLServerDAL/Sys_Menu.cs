
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Sys_Menu
	/// </summary>
	public partial class Sys_Menu:ISys_Menu
	{
		public Sys_Menu()
		{}
		#region  Method


		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.Sys_Menu model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_id", SqlDbType.Int,4),
					new SqlParameter("@Menu_name", SqlDbType.VarChar,255),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@parentname", SqlDbType.VarChar,255),
					new SqlParameter("@App_id", SqlDbType.Int,4),
					new SqlParameter("@Menu_url", SqlDbType.VarChar,255),
					new SqlParameter("@Menu_icon", SqlDbType.VarChar,50),
					new SqlParameter("@Menu_handler", SqlDbType.VarChar,50),
					new SqlParameter("@Menu_order", SqlDbType.Int,4),
					new SqlParameter("@Menu_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Menu_id;
			parameters[1].Value = model.Menu_name;
			parameters[2].Value = model.parentid;
			parameters[3].Value = model.parentname;
			parameters[4].Value = model.App_id;
			parameters[5].Value = model.Menu_url;
			parameters[6].Value = model.Menu_icon;
			parameters[7].Value = model.Menu_handler;
			parameters[8].Value = model.Menu_order;
			parameters[9].Value = model.Menu_type;

			DbHelperSQL.RunProcedure("Sys_Menu_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.Sys_Menu model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_id", SqlDbType.Int,4),
					new SqlParameter("@Menu_name", SqlDbType.VarChar,255),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@parentname", SqlDbType.VarChar,255),
					new SqlParameter("@App_id", SqlDbType.Int,4),
					new SqlParameter("@Menu_url", SqlDbType.VarChar,255),
					new SqlParameter("@Menu_icon", SqlDbType.VarChar,50),
					new SqlParameter("@Menu_handler", SqlDbType.VarChar,50),
					new SqlParameter("@Menu_order", SqlDbType.Int,4),
					new SqlParameter("@Menu_type", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Menu_id;
			parameters[1].Value = model.Menu_name;
			parameters[2].Value = model.parentid;
			parameters[3].Value = model.parentname;
			parameters[4].Value = model.App_id;
			parameters[5].Value = model.Menu_url;
			parameters[6].Value = model.Menu_icon;
			parameters[7].Value = model.Menu_handler;
			parameters[8].Value = model.Menu_order;
			parameters[9].Value = model.Menu_type;

			DbHelperSQL.RunProcedure("Sys_Menu_Update",parameters,out rowsAffected);
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
		public bool Delete(int Menu_id)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Menu_id;

			DbHelperSQL.RunProcedure("Sys_Menu_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string Menu_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Menu ");
			strSql.Append(" where Menu_id in ("+Menu_idlist + ")  ");
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
		public MesWeb.Model.Sys_Menu GetModel(int Menu_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_id", SqlDbType.Int,4)
			};
			parameters[0].Value = Menu_id;

			MesWeb.Model.Sys_Menu model=new MesWeb.Model.Sys_Menu();
			DataSet ds= DbHelperSQL.RunProcedure("Sys_Menu_GetModel",parameters,"ds");
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
		public MesWeb.Model.Sys_Menu DataRowToModel(DataRow row)
		{
			MesWeb.Model.Sys_Menu model=new MesWeb.Model.Sys_Menu();
			if (row != null)
			{
				if(row["Menu_id"]!=null && row["Menu_id"].ToString()!="")
				{
					model.Menu_id=int.Parse(row["Menu_id"].ToString());
				}
				if(row["Menu_name"]!=null)
				{
					model.Menu_name=row["Menu_name"].ToString();
				}
				if(row["parentid"]!=null && row["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(row["parentid"].ToString());
				}
				if(row["parentname"]!=null)
				{
					model.parentname=row["parentname"].ToString();
				}
				if(row["App_id"]!=null && row["App_id"].ToString()!="")
				{
					model.App_id=int.Parse(row["App_id"].ToString());
				}
				if(row["Menu_url"]!=null)
				{
					model.Menu_url=row["Menu_url"].ToString();
				}
				if(row["Menu_icon"]!=null)
				{
					model.Menu_icon=row["Menu_icon"].ToString();
				}
				if(row["Menu_handler"]!=null)
				{
					model.Menu_handler=row["Menu_handler"].ToString();
				}
				if(row["Menu_order"]!=null && row["Menu_order"].ToString()!="")
				{
					model.Menu_order=int.Parse(row["Menu_order"].ToString());
				}
				if(row["Menu_type"]!=null)
				{
					model.Menu_type=row["Menu_type"].ToString();
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
			strSql.Append("select Menu_id,Menu_name,parentid,parentname,App_id,Menu_url,Menu_icon,Menu_handler,Menu_order,Menu_type ");
			strSql.Append(" FROM Sys_Menu ");
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
			strSql.Append(" Menu_id,Menu_name,parentid,parentname,App_id,Menu_url,Menu_icon,Menu_handler,Menu_order,Menu_type ");
			strSql.Append(" FROM Sys_Menu ");
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
			strSql.Append("select count(1) FROM Sys_Menu ");
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
				strSql.Append("order by T.Menu_id desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Menu T ");
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
			parameters[0].Value = "Sys_Menu";
			parameters[1].Value = "Menu_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  Method
        #region  MethodEx

        public bool DeleteAll() {
            string sqlStr = "delete from Sys_Menu where 1=1";
            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }

        public int GetMaxId() {
            return DbHelperSQL.GetMaxID("Menu_id","Sys_Menu");
        }
        #endregion  MethodEx
    }
}

