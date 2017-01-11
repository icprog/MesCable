// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-12-2016
//
// Last Modified By : ychost
// Last Modified On : 09-12-2016
// ***********************************************************************
// <copyright file="LogHelper.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utils {
    /// <summary>
    /// this class is auto generate server log
    /// </summary>
    public class LogHelper {
        private ILog logger;

        public LogHelper(ILog log) {
            this.logger = log;
        }

        public void Info(object message) {
            this.logger.Info(message);
        }

        public void Info(object message,Exception e) {
            this.logger.Info(message,e);
        }

        public void Debug(object message) {
            this.logger.Debug(message);
        }

        public void Debug(object message,Exception e) {
            this.logger.Debug(message,e);
        }

        public void Warning(object message) {
            this.logger.Warn(message);
        }

        public void Warning(object message,Exception e) {
            this.logger.Warn(message,e);
        }

        public void Error(object message) {
            this.logger.Error(message);
        }

        public void Error(object message,Exception e) {
            this.logger.Error(message,e);
        }

        public void Fatal(object message) {
            this.logger.Fatal(message);
        }

        public void Fatal(object message,Exception e) {
            this.logger.Fatal(message,e);
        }
    }

    /// <summary>
    /// Class LogFactory.
    /// </summary>
    public class LogFactory {
        static LogFactory() {
        }

        public static LogHelper GetLogger(Type type) {
            return new LogHelper(LogManager.GetLogger(type));
        }

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-12 21:11:10  
        /// <summary>  
        /// Gets the logger.
        /// </summary>  
        /// <param name="str">The logger string</param>  
        /// <example>
        /// var log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
        /// log.Info("test");
        /// </example>
        /// <returns>LogHelper.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-13 00:44:03  
        ///  *********************cniots*************************************
        public static LogHelper GetLogger(string str) {
            return new LogHelper(LogManager.GetLogger(str));
        }
    }


}