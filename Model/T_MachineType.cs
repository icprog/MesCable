using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineType
	{
		public T_MachineType()
		{}
		#region Model
		private int _machinetypeid;
		private string _machinetype;
		/// <summary>
		/// 
		/// </summary>
		public int MachineTypeID
		{
			set{ _machinetypeid=value;}
			get{return _machinetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineType
		{
			set{ _machinetype=value;}
			get{return _machinetype;}
		}
		#endregion Model

	}
}

