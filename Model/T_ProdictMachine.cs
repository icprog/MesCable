using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ProdictMachine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ProdictMachine
	{
		public T_ProdictMachine()
		{}
		#region Model
		private int _prodictmachinemaintainid;
		private int? _machineid;
		private DateTime? _prodictmachinetime;
		/// <summary>
		/// 
		/// </summary>
		public int ProdictMachineMaintainID
		{
			set{ _prodictmachinemaintainid=value;}
			get{return _prodictmachinemaintainid;}
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
		public DateTime? ProdictMachineTime
		{
			set{ _prodictmachinetime=value;}
			get{return _prodictmachinetime;}
		}
		#endregion Model

	}
}

