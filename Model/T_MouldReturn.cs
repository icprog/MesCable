using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MouldReturn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MouldReturn
	{
		public T_MouldReturn()
		{}
		#region Model
		private int _mouldreturnid;
		private int? _mouldid;
		private int? _mouldreturnnumber;
		private int? _mouldreturnpersonid;
		private DateTime? _datetime;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int MouldReturnID
		{
			set{ _mouldreturnid=value;}
			get{return _mouldreturnid;}
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
		public int? MouldReturnNumber
		{
			set{ _mouldreturnnumber=value;}
			get{return _mouldreturnnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldReturnPersonID
		{
			set{ _mouldreturnpersonid=value;}
			get{return _mouldreturnpersonid;}
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

