using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MouldUsed:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MouldUsed
	{
		public T_MouldUsed()
		{}
		#region Model
		private int _mouldusedid;
		private int? _mouldid;
		private int? _mouldusednumber;
		private int? _mouldusedpersonid;
		private DateTime? _datetime;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int MouldUsedID
		{
			set{ _mouldusedid=value;}
			get{return _mouldusedid;}
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
		public int? MouldUsedNumber
		{
			set{ _mouldusednumber=value;}
			get{return _mouldusednumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldUsedPersonID
		{
			set{ _mouldusedpersonid=value;}
			get{return _mouldusedpersonid;}
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
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

