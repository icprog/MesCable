
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Menu
	{
		public T_Menu()
		{}
		#region Model
		private int _menuid;
		private int? _menuparentid;
		private int _menulevel=0;
		private int? _menuseq;
		private string _menuname;
		private string _menuurl;
		private string _menuicon;
		private string _menuremark;
		/// <summary>
		/// 
		/// </summary>
		public int MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuParentID
		{
			set{ _menuparentid=value;}
			get{return _menuparentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MenuLevel
		{
			set{ _menulevel=value;}
			get{return _menulevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuSeq
		{
			set{ _menuseq=value;}
			get{return _menuseq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuICON
		{
			set{ _menuicon=value;}
			get{return _menuicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuRemark
		{
			set{ _menuremark=value;}
			get{return _menuremark;}
		}
		#endregion Model

	}
}

