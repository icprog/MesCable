
using System;
namespace MesWeb.Model
{
	/// <summary>
	/// T_LayoutPicture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_LayoutPicture
	{
		public T_LayoutPicture()
		{}
		#region Model
		private int _layoutpictureid;
		private string _picwidth;
		private string _picheight;
		private string _picurl;
		private int? _xpostion;
		private int? _ypostion;
		private string _title;
		private string _message;
		private int? _state;
		private int? _parentlayoutpictureid;
		private int? _layouttypeid;
		private int? _tablerowid;
		private bool _istop= false;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int LayoutPictureID
		{
			set{ _layoutpictureid=value;}
			get{return _layoutpictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicWidth
		{
			set{ _picwidth=value;}
			get{return _picwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicHeight
		{
			set{ _picheight=value;}
			get{return _picheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? XPostion
		{
			set{ _xpostion=value;}
			get{return _xpostion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? YPostion
		{
			set{ _ypostion=value;}
			get{return _ypostion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentLayoutPictureID
		{
			set{ _parentlayoutpictureid=value;}
			get{return _parentlayoutpictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LayoutTypeID
		{
			set{ _layouttypeid=value;}
			get{return _layouttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TableRowID
		{
			set{ _tablerowid=value;}
			get{return _tablerowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        #endregion Model
        #region method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            T_LayoutPicture target = obj as T_LayoutPicture;
            if(target == null)
                return false;

           if(target.LayoutPictureID == LayoutPictureID &&
                target.Title + "" == Title+"" &&
                target.Message + "" == Message+"" &&
                target.PicUrl + "" == PicUrl + "" &&
                target.PicWidth + "" == PicWidth +"" &&
                target.PicHeight + "" == PicHeight + "" &&
                target.State == State &&
                target.XPostion == XPostion &&
                target.YPostion == YPostion &&
                target.Remark + "" == Remark + "") {
                return true;
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();  
        }
        #endregion
    }
}

