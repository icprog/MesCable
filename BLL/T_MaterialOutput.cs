/**  版本信息模板在安装目录下，可自行修改。
* T_MaterialOutput.cs
*
* 功 能： N/A
* 类 名： T_MaterialOutput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 17:36:51   N/A    初版
*
* Copyright (c) 2012 MES Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using MES.Common;
using MesWeb.Model;
using MesWeb.DALFactory;
using MesWeb.IDAL;
namespace MesWeb.BLL
{
	/// <summary>
	/// T_MaterialOutput
	/// </summary>
	public partial class T_MaterialOutput
	{
		private readonly IT_MaterialOutput dal=DataAccess.CreateT_MaterialOutput();
		public T_MaterialOutput()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MesWeb.Model.T_MaterialOutput model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_MaterialOutput model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MaterialOutputID)
		{
			
			return dal.Delete(MaterialOutputID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MaterialOutputIDlist )
		{
			return dal.DeleteList(MaterialOutputIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_MaterialOutput GetModel(int MaterialOutputID)
		{
			
			return dal.GetModel(MaterialOutputID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MesWeb.Model.T_MaterialOutput GetModelByCache(int MaterialOutputID)
		{
			
			string CacheKey = "T_MaterialOutputModel-" + MaterialOutputID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MaterialOutputID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MesWeb.Model.T_MaterialOutput)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_MaterialOutput> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_MaterialOutput> DataTableToList(DataTable dt)
		{
			List<MesWeb.Model.T_MaterialOutput> modelList = new List<MesWeb.Model.T_MaterialOutput>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MesWeb.Model.T_MaterialOutput model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

