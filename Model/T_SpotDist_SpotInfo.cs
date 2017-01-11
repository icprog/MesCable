
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_SpotDist_SpotInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SpotDist_SpotInfo
	{
		public T_SpotDist_SpotInfo()
		{}
		#region Model
		private int _id;
		private int _spotdistid;
		private int _spotinfoid;
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
		public int SpotDistId
		{
			set{ _spotdistid=value;}
			get{return _spotdistid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SpotInfoId
		{
			set{ _spotinfoid=value;}
			get{return _spotinfoid;}
		}
		#endregion Model

	}
}

