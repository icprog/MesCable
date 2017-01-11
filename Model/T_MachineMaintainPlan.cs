using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineMaintainPlan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineMaintainPlan
	{
		public T_MachineMaintainPlan()
		{}
		#region Model
		private int _machinemaintainplanid;
		private int? _machineid;
		private int? _maintainemployeeid;
		private string _maintaincontent;
		private DateTime? _maintainplandatetime;
		private string _maintainstate;
		/// <summary>
		/// 
		/// </summary>
		public int MachineMaintainPlanID
		{
			set{ _machinemaintainplanid=value;}
			get{return _machinemaintainplanid;}
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
		public int? MaintainEmployeeID
		{
			set{ _maintainemployeeid=value;}
			get{return _maintainemployeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaintainContent
		{
			set{ _maintaincontent=value;}
			get{return _maintaincontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MaintainPlanDateTime
		{
			set{ _maintainplandatetime=value;}
			get{return _maintainplandatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaintainState
		{
			set{ _maintainstate=value;}
			get{return _maintainstate;}
		}
		#endregion Model

	}
}

