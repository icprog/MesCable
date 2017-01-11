using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineStateType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineStateType
	{
		public T_MachineStateType()
		{}
		#region Model
		private int _machinestatetypeid;
		private string _machinestatetype;
		/// <summary>
		/// 
		/// </summary>
		public int MachineStateTypeID
		{
			set{ _machinestatetypeid=value;}
			get{return _machinestatetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineStateType
		{
			set{ _machinestatetype=value;}
			get{return _machinestatetype;}
		}
		#endregion Model

	}
}

