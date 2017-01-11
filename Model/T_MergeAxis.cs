using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MergeAxis:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MergeAxis
	{
		public T_MergeAxis()
		{}
		#region Model
		private int _mergeaxisid;
		private int? _axistaskid;
		private int? _specificationid;
		private int? _task;
		private int _meters;
		/// <summary>
		/// 
		/// </summary>
		public int MergeAxisID
		{
			set{ _mergeaxisid=value;}
			get{return _mergeaxisid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AxisTaskID
		{
			set{ _axistaskid=value;}
			get{return _axistaskid;}
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
		public int? Task
		{
			set{ _task=value;}
			get{return _task;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Meters
		{
			set{ _meters=value;}
			get{return _meters;}
		}
		#endregion Model

	}
}

