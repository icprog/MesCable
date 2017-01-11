using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Material:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Material
	{
		public T_Material()
		{}
		#region Model
		private int _materialid;
		private int? _materialtypeid;
		private string _materialcode;
		private int? _materialzoneid;
		private decimal? _materialnum;
		private DateTime? _materialinputtime;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
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
		public int? MaterialZoneID
		{
			set{ _materialzoneid=value;}
			get{return _materialzoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MaterialInputTime
		{
			set{ _materialinputtime=value;}
			get{return _materialinputtime;}
		}
		#endregion Model

	}
}

