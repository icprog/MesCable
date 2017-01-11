
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ServerLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ServerLog
	{
		public T_ServerLog()
		{}
		#region Model
		private int _serverlogid;
		private string _level;
		private string _logger;
		private string _message;
		private string _thread;
		private DateTime _date;
		private string _exception;
		/// <summary>
		/// 
		/// </summary>
		public int ServerLogID
		{
			set{ _serverlogid=value;}
			get{return _serverlogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Logger
		{
			set{ _logger=value;}
			get{return _logger;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Thread
		{
			set{ _thread=value;}
			get{return _thread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Exception
		{
			set{ _exception=value;}
			get{return _exception;}
		}
		#endregion Model

	}
}

