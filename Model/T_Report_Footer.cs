
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Report_Footer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report_Footer
	{
		public T_Report_Footer()
		{}
		#region Model
		private int _id;
		private int? _icpreporter;
		private int? _zdenvtestresult;
		private string _passnum;
		private string _defectnum;
		private string _defectcode;
		private int? _verifyresult;
		private string _inspector;
		private string _auditer;
		private string _approver;
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
		public int? ICPReporter
		{
			set{ _icpreporter=value;}
			get{return _icpreporter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ZDEnvTestResult
		{
			set{ _zdenvtestresult=value;}
			get{return _zdenvtestresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassNum
		{
			set{ _passnum=value;}
			get{return _passnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefectNum
		{
			set{ _defectnum=value;}
			get{return _defectnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefectCode
		{
			set{ _defectcode=value;}
			get{return _defectcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VerifyResult
		{
			set{ _verifyresult=value;}
			get{return _verifyresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Inspector
		{
			set{ _inspector=value;}
			get{return _inspector;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Auditer
		{
			set{ _auditer=value;}
			get{return _auditer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Approver
		{
			set{ _approver=value;}
			get{return _approver;}
		}
		#endregion Model

	}
}

