using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Right:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Right
	{
		public T_Right()
		{}
		#region Model
		private int _rightid;
		private int? _authenticid;
		private int? _menuid;
		private int? _menuorder;
		private bool _isvisible;
		/// <summary>
		/// 
		/// </summary>
		public int RightID
		{
			set{ _rightid=value;}
			get{return _rightid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AuthenticID
		{
			set{ _authenticid=value;}
			get{return _authenticid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuOrder
		{
			set{ _menuorder=value;}
			get{return _menuorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsVisible
		{
			set{ _isvisible=value;}
			get{return _isvisible;}
		}
		#endregion Model

	}
}

