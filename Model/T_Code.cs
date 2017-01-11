using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Code:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Code
	{
		public T_Code()
		{}
		#region Model
		private int _codeid;
		private int? _coderuleid;
		private string _codenumber;
		/// <summary>
		/// 
		/// </summary>
		public int CodeID
		{
			set{ _codeid=value;}
			get{return _codeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CodeRuleID
		{
			set{ _coderuleid=value;}
			get{return _coderuleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CodeNumber
		{
			set{ _codenumber=value;}
			get{return _codenumber;}
		}
		#endregion Model

	}
}

