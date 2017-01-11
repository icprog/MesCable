using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineAblity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineAblity
	{
		public T_MachineAblity()
		{}
		#region Model
		private int _machineablityid;
		private int? _machineid;
		private int? _machinetypeid;
		private int? _employeeid;
		private decimal? _machineablity;
		/// <summary>
		/// 
		/// </summary>
		public int MachineAblityID
		{
			set{ _machineablityid=value;}
			get{return _machineablityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineTypeID
		{
			set{ _machinetypeid=value;}
			get{return _machinetypeid;}
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
		public decimal? MachineAblity
		{
			set{ _machineablity=value;}
			get{return _machineablity;}
		}
		#endregion Model

	}
}

