
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_User
	{
		public T_User()
		{}
		#region Model
		private int _userid;
		private string _username;
		private int? _employeeid;
		private int? _authenticid;
		private string _password;
		private bool _isvalidate= false;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
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
		public int? AuthenticID
		{
			set{ _authenticid=value;}
			get{return _authenticid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsValidate
		{
			set{ _isvalidate=value;}
			get{return _isvalidate;}
		}
		#endregion Model

	}
}

