using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialConsumption:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialConsumption
	{
		public T_MaterialConsumption()
		{}
		#region Model
		private int _materialconsumptionid;
		private int? _machineid;
		private int? _materialoutputid;
		private decimal? _materialconsumptionvaule;
		private int? _jobsheetid;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialConsumptionID
		{
			set{ _materialconsumptionid=value;}
			get{return _materialconsumptionid;}
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
		public int? MaterialOutputID
		{
			set{ _materialoutputid=value;}
			get{return _materialoutputid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MaterialConsumptionVaule
		{
			set{ _materialconsumptionvaule=value;}
			get{return _materialconsumptionvaule;}
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
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

