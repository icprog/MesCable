using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineMaintain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineMaintain
	{
		public T_MachineMaintain()
		{}
		#region Model
		private int _machinemaintainid;
		private int? _machineid;
		private int? _maintainemployeeid;
		private string _maintaincontent;
		private DateTime? _maintaindatetime;
		/// <summary>
		/// 
		/// </summary>
		public int MachineMaintainID
		{
			set{ _machinemaintainid=value;}
			get{return _machinemaintainid;}
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
		public DateTime? MaintainDateTime
		{
			set{ _maintaindatetime=value;}
			get{return _maintaindatetime;}
		}
		#endregion Model

	}
}

