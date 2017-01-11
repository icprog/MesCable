using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_QRCode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_QRCode
	{
		public T_QRCode()
		{}
		#region Model
		private int _qrcodeid;
		private string _axis_no;
		private string _qrcode;
		private DateTime? _datetime;
		private int? _employeeid;
		/// <summary>
		/// 
		/// </summary>
		public int QRCodeID
		{
			set{ _qrcodeid=value;}
			get{return _qrcodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QRCode
		{
			set{ _qrcode=value;}
			get{return _qrcode;}
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
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		#endregion Model

	}
}

