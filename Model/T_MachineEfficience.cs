using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineEfficience:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineEfficience
	{
		public T_MachineEfficience()
		{}
		#region Model
		private int _machineefficienceid;
		private int? _machineid;
		private int? _jobsheetid;
		private decimal? _machineefficiencevalue;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int MachineEfficienceID
		{
			set{ _machineefficienceid=value;}
			get{return _machineefficienceid;}
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
		public int? JobSheetID
		{
			set{ _jobsheetid=value;}
			get{return _jobsheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MachineEfficienceValue
		{
			set{ _machineefficiencevalue=value;}
			get{return _machineefficiencevalue;}
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

