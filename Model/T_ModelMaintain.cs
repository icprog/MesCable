using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ModelMaintain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ModelMaintain
	{
		public T_ModelMaintain()
		{}
		#region Model
		private int _mouldmaintainid;
		private int? _mouldid;
		private int? _mouldmaintainnumber;
		private int? _mouldmaintainpersonid;
		private DateTime? _datetime;
		private bool _ismaintained;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int MouldMaintainID
		{
			set{ _mouldmaintainid=value;}
			get{return _mouldmaintainid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldID
		{
			set{ _mouldid=value;}
			get{return _mouldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldMaintainNumber
		{
			set{ _mouldmaintainnumber=value;}
			get{return _mouldmaintainnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldMaintainPersonID
		{
			set{ _mouldmaintainpersonid=value;}
			get{return _mouldmaintainpersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMaintained
		{
			set{ _ismaintained=value;}
			get{return _ismaintained;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

