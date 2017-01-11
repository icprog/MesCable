
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_TCP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_TCP
	{
		public T_TCP()
		{}
		#region Model
		private int _tcpid;
		private int? _machineid;
		private string _ipaddress;
		private int? _state;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int TCPID
		{
			set{ _tcpid=value;}
			get{return _tcpid;}
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
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
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

