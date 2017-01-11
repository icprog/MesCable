using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_EmployeeArrangement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_EmployeeArrangement
	{
		public T_EmployeeArrangement()
		{}
		#region Model
		private int _employeearrangementid;
		private int? _employeeid;
		private int? _machineid;
		/// <summary>
		/// 
		/// </summary>
		public int EmployeeArrangementID
		{
			set{ _employeearrangementid=value;}
			get{return _employeearrangementid;}
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
		/// 该人员能开的机台
		/// </summary>
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		#endregion Model

	}
}

