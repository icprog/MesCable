// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-13-2016
//
// Last Modified By : ychost
// Last Modified On : 09-13-2016
// ***********************************************************************
// <copyright file="BaseController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary>  </summary>
// ***********************************************************************
using log4net;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WebUI.Controllers {
    /// <summary>
    /// this is the base controller that all controller should implement it
    /// </summary>
    public class BaseController:Controller {
        /// <summary>
        /// The the logger object 
        /// </summary>
        protected LogHelper log;
        protected static string spliter = ",_,";

        /// <summary>         、
        /// DataSet装换为泛型集合         
        /// </summary>         
        /// <typeparam name="T"></typeparam>         
        /// <param name="ds">DataSet</param>         
        /// <param name="tableIndex">待转换数据表索引</param>         
        /// <returns></returns>         
        
            
        public static IList<T> DataSetToIList<T>(DataSet ds,int tableIndex) {
            if(ds == null || ds.Tables.Count < 0)
                return null;
            if(tableIndex > ds.Tables.Count - 1)
                return null;
            if(tableIndex < 0)
                tableIndex = 0;
            DataTable dt = ds.Tables[tableIndex];

            IList<T> result = new List<T>();
            for(int j = 0;j < dt.Rows.Count;j++) {
                T _t = (T)Activator.CreateInstance(typeof(T));
                    
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach(PropertyInfo pi in propertys) {
                    for(int i = 0;i < dt.Columns.Count;i++) {
                        if(pi.Name.Equals(dt.Columns[i].ColumnName)) {
                            if(dt.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t,dt.Rows[j][i],null);
                            else
                                pi.SetValue(_t,null,null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }
        /// <summary>         
        /// DataSet装换为泛型集合        
        ///  </summary>     
        /// <typeparam name="T"></typeparam>   
        ///<param name="ds">DataSet</param>      
        /// <param name="tableName">待转换数据表名称</param>         
        /// <returns></returns>         
        /// 2008-08-01 22:47 HPDV2806         
        public static IList<T> DataSetToIList<T>(DataSet ds,string tableName) {
            int _TableIndex = 0;
            if(ds == null || ds.Tables.Count < 0)
                return null;
            if(string.IsNullOrEmpty(tableName))
                return null;
            for(int i = 0;i < ds.Tables.Count;i++) {
                if(ds.Tables[i].TableName.Equals(tableName)) {
                    _TableIndex = i;
                    break;
                }
            }
            return DataSetToIList<T>(ds,_TableIndex);
        }

    }

}