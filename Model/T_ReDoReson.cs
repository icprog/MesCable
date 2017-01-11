using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ReDoReson:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ReDoReson
	{
		public T_ReDoReson()
		{}
		#region Model
		private int _redoresonid;
		private string _redoreson;
		/// <summary>
		/// 
		/// </summary>
		public int ReDoResonID
		{
			set{ _redoresonid=value;}
			get{return _redoresonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReDoReson
		{
			set{ _redoreson=value;}
			get{return _redoreson;}
		}
		#endregion Model

	}
}

