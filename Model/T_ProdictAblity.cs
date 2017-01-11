using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ProdictAblity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ProdictAblity
	{
		public T_ProdictAblity()
		{}
		#region Model
		private int _prodictablityid;
		private int? _jobsheetid;
		private DateTime? _finishedtime;
		private decimal? _totalfee;
		/// <summary>
		/// 
		/// </summary>
		public int ProdictAblityID
		{
			set{ _prodictablityid=value;}
			get{return _prodictablityid;}
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
		public DateTime? FinishedTime
		{
			set{ _finishedtime=value;}
			get{return _finishedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Totalfee
		{
			set{ _totalfee=value;}
			get{return _totalfee;}
		}
		#endregion Model

	}
}

