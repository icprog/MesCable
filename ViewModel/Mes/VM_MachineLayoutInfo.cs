using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {


    public class VM_MachineProperty {
        /// <summary>
        /// 机台名称
        /// </summary>
        /// <value>The name of the machine.</value>
        public string MachineName { get; set; }

        /// <summary>
        ///  当前米数
        /// </summary>
        /// <value>The current meters.</value>
        public string CurrentMeters { get; set; }


        /// <summary>
        /// 工单号
        /// </summary>
        /// <value>The job number.</value>
        public string JobNum { get; set; }

        /// <summary>
        /// 工序号
        /// </summary>
        /// <value>The spec number.</value>
        public string SpecNum { get; set; }


        /// <summary>
        /// 达成数
        /// </summary>
        /// <value>The reached number.</value>
        public string ReachedNum { get; set; }


        /// <summary>
        /// 任务数
        /// </summary>
        /// <value>The task number.</value>
        public string TaskNum { get; set; }


        /// <summary>
        /// 批次号
        /// </summary>
        /// <value>The batch number.</value>
        public string BatchNum { get; set; }

        /// <summary>
        /// 轴号
        /// </summary>
        /// <value>The axle number.</value>
        public string AxisNum { get; set; }


        /// <summary>
        /// 操作人员
        /// </summary>
        /// <value>The manu man.</value>
        public string ManuMan { get; set; }

        /// <summary>
        ///物料RFID
        /// </summary>
        /// <value>The material rfid.</value>
        public string MaterialRFID { get; set; }


        /// <summary>
        /// 单位能耗
        /// </summary>
        /// <value>The cont unit.</value>
        public string ContUnit { get; set; }


        /// <summary>
        /// 预计完成时间
        /// </summary>
        /// <value>The est time.</value>
        public string EstTime { get; set; }


        /// <summary>
        /// 单位米数价格
        /// </summary>
        /// <value>The unit price.</value>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 最大线径
        /// </summary>
        /// <value>The od maximum.</value>
        public decimal? ODMax { get; set; }

        /// <summary>
        /// 最小线径
        /// </summary>
        /// <value>The od minimum.</value>
        public decimal? ODMin { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        /// <value>The color of the spec.</value>
        public string SpecColor { get; set; }

    }
}
