
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_SensorModule_T_ParameterCode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SensorModule_T_ParameterCode
	{
		public T_SensorModule_T_ParameterCode()
		{}
		#region Model
		private int _sensormodule_parcodeid;
		private int? _sensormoduleid;
		private int? _parametercodeid;
		/// <summary>
		/// 
		/// </summary>
		public int SensorModule_PARCODEID
		{
			set{ _sensormodule_parcodeid=value;}
			get{return _sensormodule_parcodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SensorModuleID
		{
			set{ _sensormoduleid=value;}
			get{return _sensormoduleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterCodeID
		{
			set{ _parametercodeid=value;}
			get{return _parametercodeid;}
		}
		#endregion Model

	}
}

