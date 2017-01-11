using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    public class VM_LayoutPicture {
        private T_LayoutPicture layoutPicture;


        public int LayoutPictureID { get { return layoutPicture.LayoutPictureID; } }
        public string PicWidth { get { return layoutPicture.PicWidth; } }
        public string PicHeight { get { return layoutPicture.PicHeight; } }
        public string PicUrl { get { return layoutPicture.PicUrl; } }
        public int? X { get { return layoutPicture.XPostion; } }
        public int? Y { get { return layoutPicture.YPostion; } }
        public string Title { get { return layoutPicture.Title; } }
        public string Message { get { return layoutPicture.Message; } }
        public int? State { get { return layoutPicture.State; } }
        public string Remark { get { return layoutPicture.Remark; } }
        public int? LayoutTypeID { get { return layoutPicture.LayoutTypeID; } }
        public int? TableRowID { get { return layoutPicture.TableRowID; } }
        public VM_LayoutPicture(T_LayoutPicture layoutPicture) {
            this.layoutPicture = layoutPicture;
        }
        private List<VM_LayoutPicture> subSpotItems = new List<VM_LayoutPicture>();
        public List<VM_LayoutPicture> SubSpotItems { get { return subSpotItems; } }
    }
}
