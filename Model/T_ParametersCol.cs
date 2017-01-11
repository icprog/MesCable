
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ParametersCol:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ParametersCol
	{
		public T_ParametersCol()
		{}
		#region Model
		private int _parameterscolid;
		private int? _specificationid;
		private int? _machineid;
		private int? _collectedparameterid;
		private string _parameterscolsettingvalue;
		private string _parameterscolmaxiumvalue;
		private string _parameterscolminiumvalue;
		private int? _parametercodeid;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int ParametersColID
		{
			set{ _parameterscolid=value;}
			get{return _parameterscolid;}
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
		public string ParametersColSettingValue
		{
			set{ _parameterscolsettingvalue=value;}
			get{return _parameterscolsettingvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParametersColMaxiumValue
		{
			set{ _parameterscolmaxiumvalue=value;}
			get{return _parameterscolmaxiumvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParametersColMiniumValue
		{
			set{ _parameterscolminiumvalue=value;}
			get{return _parameterscolminiumvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterCodeID
		{
			set{ _parametercodeid=value;}
			get{return _parametercodeid;}
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

