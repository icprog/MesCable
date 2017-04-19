/**  版本信息模板在安装目录下，可自行修改。
* T_MaterialOutput.cs
*
* 功 能： N/A
* 类 名： T_MaterialOutput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/4/18 17:36:51   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_MaterialOutput:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_MaterialOutput
	{
		public T_MaterialOutput()
		{}
		#region Model
		private int _materialoutputid;
		private string _materialrfid;
		private string _materialtype;
		private DateTime? _gneratetime;
		private string _materialname;
		private string _weight;
		private string _color;
		private string _certificate;
		private string _contractno;
		private string _batchno;
		private string _supplycompany;
		private string _workshift;
		/// <summary>
		/// 
		/// </summary>
		public int MaterialOutputID
		{
			set{ _materialoutputid=value;}
			get{return _materialoutputid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialRFID
		{
			set{ _materialrfid=value;}
			get{return _materialrfid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialType
		{
			set{ _materialtype=value;}
			get{return _materialtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GnerateTime
		{
			set{ _gneratetime=value;}
			get{return _gneratetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialName
		{
			set{ _materialname=value;}
			get{return _materialname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Certificate
		{
			set{ _certificate=value;}
			get{return _certificate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractNo
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchNo
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplyCompany
		{
			set{ _supplycompany=value;}
			get{return _supplycompany;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string workshift
		{
			set{ _workshift=value;}
			get{return _workshift;}
		}
		#endregion Model

	}
}

