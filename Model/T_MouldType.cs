using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MouldType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MouldType
	{
		public T_MouldType()
		{}
		#region Model
		private int _mouldtypeid;
		private string _mouldtypenname;
		/// <summary>
		/// 
		/// </summary>
		public int MouldTypeID
		{
			set{ _mouldtypeid=value;}
			get{return _mouldtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MouldTypenName
		{
			set{ _mouldtypenname=value;}
			get{return _mouldtypenname;}
		}
		#endregion Model

	}
}

