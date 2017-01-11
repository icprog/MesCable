using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CheckSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CheckSheet
	{
		public T_CheckSheet()
		{}
		#region Model
		private int _checksheetid;
		private int? _checkparsrefid;
		private string _axis_no;
		private string _checkpar;
		private string _checkvalue;
		private string _checkrst;
		private DateTime? _checktime;
		private string _checkperson;
		/// <summary>
		/// 
		/// </summary>
		public int CheckSheetID
		{
			set{ _checksheetid=value;}
			get{return _checksheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckParsRefID
		{
			set{ _checkparsrefid=value;}
			get{return _checkparsrefid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPar
		{
			set{ _checkpar=value;}
			get{return _checkpar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckValue
		{
			set{ _checkvalue=value;}
			get{return _checkvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckRST
		{
			set{ _checkrst=value;}
			get{return _checkrst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPerson
		{
			set{ _checkperson=value;}
			get{return _checkperson;}
		}
		#endregion Model

	}
}

