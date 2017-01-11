
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Specification
	/// </summary>
	public partial class T_Specification:IT_Specification
	{
		public T_Specification()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SpecificationID", "T_Specification"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SpecificationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Specification");
			strSql.Append(" where SpecificationID=@SpecificationID");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecificationID", SqlDbType.Int,4)
			};
			parameters[0].Value = SpecificationID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_Specification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Specification(");
			strSql.Append("SpecificationTypeID,SpecificationName,SpecificationScale,SpecificationColor,ODMax,ODMin,SpecificationPrice)");
			strSql.Append(" values (");
			strSql.Append("@SpecificationTypeID,@SpecificationName,@SpecificationScale,@SpecificationColor,@ODMax,@ODMin,@SpecificationPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecificationTypeID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationName", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecificationScale", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecificationColor", SqlDbType.NChar,10),
					new SqlParameter("@ODMax", SqlDbType.Float,8),
					new SqlParameter("@ODMin", SqlDbType.Float,8),
					new SqlParameter("@SpecificationPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SpecificationTypeID;
			parameters[1].Value = model.SpecificationName;
			parameters[2].Value = model.SpecificationScale;
			parameters[3].Value = model.SpecificationColor;
			parameters[4].Value = model.ODMax;
			parameters[5].Value = model.ODMin;
			parameters[6].Value = model.SpecificationPrice;

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
		public bool Update(MesWeb.Model.T_Specification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Specification set ");
			strSql.Append("SpecificationTypeID=@SpecificationTypeID,");
			strSql.Append("SpecificationName=@SpecificationName,");
			strSql.Append("SpecificationScale=@SpecificationScale,");
			strSql.Append("SpecificationColor=@SpecificationColor,");
			strSql.Append("ODMax=@ODMax,");
			strSql.Append("ODMin=@ODMin,");
			strSql.Append("SpecificationPrice=@SpecificationPrice");
			strSql.Append(" where SpecificationID=@SpecificationID");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecificationTypeID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationName", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecificationScale", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecificationColor", SqlDbType.NChar,10),
					new SqlParameter("@ODMax", SqlDbType.Float,8),
					new SqlParameter("@ODMin", SqlDbType.Float,8),
					new SqlParameter("@SpecificationPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SpecificationID", SqlDbType.Int,4)};
			parameters[0].Value = model.SpecificationTypeID;
			parameters[1].Value = model.SpecificationName;
			parameters[2].Value = model.SpecificationScale;
			parameters[3].Value = model.SpecificationColor;
			parameters[4].Value = model.ODMax;
			parameters[5].Value = model.ODMin;
			parameters[6].Value = model.SpecificationPrice;
			parameters[7].Value = model.SpecificationID;

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
		public bool Delete(int SpecificationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Specification ");
			strSql.Append(" where SpecificationID=@SpecificationID");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecificationID", SqlDbType.Int,4)
			};
			parameters[0].Value = SpecificationID;

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
		public bool DeleteList(string SpecificationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Specification ");
			strSql.Append(" where SpecificationID in ("+SpecificationIDlist + ")  ");
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
		public MesWeb.Model.T_Specification GetModel(int SpecificationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SpecificationID,SpecificationTypeID,SpecificationName,SpecificationScale,SpecificationColor,ODMax,ODMin,SpecificationPrice from T_Specification ");
			strSql.Append(" where SpecificationID=@SpecificationID");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecificationID", SqlDbType.Int,4)
			};
			parameters[0].Value = SpecificationID;

			MesWeb.Model.T_Specification model=new MesWeb.Model.T_Specification();
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
		public MesWeb.Model.T_Specification DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Specification model=new MesWeb.Model.T_Specification();
			if (row != null)
			{
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["SpecificationTypeID"]!=null && row["SpecificationTypeID"].ToString()!="")
				{
					model.SpecificationTypeID=int.Parse(row["SpecificationTypeID"].ToString());
				}
				if(row["SpecificationName"]!=null)
				{
					model.SpecificationName=row["SpecificationName"].ToString();
				}
				if(row["SpecificationScale"]!=null)
				{
					model.SpecificationScale=row["SpecificationScale"].ToString();
				}
				if(row["SpecificationColor"]!=null)
				{
					model.SpecificationColor=row["SpecificationColor"].ToString();
				}
				if(row["ODMax"]!=null && row["ODMax"].ToString()!="")
				{
					model.ODMax=decimal.Parse(row["ODMax"].ToString());
				}
				if(row["ODMin"]!=null && row["ODMin"].ToString()!="")
				{
					model.ODMin=decimal.Parse(row["ODMin"].ToString());
				}
				if(row["SpecificationPrice"]!=null && row["SpecificationPrice"].ToString()!="")
				{
					model.SpecificationPrice=decimal.Parse(row["SpecificationPrice"].ToString());
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
			strSql.Append("select SpecificationID,SpecificationTypeID,SpecificationName,SpecificationScale,SpecificationColor,ODMax,ODMin,SpecificationPrice ");
			strSql.Append(" FROM T_Specification ");
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
			strSql.Append(" SpecificationID,SpecificationTypeID,SpecificationName,SpecificationScale,SpecificationColor,ODMax,ODMin,SpecificationPrice ");
			strSql.Append(" FROM T_Specification ");
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
			strSql.Append("select count(1) FROM T_Specification ");
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
				strSql.Append("order by T.SpecificationID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Specification T ");
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
			parameters[0].Value = "T_Specification";
			parameters[1].Value = "SpecificationID";
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

