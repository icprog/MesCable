
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Report_Plastic
	/// </summary>
	public partial class T_Report_Plastic:IT_Report_Plastic
	{
		public T_Report_Plastic()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_Report_Plastic"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report_Plastic");
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
		public int Add(MesWeb.Model.T_Report_Plastic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report_Plastic(");
			strSql.Append("Code,ReportHeaderId,ElecRateId,ElecStrengthId,MpaBeforeId,ElongBeforeId,AgingConditionId,MpaAfterId,ElongAfterId,MpaRateMaxId,ElongRateMaxId,AgingQualityLossId,ThermalStablityTimeId,BittleImpactTestId,ThermalDeformationId,OxyIndexId,SpecGravityId,ShoreHBTestId,ApperanceQualityId,PkgAndLabelId,ReportFooterId)");
			strSql.Append(" values (");
			strSql.Append("@Code,@ReportHeaderId,@ElecRateId,@ElecStrengthId,@MpaBeforeId,@ElongBeforeId,@AgingConditionId,@MpaAfterId,@ElongAfterId,@MpaRateMaxId,@ElongRateMaxId,@AgingQualityLossId,@ThermalStablityTimeId,@BittleImpactTestId,@ThermalDeformationId,@OxyIndexId,@SpecGravityId,@ShoreHBTestId,@ApperanceQualityId,@PkgAndLabelId,@ReportFooterId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ReportHeaderId", SqlDbType.Int,4),
					new SqlParameter("@ElecRateId", SqlDbType.Int,4),
					new SqlParameter("@ElecStrengthId", SqlDbType.Int,4),
					new SqlParameter("@MpaBeforeId", SqlDbType.Int,4),
					new SqlParameter("@ElongBeforeId", SqlDbType.Int,4),
					new SqlParameter("@AgingConditionId", SqlDbType.Int,4),
					new SqlParameter("@MpaAfterId", SqlDbType.Int,4),
					new SqlParameter("@ElongAfterId", SqlDbType.Int,4),
					new SqlParameter("@MpaRateMaxId", SqlDbType.Int,4),
					new SqlParameter("@ElongRateMaxId", SqlDbType.Int,4),
					new SqlParameter("@AgingQualityLossId", SqlDbType.Int,4),
					new SqlParameter("@ThermalStablityTimeId", SqlDbType.Int,4),
					new SqlParameter("@BittleImpactTestId", SqlDbType.Int,4),
					new SqlParameter("@ThermalDeformationId", SqlDbType.Int,4),
					new SqlParameter("@OxyIndexId", SqlDbType.Int,4),
					new SqlParameter("@SpecGravityId", SqlDbType.Int,4),
					new SqlParameter("@ShoreHBTestId", SqlDbType.Int,4),
					new SqlParameter("@ApperanceQualityId", SqlDbType.Int,4),
					new SqlParameter("@PkgAndLabelId", SqlDbType.Int,4),
					new SqlParameter("@ReportFooterId", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.ReportHeaderId;
			parameters[2].Value = model.ElecRateId;
			parameters[3].Value = model.ElecStrengthId;
			parameters[4].Value = model.MpaBeforeId;
			parameters[5].Value = model.ElongBeforeId;
			parameters[6].Value = model.AgingConditionId;
			parameters[7].Value = model.MpaAfterId;
			parameters[8].Value = model.ElongAfterId;
			parameters[9].Value = model.MpaRateMaxId;
			parameters[10].Value = model.ElongRateMaxId;
			parameters[11].Value = model.AgingQualityLossId;
			parameters[12].Value = model.ThermalStablityTimeId;
			parameters[13].Value = model.BittleImpactTestId;
			parameters[14].Value = model.ThermalDeformationId;
			parameters[15].Value = model.OxyIndexId;
			parameters[16].Value = model.SpecGravityId;
			parameters[17].Value = model.ShoreHBTestId;
			parameters[18].Value = model.ApperanceQualityId;
			parameters[19].Value = model.PkgAndLabelId;
			parameters[20].Value = model.ReportFooterId;

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
		public bool Update(MesWeb.Model.T_Report_Plastic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report_Plastic set ");
			strSql.Append("Code=@Code,");
			strSql.Append("ReportHeaderId=@ReportHeaderId,");
			strSql.Append("ElecRateId=@ElecRateId,");
			strSql.Append("ElecStrengthId=@ElecStrengthId,");
			strSql.Append("MpaBeforeId=@MpaBeforeId,");
			strSql.Append("ElongBeforeId=@ElongBeforeId,");
			strSql.Append("AgingConditionId=@AgingConditionId,");
			strSql.Append("MpaAfterId=@MpaAfterId,");
			strSql.Append("ElongAfterId=@ElongAfterId,");
			strSql.Append("MpaRateMaxId=@MpaRateMaxId,");
			strSql.Append("ElongRateMaxId=@ElongRateMaxId,");
			strSql.Append("AgingQualityLossId=@AgingQualityLossId,");
			strSql.Append("ThermalStablityTimeId=@ThermalStablityTimeId,");
			strSql.Append("BittleImpactTestId=@BittleImpactTestId,");
			strSql.Append("ThermalDeformationId=@ThermalDeformationId,");
			strSql.Append("OxyIndexId=@OxyIndexId,");
			strSql.Append("SpecGravityId=@SpecGravityId,");
			strSql.Append("ShoreHBTestId=@ShoreHBTestId,");
			strSql.Append("ApperanceQualityId=@ApperanceQualityId,");
			strSql.Append("PkgAndLabelId=@PkgAndLabelId,");
			strSql.Append("ReportFooterId=@ReportFooterId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ReportHeaderId", SqlDbType.Int,4),
					new SqlParameter("@ElecRateId", SqlDbType.Int,4),
					new SqlParameter("@ElecStrengthId", SqlDbType.Int,4),
					new SqlParameter("@MpaBeforeId", SqlDbType.Int,4),
					new SqlParameter("@ElongBeforeId", SqlDbType.Int,4),
					new SqlParameter("@AgingConditionId", SqlDbType.Int,4),
					new SqlParameter("@MpaAfterId", SqlDbType.Int,4),
					new SqlParameter("@ElongAfterId", SqlDbType.Int,4),
					new SqlParameter("@MpaRateMaxId", SqlDbType.Int,4),
					new SqlParameter("@ElongRateMaxId", SqlDbType.Int,4),
					new SqlParameter("@AgingQualityLossId", SqlDbType.Int,4),
					new SqlParameter("@ThermalStablityTimeId", SqlDbType.Int,4),
					new SqlParameter("@BittleImpactTestId", SqlDbType.Int,4),
					new SqlParameter("@ThermalDeformationId", SqlDbType.Int,4),
					new SqlParameter("@OxyIndexId", SqlDbType.Int,4),
					new SqlParameter("@SpecGravityId", SqlDbType.Int,4),
					new SqlParameter("@ShoreHBTestId", SqlDbType.Int,4),
					new SqlParameter("@ApperanceQualityId", SqlDbType.Int,4),
					new SqlParameter("@PkgAndLabelId", SqlDbType.Int,4),
					new SqlParameter("@ReportFooterId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.ReportHeaderId;
			parameters[2].Value = model.ElecRateId;
			parameters[3].Value = model.ElecStrengthId;
			parameters[4].Value = model.MpaBeforeId;
			parameters[5].Value = model.ElongBeforeId;
			parameters[6].Value = model.AgingConditionId;
			parameters[7].Value = model.MpaAfterId;
			parameters[8].Value = model.ElongAfterId;
			parameters[9].Value = model.MpaRateMaxId;
			parameters[10].Value = model.ElongRateMaxId;
			parameters[11].Value = model.AgingQualityLossId;
			parameters[12].Value = model.ThermalStablityTimeId;
			parameters[13].Value = model.BittleImpactTestId;
			parameters[14].Value = model.ThermalDeformationId;
			parameters[15].Value = model.OxyIndexId;
			parameters[16].Value = model.SpecGravityId;
			parameters[17].Value = model.ShoreHBTestId;
			parameters[18].Value = model.ApperanceQualityId;
			parameters[19].Value = model.PkgAndLabelId;
			parameters[20].Value = model.ReportFooterId;
			parameters[21].Value = model.Id;

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
			strSql.Append("delete from T_Report_Plastic ");
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
			strSql.Append("delete from T_Report_Plastic ");
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
		public MesWeb.Model.T_Report_Plastic GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Code,ReportHeaderId,ElecRateId,ElecStrengthId,MpaBeforeId,ElongBeforeId,AgingConditionId,MpaAfterId,ElongAfterId,MpaRateMaxId,ElongRateMaxId,AgingQualityLossId,ThermalStablityTimeId,BittleImpactTestId,ThermalDeformationId,OxyIndexId,SpecGravityId,ShoreHBTestId,ApperanceQualityId,PkgAndLabelId,ReportFooterId from T_Report_Plastic ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			MesWeb.Model.T_Report_Plastic model=new MesWeb.Model.T_Report_Plastic();
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
		public MesWeb.Model.T_Report_Plastic DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Report_Plastic model=new MesWeb.Model.T_Report_Plastic();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["ReportHeaderId"]!=null && row["ReportHeaderId"].ToString()!="")
				{
					model.ReportHeaderId=int.Parse(row["ReportHeaderId"].ToString());
				}
				if(row["ElecRateId"]!=null && row["ElecRateId"].ToString()!="")
				{
					model.ElecRateId=int.Parse(row["ElecRateId"].ToString());
				}
				if(row["ElecStrengthId"]!=null && row["ElecStrengthId"].ToString()!="")
				{
					model.ElecStrengthId=int.Parse(row["ElecStrengthId"].ToString());
				}
				if(row["MpaBeforeId"]!=null && row["MpaBeforeId"].ToString()!="")
				{
					model.MpaBeforeId=int.Parse(row["MpaBeforeId"].ToString());
				}
				if(row["ElongBeforeId"]!=null && row["ElongBeforeId"].ToString()!="")
				{
					model.ElongBeforeId=int.Parse(row["ElongBeforeId"].ToString());
				}
				if(row["AgingConditionId"]!=null && row["AgingConditionId"].ToString()!="")
				{
					model.AgingConditionId=int.Parse(row["AgingConditionId"].ToString());
				}
				if(row["MpaAfterId"]!=null && row["MpaAfterId"].ToString()!="")
				{
					model.MpaAfterId=int.Parse(row["MpaAfterId"].ToString());
				}
				if(row["ElongAfterId"]!=null && row["ElongAfterId"].ToString()!="")
				{
					model.ElongAfterId=int.Parse(row["ElongAfterId"].ToString());
				}
				if(row["MpaRateMaxId"]!=null && row["MpaRateMaxId"].ToString()!="")
				{
					model.MpaRateMaxId=int.Parse(row["MpaRateMaxId"].ToString());
				}
				if(row["ElongRateMaxId"]!=null && row["ElongRateMaxId"].ToString()!="")
				{
					model.ElongRateMaxId=int.Parse(row["ElongRateMaxId"].ToString());
				}
				if(row["AgingQualityLossId"]!=null && row["AgingQualityLossId"].ToString()!="")
				{
					model.AgingQualityLossId=int.Parse(row["AgingQualityLossId"].ToString());
				}
				if(row["ThermalStablityTimeId"]!=null && row["ThermalStablityTimeId"].ToString()!="")
				{
					model.ThermalStablityTimeId=int.Parse(row["ThermalStablityTimeId"].ToString());
				}
				if(row["BittleImpactTestId"]!=null && row["BittleImpactTestId"].ToString()!="")
				{
					model.BittleImpactTestId=int.Parse(row["BittleImpactTestId"].ToString());
				}
				if(row["ThermalDeformationId"]!=null && row["ThermalDeformationId"].ToString()!="")
				{
					model.ThermalDeformationId=int.Parse(row["ThermalDeformationId"].ToString());
				}
				if(row["OxyIndexId"]!=null && row["OxyIndexId"].ToString()!="")
				{
					model.OxyIndexId=int.Parse(row["OxyIndexId"].ToString());
				}
				if(row["SpecGravityId"]!=null && row["SpecGravityId"].ToString()!="")
				{
					model.SpecGravityId=int.Parse(row["SpecGravityId"].ToString());
				}
				if(row["ShoreHBTestId"]!=null && row["ShoreHBTestId"].ToString()!="")
				{
					model.ShoreHBTestId=int.Parse(row["ShoreHBTestId"].ToString());
				}
				if(row["ApperanceQualityId"]!=null && row["ApperanceQualityId"].ToString()!="")
				{
					model.ApperanceQualityId=int.Parse(row["ApperanceQualityId"].ToString());
				}
				if(row["PkgAndLabelId"]!=null && row["PkgAndLabelId"].ToString()!="")
				{
					model.PkgAndLabelId=int.Parse(row["PkgAndLabelId"].ToString());
				}
				if(row["ReportFooterId"]!=null && row["ReportFooterId"].ToString()!="")
				{
					model.ReportFooterId=int.Parse(row["ReportFooterId"].ToString());
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
			strSql.Append("select Id,Code,ReportHeaderId,ElecRateId,ElecStrengthId,MpaBeforeId,ElongBeforeId,AgingConditionId,MpaAfterId,ElongAfterId,MpaRateMaxId,ElongRateMaxId,AgingQualityLossId,ThermalStablityTimeId,BittleImpactTestId,ThermalDeformationId,OxyIndexId,SpecGravityId,ShoreHBTestId,ApperanceQualityId,PkgAndLabelId,ReportFooterId ");
			strSql.Append(" FROM T_Report_Plastic ");
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
			strSql.Append(" Id,Code,ReportHeaderId,ElecRateId,ElecStrengthId,MpaBeforeId,ElongBeforeId,AgingConditionId,MpaAfterId,ElongAfterId,MpaRateMaxId,ElongRateMaxId,AgingQualityLossId,ThermalStablityTimeId,BittleImpactTestId,ThermalDeformationId,OxyIndexId,SpecGravityId,ShoreHBTestId,ApperanceQualityId,PkgAndLabelId,ReportFooterId ");
			strSql.Append(" FROM T_Report_Plastic ");
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
			strSql.Append("select count(1) FROM T_Report_Plastic ");
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
			strSql.Append(")AS Row, T.*  from T_Report_Plastic T ");
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
			parameters[0].Value = "T_Report_Plastic";
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

