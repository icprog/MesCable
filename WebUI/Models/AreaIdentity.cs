// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-15-2016
//
// Last Modified By : ychost
// Last Modified On : 09-15-2016
// ***********************************************************************
// <copyright file="AreaIdentity.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    /// <summary>
    /// Class AreaIdentity.
    /// </summary>
    public static class AreaIdentity {
        public static string WorkArea {
            get { return "WorkArea"; }
        }
        public static string StoreArea {
            get { return "StoreArea"; }
        }

        public static string Area {
            get { return "Area"; }
        }

        public static string ExtraSensor {
            get { return "ExtraSensor"; }
        }

    }
}