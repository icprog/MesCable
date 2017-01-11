
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_MaterialOutput
	/// </summary>
	public partial class T_MaterialOutput:IT_MaterialOutput
	{
		public T_MaterialOutput()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MaterialOutputID", "T_MaterialOutput"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MaterialOutputID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_MaterialOutput");
			strSql.Append(" where MaterialOutputID=@MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialOutputID", SqlDbType.Int,4)
			};
			parameters[0].Value = MaterialOutputID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_MaterialOutput model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_MaterialOutput(");
			strSql.Append("MaterialID,MaterialNum,GnerateTime,EmployeeID,Weight,Color,Certificate)");
			strSql.Append(" values (");
			strSql.Append("@MaterialID,@MaterialNum,@GnerateTime,@EmployeeID,@Weight,@Color,@Certificate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.Int,4),
					new SqlParameter("@MaterialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@GnerateTime", SqlDbType.DateTime),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@Weight", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Certificate", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MaterialID;
			parameters[1].Value = model.MaterialNum;
			parameters[2].Value = model.GnerateTime;
			parameters[3].Value = model.EmployeeID;
			parameters[4].Value = model.Weight;
			parameters[5].Value = model.Color;
			parameters[6].Value = model.Certificate;

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
		public bool Update(MesWeb.Model.T_MaterialOutput model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_MaterialOutput set ");
			strSql.Append("MaterialID=@MaterialID,");
			strSql.Append("MaterialNum=@MaterialNum,");
			strSql.Append("GnerateTime=@GnerateTime,");
			strSql.Append("EmployeeID=@EmployeeID,");
			strSql.Append("Weight=@Weight,");
			strSql.Append("Color=@Color,");
			strSql.Append("Certificate=@Certificate");
			strSql.Append(" where MaterialOutputID=@MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.Int,4),
					new SqlParameter("@MaterialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@GnerateTime", SqlDbType.DateTime),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@Weight", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Certificate", SqlDbType.NVarChar,50),
					new SqlParameter("@MaterialOutputID", SqlDbType.Int,4)};
			parameters[0].Value = model.MaterialID;
			parameters[1].Value = model.MaterialNum;
			parameters[2].Value = model.GnerateTime;
			parameters[3].Value = model.EmployeeID;
			parameters[4].Value = model.Weight;
			parameters[5].Value = model.Color;
			parameters[6].Value = model.Certificate;
			parameters[7].Value = model.MaterialOutputID;

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
		public bool Delete(int MaterialOutputID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID=@MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialOutputID", SqlDbType.Int,4)
			};
			parameters[0].Value = MaterialOutputID;

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
		public bool DeleteList(string MaterialOutputIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID in ("+MaterialOutputIDlist + ")  ");
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
		public MesWeb.Model.T_MaterialOutput GetModel(int MaterialOutputID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MaterialOutputID,MaterialID,MaterialNum,GnerateTime,EmployeeID,Weight,Color,Certificate from T_MaterialOutput ");
			strSql.Append(" where MaterialOutputID=@MaterialOutputID");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialOutputID", SqlDbType.Int,4)
			};
			parameters[0].Value = MaterialOutputID;

			MesWeb.Model.T_MaterialOutput model=new MesWeb.Model.T_MaterialOutput();
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
		public MesWeb.Model.T_MaterialOutput DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_MaterialOutput model=new MesWeb.Model.T_MaterialOutput();
			if (row != null)
			{
				if(row["MaterialOutputID"]!=null && row["MaterialOutputID"].ToString()!="")
				{
					model.MaterialOutputID=int.Parse(row["MaterialOutputID"].ToString());
				}
				if(row["MaterialID"]!=null && row["MaterialID"].ToString()!="")
				{
					model.MaterialID=int.Parse(row["MaterialID"].ToString());
				}
				if(row["MaterialNum"]!=null)
				{
					model.MaterialNum=row["MaterialNum"].ToString();
				}
				if(row["GnerateTime"]!=null && row["GnerateTime"].ToString()!="")
				{
					model.GnerateTime=DateTime.Parse(row["GnerateTime"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["Weight"]!=null)
				{
					model.Weight=row["Weight"].ToString();
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["Certificate"]!=null)
				{
					model.Certificate=row["Certificate"].ToString();
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
			strSql.Append("select MaterialOutputID,MaterialID,MaterialNum,GnerateTime,EmployeeID,Weight,Color,Certificate ");
			strSql.Append(" FROM T_MaterialOutput ");
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
			strSql.Append(" MaterialOutputID,MaterialID,MaterialNum,GnerateTime,EmployeeID,Weight,Color,Certificate ");
			strSql.Append(" FROM T_MaterialOutput ");
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
			strSql.Append("select count(1) FROM T_MaterialOutput ");
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
				strSql.Append("order by T.MaterialOutputID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MaterialOutput T ");
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
			parameters[0].Value = "T_MaterialOutput";
			parameters[1].Value = "MaterialOutputID";
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

