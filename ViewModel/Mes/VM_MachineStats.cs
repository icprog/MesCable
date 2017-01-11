using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
   public class VM_MachineStats {

        /// <summary>
        /// 开机数
        /// </summary>
        public int BootStats { get; set; }

        /// <summary>
        /// 故障
        /// </summary>
        public int HaltStats { get; set; }
        

        /// <summary>
        /// 关机数
        /// </summary>
        public int CloseStats { get; set; }

        /// <summary>
        /// 总机台数
        /// </summary>
        public int AmountStats { get; set; }

        /// <summary>
        /// 故障数
        /// </summary>
        //public int FaultStats { get; set; }
    }
}
