// ***********************************************************************
// Assembly         : MesWeb.ViewModel
// Author           : ychost
// Created          : 09-13-2016
//
// Last Modified By : ychost
// Last Modified On : 09-13-2016
// ***********************************************************************
// <copyright file="VM_Upload_Image.cs" company="cniots">
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
    /// Class VM_Upload_Image.
    /// </summary>
    public interface VM_IUploadFile {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
         string Title { get; set; }
        /// <summary>
        /// Gets or sets the name of the success action.
        /// </summary>
        /// <value>The name of the success action.</value>
         string SuccessActionName { get; set; }
        /// <summary>
        /// Gets or sets the success action URL.
        /// </summary>
        /// <value>The success action URL.</value>
         string SuccessActionUrl { get; set; }
        /// <summary>
        /// Gets or sets the name of the error action.
        /// </summary>
        /// <value>The name of the error action.</value>
         string ErrorActionName { get; set; }
        /// <summary>
        /// Gets or sets the error action URL.
        /// </summary>
        /// <value>The error action URL.</value>
         string ErrorActionUrl { get; set; }

        /// <summary>
        /// Gets or sets the send file URL.
        /// </summary>
        /// <value>The send file URL.</value>
        string SendFileUrl { get; set; }
    }

    /// <summary>
    /// Class VM_UploadImage.
    /// </summary>
    /// <seealso cref="MesWeb.ViewModel.Mes.VM_IUploadFile" />
    public class VM_UploadImage:VM_IUploadFile {
        public string ErrorActionName {
            get;set;
        }

        public string ErrorActionUrl {
            get; set;
        }

        public string SendFileUrl {
            get;set;
        }

        public string SuccessActionName {
            get; set;
        }

        public string SuccessActionUrl {
            get; set;
        }

        public string Title {
            get; set;
        }
    }
}
