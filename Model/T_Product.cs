using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Product
	{
		public T_Product()
		{}
		#region Model
		private int _productid;
		private int? _productzoneid;
		private int? _axis_no;
		private int? _operatorid;
		private DateTime? _datetime;
		private decimal? _length;
		/// <summary>
		/// 
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductZoneID
		{
			set{ _productzoneid=value;}
			get{return _productzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		#endregion Model

	}
}

