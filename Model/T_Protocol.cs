using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Protocol:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Protocol
	{
		public T_Protocol()
		{}
		#region Model
		private int _protocolid;
		private string _protocolpara;
		private int? _collectedparameterid;
		/// <summary>
		/// 
		/// </summary>
		public int ProtocolID
		{
			set{ _protocolid=value;}
			get{return _protocolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProtocolPara
		{
			set{ _protocolpara=value;}
			get{return _protocolpara;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CollectedParameterID
		{
			set{ _collectedparameterid=value;}
			get{return _collectedparameterid;}
		}
		#endregion Model

	}
}

