using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_ElectricityPrice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ElectricityPrice
	{
		public T_ElectricityPrice()
		{}
		#region Model
		private int _electricitypriceid;
		private string _electricityprice;
		private DateTime? _electricitystarttime;
		private DateTime? _electricityendtime;
		private DateTime? _generatestarttime;
		private DateTime _generateendtime;
		/// <summary>
		/// 
		/// </summary>
		public int ElectricityPriceID
		{
			set{ _electricitypriceid=value;}
			get{return _electricitypriceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ElectricityPrice
		{
			set{ _electricityprice=value;}
			get{return _electricityprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ElectricityStartTime
		{
			set{ _electricitystarttime=value;}
			get{return _electricitystarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ElectricityEndTime
		{
			set{ _electricityendtime=value;}
			get{return _electricityendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GenerateStartTime
		{
			set{ _generatestarttime=value;}
			get{return _generatestarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime GenerateEndTime
		{
			set{ _generateendtime=value;}
			get{return _generateendtime;}
		}
		#endregion Model

	}
}

