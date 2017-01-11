using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialZone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialZone
	{
		public T_MaterialZone()
		{}
		#region Model
		private int _materialzoneid;
		private int? _materialtypeid;
		private string _materialcode;
		private string _materialpic;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialZoneID
		{
			set{ _materialzoneid=value;}
			get{return _materialzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaterialTypeID
		{
			set{ _materialtypeid=value;}
			get{return _materialtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialCode
		{
			set{ _materialcode=value;}
			get{return _materialcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialPic
		{
			set{ _materialpic=value;}
			get{return _materialpic;}
		}
		#endregion Model

	}
}

