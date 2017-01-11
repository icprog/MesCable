using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MouldZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MouldZone
	{
		public T_MouldZone()
		{}
		#region Model
		private int _mouldzoneid;
		private string _mouldzonename;
		private string _mouldzonepicurl;
		private decimal? _x_position;
		private decimal? _y_position;
		/// <summary>
		/// 
		/// </summary>
		public int MouldZoneID
		{
			set{ _mouldzoneid=value;}
			get{return _mouldzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MouldZoneName
		{
			set{ _mouldzonename=value;}
			get{return _mouldzonename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MouldZonePicUrl
		{
			set{ _mouldzonepicurl=value;}
			get{return _mouldzonepicurl;}
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

