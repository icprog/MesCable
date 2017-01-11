using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CodeType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CodeType
	{
		public T_CodeType()
		{}
		#region Model
		private int _codetypeid;
		private string _codetypename;
		/// <summary>
		/// 
		/// </summary>
		public int CodeTypeID
		{
			set{ _codetypeid=value;}
			get{return _codetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CodeTypeName
		{
			set{ _codetypename=value;}
			get{return _codetypename;}
		}
		#endregion Model

	}
}

