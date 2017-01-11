
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_PARCODE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_PARCODE
	{
		public T_PARCODE()
		{}
		#region Model
		private int _parametercodeid;
		private int? _parametercode;
		private int? _parametertype;
		private string _parametername;
		private int? _parameterunitid;
		private int? _parameterbit;
		private int? _type;
		/// <summary>
		/// 
		/// </summary>
		public int ParameterCodeID
		{
			set{ _parametercodeid=value;}
			get{return _parametercodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterCode
		{
			set{ _parametercode=value;}
			get{return _parametercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterType
		{
			set{ _parametertype=value;}
			get{return _parametertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParameterName
		{
			set{ _parametername=value;}
			get{return _parametername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterUnitID
		{
			set{ _parameterunitid=value;}
			get{return _parameterunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterBit
		{
			set{ _parameterbit=value;}
			get{return _parameterbit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

