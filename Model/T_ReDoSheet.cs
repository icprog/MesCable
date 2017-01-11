using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ReDoSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ReDoSheet
	{
		public T_ReDoSheet()
		{}
		#region Model
		private int _redosheet;
		private int? _taskid;
		private int? _redoresonid;
		private int? _employeeid;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int ReDoSheet
		{
			set{ _redosheet=value;}
			get{return _redosheet;}
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
		public int? ReDoResonID
		{
			set{ _redoresonid=value;}
			get{return _redoresonid;}
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
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

