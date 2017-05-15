/**  版本信息模板在安装目录下，可自行修改。
* Specification.cs
*
* 功 能： N/A
* 类 名： Specification
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/5/15 19:43:35   N/A    初版
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
	/// Specification:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Specification
	{
		public Specification()
		{}
		#region Model
		private int _id;
		private int _productid;
		private int _procedureid;
		private int _paramtypeid;
		private decimal? _upper;
		private decimal? _lower;
		private string _suffix;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int procedureId
		{
			set{ _procedureid=value;}
			get{return _procedureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int paramTypeId
		{
			set{ _paramtypeid=value;}
			get{return _paramtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? upper
		{
			set{ _upper=value;}
			get{return _upper;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? lower
		{
			set{ _lower=value;}
			get{return _lower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string suffix
		{
			set{ _suffix=value;}
			get{return _suffix;}
		}
		#endregion Model

	}
}

