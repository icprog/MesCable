using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Flow:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Flow
	{
		public T_Flow()
		{}
		#region Model
		private int _flowid;
		private string _axis_no;
		private int? _machineid;
		private DateTime? _datetime;
		private decimal? _cpk_od;
		private decimal? _avg_thine;
		private int? _employeeid;
		private string _materialid;
		/// <summary>
		/// 
		/// </summary>
		public int FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
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
		public decimal? CPK_OD
		{
			set{ _cpk_od=value;}
			get{return _cpk_od;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AVG_Thine
		{
			set{ _avg_thine=value;}
			get{return _avg_thine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		#endregion Model

	}
}

