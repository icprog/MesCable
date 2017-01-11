using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_DumplingZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_DumplingZone
	{
		public T_DumplingZone()
		{}
		#region Model
		private int _dumplingzoneid;
		private string _dumplingzonename;
		private string _dumplingzonepicurl;
		private decimal? _x_position;
		private decimal? _y_position;
		/// <summary>
		/// 
		/// </summary>
		public int DumplingZoneID
		{
			set{ _dumplingzoneid=value;}
			get{return _dumplingzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DumplingZoneName
		{
			set{ _dumplingzonename=value;}
			get{return _dumplingzonename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DumplingZonePicUrl
		{
			set{ _dumplingzonepicurl=value;}
			get{return _dumplingzonepicurl;}
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

