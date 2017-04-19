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
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace MesWeb.IDAL
{
	/// <summary>
	/// 接口层T_MaterialOutput
	/// </summary>
	public interface IT_MaterialOutput
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(MesWeb.Model.T_MaterialOutput model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MesWeb.Model.T_MaterialOutput model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int MaterialOutputID);
		bool DeleteList(string MaterialOutputIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MesWeb.Model.T_MaterialOutput GetModel(int MaterialOutputID);
		MesWeb.Model.T_MaterialOutput DataRowToModel(DataRow row);
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

		#endregion  MethodEx
	} 
}
