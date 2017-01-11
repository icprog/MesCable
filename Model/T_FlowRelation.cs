using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_FlowRelation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_FlowRelation
	{
		public T_FlowRelation()
		{}
		#region Model
		private int _flowrelationid;
		private int? _authenticid;
		private int? _applicationitemid;
		private int? _flowid;
		/// <summary>
		/// 
		/// </summary>
		public int FlowRelationID
		{
			set{ _flowrelationid=value;}
			get{return _flowrelationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AuthenticID
		{
			set{ _authenticid=value;}
			get{return _authenticid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplicationItemID
		{
			set{ _applicationitemid=value;}
			get{return _applicationitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		#endregion Model

	}
}

