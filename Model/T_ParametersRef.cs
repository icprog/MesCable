using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ParametersRef:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ParametersRef
	{
		public T_ParametersRef()
		{}
		#region Model
		private int _parametersrefid;
		private int? _specificationid;
		private int? _machineid;
		private int? _collectedparameterid;
		private decimal? _settingvalue;
		private decimal? _maxiumvalue;
		private decimal? _miniumvalue;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int ParametersRefID
		{
			set{ _parametersrefid=value;}
			get{return _parametersrefid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
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
		public int? CollectedParameterID
		{
			set{ _collectedparameterid=value;}
			get{return _collectedparameterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SettingValue
		{
			set{ _settingvalue=value;}
			get{return _settingvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MaxiumValue
		{
			set{ _maxiumvalue=value;}
			get{return _maxiumvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MiniumValue
		{
			set{ _miniumvalue=value;}
			get{return _miniumvalue;}
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

