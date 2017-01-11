
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Axis:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Axis
	{
		public T_Axis()
		{}
		#region Model
		private int _axisid;
		private string _codenumber;
		private string _axis_no;
		private DateTime? _datetime;
		private string _comment;
		private string _operator;
		/// <summary>
		/// 
		/// </summary>
		public int AxisID
		{
			set{ _axisid=value;}
			get{return _axisid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CodeNumber
		{
			set{ _codenumber=value;}
			get{return _codenumber;}
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
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		#endregion Model

	}
}

