using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Flow_Info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Flow_Info
	{
		public T_Flow_Info()
		{}
		#region Model
		private int _flowid;
		private string _flowname;
		private int? _procid;
		private bool _issystem;
		private string _signname;
		private bool _isagreement;
		private DateTime? _signdate;
		/// <summary>
		/// 
		/// </summary>
		public int FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FlowName
		{
			set{ _flowname=value;}
			get{return _flowname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProcID
		{
			set{ _procid=value;}
			get{return _procid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSystem
		{
			set{ _issystem=value;}
			get{return _issystem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SignName
		{
			set{ _signname=value;}
			get{return _signname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsAgreement
		{
			set{ _isagreement=value;}
			get{return _isagreement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SignDate
		{
			set{ _signdate=value;}
			get{return _signdate;}
		}
		#endregion Model

	}
}

