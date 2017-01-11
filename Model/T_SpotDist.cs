
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_SpotDist:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SpotDist
	{
		public T_SpotDist()
		{}
		#region Model
		private int _id;
		private string _url;
		private string _pixel;
		private int? _spotdistentityid;
		private int? _spotdisttypeid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pixel
		{
			set{ _pixel=value;}
			get{return _pixel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpotDistEntityId
		{
			set{ _spotdistentityid=value;}
			get{return _spotdistentityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpotDistTypeId
		{
			set{ _spotdisttypeid=value;}
			get{return _spotdisttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

