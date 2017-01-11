using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_JobSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_JobSheet
	{
		public T_JobSheet()
		{}
		#region Model
		private int _jobsheetid;
		private string _jobsheetname;
		private string _jobsheetcode;
		private DateTime? _jobsheetdate;
		private int? _materialid;
		private int? _unitlength;
		private int? _numer;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int JobSheetID
		{
			set{ _jobsheetid=value;}
			get{return _jobsheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobSheetName
		{
			set{ _jobsheetname=value;}
			get{return _jobsheetname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobSheetCode
		{
			set{ _jobsheetcode=value;}
			get{return _jobsheetcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JobSheetDate
		{
			set{ _jobsheetdate=value;}
			get{return _jobsheetdate;}
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
		public int? UnitLength
		{
			set{ _unitlength=value;}
			get{return _unitlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Numer
		{
			set{ _numer=value;}
			get{return _numer;}
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

