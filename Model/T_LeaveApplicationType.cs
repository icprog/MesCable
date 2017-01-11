using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LeaveApplicationType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LeaveApplicationType
	{
		public T_LeaveApplicationType()
		{}
		#region Model
		private int _leaveapplicationtypeid;
		private string _leaveapplicationtype;
		/// <summary>
		/// 
		/// </summary>
		public int LeaveApplicationTypeID
		{
			set{ _leaveapplicationtypeid=value;}
			get{return _leaveapplicationtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LeaveApplicationType
		{
			set{ _leaveapplicationtype=value;}
			get{return _leaveapplicationtype;}
		}
		#endregion Model

	}
}

