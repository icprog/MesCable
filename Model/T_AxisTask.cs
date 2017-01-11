using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_AxisTask:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_AxisTask
	{
		public T_AxisTask()
		{}
		#region Model
		private int _axistaskid;
		private int? _jobsheetitemdetailid;
		private int? _specificationid;
		private string _color;
		private int? _unitlenth;
		private int? _num;
		private int? _weight;
		/// <summary>
		/// 
		/// </summary>
		public int AxisTaskID
		{
			set{ _axistaskid=value;}
			get{return _axistaskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobSheetItemDetailID
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
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UnitLenth
		{
			set{ _unitlenth=value;}
			get{return _unitlenth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		#endregion Model

	}
}

