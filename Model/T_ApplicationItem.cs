using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ApplicationItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ApplicationItem
	{
		public T_ApplicationItem()
		{}
		#region Model
		private int _applicationitemid;
		private string _applicationitemtype;
		/// <summary>
		/// 
		/// </summary>
		public int ApplicationItemID
		{
			set{ _applicationitemid=value;}
			get{return _applicationitemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplicationItemType
		{
			set{ _applicationitemtype=value;}
			get{return _applicationitemtype;}
		}
		#endregion Model

	}
}

