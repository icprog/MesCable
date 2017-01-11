using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_OpenMachineCondition:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_OpenMachineCondition
	{
		public T_OpenMachineCondition()
		{}
		#region Model
		private int _openmachineconditionid;
		private int? _machineid;
		private bool _ismaterialiok;
		private bool _ismoudok;
		private bool _ismachinefree;
		/// <summary>
		/// 
		/// </summary>
		public int OpenMachineConditionID
		{
			set{ _openmachineconditionid=value;}
			get{return _openmachineconditionid;}
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
		public bool IsMaterialIOK
		{
			set{ _ismaterialiok=value;}
			get{return _ismaterialiok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMoudOK
		{
			set{ _ismoudok=value;}
			get{return _ismoudok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMachineFree
		{
			set{ _ismachinefree=value;}
			get{return _ismachinefree;}
		}
		#endregion Model

	}
}

