
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_SpotDist_SpotInfo
	/// </summary>
	public partial class T_SpotDist_SpotInfo:IT_SpotDist_SpotInfo
	{
		public T_SpotDist_SpotInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_SpotDist_SpotInfo"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_SpotDist_SpotInfo");
			strSql.Append(" where Id="+Id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_SpotDist_SpotInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SpotDistId != null)
			{
				strSql1.Append("SpotDistId,");
				strSql2.Append(""+model.SpotDistId+",");
			}
			if (model.SpotInfoId != null)
			{
				strSql1.Append("SpotInfoId,");
				strSql2.Append(""+model.SpotInfoId+",");
			}
			strSql.Append("insert into T_SpotDist_SpotInfo(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_SpotDist_SpotInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_SpotDist_SpotInfo set ");
			if (model.SpotDistId != null)
			{
				strSql.Append("SpotDistId="+model.SpotDistId+",");
			}
			if (model.SpotInfoId != null)
			{
				strSql.Append("SpotInfoId="+model.SpotInfoId+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Id="+ model.Id+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public bool Delete(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_SpotDist_SpotInfo ");
			strSql.Append(" where Id="+Id+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_SpotDist_SpotInfo ");
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
		public MesWeb.Model.T_SpotDist_SpotInfo GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Id,SpotDistId,SpotInfoId ");
			strSql.Append(" from T_SpotDist_SpotInfo ");
			strSql.Append(" where Id="+Id+"" );
			MesWeb.Model.T_SpotDist_SpotInfo model=new MesWeb.Model.T_SpotDist_SpotInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
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
		public MesWeb.Model.T_SpotDist_SpotInfo DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_SpotDist_SpotInfo model=new MesWeb.Model.T_SpotDist_SpotInfo();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["SpotDistId"]!=null && row["SpotDistId"].ToString()!="")
				{
					model.SpotDistId=int.Parse(row["SpotDistId"].ToString());
				}
				if(row["SpotInfoId"]!=null && row["SpotInfoId"].ToString()!="")
				{
					model.SpotInfoId=int.Parse(row["SpotInfoId"].ToString());
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
			strSql.Append("select Id,SpotDistId,SpotInfoId ");
			strSql.Append(" FROM T_SpotDist_SpotInfo ");
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
			strSql.Append(" Id,SpotDistId,SpotInfoId ");
			strSql.Append(" FROM T_SpotDist_SpotInfo ");
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
			strSql.Append("select count(1) FROM T_SpotDist_SpotInfo ");
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
			strSql.Append(")AS Row, T.*  from T_SpotDist_SpotInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /*
		*/

        #endregion  Method
        #region  MethodEx
        public bool DeleteListEx(string where) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_SpotDist_SpotInfo ");
            strSql.Append(" where "+where);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if(rows > 0) {
                return true;
            } else {
                return false;
            }
        }
        #endregion  MethodEx
    }
}

