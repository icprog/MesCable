
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Value:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Value
	{
		public T_Report_Value()
		{}
		#region Model
		private int _id;
		private string _unit;
		private string _standard;
		private string _actual1;
		private string _actual2;
		private string _actual3;
		private string _actual4;
		private string _actual5;
		private string _result;
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
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Standard
		{
			set{ _standard=value;}
			get{return _standard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Actual1
		{
			set{ _actual1=value;}
			get{return _actual1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Actual2
		{
			set{ _actual2=value;}
			get{return _actual2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Actual3
		{
			set{ _actual3=value;}
			get{return _actual3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Actual4
		{
			set{ _actual4=value;}
			get{return _actual4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Actual5
		{
			set{ _actual5=value;}
			get{return _actual5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		#endregion Model

	}
}

