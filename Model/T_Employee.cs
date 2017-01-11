
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Employee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Employee
	{
		public T_Employee()
		{}
		#region Model
		private long _employeeid;
		private int? _departmentid;
		private string _employeename;
		private string _employeecode;
		private string _employeesex;
		private int? _employeeage;
		private string _employeetel;
		private int? _dutyid;
		private DateTime? _generatortime;
		private bool _isdeleted= false;
		/// <summary>
		/// 
		/// </summary>
		public long EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeCode
		{
			set{ _employeecode=value;}
			get{return _employeecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeSex
		{
			set{ _employeesex=value;}
			get{return _employeesex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeAge
		{
			set{ _employeeage=value;}
			get{return _employeeage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeTel
		{
			set{ _employeetel=value;}
			get{return _employeetel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DutyID
		{
			set{ _dutyid=value;}
			get{return _dutyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GeneratorTime
		{
			set{ _generatortime=value;}
			get{return _generatortime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
		}
		#endregion Model

	}
}

