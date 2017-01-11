
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LayoutType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LayoutType
	{
		public T_LayoutType()
		{}
		#region Model
		private int _layoutttypeid;
		private string _tablename;
		private string _aliasname;
		private bool _isexisttable= false;
		private string _type;
		/// <summary>
		/// 
		/// </summary>
		public int LayoutTtypeID
		{
			set{ _layoutttypeid=value;}
			get{return _layoutttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AliasName
		{
			set{ _aliasname=value;}
			get{return _aliasname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsExistTable
		{
			set{ _isexisttable=value;}
			get{return _isexisttable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

