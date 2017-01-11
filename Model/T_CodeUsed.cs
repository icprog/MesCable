
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_CodeUsed:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CodeUsed
	{
		public T_CodeUsed()
		{}
		#region Model
		private int _codeusedid;
		private string _codenumber;
		private string _axis_no;
		private DateTime? _generatortime;
		private int? _machineid;
		/// <summary>
		/// 
		/// </summary>
		public int CodeUsedID
		{
			set{ _codeusedid=value;}
			get{return _codeusedid;}
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
		public DateTime? GeneratorTime
		{
			set{ _generatortime=value;}
			get{return _generatortime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		#endregion Model

	}
}

