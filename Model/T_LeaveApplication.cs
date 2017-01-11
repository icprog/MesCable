using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LeaveApplication:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LeaveApplication
	{
		public T_LeaveApplication()
		{}
		#region Model
		private int _leaveapplicationid;
		private int? _employeeid;
		private int? _flowid;
		private int? _leaveapplicationtypeid;
		private DateTime? _leaveapplicationdate;
		private decimal? _leaveapplicationdays;
		private string _state;
		/// <summary>
		/// 
		/// </summary>
		public int LeaveApplicationID
		{
			set{ _leaveapplicationid=value;}
			get{return _leaveapplicationid;}
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
		public int? FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LeaveApplicationTypeID
		{
			set{ _leaveapplicationtypeid=value;}
			get{return _leaveapplicationtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LeaveApplicationDate
		{
			set{ _leaveapplicationdate=value;}
			get{return _leaveapplicationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LeaveApplicationDays
		{
			set{ _leaveapplicationdays=value;}
			get{return _leaveapplicationdays;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

