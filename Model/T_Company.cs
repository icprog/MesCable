using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Company:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Company
	{
		public T_Company()
		{}
		#region Model
		private int _companyid;
		private string _companyname;
		private string _companyinfo;
		private string _companyaddress;
		private string _companycontactperson;
		private string _companycontacttel;
		/// <summary>
		/// 
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyInfo
		{
			set{ _companyinfo=value;}
			get{return _companyinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyAddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyContactPerson
		{
			set{ _companycontactperson=value;}
			get{return _companycontactperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyContactTel
		{
			set{ _companycontacttel=value;}
			get{return _companycontacttel;}
		}
		#endregion Model

	}
}

