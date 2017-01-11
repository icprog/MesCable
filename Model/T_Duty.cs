using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Duty:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Duty
	{
		public T_Duty()
		{}
		#region Model
		private int _dutyid;
		private string _dutytype;
		/// <summary>
		/// 
		/// </summary>
		public int DutyID
		{
			set{ _dutyid=value;}
			get{return _dutyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DutyType
		{
			set{ _dutytype=value;}
			get{return _dutytype;}
		}
		#endregion Model

	}
}

