
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_TCP
	/// </summary>
	public partial class T_TCP:IT_TCP
	{
		public T_TCP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TCPID", "T_TCP"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TCPID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_TCP");
			strSql.Append(" where TCPID=@TCPID");
			SqlParameter[] parameters = {
					new SqlParameter("@TCPID", SqlDbType.Int,4)
			};
			parameters[0].Value = TCPID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_TCP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_TCP(");
			strSql.Append("MachineID,IPAddress,State,DateTime)");
			strSql.Append(" values (");
			strSql.Append("@MachineID,@IPAddress,@State,@DateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@IPAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.IPAddress;
			parameters[2].Value = model.State;
			parameters[3].Value = model.DateTime;

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
		public bool Update(MesWeb.Model.T_TCP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_TCP set ");
			strSql.Append("MachineID=@MachineID,");
			strSql.Append("IPAddress=@IPAddress,");
			strSql.Append("State=@State,");
			strSql.Append("DateTime=@DateTime");
			strSql.Append(" where TCPID=@TCPID");
			SqlParameter[] parameters = {
					new SqlParameter("@MachineID", SqlDbType.Int,4),
					new SqlParameter("@IPAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@TCPID", SqlDbType.Int,4)};
			parameters[0].Value = model.MachineID;
			parameters[1].Value = model.IPAddress;
			parameters[2].Value = model.State;
			parameters[3].Value = model.DateTime;
			parameters[4].Value = model.TCPID;

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
		public bool Delete(int TCPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_TCP ");
			strSql.Append(" where TCPID=@TCPID");
			SqlParameter[] parameters = {
					new SqlParameter("@TCPID", SqlDbType.Int,4)
			};
			parameters[0].Value = TCPID;

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
		public bool DeleteList(string TCPIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_TCP ");
			strSql.Append(" where TCPID in ("+TCPIDlist + ")  ");
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
		public MesWeb.Model.T_TCP GetModel(int TCPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TCPID,MachineID,IPAddress,State,DateTime from T_TCP ");
			strSql.Append(" where TCPID=@TCPID");
			SqlParameter[] parameters = {
					new SqlParameter("@TCPID", SqlDbType.Int,4)
			};
			parameters[0].Value = TCPID;

			MesWeb.Model.T_TCP model=new MesWeb.Model.T_TCP();
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
		public MesWeb.Model.T_TCP DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_TCP model=new MesWeb.Model.T_TCP();
			if (row != null)
			{
				if(row["TCPID"]!=null && row["TCPID"].ToString()!="")
				{
					model.TCPID=int.Parse(row["TCPID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["IPAddress"]!=null)
				{
					model.IPAddress=row["IPAddress"].ToString();
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
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
			strSql.Append("select TCPID,MachineID,IPAddress,State,DateTime ");
			strSql.Append(" FROM T_TCP ");
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
			strSql.Append(" TCPID,MachineID,IPAddress,State,DateTime ");
			strSql.Append(" FROM T_TCP ");
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
			strSql.Append("select count(1) FROM T_TCP ");
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
				strSql.Append("order by T.TCPID desc");
			}
			strSql.Append(")AS Row, T.*  from T_TCP T ");
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
			parameters[0].Value = "T_TCP";
			parameters[1].Value = "TCPID";
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

