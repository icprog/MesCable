
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Report_Product_Standard
	/// </summary>
	public partial class T_Report_Product_Standard:IT_Report_Product_Standard
	{
		public T_Report_Product_Standard()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_Report_Product_Standard"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Product_Standard");
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
		public int Add(MesWeb.Model.T_Report_Product_Standard model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Product_Standard(");
			strSql.Append("ConductorStruct,VerticalDia,EdgeDiaAvg,EdgeDiaMin,SheathAvg,SheathMin,Resistance,VoltageTest)");
			strSql.Append(" values (");
			strSql.Append("@ConductorStruct,@VerticalDia,@EdgeDiaAvg,@EdgeDiaMin,@SheathAvg,@SheathMin,@Resistance,@VoltageTest)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ConductorStruct", SqlDbType.NVarChar,50),
					new SqlParameter("@VerticalDia", SqlDbType.NVarChar,50),
					new SqlParameter("@EdgeDiaAvg", SqlDbType.NVarChar,50),
					new SqlParameter("@EdgeDiaMin", SqlDbType.NVarChar,50),
					new SqlParameter("@SheathAvg", SqlDbType.NVarChar,50),
					new SqlParameter("@SheathMin", SqlDbType.NVarChar,50),
					new SqlParameter("@Resistance", SqlDbType.NVarChar,50),
					new SqlParameter("@VoltageTest", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ConductorStruct;
			parameters[1].Value = model.VerticalDia;
			parameters[2].Value = model.EdgeDiaAvg;
			parameters[3].Value = model.EdgeDiaMin;
			parameters[4].Value = model.SheathAvg;
			parameters[5].Value = model.SheathMin;
			parameters[6].Value = model.Resistance;
			parameters[7].Value = model.VoltageTest;

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
		public bool Update(MesWeb.Model.T_Report_Product_Standard model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Product_Standard set ");
			strSql.Append("ConductorStruct=@ConductorStruct,");
			strSql.Append("VerticalDia=@VerticalDia,");
			strSql.Append("EdgeDiaAvg=@EdgeDiaAvg,");
			strSql.Append("EdgeDiaMin=@EdgeDiaMin,");
			strSql.Append("SheathAvg=@SheathAvg,");
			strSql.Append("SheathMin=@SheathMin,");
			strSql.Append("Resistance=@Resistance,");
			strSql.Append("VoltageTest=@VoltageTest");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ConductorStruct", SqlDbType.NVarChar,50),
					new SqlParameter("@VerticalDia", SqlDbType.NVarChar,50),
					new SqlParameter("@EdgeDiaAvg", SqlDbType.NVarChar,50),
					new SqlParameter("@EdgeDiaMin", SqlDbType.NVarChar,50),
					new SqlParameter("@SheathAvg", SqlDbType.NVarChar,50),
					new SqlParameter("@SheathMin", SqlDbType.NVarChar,50),
					new SqlParameter("@Resistance", SqlDbType.NVarChar,50),
					new SqlParameter("@VoltageTest", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ConductorStruct;
			parameters[1].Value = model.VerticalDia;
			parameters[2].Value = model.EdgeDiaAvg;
			parameters[3].Value = model.EdgeDiaMin;
			parameters[4].Value = model.SheathAvg;
			parameters[5].Value = model.SheathMin;
			parameters[6].Value = model.Resistance;
			parameters[7].Value = model.VoltageTest;
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
			strSql.Append("delete from T_Report_Product_Standard ");
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
			strSql.Append("delete from T_Report_Product_Standard ");
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
		public MesWeb.Model.T_Report_Product_Standard GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ConductorStruct,VerticalDia,EdgeDiaAvg,EdgeDiaMin,SheathAvg,SheathMin,Resistance,VoltageTest from T_Report_Product_Standard ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MesWeb.Model.T_Report_Product_Standard model=new MesWeb.Model.T_Report_Product_Standard();
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
		public MesWeb.Model.T_Report_Product_Standard DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Report_Product_Standard model=new MesWeb.Model.T_Report_Product_Standard();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ConductorStruct"]!=null)
				{
					model.ConductorStruct=row["ConductorStruct"].ToString();
				}
				if(row["VerticalDia"]!=null)
				{
					model.VerticalDia=row["VerticalDia"].ToString();
				}
				if(row["EdgeDiaAvg"]!=null)
				{
					model.EdgeDiaAvg=row["EdgeDiaAvg"].ToString();
				}
				if(row["EdgeDiaMin"]!=null)
				{
					model.EdgeDiaMin=row["EdgeDiaMin"].ToString();
				}
				if(row["SheathAvg"]!=null)
				{
					model.SheathAvg=row["SheathAvg"].ToString();
				}
				if(row["SheathMin"]!=null)
				{
					model.SheathMin=row["SheathMin"].ToString();
				}
				if(row["Resistance"]!=null)
				{
					model.Resistance=row["Resistance"].ToString();
				}
				if(row["VoltageTest"]!=null)
				{
					model.VoltageTest=row["VoltageTest"].ToString();
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
			strSql.Append("select Id,ConductorStruct,VerticalDia,EdgeDiaAvg,EdgeDiaMin,SheathAvg,SheathMin,Resistance,VoltageTest ");
			strSql.Append(" FROM T_Report_Product_Standard ");
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
			strSql.Append(" Id,ConductorStruct,VerticalDia,EdgeDiaAvg,EdgeDiaMin,SheathAvg,SheathMin,Resistance,VoltageTest ");
			strSql.Append(" FROM T_Report_Product_Standard ");
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
			strSql.Append("select count(1) FROM T_Report_Product_Standard ");
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
			strSql.Append(")AS Row, T.*  from T_Report_Product_Standard T ");
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
			parameters[0].Value = "T_Report_Product_Standard";
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

