
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Product_Actual:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Product_Actual
	{
		public T_Report_Product_Actual()
		{}
		#region Model
		private int _id;
		private string _conductorstruct;
		private string _verticaldiaheader1;
		private string _verticaldiaheader2;
		private string _verticaldiafooter1;
		private string _verticaldiafooter2;
		private string _edgediaavgheader;
		private string _edgediaavgfooter;
		private string _edgediaminheader;
		private string _edgediaminfooter;
		private string _sheathavgheader;
		private string _sheathavgfooter;
		private string _sheathminheader;
		private string _sheathminfooter;
		private string _resistance;
		private string _voltagetest;
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
		public string ConductorStruct
		{
			set{ _conductorstruct=value;}
			get{return _conductorstruct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VerticalDiaHeader1
		{
			set{ _verticaldiaheader1=value;}
			get{return _verticaldiaheader1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VerticalDiaHeader2
		{
			set{ _verticaldiaheader2=value;}
			get{return _verticaldiaheader2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VerticalDiaFooter1
		{
			set{ _verticaldiafooter1=value;}
			get{return _verticaldiafooter1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VerticalDiaFooter2
		{
			set{ _verticaldiafooter2=value;}
			get{return _verticaldiafooter2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaAvgHeader
		{
			set{ _edgediaavgheader=value;}
			get{return _edgediaavgheader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaAvgFooter
		{
			set{ _edgediaavgfooter=value;}
			get{return _edgediaavgfooter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaMinHeader
		{
			set{ _edgediaminheader=value;}
			get{return _edgediaminheader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaMinFooter
		{
			set{ _edgediaminfooter=value;}
			get{return _edgediaminfooter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathAvgHeader
		{
			set{ _sheathavgheader=value;}
			get{return _sheathavgheader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathAvgFooter
		{
			set{ _sheathavgfooter=value;}
			get{return _sheathavgfooter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathMinHeader
		{
			set{ _sheathminheader=value;}
			get{return _sheathminheader;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathMinFooter
		{
			set{ _sheathminfooter=value;}
			get{return _sheathminfooter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Resistance
		{
			set{ _resistance=value;}
			get{return _resistance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoltageTest
		{
			set{ _voltagetest=value;}
			get{return _voltagetest;}
		}
		#endregion Model

	}
}

