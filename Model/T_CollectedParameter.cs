
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CollectedParameter:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CollectedParameter
	{
		public T_CollectedParameter()
		{}
		#region Model
		private int _collectedparameterid;
		private string _collectedparametername;
		private int? _collectedparameterbit;
		private int _parameterunitid;
		/// <summary>
		/// 
		/// </summary>
		public int CollectedParameterID
		{
			set{ _collectedparameterid=value;}
			get{return _collectedparameterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CollectedParameterName
		{
			set{ _collectedparametername=value;}
			get{return _collectedparametername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CollectedParameterBit
		{
			set{ _collectedparameterbit=value;}
			get{return _collectedparameterbit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParameterUnitID
		{
			set{ _parameterunitid=value;}
			get{return _parameterunitid;}
		}
		#endregion Model

	}
}

