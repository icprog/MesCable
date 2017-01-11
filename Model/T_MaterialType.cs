using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialType
	{
		public T_MaterialType()
		{}
		#region Model
		private int _materialtypeid;
		private string _materialtype;
		private string _materialtypeinfo;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialTypeID
		{
			set{ _materialtypeid=value;}
			get{return _materialtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialType
		{
			set{ _materialtype=value;}
			get{return _materialtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialTypeInfo
		{
			set{ _materialtypeinfo=value;}
			get{return _materialtypeinfo;}
		}
		#endregion Model

	}
}

