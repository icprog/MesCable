using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Task:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Task
	{
		public T_Task()
		{}
		#region Model
		private int _taskid;
		private int? _machineid;
		private int? _specificationid;
		private int? _mergeaxisid;
		private int? _employeeid;
		private DateTime? _datetime;
		private bool _isfinished;
		/// <summary>
		/// 
		/// </summary>
		public int TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
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
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MergeAxisID
		{
			set{ _mergeaxisid=value;}
			get{return _mergeaxisid;}
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
		/// 预计开机时间
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsFinished
		{
			set{ _isfinished=value;}
			get{return _isfinished;}
		}
		#endregion Model

	}
}

