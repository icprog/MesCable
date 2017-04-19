/**  版本信息模板在安装目录下，可自行修改。
* T_CurrentData.cs
*
* 功 能： N/A
* 类 名： T_CurrentData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 17:22:00   N/A    初版
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
	/// T_CurrentData
	/// </summary>
	public partial class T_CurrentData
	{
		private readonly IT_CurrentData dal=DataAccess.CreateT_CurrentData();
		public T_CurrentData()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MesWeb.Model.T_CurrentData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_CurrentData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CurrentDataID)
		{
			
			return dal.Delete(CurrentDataID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CurrentDataIDlist )
		{
			return dal.DeleteList(CurrentDataIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_CurrentData GetModel(int CurrentDataID)
		{
			
			return dal.GetModel(CurrentDataID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MesWeb.Model.T_CurrentData GetModelByCache(int CurrentDataID)
		{
			
			string CacheKey = "T_CurrentDataModel-" + CurrentDataID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CurrentDataID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MesWeb.Model.T_CurrentData)objModel;
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
		public List<MesWeb.Model.T_CurrentData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_CurrentData> DataTableToList(DataTable dt)
		{
			List<MesWeb.Model.T_CurrentData> modelList = new List<MesWeb.Model.T_CurrentData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MesWeb.Model.T_CurrentData model;
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

