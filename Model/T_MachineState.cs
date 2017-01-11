using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineState
	{
		public T_MachineState()
		{}
		#region Model
		private int _machinestateid;
		private int? _machineid;
		private int? _machinestatetypeid;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int MachineStateID
		{
			set{ _machinestateid=value;}
			get{return _machinestateid;}
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
		public int? MachineStateTypeID
		{
			set{ _machinestatetypeid=value;}
			get{return _machinestatetypeid;}
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

