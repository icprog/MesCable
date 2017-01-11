using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Authentic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Authentic
	{
		public T_Authentic()
		{}
		#region Model
		private int _authenticid;
		private string _authentictypename;
		/// <summary>
		/// 
		/// </summary>
		public int AuthenticID
		{
			set{ _authenticid=value;}
			get{return _authenticid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AuthenticTypeName
		{
			set{ _authentictypename=value;}
			get{return _authentictypename;}
		}
		#endregion Model

	}
}

