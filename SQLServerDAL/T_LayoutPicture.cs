
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_LayoutPicture
	/// </summary>
	public partial class T_LayoutPicture:IT_LayoutPicture
	{
		public T_LayoutPicture()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LayoutPictureID", "T_LayoutPicture"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LayoutPictureID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutPictureID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutPictureID;

			int result= DbHelperSQL.RunProcedure("T_LayoutPicture_Exists",parameters,out rowsAffected);
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
		public int Add(MesWeb.Model.T_LayoutPicture model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutPictureID", SqlDbType.Int,4),
					new SqlParameter("@PicWidth", SqlDbType.NVarChar,50),
					new SqlParameter("@PicHeight", SqlDbType.NVarChar,50),
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@XPostion", SqlDbType.Int,4),
					new SqlParameter("@YPostion", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ParentLayoutPictureID", SqlDbType.Int,4),
					new SqlParameter("@LayoutTypeID", SqlDbType.Int,4),
					new SqlParameter("@TableRowID", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.PicWidth;
			parameters[2].Value = model.PicHeight;
			parameters[3].Value = model.PicUrl;
			parameters[4].Value = model.XPostion;
			parameters[5].Value = model.YPostion;
			parameters[6].Value = model.Title;
			parameters[7].Value = model.Message;
			parameters[8].Value = model.State;
			parameters[9].Value = model.ParentLayoutPictureID;
			parameters[10].Value = model.LayoutTypeID;
			parameters[11].Value = model.TableRowID;
			parameters[12].Value = model.IsTop;
			parameters[13].Value = model.Remark;

			DbHelperSQL.RunProcedure("T_LayoutPicture_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_LayoutPicture model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutPictureID", SqlDbType.Int,4),
					new SqlParameter("@PicWidth", SqlDbType.NVarChar,50),
					new SqlParameter("@PicHeight", SqlDbType.NVarChar,50),
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@XPostion", SqlDbType.Int,4),
					new SqlParameter("@YPostion", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ParentLayoutPictureID", SqlDbType.Int,4),
					new SqlParameter("@LayoutTypeID", SqlDbType.Int,4),
					new SqlParameter("@TableRowID", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LayoutPictureID;
			parameters[1].Value = model.PicWidth;
			parameters[2].Value = model.PicHeight;
			parameters[3].Value = model.PicUrl;
			parameters[4].Value = model.XPostion;
			parameters[5].Value = model.YPostion;
			parameters[6].Value = model.Title;
			parameters[7].Value = model.Message;
			parameters[8].Value = model.State;
			parameters[9].Value = model.ParentLayoutPictureID;
			parameters[10].Value = model.LayoutTypeID;
			parameters[11].Value = model.TableRowID;
			parameters[12].Value = model.IsTop;
			parameters[13].Value = model.Remark;

			DbHelperSQL.RunProcedure("T_LayoutPicture_Update",parameters,out rowsAffected);
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
		public bool Delete(int LayoutPictureID)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutPictureID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutPictureID;

			DbHelperSQL.RunProcedure("T_LayoutPicture_Delete",parameters,out rowsAffected);
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
		public bool DeleteList(string LayoutPictureIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LayoutPicture ");
			strSql.Append(" where LayoutPictureID in ("+LayoutPictureIDlist + ")  ");
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
		public MesWeb.Model.T_LayoutPicture GetModel(int LayoutPictureID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@LayoutPictureID", SqlDbType.Int,4)
			};
			parameters[0].Value = LayoutPictureID;

			MesWeb.Model.T_LayoutPicture model=new MesWeb.Model.T_LayoutPicture();
			DataSet ds= DbHelperSQL.RunProcedure("T_LayoutPicture_GetModel",parameters,"ds");
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
		public MesWeb.Model.T_LayoutPicture DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_LayoutPicture model=new MesWeb.Model.T_LayoutPicture();
			if (row != null)
			{
				if(row["LayoutPictureID"]!=null && row["LayoutPictureID"].ToString()!="")
				{
					model.LayoutPictureID=int.Parse(row["LayoutPictureID"].ToString());
				}
				if(row["PicWidth"]!=null)
				{
					model.PicWidth=row["PicWidth"].ToString();
				}
				if(row["PicHeight"]!=null)
				{
					model.PicHeight=row["PicHeight"].ToString();
				}
				if(row["PicUrl"]!=null)
				{
					model.PicUrl=row["PicUrl"].ToString();
				}
				if(row["XPostion"]!=null && row["XPostion"].ToString()!="")
				{
					model.XPostion=int.Parse(row["XPostion"].ToString());
				}
				if(row["YPostion"]!=null && row["YPostion"].ToString()!="")
				{
					model.YPostion=int.Parse(row["YPostion"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Message"]!=null)
				{
					model.Message=row["Message"].ToString();
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["ParentLayoutPictureID"]!=null && row["ParentLayoutPictureID"].ToString()!="")
				{
					model.ParentLayoutPictureID=int.Parse(row["ParentLayoutPictureID"].ToString());
				}
				if(row["LayoutTypeID"]!=null && row["LayoutTypeID"].ToString()!="")
				{
					model.LayoutTypeID=int.Parse(row["LayoutTypeID"].ToString());
				}
				if(row["TableRowID"]!=null && row["TableRowID"].ToString()!="")
				{
					model.TableRowID=int.Parse(row["TableRowID"].ToString());
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					if((row["IsTop"].ToString()=="1")||(row["IsTop"].ToString().ToLower()=="true"))
					{
						model.IsTop=true;
					}
					else
					{
						model.IsTop=false;
					}
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select LayoutPictureID,PicWidth,PicHeight,PicUrl,XPostion,YPostion,Title,Message,State,ParentLayoutPictureID,LayoutTypeID,TableRowID,IsTop,Remark ");
			strSql.Append(" FROM T_LayoutPicture ");
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
			strSql.Append(" LayoutPictureID,PicWidth,PicHeight,PicUrl,XPostion,YPostion,Title,Message,State,ParentLayoutPictureID,LayoutTypeID,TableRowID,IsTop,Remark ");
			strSql.Append(" FROM T_LayoutPicture ");
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
			strSql.Append("select count(1) FROM T_LayoutPicture ");
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
				strSql.Append("order by T.LayoutPictureID desc");
			}
			strSql.Append(")AS Row, T.*  from T_LayoutPicture T ");
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
			parameters[0].Value = "T_LayoutPicture";
			parameters[1].Value = "LayoutPictureID";
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

