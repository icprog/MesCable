using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_SpecificationType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SpecificationType
	{
		public T_SpecificationType()
		{}
		#region Model
		private int _specificationtypeid;
		private string _specificationtype;
		/// <summary>
		/// 
		/// </summary>
		public int SpecificationTypeID
		{
			set{ _specificationtypeid=value;}
			get{return _specificationtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecificationType
		{
			set{ _specificationtype=value;}
			get{return _specificationtype;}
		}
		#endregion Model

	}
}

