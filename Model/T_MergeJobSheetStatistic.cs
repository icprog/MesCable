using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MergeJobSheetStatistic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MergeJobSheetStatistic
	{
		public T_MergeJobSheetStatistic()
		{}
		#region Model
		private int _mergejobsheetstatisticid;
		private int _needmergejobsheetid;
		private int? _jobsheetid;
		private DateTime? _operatordatetime;
		private int? _employeeid;
		/// <summary>
		/// 
		/// </summary>
		public int MergeJobSheetStatisticID
		{
			set{ _mergejobsheetstatisticid=value;}
			get{return _mergejobsheetstatisticid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NeedMergeJobSheetID
		{
			set{ _needmergejobsheetid=value;}
			get{return _needmergejobsheetid;}
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
		public DateTime? OperatorDateTime
		{
			set{ _operatordatetime=value;}
			get{return _operatordatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		#endregion Model

	}
}

