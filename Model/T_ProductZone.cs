using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ProductZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ProductZone
	{
		public T_ProductZone()
		{}
		#region Model
		private int _productzoneid;
		private string _productzonename;
		private string _productzonepicurl;
		private decimal? _x_position;
		private decimal? _y_position;
		/// <summary>
		/// 
		/// </summary>
		public int ProductZoneID
		{
			set{ _productzoneid=value;}
			get{return _productzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductZoneName
		{
			set{ _productzonename=value;}
			get{return _productzonename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductZonePicUrl
		{
			set{ _productzonepicurl=value;}
			get{return _productzonepicurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? X_Position
		{
			set{ _x_position=value;}
			get{return _x_position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Y_Position
		{
			set{ _y_position=value;}
			get{return _y_position;}
		}
		#endregion Model

	}
}

