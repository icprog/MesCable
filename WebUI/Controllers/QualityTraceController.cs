// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-03-2016
//
// Last Modified By : ychost
// Last Modified On : 09-03-2016
// ***********************************************************************
// <copyright file="QualityTraceController.cs" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using MES.DBUtility;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Utils;
using static WebUI.Controllers.LayoutBaseController;

namespace WebUI.Controllers {
    /// <summary>
    /// Class QualityTraceController.
    /// </summary>
    public class QualityTraceController:BaseController {

        /// *********************cniots*************************************  
        ///  Author           : ychost  
        ///  Created          : 2016-09-03 20:03:35  
        /// <summary>  
        /// response the main page of quality trace
        /// </summary>  
        /// <returns>ActionResult.</returns>  
        ///  Last Modified By : ychost  
        ///  Last Modified On : 2016-09-03 20:03:35  
        ///  *********************cniots*************************************
        public ActionResult Index() {
            return View();
        }



        public ActionResult TraceSearch() {
            //var axisNum = "CP0120160920010001";
            //var vmJSMind = new VM_JSMind();
            //var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            //var bllMachine = new MesWeb.BLL.T_Machine();
            //var bllMachineType = new MesWeb.BLL.T_MachineType();

            //var codeUsed = bllCodeUsed.GetModelList("Axis_No = '" + axisNum + "'").FirstOrDefault();
            //var machine = bllMachine.GetModel((int)codeUsed.MachineID);
            //var machineType = bllMachineType.GetModel((int)machine.MachineTypeID);
            //var time = codeUsed.GeneratorTime.Value;
            //string historyTabName = "HISMAIN" + time.Year + time.Month.ToString("00") + machineType.MachineTypeID.ToString("00").Trim();
            //try {
            //    var bllHistory = new MesWeb.BLL.T_HistoryData(historyTabName);

            //    var allHistoryData = bllHistory.GetAllModeList();

            //} catch(Exception e) {
            //    log.Error("查找历史数据库失败",e);
            //}

            return View();
        }

        public ActionResult MaterialSearch() {
            return View();
        }

        public static string SERACH_ASIX = "AXISNUM";

        [HttpPost]
        public JsonResult GetTraceDataAction(string axisNumStr) {
            var retData = new VM_Result_Data();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var vmJSMind = new VM_JSMind();
            var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllMachineType = new MesWeb.BLL.T_MachineType();
            VM_JSMind vmJsMind = new VM_JSMind();

            retData.Appendix = genMindStruct(axisNumStr.Trim(),"root",ref vmJsMind,isRoot: true);
            if(vmJsMind.data.Count > 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "查询成功";
            } else {
                retData.Content = "查询失败";
            }

            return Json(retData);
        }


        [HttpPost]
        public JsonResult GetTraceDataActionTest(string volNum) {
            var retData = new VM_Result_Data();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            retData.Content = "查询失败";

            if(volNum.ToUpper() == "A1501") {
                VM_JSMind vmJsMind = new VM_JSMind();
                VM_ProcDetail detail1 = new VM_ProcDetail() {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "904护套",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail2 = new VM_ProcDetail() {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "2#编织",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail3 = new VM_ProcDetail() {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "1#成缆",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail4 = new VM_ProcDetail() {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "604挤绝缘",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail5 = new VM_ProcDetail() {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "605挤护套",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司",
                   
                };

                vmJsMind.data = new List<JSMind_Data> {
                    new JSMind_Data("r1","","904护套",detail1,true),
                    new JSMind_Data("r2","r1","2#编织",detail2),
                    new JSMind_Data("r3","r2","1#成缆",detail3),
                    new JSMind_Data("r4","r3","604挤绝缘",detail4),
                    new JSMind_Data("r5","r3","605挤护套",detail5),
                };
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = vmJsMind;
            }
            return Json(retData);
        }

        [HttpPost]
        public JsonResult GetProcDetail(VM_ProcDetail procDetail) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var retData = new VM_Result_Data();
            procDetail.CertProduct = "<a href='javascript:void(0)' onclick='showCertProduct()'>成品证书</a> <a href='javascript:void(0)' onclick='showCertPlastic()'>塑料证书</a>";

            var procDetailList = new List<VM_ProcDetail>();
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllEmp = new MesWeb.BLL.T_Employee();
            var bllSpec = new MesWeb.BLL.T_Specification();
            var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            var bllAxis = new MesWeb.BLL.T_Axis();
            try {
                var specID = procDetail.SpecificationID;

                //TODO 模拟数据
                //specID = 1;
                //  var spec = bllSpec.GetModel((int)specID);
                //规格信息
                var spec = new MesWeb.Model.T_Specification { SpecificationName = "规格",SpecificationColor = "黑色" };

                procDetail.SpecName = spec.SpecificationName;
                procDetail.SpecColor = spec.SpecificationColor;
                //找到历史数据表
                HisData hisData = new HisData(procDetail.Axis_No);
                //查询OD的最值
                var hisDs = DbHelperSQL.Query("SELECT MAX(CollectedValue) AS Max,MIN(CollectedValue) AS Min" +
                            " FROM  " + hisData.TableName +
                            " WHERE(ParameterCodeID = " + (int)SPEC_PARAM_CODE.OUTTER_OD + ") AND(Axis_No = '" + procDetail.Axis_No + "')" +
                            " GROUP BY Axis_No");
                try {
                    var hisRow = hisDs.Tables[0].Rows[0];
                    var odMax = hisRow["max"].ToString();
                    var odMin = hisRow["min"].ToString();
                    procDetail.ODMax = odMax;
                    procDetail.ODMin = odMin;
                } catch {

                }
                procDetail.EmployeeName = procDetail.EmployeeID_Main;
                //获取回溯信息
                var axisInfo = bllAxis.GetModelList("Axis_No = '" + procDetail.Axis_No + "'").FirstOrDefault();
                if(axisInfo != null) {
                    procDetail.Comment = axisInfo.comment;
                }
                var codeUsed = bllCodeUsed.GetModelList("Axis_No = '" + procDetail.Axis_No + "'").FirstOrDefault();
                //时间
                if(codeUsed != null) {
                    procDetail.GeneratorTime = codeUsed.GeneratorTime.Value.ToShortDateString();
                }
                //机台
                var machine = bllMachine.GetModel((int)procDetail.MachineID);
                if(machine != null) {
                    procDetail.MachineName = "<a  href='javascript: void(0)' axisNum='" + procDetail.Axis_No + "'  onclick='viewHisMachine(this)' machineId='" + machine.MachineID + "'>" + machine.MachineName + "</a>";
                }
                retData.Code = RESULT_CODE.OK;
                TempData[SERACH_ASIX] = procDetail.Axis_No;

            } catch(Exception e) {
                log.Error("查询轴号信息失败",e);
                retData.Content = "查询失败，请联系管理员";
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = procDetail;
            }
            procDetailList.Add(procDetail);
            retData.Appendix = procDetailList;

            return Json(retData);
        }

        public VM_JSMind genMindStruct(string axisNumStr,string id,ref VM_JSMind mind,string parentId = "",bool isRoot = false) {
            if(string.IsNullOrEmpty(axisNumStr) || !HisMain.IsAxisNum(axisNumStr)) {
                return null;
            }
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllMachineType = new MesWeb.BLL.T_MachineType();


            var axisNum = new HisMain(axisNumStr);
            var hisTabName = "HISMAIN" + axisNum.Year + axisNum.Month + axisNum.MachineTypeID.Trim();
            var bllHisMain = new MesWeb.BLL.T_HisMain(hisTabName);
            var hisMain = bllHisMain.GetModelList("Axis_No = '" + axisNumStr + "'").FirstOrDefault();
            var machineType = bllMachineType.GetModel(int.Parse(axisNum.MachineTypeID));
            var machine = bllMachine.GetModel(int.Parse(axisNum.MachineID));
            var node = new JSMind_Data();


            node.topic = machineType.MachineType + machine.MachineName;
            node.id = id;
            node.parentid = parentId;
            node.isroot = isRoot;
            node.data = hisMain;
            mind.data.Add(node);
            if(hisMain != null) {
                var startAxisNums = ("" + hisMain.Start_Axis_No).Split(',');
                foreach(var stNum in startAxisNums) {
                    genMindStruct(stNum,stNum,ref mind,id);
                }
            }

            return mind;

        }



        [HttpPost]
        public JsonResult GetAllReportAction() {
            var retData = new VM_Result_Data();
            var cerFolder = ConfigurationManager.AppSettings["CertificateFolder"];
            var filePath = Path.Combine(Server.MapPath("~" + cerFolder));
            retData.Appendix = FindFile(filePath);
            retData.Code = RESULT_CODE.OK;
            return Json(retData);
        }

        public List<string> FindFile(string sSourcePath) {
            //在指定目录及子目录下查找文件,在list中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(sSourcePath);
            DirectoryInfo[] DirSub = Dir.GetDirectories();
            List<String> list = new List<string>();

            if(DirSub.Length <= 0) {
                foreach(FileInfo f in Dir.GetFiles("*.*",SearchOption.TopDirectoryOnly)) //查找文件
                {
                    list.Add(@"\" + f.ToString());
                }
            }
            int t = 1;
            foreach(DirectoryInfo d in DirSub)//查找子目录 
            {
                FindFile(Dir + @"\" + d.ToString());
                list.Add(Dir + @"\" + d.ToString());
                if(t == 1) {
                    foreach(FileInfo f in Dir.GetFiles("*.*",SearchOption.TopDirectoryOnly)) //查找文件
                    {
                        list.Add(@"\" + f.ToString());
                    }
                    t = t + 1;
                }
            }
            return list;
        }
    }



    /// <summary>
    /// Class Axis.
    /// </summary>
    public class HisMain {
        public string MachineTypeID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string MachineID { get; set; }
        public string AxisNumStr { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        /// <value>The LSH.</value>
        public string LSH { get; set; }

        public HisMain() {

        }

        public HisMain(string year,string month,string machineId) {
            this.Year = year;
            this.Month = month;
            this.MachineID = machineId;
        }

        public HisMain(string axisNumStr) {
            this.AxisNumStr = axisNumStr;
            init(AxisNumStr);
        }



        public static HisMain Parse(string axisNumStr) {
            return new HisMain(axisNumStr);
        }

        private void init(string axisNumStr) {
            axisNumStr = axisNumStr.Trim();
            if(!axisNumStr.StartsWith("CP") || axisNumStr.Length != 18) {
                return;
            }
            try {
                MachineTypeID = axisNumStr.Substring(2,2);
                Year = axisNumStr.Substring(4,4);
                Month = axisNumStr.Substring(8,2);
                Day = axisNumStr.Substring(10,2);
                if(MachineTypeID.StartsWith("0")) {
                    MachineTypeID = MachineTypeID.Substring(1);
                }

                MachineID = axisNumStr.Substring(12,2);
                LSH = axisNumStr.Substring(14,4);
            } catch(Exception e) {
                throw e;
            }
        }

        public static bool IsAxisNum(string axisNumStr) {
            if(!axisNumStr.StartsWith("CP") || axisNumStr.Length != 18) {
                return false;
            }
            return true;
        }

        public string GetHisDataTableName() {
            if(IsAxisNum(this.AxisNumStr)) {
                return GetHisMainTableName(this.AxisNumStr);
            } else {
                return null;
            }
        }

        public static string GetHisMainTableName(string axisNumStr) {
            var axisNum = new HisMain(axisNumStr);
            return "HISMAIN" + axisNum.Year + axisNum.Month + axisNum.MachineTypeID.Trim();
        }

        public static string GetHisMainTableName(DateTime dateTime,int machineTypeId) {
            return "HISMAIN" + dateTime.Year.ToString("0000") + dateTime.Month.ToString("00") + machineTypeId.ToString();
        }

    }


}