
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Specification:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Specification
	{
		public T_Specification()
		{}
		#region Model
		private int _specificationid;
		private int? _specificationtypeid;
		private string _specificationname;
		private string _specificationscale;
		private string _specificationcolor;
		private decimal? _odmax;
		private decimal? _odmin;
		private decimal? _specificationprice;
		/// <summary>
		/// 
		/// </summary>
		public int SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecificationTypeID
		{
			set{ _specificationtypeid=value;}
			get{return _specificationtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecificationName
		{
			set{ _specificationname=value;}
			get{return _specificationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecificationScale
		{
			set{ _specificationscale=value;}
			get{return _specificationscale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecificationColor
		{
			set{ _specificationcolor=value;}
			get{return _specificationcolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODMax
		{
			set{ _odmax=value;}
			get{return _odmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODMin
		{
			set{ _odmin=value;}
			get{return _odmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpecificationPrice
		{
			set{ _specificationprice=value;}
			get{return _specificationprice;}
		}
		#endregion Model

	}
}

