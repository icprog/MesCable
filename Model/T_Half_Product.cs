﻿using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Half_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Half_Product
	{
		public T_Half_Product()
		{}
		#region Model
		private int _half_productid;
		private int? _half_productzoneid;
		private int? _axis_no;
		private DateTime? _datetime;
		private decimal? _length;
		private int? _operatorid;
		/// <summary>
		/// 
		/// </summary>
		public int Half_ProductID
		{
			set{ _half_productid=value;}
			get{return _half_productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Half_ProductZoneID
		{
			set{ _half_productzoneid=value;}
			get{return _half_productzoneid;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		#endregion Model

	}
}

