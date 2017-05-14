using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MaterialController : Controller
    {

        public static readonly string gumReportType = "gum";
        public static readonly string productReportType = "product";
        public static readonly string spliter = ",_,";

        // GET: Material
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加胶料检验报告
        /// </summary>
        /// <returns></returns>
        public ActionResult GumReportAdd()
        {
            return View();
        }

        /// <summary>
        /// 添加成品检验报告
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductReportAdd()
        {
            return View();
        }

        /// <summary>
        /// 搜索胶料检验报告
        /// </summary>
        /// <returns></returns>
        public ActionResult GumReportSearch()
        {
            return View();
        }

        /// <summary>
        /// 搜索成品检验报告
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductReportSearch()
        {
            return View();
        }

        /// <summary>
        /// 胶料报告详情
        /// </summary>
        /// <returns></returns>
        public ActionResult GumReportDetail(int Id)
        {
            //var bllAllReport = new MesWeb.BLL.T_AllReport();
            //var report = bllAllReport.GetModel(Id);
            return View(Id);
        }

        public ActionResult ProductReportDetail(int Id)
        {
            return View(Id);
        }

        /// <summary>
        /// 试验登记表
        /// </summary>
        /// <returns></returns>
        public ActionResult TrialReportAdd()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetReportDetailAction(int Id)
        {
            var retData = new VM_Result_Data();
            retData.Content = "获取报表详情失败";
            var bllAllReport = new MesWeb.BLL.T_AllReport();
            var report = bllAllReport.GetModel(Id);
            var reportValue = new List<String>();
            var remarkValue = new List<String>();
            if (report != null)
            {
                reportValue = report.ReportValue.Split(new string[] { spliter }, StringSplitOptions.None).ToList();
                remarkValue = report.Remark.Split(new string[] { spliter }, StringSplitOptions.None).ToList();


                retData.Appendix = new { remark = remarkValue, report = reportValue };

                retData.Code = RESULT_CODE.OK;
                retData.Content = "查询报表成功";
            }
            return Json(retData);
        }
        /// <summary>
        /// 成品报告详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductReport()
        {
            return View();
        }

        /// <summary>
        /// 添加报表
        /// </summary>
        /// <param name="data">报表数据</param>
        /// <param name="index">索引数据，报表数据的下表</param>
        /// <param name="type">报表类型，gum,product等等</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddReportAction(List<string> data, List<int> index, string type)
        {
            var retData = new VM_Result_Data();
            retData.Content = "添加报表失败";
            if (addReport(data, index, type, null))
            {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "添加报表成功";
            }

            return Json(retData);
        }

        /// <summary>
        /// 添加多行数据的报表
        /// </summary>
        /// <param name="allData">数据</param>
        /// <param name="index">索引号</param>
        /// <param name="type">类型</param>
        /// <param name="remark">备注数据，比如填写员日期等等，每行都有</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMultiRowReportAction(List<List<string>> allData, List<int> index, string type, List<string> remark)
        {
            var retData = new VM_Result_Data();
            retData.Content = "添加报表失败";
            var isAllAdded = true;
            if (allData != null && index != null)
            {
                allData.ForEach(d =>
                {
                    isAllAdded = addReport(d, index, type, remark);
                });
            }
            else
            {
                isAllAdded = false;
            }
            if (isAllAdded)
            {
                retData.Code = RESULT_CODE.OK;
                retData.Content = "添加报表成功";
            }
            return Json(retData);
        }


        public static int SearchReportId(List<string> cond, string type)
        {
            var bllAllReport = new MesWeb.BLL.T_AllReport();
            var condStr = "";
            if (cond != null && cond.Count > 0)
            {
                cond.ForEach(c =>
                {
                    condStr = condStr + spliter + c + "%";
                });
                condStr = condStr.Substring(spliter.Length);
            }
            var result = bllAllReport.GetModelList("ReportType = '" + type + "' and  IndexValue like '%" + condStr + "' ").FirstOrDefault();
            return result.Id;
        }

        /// <summary>
        /// 查询报表
        /// </summary>
        /// <param name="cond">条件</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchReportAction(List<string> cond, string type)
        {
            var retData = new VM_Result_Data();
            retData.Content = "查询失败";
            var bllAllReport = new MesWeb.BLL.T_AllReport();
            var condStr = "";
            if (cond != null && cond.Count > 0)
            {
                cond.ForEach(c =>
                {
                    condStr = condStr + spliter + c + "%";
                });
                condStr = condStr.Substring(spliter.Length);
            }
            var result = bllAllReport.GetModelList("ReportType = '" + type + "' and  IndexValue like '" + condStr + "' ");
            if (result != null && result.Count > 0)
            {

                var repList = new List<VM_GumReportSearchResult>();
                var results = new List<SearchReportResult>();

                result.ForEach(report =>
                {
                    var value = report.ReportValue.Split(new string[] { spliter }, StringSplitOptions.None).ToList();
                    var remark = report.Remark.Split(new string[] { spliter }, StringSplitOptions.None).ToList();
                    var res = new SearchReportResult();
                    //通用型结果
                    res.Remark = remark;
                    res.Report = value;
                    res.Id = report.Id;
                    res.InputDate = report.InputDate.HasValue ? report.InputDate.Value.ToString("yyyy-MM-dd") : "--";
                    results.Add(res);

                    var rep = new VM_GumReportSearchResult();
                    //翻译字段
                    rep.BatchNum = value[2];
                    rep.InputDate = report.InputDate.HasValue ? report.InputDate.Value.ToString("yyyy-MM-dd") : "--";
                    rep.SpecNum = value[1];
                    rep.Supplier = value[0];
                    rep.Detail = "<a reportId='" + report.Id + "' onclick='navToGumDetail(this)'>详细</a>";

                    repList.Add(rep);
                });
                retData.Content = results;
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = repList;
            }
            return Json(retData);
        }

        class SearchReportResult
        {
            public List<String> Report;
            public List<string> Remark;
            public string InputDate;
            public int Id;
        }



        private bool addReport(List<string> data, List<int> index, string type, List<string> remark)
        {
            try
            {
                if (data != null && data.Count > 0 && type != null)
                {
                    MesWeb.Model.T_AllReport report = new MesWeb.Model.T_AllReport();
                    string dataStr = "";
                    //内容数据
                    data.ForEach(d =>
                    {
                        dataStr = dataStr + spliter + d;
                    });

                    dataStr = dataStr.Substring(spliter.Length);
                    //索引数据
                    string indexStr = "";
                    index.ForEach(i =>
                    {
                        indexStr = indexStr + spliter + data[i];
                    });
                    indexStr = indexStr.Substring(spliter.Length);

                    //备注数据
                    string remarkStr = "";
                    if (remark != null && remark.Count > 0)
                    {
                        remark.ForEach(r =>
                        {
                            remarkStr = remarkStr + spliter + r;
                        });
                    }
                    if (!string.IsNullOrEmpty(remarkStr))
                    {
                        remarkStr = remarkStr.Substring(spliter.Length);

                    }

                    //生成报表
                    report.IndexValue = indexStr;
                    report.InputDate = DateTime.Now;
                    report.ReportType = type;
                    report.ReportValue = dataStr;
                    report.Remark = remarkStr;
                    //添加报表
                    MesWeb.BLL.T_AllReport bllReport = new MesWeb.BLL.T_AllReport();
                    bllReport.Add(report);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}