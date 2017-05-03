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
using System.Data;

namespace WebUI.Controllers
{
    /// <summary>
    /// Class QualityTraceController.
    /// </summary>
    public class QualityTraceController : BaseController
    {

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
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TraceSearch()
        {
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

        public ActionResult MaterialSearch()
        {
            return View();
        }

        public ActionResult TraceDetail(string Id)
        {
            var axisNumStr = Id;
            VM_JSMind vmJsMind = new VM_JSMind();
            try
            {
                genMindStruct(axisNumStr.Trim(), "root", ref vmJsMind, isRoot: true);
            }
            catch (Exception e)
            {
            }

            return View(vmJsMind);
        }
        

        public ActionResult MachineHistory(string id)
        {
            var data = id.Split(new string[] { spliter }, StringSplitOptions.None).ToList();

            return View(data);
        }

        [HttpPost]
        public JsonResult GetMahineHistoryDataAction(MesWeb.ViewModel.Mes.MahineHistoryQueryCond cond)
        {
            var retData = new MesWeb.ViewModel.Promise.VM_Result_Data();
            retData.Content = "获取机台历史数据失败，请联系管理员";

            try
            {
                var hisData = new HisData(cond.axisNum);
                var bllHisData = new MesWeb.BLL.T_HisData(hisData.TableName);
                //string querySql = "select * From  "+hisData.TableName + " where Axis_No = '" + cond.axisNum + " order by 'CollectedTime'";
                var allData = bllHisData.GetModelList("Axis_No  LIKE '%" + cond.axisNum + "%' ORDER BY  'CollectedTime'");
                if (allData.Count > 0 && allData[0].MachineID.HasValue)
                {
                    var bllMachine = new MesWeb.BLL.T_Machine();
                    var machine = bllMachine.GetModel(allData[0].MachineID.Value);

                }
                retData.Appendix = allData;
                retData.Content = "加载成功";
                retData.Code = RESULT_CODE.OK;


            }
            catch (Exception e)
            {
                retData.Content = e;
            }

            return new ConfigurableJsonResult { Data = retData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public class HistoryInfo
        {
            public string MachineName { get; set; }
            public string AxisNum { get; set; }
            public string AxisCOlor { get; set; }
            public string printCode { get; set; }
        }

        public static string SERACH_ASIX = "AXISNUM";



        [HttpPost]
        public JsonResult GetTraceDataAction(string axisNumStr)
        {
            var retData = new VM_Result_Data();
            var vmJSMind = new VM_JSMind();
            var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllMachineType = new MesWeb.BLL.T_MachineType();
            VM_JSMind vmJsMind = new VM_JSMind();

            retData.Appendix = genMindStruct(axisNumStr.Trim(), "root", ref vmJsMind, isRoot: true);
            if (vmJsMind.data.Count > 0)
            {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "查询成功";
            }
            else
            {
                retData.Content = "查询失败";
            }

            return Json(retData);
        }


        public ActionResult HalfProduct()
        {
            return View();
        }

        //获取同一年的轴号数据集合
        private List<List<MesWeb.Model.T_HisMain>> getSameYearData(DateTime? startTime, DateTime? endTime, string machineType = "5")
        {
            var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            var usedCodeList = new List<MesWeb.Model.T_CodeUsed>();
            var bllSpec = new MesWeb.BLL.T_Specification();
            List<MesWeb.Model.T_HisMain> hisMainList = new List<MesWeb.Model.T_HisMain>();
            var startMonth = startTime.Value.Month;
            var endMonth = endTime.Value.Month;
            List<List<MesWeb.Model.T_HisMain>> hisMainListArray = new List<List<MesWeb.Model.T_HisMain>>();
            string cp = "CP0" + machineType;
            List<MesWeb.Model.T_HisMain> hisMainTmps;
            for (var i = startMonth; i <= endMonth; ++i)
            {
                var tableName = "HISMAIN" + startTime.Value.Year + i.ToString("00") + machineType;
                var bllHisMain = new MesWeb.BLL.T_HisMain(tableName);
                //同一月
                if (startMonth == endMonth)
                {
                    for (var j = startTime.Value.Day; j <= endTime.Value.Day; ++j)
                    {
                        hisMainTmps = bllHisMain.GetModelList("Axis_No like '" + cp + "" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                        if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                        hisMainTmps = bllHisMain.GetModelList("Axis_No like 'ZD" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                        if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                    }
                    //不是同一月
                }
                else
                {
                    //起始月
                    if (i == startMonth)
                    {

                        //遍历起始月
                        for (var j = startTime.Value.Day; j <= 31; ++j)
                        {
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like '" + cp + "" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like 'ZD" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                        }
                        //遍历终止月
                    }
                    else if (i == endMonth)
                    {
                        for (var j = 1; j <= endTime.Value.Day; ++j)
                        {
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like '" + cp + "" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like 'ZD" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                        }
                        //遍历其它月
                    }
                    else
                    {
                        for (var j = 1; j <= 31; ++j)
                        {
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like '" + cp + "" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                            hisMainTmps = bllHisMain.GetModelList("Axis_No like 'ZD" + startTime.Value.Year + i.ToString("00") + j.ToString("00") + "%" + "'");
                            if (hisMainTmps.Count > 0) hisMainList.AddRange(hisMainTmps);
                        }
                    }
                }
                try
                {
                    hisMainListArray.Add(hisMainList);
                }
                catch
                {
                    return hisMainListArray;
                }
            }
            return hisMainListArray;
        }

        public ActionResult HalfSearch()
        {
            return View();
        }



        [HttpPost]
        public JsonResult SearchTraceBrefAction(VM_Trace_Search_Cond cond)
        {
            var retData = new VM_Result_Data();
            retData.Content = "查询失败";
            if (string.IsNullOrEmpty(cond.MachineType))
            {
                cond.MachineType = "5";
            }
            var brefList = new List<VM_Trace_Bref>();
            try
            {

                List<List<MesWeb.Model.T_HisMain>> hisMainListArray = new List<List<MesWeb.Model.T_HisMain>>();
                var bllSpec = new MesWeb.BLL.T_Specification();
                if (!string.IsNullOrEmpty(cond.AxisNum))
                {
                    var axisNum = new HisMain(cond.AxisNum);
                    var hisTabName = "HISMAIN" + axisNum.Year + axisNum.Month + axisNum.MachineTypeID.Trim();
                    var bllHisMain = new MesWeb.BLL.T_HisMain(hisTabName);
                    var hisMainList = bllHisMain.GetModelList("Axis_No like '%" + cond.AxisNum + "%'");
                    hisMainListArray.Add(hisMainList);
                }
                else if (cond.StartTime.HasValue && cond.EndTime.HasValue && cond.StartTime < cond.EndTime)
                {
                    //同一年
                    if (cond.StartTime.Value.Year == cond.EndTime.Value.Year)
                    {
                        var listArray = getSameYearData(cond.StartTime, cond.EndTime, cond.MachineType);
                        hisMainListArray.AddRange(listArray);
                        //不是同一年
                    }
                    else
                    {
                        for (var y = cond.StartTime.Value.Year; y <= cond.EndTime.Value.Year; ++y)
                        {
                            List<List<MesWeb.Model.T_HisMain>> listArray = null;
                            if (y == cond.StartTime.Value.Year)
                            {
                                listArray = getSameYearData(cond.StartTime, new DateTime(y, 12, 31), cond.MachineType);
                            }
                            else if (y == cond.EndTime.Value.Year)
                            {
                                listArray = getSameYearData(new DateTime(y, 1, 1), cond.EndTime, cond.MachineType);
                            }
                            else
                            {
                                listArray = getSameYearData(new DateTime(y, 1, 1), new DateTime(y, 12, 31), cond.MachineType);
                            }

                            hisMainListArray.AddRange(listArray);
                        }
                    }
                }


                hisMainListArray.ForEach(hlist =>
                {
                    //生成结果
                    hlist.ForEach(h =>
                    {
                        try
                        {
                            var bref = new VM_Trace_Bref();
                            bref.SpecNum = "未录入";
                            if (h.SpecificationID.HasValue)
                            {
                                var spec = bllSpec.GetModel(h.SpecificationID.Value);
                                if (spec != null)
                                {
                                    bref.SpecNum = spec.SpecificationName;
                                }
                            }
                            bref.Axis_No = h.Axis_No.Replace(",", "");
                            var axisNum = new HisMain(h.Axis_No);
                            bref.Date = axisNum.Year + "-" + axisNum.Month + "-" + axisNum.Day;

                            bref.PrintCode = string.IsNullOrEmpty(h.Printcode) ? "未录入" : h.Printcode;
                            bref.Detail = "<a  tabId=" + h.CurrentDataID + "  tabName = '" + axisNum.GetHisDataTableName() + "' axisNum='" + axisNum.AxisNumStr + "' onclick='showTraceDetail(this)'>详情</a>";
                            brefList.Add(bref);
                        }
                        catch(Exception e)
                        {
                        
                        }
                    });
                });



                if (brefList.Count > 0)
                {
                    retData.Code = RESULT_CODE.OK;
                    retData.Appendix = brefList;
                    retData.Content = "查询成功";
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Json(retData);
        }


        static class PrintCode
        {
            public static string ParseToDate(string printCode)
            {

                if (!printCode.ToUpper().StartsWith("ZD"))
                {
                    return null;
                }
                return "20" + printCode.Substring(2, 4);
            }
        }

        [HttpPost]
        public JsonResult GetTraceDataActionTest(string volNum)
        {
            var retData = new VM_Result_Data();
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            retData.Content = "查询失败";

            if (volNum.ToUpper() == "A1501")
            {
                VM_JSMind vmJsMind = new VM_JSMind();
                VM_ProcDetail detail1 = new VM_ProcDetail()
                {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "904护套",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail2 = new VM_ProcDetail()
                {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "2#编织",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail3 = new VM_ProcDetail()
                {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "1#成缆",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail4 = new VM_ProcDetail()
                {
                    Axis_No = "CP0420161106040001",
                    SpecColor = "黑色",
                    ODMax = "3.1",
                    ODMin = "1.7",
                    MachineName = "604挤绝缘",
                    EmployeeName = "李云",
                    GeneratorTime = "2016-11-06",
                    Supplier = "中德电缆公司"
                };
                VM_ProcDetail detail5 = new VM_ProcDetail()
                {
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
        public JsonResult GetProcDetail(VM_ProcDetail procDetail)
        {
            var retData = new VM_Result_Data();
            if (procDetail == null)
            {
                procDetail = new VM_ProcDetail();
            }
            //procDetail.CertProduct = "<a href='javascript:void(0)' onclick='showCertProduct()'>成品证书</a> <a href='javascript:void(0)' onclick='showCertPlastic()'>塑料证书</a>";

            var procDetailList = new List<VM_ProcDetail>();
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllEmp = new MesWeb.BLL.T_Employee();
            var bllSpec = new MesWeb.BLL.T_Specification();
            var bllCodeUsed = new MesWeb.BLL.T_CodeUsed();
            var bllAxis = new MesWeb.BLL.T_Axis();
            try
            {
                if (!string.IsNullOrEmpty(procDetail.Printcode))
                {
                    //var bllPd = new MesWeb.BLL.T_Report_Product();
                    //var pd = bllPd.GetModelList("VolNum = '" + procDetail.Printcode + "'").FirstOrDefault();
                    //if(pd != null) {
                    //    procDetail.CertProduct += "<a id=" + pd.Id + " onclick='showRportProduct(this)'>成品表 , </a>";
                    //} else {
                    //    procDetail.CertProduct += "<a style='text-decoration:line-through'>未录入 , </a>";

                    //}
                    var bllAllReport = new MesWeb.BLL.T_AllReport();
                    var productRp = bllAllReport.GetModelList("IndexValue like '" + procDetail.Printcode + "%'").FirstOrDefault();
                    if (productRp != null)
                    {
                        procDetail.CertProduct += "<a id=" + productRp.Id + " onclick='showRportProduct(this)'>成品表 , </a>";
                    }

                }


                try
                {
                    //找到历史数据表
                    HisData hisData = new HisData(procDetail.Axis_No);
                    //查询OD的最值
                    var hisDs = DbHelperSQL.Query("SELECT MAX(CollectedValue) AS Max,MIN(CollectedValue) AS Min" +
                                " FROM  " + hisData.TableName +
                                " WHERE(ParameterCodeID = " + (int)SPEC_PARAM_CODE.OUTTER_OD + ") AND(Axis_No = '" + procDetail.Axis_No + "')" +
                                " GROUP BY Axis_No");

                    var hisRow = hisDs.Tables[0].Rows[0];
                    var odMax = hisRow["max"].ToString();
                    var odMin = hisRow["min"].ToString();
                    procDetail.ODMax = odMax;
                    procDetail.ODMin = odMin;
                }
                catch
                {

                }

                //获取回溯信息
                var axisInfo = bllAxis.GetModelList("Axis_No = '" + procDetail.Axis_No + "'").FirstOrDefault();
                if (axisInfo != null)
                {
                    procDetail.Comment = axisInfo.comment;
                }
                var codeUsed = bllCodeUsed.GetModelList("Axis_No = '" + procDetail.Axis_No + "'").FirstOrDefault();
                //时间
                if (codeUsed != null)
                {
                    procDetail.GeneratorTime = codeUsed.GeneratorTime.Value.ToShortDateString();
                }
                //机台
                var machine = bllMachine.GetModel((int)procDetail.MachineID);
                //规格
                var specID = procDetail.SpecificationID;
                if (specID.HasValue)
                {
                    var certPls = "<a style='text-decoration:line-through'> 未录入</a>";
                    procDetail.CertProduct += certPls;
                    var spec = bllSpec.GetModel((int)specID);
                    if (spec != null)
                    {
                        procDetail.SpecName = spec.SpecificationName;
                        procDetail.SpecColor = spec.SpecificationColor;
                    }
                }

                if (machine != null)
                {
                    //只有挤绝缘和挤护套有数据
                    if (machine.MachineTypeID == 2 || machine.MachineTypeID == 5)
                    {
                        var machineName = machine.MachineName ?? "";
                        var axisColor = procDetail.SpecColor ?? "";
                        var printCode = procDetail.Printcode ?? "";
                        procDetail.MachineName = "<a  href='javascript: void(0)' printCode='" + printCode + "' axisColor='" + axisColor + "'  machineName='" + machineName + "'   axisNum='" + procDetail.Axis_No + "'  onclick='viewHisMachine(this)' machineId='" + machine.MachineID + "'>" + machine.MachineName + "</a>";
                    }
                    else
                    {
                        procDetail.MachineName = machine.MachineName;
                    }
                }
                retData.Code = RESULT_CODE.OK;
                TempData[SERACH_ASIX] = procDetail.Axis_No;



            }
            catch (Exception e)
            {
                retData.Content = "查询失败，请联系管理员";
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = procDetail;
            }
            procDetailList.Add(procDetail);
            retData.Appendix = procDetailList;

            return Json(retData);
        }



        public VM_JSMind genMindStruct(string axisNumStr, string id, ref VM_JSMind mind, string parentId = "", bool isRoot = false)
        {
            if (string.IsNullOrEmpty(axisNumStr) || !HisMain.IsAxisNum(axisNumStr))
            {
                return null;
            }
            var bllMachine = new MesWeb.BLL.T_Machine();
            var bllMachineType = new MesWeb.BLL.T_MachineType();
            var bllEmployee = new MesWeb.BLL.T_Employee();
            var bllMaterial = new MesWeb.BLL.T_MaterialOutput();
            HisMain axisNum = new HisMain();
            if (axisNumStr.StartsWith("ZD"))
            {
                axisNum.Year = axisNumStr.Substring(2, 4);
                axisNum.Month = axisNumStr.Substring(6, 2);
                axisNum.MachineTypeID = "5";
            }
            else if (axisNumStr.StartsWith("CP"))
            {
                axisNum = new HisMain(axisNumStr);
            }
            var hisTabName = "HISMAIN" + axisNum.Year + axisNum.Month + axisNum.MachineTypeID.Trim();
            var bllHisMain = new MesWeb.BLL.T_HisMain(hisTabName);
            var hisMain = bllHisMain.GetModelList("Axis_No like '%" + axisNumStr + "%'").FirstOrDefault();
            if (hisMain == null)
            {
                return null;
            }
            var machineType = bllMachineType.GetModel(int.Parse(axisNum.MachineTypeID));
            MesWeb.Model.T_MaterialOutput material = null;
            if (hisMain != null)
            {
                material = bllMaterial.GetModelList("MaterialRFID = '" + hisMain.MaterialRFID + "'").FirstOrDefault();
            }
            if (material != null)
            {
                hisMain.SpecColor = material.Color;
                hisMain.SpecName = material.MaterialType;
                hisMain.Supplier = material.SupplyCompany;
            }


            var employeeCode = hisMain.EmployeeID_Main;
            var employee = bllEmployee.GetModelList("EmployeeCode = '" + employeeCode + "'").FirstOrDefault();
            if (employee != null)
            {
                hisMain.EmployeeID_Main = employee.EmployeeName;

            }
            var machine = bllMachine.GetModel(hisMain.MachineID.Value);

            var node = new JSMind_Data();


            node.topic = machineType.MachineType + machine.MachineName;
            node.id = id;
            node.parentid = parentId;
            node.isroot = isRoot;
            node.data = hisMain;
            mind.data.Add(node);
            if (hisMain != null)
            {
                var startAxisNums = ("" + hisMain.Start_Axis_No).Split(',');
                foreach (var stNum in startAxisNums)
                {
                    genMindStruct(stNum, stNum, ref mind, id);
                }
            }

            return mind;

        }



        [HttpPost]
        public JsonResult GetAllReportAction()
        {
            var retData = new VM_Result_Data();
            var cerFolder = ConfigurationManager.AppSettings["CertificateFolder"];
            var filePath = Path.Combine(Server.MapPath("~" + cerFolder));
            retData.Appendix = FindFile(filePath);
            retData.Code = RESULT_CODE.OK;
            return Json(retData);
        }

        public List<string> FindFile(string sSourcePath)
        {
            //在指定目录及子目录下查找文件,在list中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(sSourcePath);
            DirectoryInfo[] DirSub = Dir.GetDirectories();
            List<String> list = new List<string>();

            if (DirSub.Length <= 0)
            {
                foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
                {
                    list.Add(@"\" + f.ToString());
                }
            }
            int t = 1;
            foreach (DirectoryInfo d in DirSub)//查找子目录 
            {
                FindFile(Dir + @"\" + d.ToString());
                list.Add(Dir + @"\" + d.ToString());
                if (t == 1)
                {
                    foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
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
    public class HisMain
    {
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

        public HisMain()
        {

        }

        public HisMain(string year, string month, string machineId)
        {
            this.Year = year;
            this.Month = month;
            this.MachineID = machineId;
        }

        public HisMain(string axisNumStr)
        {
            this.AxisNumStr = axisNumStr;
            init(AxisNumStr);
        }



        public static HisMain Parse(string axisNumStr)
        {
            return new HisMain(axisNumStr);
        }

        private void init(string axisNumStr)
        {
            axisNumStr = axisNumStr.Trim();
            if (!axisNumStr.StartsWith("CP"))

            {
                Year = axisNumStr.Substring(2, 4);
                Month = axisNumStr.Substring(6, 2);
                MachineTypeID = "5";
                Day = axisNumStr.Substring(8, 2);
                return;
            }
            try
            {
                var machineIdStart = 12;
                if (axisNumStr.Length == 19)
                {
                    ++machineIdStart;
                }
                MachineTypeID = axisNumStr.Substring(2, 2);
                Year = axisNumStr.Substring(4, 4);
                Month = axisNumStr.Substring(8, 2);
                Day = axisNumStr.Substring(10, 2);
                if (MachineTypeID.StartsWith("0"))
                {
                    MachineTypeID = MachineTypeID.Substring(1);
                }

                MachineID = axisNumStr.Substring(machineIdStart, 3);
                LSH = axisNumStr.Substring(machineIdStart + 3);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool IsAxisNum(string axisNumStr)
        {
            //if (!axisNumStr.StartsWith("CP") && !axisNumStr.StartsWith("ZD"))
            //{
            //    return false;
            //}
            return true;
        }

        public string GetHisDataTableName()
        {
            if (IsAxisNum(this.AxisNumStr))
            {
                return GetHisMainTableName(this.AxisNumStr);
            }
            else
            {
                return null;
            }
        }

        public static string GetHisMainTableName(string axisNumStr)
        {
            var axisNum = new HisMain(axisNumStr);
            return "HISMAIN" + axisNum.Year + axisNum.Month + axisNum.MachineTypeID.Trim();
        }

        public static string GetHisMainTableName(DateTime dateTime, int machineTypeId)
        {
            return "HISMAIN" + dateTime.Year.ToString("0000") + dateTime.Month.ToString("00") + machineTypeId.ToString();
        }

    }


}