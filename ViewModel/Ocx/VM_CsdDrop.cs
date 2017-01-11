// ***********************************************************************
// Assembly         : MesWeb.ViewModel
// Author           : ychost
// Created          : 09-11-2016
//
// Last Modified By : ychost
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="CsdDropdown.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Ocx {
    /// <summary>
    /// the Dynamic-jQuery-Cascading-Dropdown-Lists-Plugin viewmodel
    /// </summary>
    public class VM_CscDrop {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VM_CscDrop"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool selected { get; set; }
    }
}
