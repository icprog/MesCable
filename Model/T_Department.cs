using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Department
	{
		public T_Department()
		{}
		#region Model
		private int _departmentid;
		private string _departmentname;
		private string _departmentcontactperson;
		private string _departmenttel;
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentContactPerson
		{
			set{ _departmentcontactperson=value;}
			get{return _departmentcontactperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentTel
		{
			set{ _departmenttel=value;}
			get{return _departmenttel;}
		}
		#endregion Model

	}
}

