using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_JobSheetItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_JobSheetItem
	{
		public T_JobSheetItem()
		{}
		#region Model
		private int _jobsheetitemid;
		private int? _jobsheetid;
		private int? _machineid;
		private string _jobsheetitem;
		private int? _morder;
		/// <summary>
		/// 
		/// </summary>
		public int JobSheetItemID
		{
			set{ _jobsheetitemid=value;}
			get{return _jobsheetitemid;}
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
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobSheetItem
		{
			set{ _jobsheetitem=value;}
			get{return _jobsheetitem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MOrder
		{
			set{ _morder=value;}
			get{return _morder;}
		}
		#endregion Model

	}
}

