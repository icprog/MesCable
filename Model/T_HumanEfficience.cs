using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_HumanEfficience:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_HumanEfficience
	{
		public T_HumanEfficience()
		{}
		#region Model
		private int _humanefficienceid;
		private int? _jobsheetid;
		private int? _machineid;
		private int? _emplouyeeid;
		private int? _efficiencevalue;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int HumanEfficienceID
		{
			set{ _humanefficienceid=value;}
			get{return _humanefficienceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobSheetID
		{
			set{ _jobsheetid=value;}
			get{return _jobsheetid;}
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
		public int? EmplouyeeID
		{
			set{ _emplouyeeid=value;}
			get{return _emplouyeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EfficienceValue
		{
			set{ _efficiencevalue=value;}
			get{return _efficiencevalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

