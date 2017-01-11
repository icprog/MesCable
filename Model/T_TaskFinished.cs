using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_TaskFinished:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_TaskFinished
	{
		public T_TaskFinished()
		{}
		#region Model
		private int _taskfinishedid;
		private int? _taskid;
		private DateTime? _datetime;
		private decimal? _finishedvalue;
		/// <summary>
		/// 
		/// </summary>
		public int TaskFinishedID
		{
			set{ _taskfinishedid=value;}
			get{return _taskfinishedid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
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
		public decimal? FinishedValue
		{
			set{ _finishedvalue=value;}
			get{return _finishedvalue;}
		}
		#endregion Model

	}
}

