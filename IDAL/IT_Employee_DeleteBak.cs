
using System;
using System.Data;
namespace MesWeb.IDAL
{
	/// <summary>
	/// 接口层T_Employee_DeleteBak
	/// </summary>
	public interface IT_Employee_DeleteBak
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		long Add(MesWeb.Model.T_Employee_DeleteBak model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MesWeb.Model.T_Employee_DeleteBak model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(long EmployeeID);
		bool DeleteList(string EmployeeIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MesWeb.Model.T_Employee_DeleteBak GetModel(long EmployeeID);
		MesWeb.Model.T_Employee_DeleteBak DataRowToModel(DataRow row);
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
