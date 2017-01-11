using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Technique:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Technique
	{
		public T_Technique()
		{}
		#region Model
		private int _techniqueid;
		private int? _collectedparameterid;
		private int? _machineid;
		private int? _specificationid;
		private decimal? _parametervaluemin;
		private decimal? _parametervaluemax;
		/// <summary>
		/// 
		/// </summary>
		public int TechniqueID
		{
			set{ _techniqueid=value;}
			get{return _techniqueid;}
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
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
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
		public decimal? ParameterValueMin
		{
			set{ _parametervaluemin=value;}
			get{return _parametervaluemin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ParameterValueMax
		{
			set{ _parametervaluemax=value;}
			get{return _parametervaluemax;}
		}
		#endregion Model

	}
}

