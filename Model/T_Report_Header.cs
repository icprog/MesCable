
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Header:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Header
	{
		public T_Report_Header()
		{}
		#region Model
		private int _id;
		private string _specnum;
		private string _supplier;
		private string _samplecolor;
		private string _batchnum;
		private string _incommingqty;
		private string _hasoutfactoryreport;
		private string _samplenum;
		private string _checkdate;
		private DateTime? _inputdate;
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
		public string SpecNum
		{
			set{ _specnum=value;}
			get{return _specnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Supplier
		{
			set{ _supplier=value;}
			get{return _supplier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleColor
		{
			set{ _samplecolor=value;}
			get{return _samplecolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchNum
		{
			set{ _batchnum=value;}
			get{return _batchnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InCommingQty
		{
			set{ _incommingqty=value;}
			get{return _incommingqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HasOutFactoryReport
		{
			set{ _hasoutfactoryreport=value;}
			get{return _hasoutfactoryreport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleNum
		{
			set{ _samplenum=value;}
			get{return _samplenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InputDate
		{
			set{ _inputdate=value;}
			get{return _inputdate;}
		}
		#endregion Model

	}
}

