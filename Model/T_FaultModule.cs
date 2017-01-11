
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_FaultModule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_FaultModule
	{
		public T_FaultModule()
		{}
		#region Model
		private int _faultmoduleid;
		private int? _machineid;
		private string _state;
		private string _serialnum;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int FaultModuleID
		{
			set{ _faultmoduleid=value;}
			get{return _faultmoduleid;}
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
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

