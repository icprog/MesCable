using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Port:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Port
	{
		public T_Port()
		{}
		#region Model
		private int _portid;
		private int? _specificationid;
		private int? _port;
		/// <summary>
		/// 
		/// </summary>
		public int PortID
		{
			set{ _portid=value;}
			get{return _portid;}
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
		public int? Port
		{
			set{ _port=value;}
			get{return _port;}
		}
		#endregion Model

	}
}

