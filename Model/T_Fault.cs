using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Fault:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Fault
	{
		public T_Fault()
		{}
		#region Model
		private int _faultid;
		private int? _faultparameterid;
		private decimal? _faultvalue;
		private int? _machineid;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int FaultID
		{
			set{ _faultid=value;}
			get{return _faultid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FaultParameterID
		{
			set{ _faultparameterid=value;}
			get{return _faultparameterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FaultValue
		{
			set{ _faultvalue=value;}
			get{return _faultvalue;}
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
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

