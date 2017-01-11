using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MachineParameter:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MachineParameter
	{
		public T_MachineParameter()
		{}
		#region Model
		private int _machineparameterid;
		private int? _machineid;
		private string _collectedparameterids;
		/// <summary>
		/// 
		/// </summary>
		public int MachineParameterID
		{
			set{ _machineparameterid=value;}
			get{return _machineparameterid;}
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
		public string CollectedParameterIDS
		{
			set{ _collectedparameterids=value;}
			get{return _collectedparameterids;}
		}
		#endregion Model

	}
}

