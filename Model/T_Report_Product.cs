
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Product
	{
		public T_Report_Product()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _volnum;
		private string _specnum;
		private string _num;
		private int? _standardid;
		private int? _actualid;
		private string _appearance;
		private string _checkresult;
		private DateTime? _inputdate;
		private string _supplier;
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
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VolNum
		{
			set{ _volnum=value;}
			get{return _volnum;}
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
		public string Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StandardId
		{
			set{ _standardid=value;}
			get{return _standardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ActualId
		{
			set{ _actualid=value;}
			get{return _actualid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Appearance
		{
			set{ _appearance=value;}
			get{return _appearance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckResult
		{
			set{ _checkresult=value;}
			get{return _checkresult;}
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
		public string Supplier
		{
			set{ _supplier=value;}
			get{return _supplier;}
		}
		#endregion Model

	}
}

