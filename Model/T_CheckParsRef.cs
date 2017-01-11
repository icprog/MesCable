using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CheckParsRef:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CheckParsRef
	{
		public T_CheckParsRef()
		{}
		#region Model
		private int _checkparsrefid;
		private int? _checktypeid;
		private decimal? _uppervalue;
		private decimal? _lower;
		private string _otherstandard;
		/// <summary>
		/// 
		/// </summary>
		public int CheckParsRefID
		{
			set{ _checkparsrefid=value;}
			get{return _checkparsrefid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckTypeID
		{
			set{ _checktypeid=value;}
			get{return _checktypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UpperValue
		{
			set{ _uppervalue=value;}
			get{return _uppervalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Lower
		{
			set{ _lower=value;}
			get{return _lower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherStandard
		{
			set{ _otherstandard=value;}
			get{return _otherstandard;}
		}
		#endregion Model

	}
}

