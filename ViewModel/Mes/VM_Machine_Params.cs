using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    /// <summary>
    /// one machine with parameters
    /// </summary>
    public class VM_Machine_Params {
        public VM_Machine_Params() {

        }

        /// <summary>
        /// the name of machine
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// the parameter's collection 
        /// </summary>
        public List<VM_Param> Params { get; set; }
    }

    /// <summary>
    /// one kind of parameters
    /// </summary>
    public class VM_Param {
        public VM_Param() {

        }

        /// <summary>
        /// the name of parameter 
        /// </summary>
        public string ParamName { get; set; }


        /// <summary>
        /// the value's collection of parameters
        /// </summary>
        public List<VM_Param_Value> ParamValues { get; set; }


        /// <summary>
        /// the parameter's unit name
        /// </summary>
        public string ParamUnitName { get; set; }


        /// <summary>
        /// the parameter's unit symbol
        /// </summary>
        public string ParamUnitSymbol { get; set; }
    }

    /// <summary>
    /// the value's collection of one parameter
    /// </summary>
    public class VM_Param_Value {
        public VM_Param_Value() {

        }

        /// <summary>
        /// the worker setting value
        /// </summary>
        public string SettingValue { get; set; }

        ///// <summary>
        ///// the max value
        ///// </summary>
        //public string MaxValue { get; set; }


        ///// <summary>
        ///// the min value
        ///// </summary>
        //public string MinValue { get; set; }


        /// <summary>
        /// the create time of value
        /// </summary>
        public DateTime? CollectedTime { get; set; }

        /// <summary>
        /// the sensor collected value
        /// </summary>
        public string CollectedValue { get; set; }
    }

}
