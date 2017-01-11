// ***********************************************************************
// Assembly         : MesWeb.ViewModel
// Author           : ychost
// Created          : 09-15-2016
//
// Last Modified By : ychost
// Last Modified On : 09-15-2016
// ***********************************************************************
// <copyright file="VM_AddMachineLayout.cs" company="cniots">
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
    /// Class VM_AddMachineLayout.
    /// </summary>
    public class VM_AddMachineAdmin:MesWeb.Model.T_LayoutPicture {
        public string MachineName { get; set; }
        public string ManufactureName { get; set; }
        public int MachinePower { get; set; }
        public string AddressNumber { get; set; }
        public DateTime ProductDate { get; set; }
        public int MachineEfficiency { get; set; }
        public int MachineTypeID { get; set; }
        public MesWeb.Model.T_Machine Machine {
            get {
                return new Model.T_Machine {
                    MachinePositionX = XPostion,
                    MachinePositionY = YPostion,
                    MachineName = MachineName,
                    MachinePower = MachinePower,
                    AddressNumber = AddressNumber,
                    ManufactureName = ManufactureName,
                    ProductDate = ProductDate,
                    MachineZoneID = ParentLayoutPictureID,
                    MachineEfficiency = MachineEfficiency,
                    MachineTypeID = MachineTypeID
                    
                };
            }
        }

        public MesWeb.Model.T_LayoutPicture MachineLayout {
            get {
                this.Title = MachineName;
                return this;
            }
        }
    }
}
