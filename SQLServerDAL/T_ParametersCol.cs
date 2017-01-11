
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_ParametersCol
	/// </summary>
	public partial class T_ParametersCol:IT_ParametersCol
	{
		public T_ParametersCol()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ParametersColID", "T_ParametersCol"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ParametersColID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ParametersColID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParametersColID;

			int result= DbHelperSQL.RunProcedure("T_ParametersCol_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_ParametersCol model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ParametersColID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4),
					new SqlParameter("@ParametersColSettingValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParametersColMaxiumValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParametersColMiniumValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.CollectedParameterID;
			parameters[4].Value = model.ParametersColSettingValue;
			parameters[5].Value = model.ParametersColMaxiumValue;
			parameters[6].Value = model.ParametersColMiniumValue;
			parameters[7].Value = model.ParameterCodeID;
			parameters[8].Value = model.DateTime;

			DbHelperSQL.RunProcedure("T_ParametersCol_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_ParametersCol model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ParametersColID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@CollectedParameterID", SqlDbType.Int,4),
					new SqlParameter("@ParametersColSettingValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParametersColMaxiumValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParametersColMiniumValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ParameterCodeID", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ParametersColID;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.CollectedParameterID;
			parameters[4].Value = model.ParametersColSettingValue;
			parameters[5].Value = model.ParametersColMaxiumValue;
			parameters[6].Value = model.ParametersColMiniumValue;
			parameters[7].Value = model.ParameterCodeID;
			parameters[8].Value = model.DateTime;

			DbHelperSQL.RunProcedure("T_ParametersCol_Update",parameters,out rowsAffected);
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
		public bool Delete(int ParametersColID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ParametersColID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParametersColID;

			DbHelperSQL.RunProcedure("T_ParametersCol_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string ParametersColIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_ParametersCol ");
			strSql.Append(" where ParametersColID in ("+ParametersColIDlist + ")  ");
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
		public MesWeb.Model.T_ParametersCol GetModel(int ParametersColID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ParametersColID", SqlDbType.Int,4)
			};
			parameters[0].Value = ParametersColID;

			MesWeb.Model.T_ParametersCol model=new MesWeb.Model.T_ParametersCol();
			DataSet ds= DbHelperSQL.RunProcedure("T_ParametersCol_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_ParametersCol DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_ParametersCol model=new MesWeb.Model.T_ParametersCol();
			if (row != null)
			{
				if(row["ParametersColID"]!=null && row["ParametersColID"].ToString()!="")
				{
					model.ParametersColID=int.Parse(row["ParametersColID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["CollectedParameterID"]!=null && row["CollectedParameterID"].ToString()!="")
				{
					model.CollectedParameterID=int.Parse(row["CollectedParameterID"].ToString());
				}
				if(row["ParametersColSettingValue"]!=null)
				{
					model.ParametersColSettingValue=row["ParametersColSettingValue"].ToString();
				}
				if(row["ParametersColMaxiumValue"]!=null)
				{
					model.ParametersColMaxiumValue=row["ParametersColMaxiumValue"].ToString();
				}
				if(row["ParametersColMiniumValue"]!=null)
				{
					model.ParametersColMiniumValue=row["ParametersColMiniumValue"].ToString();
				}
				if(row["ParameterCodeID"]!=null && row["ParameterCodeID"].ToString()!="")
				{
					model.ParameterCodeID=int.Parse(row["ParameterCodeID"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select ParametersColID,SpecificationID,MachineID,CollectedParameterID,ParametersColSettingValue,ParametersColMaxiumValue,ParametersColMiniumValue,ParameterCodeID,DateTime ");
			strSql.Append(" FROM T_ParametersCol ");
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
			strSql.Append(" ParametersColID,SpecificationID,MachineID,CollectedParameterID,ParametersColSettingValue,ParametersColMaxiumValue,ParametersColMiniumValue,ParameterCodeID,DateTime ");
			strSql.Append(" FROM T_ParametersCol ");
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
			strSql.Append("select count(1) FROM T_ParametersCol ");
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
				strSql.Append("order by T.ParametersColID desc");
			}
			strSql.Append(")AS Row, T.*  from T_ParametersCol T ");
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
			parameters[0].Value = "T_ParametersCol";
			parameters[1].Value = "ParametersColID";
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

