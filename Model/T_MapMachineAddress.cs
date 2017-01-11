
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MapMachineAddress:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MapMachineAddress
	{
		public T_MapMachineAddress()
		{}
		#region Model
		private int _mapmachineaddressid;
		private string _maprule;
		/// <summary>
		/// 
		/// </summary>
		public int MapMachineAddressID
		{
			set{ _mapmachineaddressid=value;}
			get{return _mapmachineaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MapRule
		{
			set{ _maprule=value;}
			get{return _maprule;}
		}
		#endregion Model

	}
}

