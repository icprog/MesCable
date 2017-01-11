using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_DumplingType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_DumplingType
	{
		public T_DumplingType()
		{}
		#region Model
		private int _dumplingtype;
		private string _dumplingtypename;
		/// <summary>
		/// 
		/// </summary>
		public int DumplingType
		{
			set{ _dumplingtype=value;}
			get{return _dumplingtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DumplingTypeName
		{
			set{ _dumplingtypename=value;}
			get{return _dumplingtypename;}
		}
		#endregion Model

	}
}

