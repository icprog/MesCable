using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CodeRule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CodeRule
	{
		public T_CodeRule()
		{}
		#region Model
		private int _coderuleid;
		private int? _codetypeid;
		private int? _rank;
		private int? _ranklen;
		private string _rankmean;
		/// <summary>
		/// 
		/// </summary>
		public int CodeRuleID
		{
			set{ _coderuleid=value;}
			get{return _coderuleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CodeTypeID
		{
			set{ _codetypeid=value;}
			get{return _codetypeid;}
		}
		/// <summary>
		/// 段位
		/// </summary>
		public int? Rank
		{
			set{ _rank=value;}
			get{return _rank;}
		}
		/// <summary>
		/// 段位长度
		/// </summary>
		public int? RankLen
		{
			set{ _ranklen=value;}
			get{return _ranklen;}
		}
		/// <summary>
		/// 段位含义
		/// </summary>
		public string RankMean
		{
			set{ _rankmean=value;}
			get{return _rankmean;}
		}
		#endregion Model

	}
}

