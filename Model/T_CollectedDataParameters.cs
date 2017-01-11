/**  版本信息模板在安装目录下，可自行修改。
* T_CollectedDataParameters.cs
*
* 功 能： N/A
* 类 名： T_CollectedDataParameters
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:21   N/A    初版
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
	/// T_CollectedDataParameters:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CollectedDataParameters
	{
		public T_CollectedDataParameters()
		{}
		#region Model
		private int _collecteddataparametersid;
		private string _collectedvalue;
		private DateTime? _collectedtime;
		private int? _parametercodeid;
		private int? _machineid;
		private string _axis_no;
		/// <summary>
		/// 
		/// </summary>
		public int CollectedDataParametersID
		{
			set{ _collecteddataparametersid=value;}
			get{return _collecteddataparametersid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CollectedValue
		{
			set{ _collectedvalue=value;}
			get{return _collectedvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CollectedTime
		{
			set{ _collectedtime=value;}
			get{return _collectedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterCodeID
		{
			set{ _parametercodeid=value;}
			get{return _parametercodeid;}
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
		public string Axis_No
		{
			set{ _axis_no=value;}
			get{return _axis_no;}
		}
		#endregion Model

	}
}

