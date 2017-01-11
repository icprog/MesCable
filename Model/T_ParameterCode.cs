/**  版本信息模板在安装目录下，可自行修改。
* T_ParameterCode.cs
*
* 功 能： N/A
* 类 名： T_ParameterCode
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/24 11:15:23   N/A    初版
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
	/// T_ParameterCode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ParameterCode
	{
		public T_ParameterCode()
		{}
		#region Model
		private int _parametercodeid;
		private int? _parametercode;
		private int? _parametertype;
		private string _parametername;
		private int? _parameterunitid;
		private int? _parameterbit;
		private int? _type;
		/// <summary>
		/// 
		/// </summary>
		public int ParameterCodeID
		{
			set{ _parametercodeid=value;}
			get{return _parametercodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterCode
		{
			set{ _parametercode=value;}
			get{return _parametercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterType
		{
			set{ _parametertype=value;}
			get{return _parametertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParameterName
		{
			set{ _parametername=value;}
			get{return _parametername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterUnitID
		{
			set{ _parameterunitid=value;}
			get{return _parameterunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParameterBit
		{
			set{ _parameterbit=value;}
			get{return _parameterbit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

