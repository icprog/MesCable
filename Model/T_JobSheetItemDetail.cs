using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_JobSheetItemDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_JobSheetItemDetail
	{
		public T_JobSheetItemDetail()
		{}
		#region Model
		private int _jobsheetitemdetailid;
		private int? _specificationid;
		private int? _jobsheetitemid;
		private string _jobsheetdetailitem;
		private string _jobsheetdetailitemvalue;
		/// <summary>
		/// 
		/// </summary>
		public int JobSheetItemDetailID
		{
			set{ _jobsheetitemdetailid=value;}
			get{return _jobsheetitemdetailid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobSheetItemID
		{
			set{ _jobsheetitemid=value;}
			get{return _jobsheetitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobSheetDetailItem
		{
			set{ _jobsheetdetailitem=value;}
			get{return _jobsheetdetailitem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobSheetDetailItemValue
		{
			set{ _jobsheetdetailitemvalue=value;}
			get{return _jobsheetdetailitemvalue;}
		}
		#endregion Model

	}
}

