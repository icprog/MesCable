/**  版本信息模板在安装目录下，可自行修改。
* T_SensorModule.cs
*
* 功 能： N/A
* 类 名： T_SensorModule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:24   N/A    初版
*
* Copyright (c) 2012 MES Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_SensorModule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SensorModule
	{
		public T_SensorModule()
		{}
		#region Model
		private int _sensormoduleid;
		private int? _machineid;
		private int? _faultmoduleid=-1;
		private string _serialnum;
		private DateTime? _installtime;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int SensorModuleID
		{
			set{ _sensormoduleid=value;}
			get{return _sensormoduleid;}
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
		public int? FaultModuleID
		{
			set{ _faultmoduleid=value;}
			get{return _faultmoduleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InstallTime
		{
			set{ _installtime=value;}
			get{return _installtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

