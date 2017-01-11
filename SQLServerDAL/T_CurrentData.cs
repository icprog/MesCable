
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_CurrentData
	/// </summary>
	public partial class T_CurrentData:IT_CurrentData
	{
		public T_CurrentData()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CurrentDataID", "T_CurrentData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CurrentDataID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CurrentData");
			strSql.Append(" where CurrentDataID=@CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrentDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrentDataID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_CurrentData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CurrentData(");
			strSql.Append("TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode)");
			strSql.Append(" values (");
			strSql.Append("@TaskID,@SpecificationID,@MachineID,@MachineTypeID,@EmployeeID_Main,@EmployeeID_Assistant,@Start_Axis_No,@Axis_No,@Printcode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TaskID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("@EmployeeID_Main", SqlDbType.NVarChar,-1),
					new SqlParameter("@EmployeeID_Assistant", SqlDbType.NVarChar,-1),
					new SqlParameter("@Start_Axis_No", SqlDbType.NVarChar,-1),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@Printcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TaskID;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.MachineTypeID;
			parameters[4].Value = model.EmployeeID_Main;
			parameters[5].Value = model.EmployeeID_Assistant;
			parameters[6].Value = model.Start_Axis_No;
			parameters[7].Value = model.Axis_No;
			parameters[8].Value = model.Printcode;

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
		public bool Update(MesWeb.Model.T_CurrentData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CurrentData set ");
			strSql.Append("TaskID=@TaskID,");
			strSql.Append("SpecificationID=@SpecificationID,");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("MachineTypeID=@MachineTypeID,");
			strSql.Append("EmployeeID_Main=@EmployeeID_Main,");
			strSql.Append("EmployeeID_Assistant=@EmployeeID_Assistant,");
			strSql.Append("Start_Axis_No=@Start_Axis_No,");
			strSql.Append("Axis_No=@Axis_No,");
			strSql.Append("Printcode=@Printcode");
			strSql.Append(" where CurrentDataID=@CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("@TaskID", SqlDbType.Int,4),
					new SqlParameter("@SpecificationID", SqlDbType.Int,4),
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("@EmployeeID_Main", SqlDbType.NVarChar,-1),
					new SqlParameter("@EmployeeID_Assistant", SqlDbType.NVarChar,-1),
					new SqlParameter("@Start_Axis_No", SqlDbType.NVarChar,-1),
					new SqlParameter("@Axis_No", SqlDbType.NVarChar,50),
					new SqlParameter("@Printcode", SqlDbType.NVarChar,50),
					new SqlParameter("@CurrentDataID", SqlDbType.Int,4)};
			parameters[0].Value = model.TaskID;
			parameters[1].Value = model.SpecificationID;
			parameters[2].Value = model.MachineID;
			parameters[3].Value = model.MachineTypeID;
			parameters[4].Value = model.EmployeeID_Main;
			parameters[5].Value = model.EmployeeID_Assistant;
			parameters[6].Value = model.Start_Axis_No;
			parameters[7].Value = model.Axis_No;
			parameters[8].Value = model.Printcode;
			parameters[9].Value = model.CurrentDataID;

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
		public bool Delete(int CurrentDataID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CurrentData ");
			strSql.Append(" where CurrentDataID=@CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrentDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrentDataID;

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
		public bool DeleteList(string CurrentDataIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_CurrentData ");
			strSql.Append(" where CurrentDataID in ("+CurrentDataIDlist + ")  ");
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
		public MesWeb.Model.T_CurrentData GetModel(int CurrentDataID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode from T_CurrentData ");
			strSql.Append(" where CurrentDataID=@CurrentDataID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrentDataID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrentDataID;

			MesWeb.Model.T_CurrentData model=new MesWeb.Model.T_CurrentData();
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
		public MesWeb.Model.T_CurrentData DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_CurrentData model=new MesWeb.Model.T_CurrentData();
			if (row != null)
			{
				if(row["CurrentDataID"]!=null && row["CurrentDataID"].ToString()!="")
				{
					model.CurrentDataID=int.Parse(row["CurrentDataID"].ToString());
				}
				if(row["TaskID"]!=null && row["TaskID"].ToString()!="")
				{
					model.TaskID=int.Parse(row["TaskID"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["MachineTypeID"]!=null && row["MachineTypeID"].ToString()!="")
				{
					model.MachineTypeID=int.Parse(row["MachineTypeID"].ToString());
				}
				if(row["EmployeeID_Main"]!=null)
				{
					model.EmployeeID_Main=row["EmployeeID_Main"].ToString();
				}
				if(row["EmployeeID_Assistant"]!=null)
				{
					model.EmployeeID_Assistant=row["EmployeeID_Assistant"].ToString();
				}
				if(row["Start_Axis_No"]!=null)
				{
					model.Start_Axis_No=row["Start_Axis_No"].ToString();
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["Printcode"]!=null)
				{
					model.Printcode=row["Printcode"].ToString();
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
			strSql.Append("select CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode ");
			strSql.Append(" FROM T_CurrentData ");
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
			strSql.Append(" CurrentDataID,TaskID,SpecificationID,MachineID,MachineTypeID,EmployeeID_Main,EmployeeID_Assistant,Start_Axis_No,Axis_No,Printcode ");
			strSql.Append(" FROM T_CurrentData ");
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
			strSql.Append("select count(1) FROM T_CurrentData ");
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
				strSql.Append("order by T.CurrentDataID desc");
			}
			strSql.Append(")AS Row, T.*  from T_CurrentData T ");
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
			parameters[0].Value = "T_CurrentData";
			parameters[1].Value = "CurrentDataID";
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

