using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_Statistic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Statistic
	{
		public T_Statistic()
		{}
		#region Model
		private int _statisticid;
		private int? _taskid;
		private int? _machinetype;
		private int? _specificationid;
		private int? _jobsheetid;
		private int? _machineid;
		private int? _employeeid;
		private int? _runtime;
		private int? _downtime;
		private int? _velocity;
		private decimal? _ppm;
		private decimal? _pr;
		private decimal? _orv;
		private decimal? _qr;
		private decimal? _oee;
		private decimal? _odex;
		private decimal? _oddx;
		private decimal? _odkurts;
		private decimal? _odmax;
		private decimal? _odmin;
		private decimal? _stressex;
		private decimal? _stressdx;
		private decimal? _stresskurts;
		private decimal? _stressmax;
		private decimal? _stressmin;
		private decimal? _speedex;
		private decimal? _speedx;
		private decimal? _speekurts;
		private decimal? _speemax;
		private decimal? _speemin;
		private decimal? _unitpower;
		private decimal? _unitproduct;
		private string _axis_no;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int StatisticID
		{
			set{ _statisticid=value;}
			get{return _statisticid;}
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
		public int? MachineType
		{
			set{ _machinetype=value;}
			get{return _machinetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpecificationID
		{
			set{ _specificationid=value;}
			get{return _specificationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobSheetID
		{
			set{ _jobsheetid=value;}
			get{return _jobsheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RunTime
		{
			set{ _runtime=value;}
			get{return _runtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DownTime
		{
			set{ _downtime=value;}
			get{return _downtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Velocity
		{
			set{ _velocity=value;}
			get{return _velocity;}
		}
		/// <summary>
		/// 直通率
		/// </summary>
		public decimal? PPM
		{
			set{ _ppm=value;}
			get{return _ppm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PR
		{
			set{ _pr=value;}
			get{return _pr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORV
		{
			set{ _orv=value;}
			get{return _orv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? QR
		{
			set{ _qr=value;}
			get{return _qr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OEE
		{
			set{ _oee=value;}
			get{return _oee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODEX
		{
			set{ _odex=value;}
			get{return _odex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODDX
		{
			set{ _oddx=value;}
			get{return _oddx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODkurts
		{
			set{ _odkurts=value;}
			get{return _odkurts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODMax
		{
			set{ _odmax=value;}
			get{return _odmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ODMin
		{
			set{ _odmin=value;}
			get{return _odmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StressEX
		{
			set{ _stressex=value;}
			get{return _stressex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StressDX
		{
			set{ _stressdx=value;}
			get{return _stressdx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Stresskurts
		{
			set{ _stresskurts=value;}
			get{return _stresskurts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StressMax
		{
			set{ _stressmax=value;}
			get{return _stressmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? StressMin
		{
			set{ _stressmin=value;}
			get{return _stressmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpeedEX
		{
			set{ _speedex=value;}
			get{return _speedex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpeeDX
		{
			set{ _speedx=value;}
			get{return _speedx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Speekurts
		{
			set{ _speekurts=value;}
			get{return _speekurts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpeeMax
		{
			set{ _speemax=value;}
			get{return _speemax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SpeeMin
		{
			set{ _speemin=value;}
			get{return _speemin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPower
		{
			set{ _unitpower=value;}
			get{return _unitpower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitProduct
		{
			set{ _unitproduct=value;}
			get{return _unitproduct;}
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
		public DateTime? Datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

