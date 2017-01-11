using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineZone
	{
		public T_MachineZone()
		{}
		#region Model
		private int _machinezoneid;
		private string _machinezone;
		private string _machinezonepicurl;
		/// <summary>
		/// 
		/// </summary>
		public int MachineZoneID
		{
			set{ _machinezoneid=value;}
			get{return _machinezoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineZone
		{
			set{ _machinezone=value;}
			get{return _machinezone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineZonePicUrl
		{
			set{ _machinezonepicurl=value;}
			get{return _machinezonepicurl;}
		}
		#endregion Model

	}
}

