
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Product_Standard:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Product_Standard
	{
		public T_Report_Product_Standard()
		{}
		#region Model
		private int _id;
		private string _conductorstruct;
		private string _verticaldia;
		private string _edgediaavg;
		private string _edgediamin;
		private string _sheathavg;
		private string _sheathmin;
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
		public string VerticalDia
		{
			set{ _verticaldia=value;}
			get{return _verticaldia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaAvg
		{
			set{ _edgediaavg=value;}
			get{return _edgediaavg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EdgeDiaMin
		{
			set{ _edgediamin=value;}
			get{return _edgediamin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathAvg
		{
			set{ _sheathavg=value;}
			get{return _sheathavg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SheathMin
		{
			set{ _sheathmin=value;}
			get{return _sheathmin;}
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

