using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Half_ProductZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Half_ProductZone
	{
		public T_Half_ProductZone()
		{}
		#region Model
		private int _half_productzoneid;
		private string _half_productzonename;
		private string _half_productzonepicurl;
		private decimal? _x_position;
		private decimal? _y_position;
		/// <summary>
		/// 
		/// </summary>
		public int Half_ProductZoneID
		{
			set{ _half_productzoneid=value;}
			get{return _half_productzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Half_ProductZoneName
		{
			set{ _half_productzonename=value;}
			get{return _half_productzonename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Half_ProductZonePicUrl
		{
			set{ _half_productzonepicurl=value;}
			get{return _half_productzonepicurl;}
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

