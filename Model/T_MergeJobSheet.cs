using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MergeJobSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MergeJobSheet
	{
		public T_MergeJobSheet()
		{}
		#region Model
		private int _mergejobsheetid;
		private int? _jobsheetid;
		private int? _needmergejobsheetid;
		private bool _isfinished;
		/// <summary>
		/// 
		/// </summary>
		public int MergeJobSheetID
		{
			set{ _mergejobsheetid=value;}
			get{return _mergejobsheetid;}
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
		public int? NeedMergeJobSheetID
		{
			set{ _needmergejobsheetid=value;}
			get{return _needmergejobsheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsFinished
		{
			set{ _isfinished=value;}
			get{return _isfinished;}
		}
		#endregion Model

	}
}

