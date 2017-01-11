
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Machine
	/// </summary>
	public partial class T_Machine:IT_Machine
	{
		public T_Machine()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MachineID", "T_Machine"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MachineID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4)
			};
			parameters[0].Value = MachineID;

			int result= DbHelperSQL.RunProcedure("T_Machine_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_Machine model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@MachinePositionX", SqlDbType.Float,8),
					new SqlParameter("@MachinePositionY", SqlDbType.Float,8),
					new SqlParameter("@MachineZoneID", SqlDbType.Int,4),
					new SqlParameter("@MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("@MachinePower", SqlDbType.Int,4),
					new SqlParameter("@MachineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManufactureName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductDate", SqlDbType.DateTime),
					new SqlParameter("@AddressNumber", SqlDbType.NChar,10),
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4),
					new SqlParameter("@MachineEfficiency", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.MachinePositionX;
			parameters[2].Value = model.MachinePositionY;
			parameters[3].Value = model.MachineZoneID;
			parameters[4].Value = model.MachineTypeID;
			parameters[5].Value = model.MachinePower;
			parameters[6].Value = model.MachineName;
			parameters[7].Value = model.ManufactureName;
			parameters[8].Value = model.ProductDate;
			parameters[9].Value = model.AddressNumber;
			parameters[10].Value = model.MapMachineAddressID;
			parameters[11].Value = model.MachineEfficiency;

			DbHelperSQL.RunProcedure("T_Machine_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_Machine model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@MachinePositionX", SqlDbType.Float,8),
					new SqlParameter("@MachinePositionY", SqlDbType.Float,8),
					new SqlParameter("@MachineZoneID", SqlDbType.Int,4),
					new SqlParameter("@MachineTypeID", SqlDbType.Int,4),
					new SqlParameter("@MachinePower", SqlDbType.Int,4),
					new SqlParameter("@MachineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManufactureName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductDate", SqlDbType.DateTime),
					new SqlParameter("@AddressNumber", SqlDbType.NChar,10),
					new SqlParameter("@MapMachineAddressID", SqlDbType.Int,4),
					new SqlParameter("@MachineEfficiency", SqlDbType.Int,4)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.MachinePositionX;
			parameters[2].Value = model.MachinePositionY;
			parameters[3].Value = model.MachineZoneID;
			parameters[4].Value = model.MachineTypeID;
			parameters[5].Value = model.MachinePower;
			parameters[6].Value = model.MachineName;
			parameters[7].Value = model.ManufactureName;
			parameters[8].Value = model.ProductDate;
			parameters[9].Value = model.AddressNumber;
			parameters[10].Value = model.MapMachineAddressID;
			parameters[11].Value = model.MachineEfficiency;

			DbHelperSQL.RunProcedure("T_Machine_Update",parameters,out rowsAffected);
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
		public bool Delete(int MachineID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4)
			};
			parameters[0].Value = MachineID;

			DbHelperSQL.RunProcedure("T_Machine_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string MachineIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Machine ");
			strSql.Append(" where MachineID in ("+MachineIDlist + ")  ");
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
		public MesWeb.Model.T_Machine GetModel(int MachineID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4)
			};
			parameters[0].Value = MachineID;

			MesWeb.Model.T_Machine model=new MesWeb.Model.T_Machine();
			DataSet ds= DbHelperSQL.RunProcedure("T_Machine_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_Machine DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Machine model=new MesWeb.Model.T_Machine();
			if (row != null)
			{
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["MachinePositionX"]!=null && row["MachinePositionX"].ToString()!="")
				{
					model.MachinePositionX=decimal.Parse(row["MachinePositionX"].ToString());
				}
				if(row["MachinePositionY"]!=null && row["MachinePositionY"].ToString()!="")
				{
					model.MachinePositionY=decimal.Parse(row["MachinePositionY"].ToString());
				}
				if(row["MachineZoneID"]!=null && row["MachineZoneID"].ToString()!="")
				{
					model.MachineZoneID=int.Parse(row["MachineZoneID"].ToString());
				}
				if(row["MachineTypeID"]!=null && row["MachineTypeID"].ToString()!="")
				{
					model.MachineTypeID=int.Parse(row["MachineTypeID"].ToString());
				}
				if(row["MachinePower"]!=null && row["MachinePower"].ToString()!="")
				{
					model.MachinePower=int.Parse(row["MachinePower"].ToString());
				}
				if(row["MachineName"]!=null)
				{
					model.MachineName=row["MachineName"].ToString();
				}
				if(row["ManufactureName"]!=null)
				{
					model.ManufactureName=row["ManufactureName"].ToString();
				}
				if(row["ProductDate"]!=null && row["ProductDate"].ToString()!="")
				{
					model.ProductDate=DateTime.Parse(row["ProductDate"].ToString());
				}
				if(row["AddressNumber"]!=null)
				{
					model.AddressNumber=row["AddressNumber"].ToString();
				}
				if(row["MapMachineAddressID"]!=null && row["MapMachineAddressID"].ToString()!="")
				{
					model.MapMachineAddressID=int.Parse(row["MapMachineAddressID"].ToString());
				}
				if(row["MachineEfficiency"]!=null && row["MachineEfficiency"].ToString()!="")
				{
					model.MachineEfficiency=int.Parse(row["MachineEfficiency"].ToString());
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
			strSql.Append("select MachineID,MachinePositionX,MachinePositionY,MachineZoneID,MachineTypeID,MachinePower,MachineName,ManufactureName,ProductDate,AddressNumber,MapMachineAddressID,MachineEfficiency ");
			strSql.Append(" FROM T_Machine ");
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
			strSql.Append(" MachineID,MachinePositionX,MachinePositionY,MachineZoneID,MachineTypeID,MachinePower,MachineName,ManufactureName,ProductDate,AddressNumber,MapMachineAddressID,MachineEfficiency ");
			strSql.Append(" FROM T_Machine ");
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
			strSql.Append("select count(1) FROM T_Machine ");
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
				strSql.Append("order by T.MachineID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Machine T ");
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
			parameters[0].Value = "T_Machine";
			parameters[1].Value = "MachineID";
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

