
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Machine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Machine
	{
		public T_Machine()
		{}
		#region Model
		private int _machineid;
		private decimal? _machinepositionx;
		private decimal? _machinepositiony;
		private int? _machinezoneid;
		private int? _machinetypeid;
		private int? _machinepower;
		private string _machinename;
		private string _manufacturename;
		private DateTime? _productdate;
		private string _addressnumber;
		private int? _mapmachineaddressid;
		private int? _machineefficiency;
		/// <summary>
		/// 
		/// </summary>
		public int MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MachinePositionX
		{
			set{ _machinepositionx=value;}
			get{return _machinepositionx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MachinePositionY
		{
			set{ _machinepositiony=value;}
			get{return _machinepositiony;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineZoneID
		{
			set{ _machinezoneid=value;}
			get{return _machinezoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineTypeID
		{
			set{ _machinetypeid=value;}
			get{return _machinetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachinePower
		{
			set{ _machinepower=value;}
			get{return _machinepower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineName
		{
			set{ _machinename=value;}
			get{return _machinename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManufactureName
		{
			set{ _manufacturename=value;}
			get{return _manufacturename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProductDate
		{
			set{ _productdate=value;}
			get{return _productdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddressNumber
		{
			set{ _addressnumber=value;}
			get{return _addressnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MapMachineAddressID
		{
			set{ _mapmachineaddressid=value;}
			get{return _mapmachineaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineEfficiency
		{
			set{ _machineefficiency=value;}
			get{return _machineefficiency;}
		}
		#endregion Model

	}
}

