using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LogDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LogDetail
	{
		public T_LogDetail()
		{}
		#region Model
		private int _logdetailid;
		private string _originname;
		private string _origincontent;
		private string _currentname;
		private string _currentcontent;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int LogDetailID
		{
			set{ _logdetailid=value;}
			get{return _logdetailid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginName
		{
			set{ _originname=value;}
			get{return _originname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginContent
		{
			set{ _origincontent=value;}
			get{return _origincontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CurrentName
		{
			set{ _currentname=value;}
			get{return _currentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CurrentContent
		{
			set{ _currentcontent=value;}
			get{return _currentcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

