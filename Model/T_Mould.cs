using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Mould:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Mould
	{
		public T_Mould()
		{}
		#region Model
		private int _mouldid;
		private int? _mouldzoneid;
		private int? _mouldtypeid;
		private string _mouldname;
		private int? _mouldnumber;
		private int? _employeeid;
		/// <summary>
		/// 
		/// </summary>
		public int MouldID
		{
			set{ _mouldid=value;}
			get{return _mouldid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldZoneID
		{
			set{ _mouldzoneid=value;}
			get{return _mouldzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldTypeID
		{
			set{ _mouldtypeid=value;}
			get{return _mouldtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MouldName
		{
			set{ _mouldname=value;}
			get{return _mouldname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MouldNumber
		{
			set{ _mouldnumber=value;}
			get{return _mouldnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		#endregion Model

	}
}

