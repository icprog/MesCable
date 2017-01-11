using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_OEE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_OEE
	{
		public T_OEE()
		{}
		#region Model
		private int _oeeid;
		private int? _taskid;
		private int? _employeeid;
		private int? _machineid;
		private int? _machinetypeid;
		private int? _jobsheetid;
		private decimal? _pr;
		private decimal? _orr;
		private string _oee;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int OEEID
		{
			set{ _oeeid=value;}
			get{return _oeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
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
		public int? JobSheetID
		{
			set{ _jobsheetid=value;}
			get{return _jobsheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PR
		{
			set{ _pr=value;}
			get{return _pr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORR
		{
			set{ _orr=value;}
			get{return _orr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OEE
		{
			set{ _oee=value;}
			get{return _oee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

