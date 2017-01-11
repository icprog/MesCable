// ***********************************************************************
// Assembly         : MesWeb.ViewModel
// Author           : ychost
// Created          : 09-15-2016
//
// Last Modified By : ychost
// Last Modified On : 09-15-2016
// ***********************************************************************
// <copyright file="VM_AddSensorLayout.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {
    /// <summary>
    /// Class VM_AddSensorLayout.
    /// </summary>
    public class VM_AddSensorAdmin:MesWeb.Model.T_LayoutPicture {

        public List<String> ParameterCodeIDs { get; set; }
        public string SerialNum { get; set; }

        public DateTime? installTime { get; set; }
        public int MachineID { get; set; }

        public MesWeb.Model.T_SensorModule SensorModule {
            get {
                return new Model.T_SensorModule {
                    SerialNum = SerialNum,
                    InstallTime = DateTime.Now,
                      
                    //  CollectedParameterID = CollectedParameterID,
                    MachineID = MachineID,
            

                };
            }
        }

        public MesWeb.Model.T_LayoutPicture SensorLayout {
            get {
                return this;
            }
        }
    }
}
