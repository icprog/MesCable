using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Log
	{
		public T_Log()
		{}
		#region Model
		private int _logid;
		private int? _userid;
		private int? _logtypeid;
		private int? _logdetailid;
		private DateTime? _logintime;
		private string _loginip;
		/// <summary>
		/// 
		/// </summary>
		public int LogID
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogTypeID
		{
			set{ _logtypeid=value;}
			get{return _logtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogDetailID
		{
			set{ _logdetailid=value;}
			get{return _logdetailid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginIP
		{
			set{ _loginip=value;}
			get{return _loginip;}
		}
		#endregion Model

	}
}

