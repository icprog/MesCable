
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_LayoutType
	/// </summary>
	public partial class T_LayoutType:IT_LayoutType
	{
		public T_LayoutType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LayoutTtypeID", "T_LayoutType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LayoutTtypeID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutTtypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutTtypeID;

			int result= DbHelperSQL.RunProcedure("T_LayoutType_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_LayoutType model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutTtypeID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@AliasName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsExistTable", SqlDbType.Bit,1),
					new SqlParameter("@Type", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.AliasName;
			parameters[3].Value = model.IsExistTable;
			parameters[4].Value = model.Type;

			DbHelperSQL.RunProcedure("T_LayoutType_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_LayoutType model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutTtypeID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@AliasName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsExistTable", SqlDbType.Bit,1),
					new SqlParameter("@Type", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LayoutTtypeID;
			parameters[1].Value = model.TableName;
			parameters[2].Value = model.AliasName;
			parameters[3].Value = model.IsExistTable;
			parameters[4].Value = model.Type;

			DbHelperSQL.RunProcedure("T_LayoutType_Update",parameters,out rowsAffected);
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
		public bool Delete(int LayoutTtypeID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutTtypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutTtypeID;

			DbHelperSQL.RunProcedure("T_LayoutType_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string LayoutTtypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LayoutType ");
			strSql.Append(" where LayoutTtypeID in ("+LayoutTtypeIDlist + ")  ");
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
		public MesWeb.Model.T_LayoutType GetModel(int LayoutTtypeID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutTtypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutTtypeID;

			MesWeb.Model.T_LayoutType model=new MesWeb.Model.T_LayoutType();
			DataSet ds= DbHelperSQL.RunProcedure("T_LayoutType_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_LayoutType DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_LayoutType model=new MesWeb.Model.T_LayoutType();
			if (row != null)
			{
				if(row["LayoutTtypeID"]!=null && row["LayoutTtypeID"].ToString()!="")
				{
					model.LayoutTtypeID=int.Parse(row["LayoutTtypeID"].ToString());
				}
				if(row["TableName"]!=null)
				{
					model.TableName=row["TableName"].ToString();
				}
				if(row["AliasName"]!=null)
				{
					model.AliasName=row["AliasName"].ToString();
				}
				if(row["IsExistTable"]!=null && row["IsExistTable"].ToString()!="")
				{
					if((row["IsExistTable"].ToString()=="1")||(row["IsExistTable"].ToString().ToLower()=="true"))
					{
						model.IsExistTable=true;
					}
					else
					{
						model.IsExistTable=false;
					}
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
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
			strSql.Append("select LayoutTtypeID,TableName,AliasName,IsExistTable,Type ");
			strSql.Append(" FROM T_LayoutType ");
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
			strSql.Append(" LayoutTtypeID,TableName,AliasName,IsExistTable,Type ");
			strSql.Append(" FROM T_LayoutType ");
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
			strSql.Append("select count(1) FROM T_LayoutType ");
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
				strSql.Append("order by T.LayoutTtypeID desc");
			}
			strSql.Append(")AS Row, T.*  from T_LayoutType T ");
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
			parameters[0].Value = "T_LayoutType";
			parameters[1].Value = "LayoutTtypeID";
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

