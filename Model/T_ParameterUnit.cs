
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ParameterUnit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ParameterUnit
	{
		public T_ParameterUnit()
		{}
		#region Model
		private int _parameterunitid;
		private string _parameterunitname;
		private string _parameterunitsymbol;
		/// <summary>
		/// 
		/// </summary>
		public int ParameterUnitID
		{
			set{ _parameterunitid=value;}
			get{return _parameterunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParameterUnitName
		{
			set{ _parameterunitname=value;}
			get{return _parameterunitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParameterUnitSymbol
		{
			set{ _parameterunitsymbol=value;}
			get{return _parameterunitsymbol;}
		}
		#endregion Model

	}
}

