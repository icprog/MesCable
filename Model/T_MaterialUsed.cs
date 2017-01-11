using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialUsed:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialUsed
	{
		public T_MaterialUsed()
		{}
		#region Model
		private int _materialusedid;
		private int? _specificationid;
		private int? _materialid;
		private decimal? _number;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialUsedID
		{
			set{ _materialusedid=value;}
			get{return _materialusedid;}
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
		public int? MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		#endregion Model

	}
}

