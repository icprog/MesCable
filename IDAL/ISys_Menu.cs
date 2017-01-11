
using System;
using System.Data;
namespace MesWeb.IDAL
{
	/// <summary>
	/// 接口层Sys_Menu
	/// </summary>
	public interface ISys_Menu
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(MesWeb.Model.Sys_Menu model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MesWeb.Model.Sys_Menu model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int Menu_id);
		bool DeleteList(string Menu_idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MesWeb.Model.Sys_Menu GetModel(int Menu_id);
		MesWeb.Model.Sys_Menu DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        bool DeleteAll();
        int GetMaxId();
		#endregion  MethodEx
	} 
}
