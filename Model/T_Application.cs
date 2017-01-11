using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Application:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Application
	{
		public T_Application()
		{}
		#region Model
		private int _applicationid;
		private int? _aplication_employeeid;
		private string _problemdetail;
		private DateTime? _applicationdatetime;
		private string _applicationstate;
		/// <summary>
		/// 
		/// </summary>
		public int ApplicationID
		{
			set{ _applicationid=value;}
			get{return _applicationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Aplication_EmployeeID
		{
			set{ _aplication_employeeid=value;}
			get{return _aplication_employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProblemDetail
		{
			set{ _problemdetail=value;}
			get{return _problemdetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApplicationDateTime
		{
			set{ _applicationdatetime=value;}
			get{return _applicationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplicationState
		{
			set{ _applicationstate=value;}
			get{return _applicationstate;}
		}
		#endregion Model

	}
}

