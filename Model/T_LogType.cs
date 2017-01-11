using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LogType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LogType
	{
		public T_LogType()
		{}
		#region Model
		private int _logtypeid;
		private string _logtypename;
		/// <summary>
		/// 
		/// </summary>
		public int LogTypeID
		{
			set{ _logtypeid=value;}
			get{return _logtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogTypeName
		{
			set{ _logtypename=value;}
			get{return _logtypename;}
		}
		#endregion Model

	}
}

