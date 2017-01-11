
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialOutput:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialOutput
	{
		public T_MaterialOutput()
		{}
		#region Model
		private int _materialoutputid;
		private int? _materialid;
		private string _materialnum;
		private DateTime? _gneratetime;
		private int? _employeeid;
		private string _weight;
		private string _color;
		private string _certificate;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialOutputID
		{
			set{ _materialoutputid=value;}
			get{return _materialoutputid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GnerateTime
		{
			set{ _gneratetime=value;}
			get{return _gneratetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Certificate
		{
			set{ _certificate=value;}
			get{return _certificate;}
		}
		#endregion Model

	}
}

