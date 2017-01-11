using MesWeb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Spot {
    public class VM_Spot_Dist {
        private T_SpotDist _md_spot_dist;
        public T_SpotDist md_spot_dist {
            get {
                return _md_spot_dist;
            }
            set {
                _md_spot_dist = value;
            }
        }
        public VM_Spot_Dist() {

        }

        public VM_Spot_Dist(T_SpotDist sd) {
            md_spot_dist = sd;
        }
        public int Id { get { return md_spot_dist.Id; } }
        public string Pixel { get { return md_spot_dist.Pixel; } }
        private readonly List<VM_Spot_Info> spots = new List<VM_Spot_Info>();
        public List<VM_Spot_Info> Spots { get { return spots; } }
        public string Url { get { return md_spot_dist.Url; } }
        public string Remark { get { return md_spot_dist.Remark; } }
      
    }

    public class VM_Spot_Info {
        private T_SpotInfo _md_spot_info;
        public T_SpotInfo md_spot_info { get { return _md_spot_info; } set { _md_spot_info = value; } }
        public VM_Spot_Info() {

        }
        public VM_Spot_Info(T_SpotInfo si) {
            _md_spot_info = si;
        }
        public int Id { get { return _md_spot_info.Id; } }
        public int? X { get { return _md_spot_info.X; } }
        public int? Y { get { return _md_spot_info.Y; } }
        public string Title { get { return _md_spot_info.Title; } }
        public string Message { get { return _md_spot_info.Message; } }
        public int? ContainDistId { get { return _md_spot_info.ContainDistId; } }
        public string State { get { return _md_spot_info.State; } }
        public string Remark { get {return _md_spot_info.Remark; } }
        ////[JsonIgnore]
        //private readonly List<VM_Spot_Dist> dists = new List<VM_Spot_Dist>();
        //public List<VM_Spot_Dist> Dists { get { return dists; } }
    }
}
