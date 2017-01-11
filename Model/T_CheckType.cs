using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CheckType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CheckType
	{
		public T_CheckType()
		{}
		#region Model
		private int _checktypeid;
		private int? _specificationid;
		private string _checktypename;
		/// <summary>
		/// 
		/// </summary>
		public int CheckTypeID
		{
			set{ _checktypeid=value;}
			get{return _checktypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckTypeName
		{
			set{ _checktypename=value;}
			get{return _checktypename;}
		}
		#endregion Model

	}
}

