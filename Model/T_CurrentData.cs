
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CurrentData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CurrentData
	{
		public T_CurrentData()
		{}
		#region Model
		private int _currentdataid;
		private int? _taskid;
		private int? _specificationid;
		private int? _machineid;
		private int? _machinetypeid;
		private string _employeeid_main;
		private string _employeeid_assistant;
		private string _start_axis_no;
		private string _axis_no;
		private string _printcode;
		/// <summary>
		/// 
		/// </summary>
		public int CurrentDataID
		{
			set{ _currentdataid=value;}
			get{return _currentdataid;}
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
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
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
		public string EmployeeID_Main
		{
			set{ _employeeid_main=value;}
			get{return _employeeid_main;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeID_Assistant
		{
			set{ _employeeid_assistant=value;}
			get{return _employeeid_assistant;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Start_Axis_No
		{
			set{ _start_axis_no=value;}
			get{return _start_axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Printcode
		{
			set{ _printcode=value;}
			get{return _printcode;}
		}
		#endregion Model

	}
}

