using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Dumpling:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Dumpling
	{
		public T_Dumpling()
		{}
		#region Model
		private int _dumplingid;
		private int? _dumplingtypeid;
		private int? _checkperson;
		private DateTime? _datetime;
		private string _dumplingcode;
		private int? _dumplingzoneid;
		/// <summary>
		/// 
		/// </summary>
		public int DumplingID
		{
			set{ _dumplingid=value;}
			get{return _dumplingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DumplingTypeID
		{
			set{ _dumplingtypeid=value;}
			get{return _dumplingtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckPerson
		{
			set{ _checkperson=value;}
			get{return _checkperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DumplingCode
		{
			set{ _dumplingcode=value;}
			get{return _dumplingcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DumplingZoneID
		{
			set{ _dumplingzoneid=value;}
			get{return _dumplingzoneid;}
		}
		#endregion Model

	}
}

