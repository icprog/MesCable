using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_EmployeeState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_EmployeeState
	{
		public T_EmployeeState()
		{}
		#region Model
		private int _employeestateid;
		private int? _employeeid;
		private bool _state;
		/// <summary>
		/// 
		/// </summary>
		public int EmployeeStateID
		{
			set{ _employeestateid=value;}
			get{return _employeestateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

