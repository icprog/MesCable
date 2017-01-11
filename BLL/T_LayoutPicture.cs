
using System;
using System.Data;
using System.Collections.Generic;
using MES.Common;
using MesWeb.Model;
using MesWeb.DALFactory;
using MesWeb.IDAL;
using System.IO;

namespace MesWeb.BLL
{
	/// <summary>
	/// T_LayoutPicture
	/// </summary>
	public partial class T_LayoutPicture
	{
		private readonly IT_LayoutPicture dal=DataAccess.CreateT_LayoutPicture();
		public T_LayoutPicture()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LayoutPictureID)
		{
			return dal.Exists(LayoutPictureID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MesWeb.Model.T_LayoutPicture model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MesWeb.Model.T_LayoutPicture model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LayoutPictureID)
		{
            var layoutPic = dal.GetModel(LayoutPictureID);
            if(layoutPic == null)
                return false;
            DeleteFile(layoutPic.PicUrl);
			return dal.Delete(LayoutPictureID);
		}

        ///<autor>ychost</autor>
        ///<datecreated>2016-09-02</datecreated>
        /// <summary>
        /// delete file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns></returns>
        public bool DeleteFile(string path) {
            if(File.Exists( path)) {
                File.Delete(path);
                return true;
            }
            return false;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LayoutPictureIDlist )
		{
            var strIdList = LayoutPictureIDlist.Split(',');
            try {
                foreach(var strId in strIdList) {
                    int delId = int.Parse(strId.Trim());
                    var delLayoutPic = dal.GetModel(delId);
                    DeleteFile(delLayoutPic.PicUrl);
                }
            } catch {

            }

			return dal.DeleteList(LayoutPictureIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_LayoutPicture GetModel(int LayoutPictureID)
		{
			
			return dal.GetModel(LayoutPictureID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MesWeb.Model.T_LayoutPicture GetModelByCache(int LayoutPictureID)
		{
			
			string CacheKey = "T_LayoutPictureModel-" + LayoutPictureID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LayoutPictureID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MesWeb.Model.T_LayoutPicture)objModel;
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
		public List<MesWeb.Model.T_LayoutPicture> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MesWeb.Model.T_LayoutPicture> DataTableToList(DataTable dt)
		{
			List<MesWeb.Model.T_LayoutPicture> modelList = new List<MesWeb.Model.T_LayoutPicture>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MesWeb.Model.T_LayoutPicture model;
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

