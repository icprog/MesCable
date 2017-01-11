using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Salary:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Salary
	{
		public T_Salary()
		{}
		#region Model
		private int _salaryid;
		private int? _employeeid;
		private decimal? _basic_salary;
		private decimal? _man_hour_salary;
		private decimal? _overtime_salary;
		/// <summary>
		/// 
		/// </summary>
		public int SalaryID
		{
			set{ _salaryid=value;}
			get{return _salaryid;}
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
		public decimal? Basic_Salary
		{
			set{ _basic_salary=value;}
			get{return _basic_salary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Man_Hour_Salary
		{
			set{ _man_hour_salary=value;}
			get{return _man_hour_salary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OverTime_Salary
		{
			set{ _overtime_salary=value;}
			get{return _overtime_salary;}
		}
		#endregion Model

	}
}

