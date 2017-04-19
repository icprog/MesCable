
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_AllReport:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_AllReport
	{
		public T_AllReport()
		{}
		#region Model
		private int _id;
		private string _reportvalue;
		private string _indexvalue;
		private string _reporttype;
		private DateTime? _inputdate;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportValue
		{
			set{ _reportvalue=value;}
			get{return _reportvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndexValue
		{
			set{ _indexvalue=value;}
			get{return _indexvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportType
		{
			set{ _reporttype=value;}
			get{return _reporttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InputDate
		{
			set{ _inputdate=value;}
			get{return _inputdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

