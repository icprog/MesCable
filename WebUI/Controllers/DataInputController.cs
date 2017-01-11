using MesWeb.Model;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers {
    /// <summary>
    /// 数据录入
    /// </summary>
    public class DataInputController:BaseController {
        // GET: DataInput
        public ActionResult Index() {
            return View();
        }

        /// <summary>
        /// 成品
        /// </summary>
        /// <returns></returns>
        public ActionResult Product() {
            return View();
        }

        /// <summary>
        /// 胶料
        /// </summary>
        /// <returns></returns>
        public ActionResult Plastic() {
            return View();
        }

        /// <summary>
        /// 导体
        /// </summary>
        /// <returns></returns>
        public ActionResult Conductor() {
            return View();
        }

        public ActionResult ProductTest() {

            return View();
        }

        public ActionResult PlasticTest() {
            return View();
        }

        /// <summary>
        /// 塑料搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult PlasticSearch() {
            return View();
        }

        public ActionResult ProductSearch() {
            return View();
        }

        /// <summary>
        /// 添加成品报告
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddProductReportAction(VM_Report_Product product) {
            var retData = new VM_Result_Data();
            retData.Content = "添加成品失败";

            var bllPd = new MesWeb.BLL.T_Report_Product();
            var bllPdStd = new MesWeb.BLL.T_Report_Product_Standard();
            var bllPdActual = new MesWeb.BLL.T_Report_Product_Actual();
            try {
                var stdId = bllPdStd.Add(product.ReportProductStd);
                var actualId = bllPdActual.Add(product.ReportProductActual);
                if(stdId > 0 && actualId > 0) {
                    var pd = product.ReportProduct;
                    pd.StandardId = stdId;
                    pd.ActualId = actualId;
                    if(bllPd.Add(pd) > 0) {
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "添加成品表成功";
                    }
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error(e);
            }

            return Json(retData);
        }

        /// <summary>
        /// 表详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductDetail(int id) {
            var detail = getProductDetailById(id);
            return View(detail);
        }

        /// <summary>
        /// 保存更新成品报表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveReportProductAction(VM_Report_Product product) {
            var retData = new VM_Result_Data();
            retData.Content = "更新成品表失败";
            var bllPd = new MesWeb.BLL.T_Report_Product();
            var bllRpStd = new MesWeb.BLL.T_Report_Product_Standard();
            var bllRpActual = new MesWeb.BLL.T_Report_Product_Actual();
            var oldPd = bllPd.GetModelList("Code = '" + product.Code + "'").First();
            if(oldPd != null) {
                try {
                    //更新主表
                    var oldPdId = oldPd.Id;
                    var rpStdId = oldPd.StandardId;
                    var rpActualId = oldPd.ActualId;

                    var newPd = product.ReportProduct;
                    newPd.Id = oldPd.Id;
                    newPd.ActualId = rpActualId;
                    newPd.StandardId = rpStdId;
                    bllPd.Update(newPd);
                    //更新标准值表

                    if(rpStdId.HasValue) {
                        var rpStd = product.ReportProductStd;
                        rpStd.Id = rpStdId.Value;
                        bllRpStd.Update(rpStd);
                    }
                    //更新实际值表
                    if(rpActualId.HasValue) {
                        var rpActual = product.ReportProductActual;
                        rpActual.Id = rpActualId.Value;
                        bllRpActual.Update(rpActual);
                    }
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "更新成品表成功";
                } catch(Exception e) {
                    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                    log.Error(e);
                }
            }
            return Json(retData);
        }

        /// <summary>
        /// 添加塑料报告
        /// </summary>
        /// <param name="plastic"></param>
        /// <returns></returns>
        public JsonResult AddPlasticReportAction(VM_Report_Plastic plastic) {
            var retData = new VM_Result_Data();
            retData.Content = "添加塑料报告失败";
            var rp = toPlasticModel(plastic);
            if(rp != null) {
                var bllRp = new MesWeb.BLL.T_Report_Plastic();
                if(bllRp.Add(rp) > 0) {
                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "添加塑料表成功";
                }
            }

            return Json(retData);
        }

        public JsonResult SaveReportPlasticAction(VM_Report_Plastic plastic) {
            var retData = new VM_Result_Data();
            retData.Content = "更新塑料报告失败";
            var bllPls = new MesWeb.BLL.T_Report_Plastic();
            var bllHeader = new MesWeb.BLL.T_Report_Header();
            var bllFooter = new MesWeb.BLL.T_Report_Footer();
            var bllValue = new MesWeb.BLL.T_Report_Value();
            try {
                var oldHeader = bllHeader.GetModelList("SpecNum = '" + plastic.Header_SpecNum + "'").First();
                if(oldHeader != null) {
                    var oldPls = bllPls.GetModelList("ReportHeaderId = '" + oldHeader.Id + "'").First();
                    if(oldPls != null) {
                        //更新header
                        var newHeader = plastic.toReportHeader();
                        newHeader.Id = oldHeader.Id;
                        bllHeader.Update(newHeader);
                        //更新footer
                        var oldFooter = bllFooter.GetModel(oldPls.ReportFooterId.Value);
                        var newFooter = plastic.toReportFooter();
                        newFooter.Id = oldFooter.Id;
                        bllFooter.Update(newFooter);
                        //更新plastic
                        oldPls.Code = plastic.Code;
                        bllPls.Update(oldPls);
                        //更新具体值
                        var oldElecRate = bllValue.GetModel(oldPls.ElecRateId.Value);
                        var newElecRate = plastic.toElecRateValue();
                        newElecRate.Id = oldElecRate.Id;
                        bllValue.Update(newElecRate);

                        var oldElecStrength = bllValue.GetModel(oldPls.ElecStrengthId.Value);
                        var newElecStrength = plastic.toElecStrengthValue();
                        newElecStrength.Id = oldElecStrength.Id;
                        bllValue.Update(newElecStrength);

                        var oldMpaBefore = bllValue.GetModel(oldPls.MpaBeforeId.Value);
                        var newMpaBefore = plastic.toMpaBeforeValue();
                        newMpaBefore.Id = oldMpaBefore.Id;
                        bllValue.Update(newMpaBefore);

                        var oldElongBefore = bllValue.GetModel(oldPls.ElongBeforeId.Value);
                        var newElongBefore = plastic.toElongBeforeValue();
                        newElongBefore.Id = oldElongBefore.Id;
                        bllValue.Update(newElongBefore);

                        var oldAgingCondition = bllValue.GetModel(oldPls.AgingConditionId.Value);
                        var newAgingCondition = plastic.toAgingConditionValue();
                        newAgingCondition.Id = oldAgingCondition.Id;
                        bllValue.Update(newAgingCondition);

                        var oldMpaAfter = bllValue.GetModel(oldPls.MpaAfterId.Value);
                        var newMpaAfter = plastic.toMpaAfterValue();
                        newMpaAfter.Id = oldMpaAfter.Id;
                        bllValue.Update(newMpaAfter);

                        var oldElongAfter = bllValue.GetModel(oldPls.ElongAfterId.Value);
                        var newElongAfter = plastic.toElongAfterValue();
                        newElongAfter.Id = oldElongAfter.Id;
                        bllValue.Update(newElongAfter);

                        var oldMpaRateMax = bllValue.GetModel(oldPls.MpaRateMaxId.Value);
                        var newMpaRateMax = plastic.toMpaRateMaxValue();
                        newMpaRateMax.Id = oldMpaRateMax.Id;
                        bllValue.Update(newMpaRateMax);

                        var oldElongRateMax = bllValue.GetModel(oldPls.ElongRateMaxId.Value);
                        var newElongRateMax = plastic.toElongRateMaxValue();
                        newElongRateMax.Id = oldElongRateMax.Id;
                        bllValue.Update(newElongRateMax);

                        var oldAgingQualityLoss = bllValue.GetModel(oldPls.AgingQualityLossId.Value);
                        var newAgingQualityLoss = plastic.toAgingQualityLossValue();
                        newAgingQualityLoss.Id = oldAgingQualityLoss.Id;
                        bllValue.Update(newAgingQualityLoss);

                        var oldThermalStablityTime = bllValue.GetModel(oldPls.ThermalStablityTimeId.Value);
                        var newThermalStablityTime = plastic.toThermalStablityTimeValue();
                        newThermalStablityTime.Id = oldThermalStablityTime.Id;
                        bllValue.Update(newThermalStablityTime);

                        var oldBittleImpactTest = bllValue.GetModel(oldPls.BittleImpactTestId.Value);
                        var newBittleImpactTest = plastic.toBittleImpactTestValue();
                        newBittleImpactTest.Id = oldBittleImpactTest.Id;
                        bllValue.Update(newBittleImpactTest);

                        var oldThermalDeformation = bllValue.GetModel(oldPls.ThermalDeformationId.Value);
                        var newThermalDeformation = plastic.toThermalDeformationValue();
                        newThermalDeformation.Id = oldThermalDeformation.Id;
                        bllValue.Update(newThermalDeformation);

                        var oldOxyIndex = bllValue.GetModel(oldPls.OxyIndexId.Value);
                        var newOxyIndex = plastic.toOxyIndexValue();
                        newOxyIndex.Id = oldOxyIndex.Id;
                        bllValue.Update(newOxyIndex);

                        var oldSpecGravity = bllValue.GetModel(oldPls.SpecGravityId.Value);
                        var newSpecGravity = plastic.toSpecGravityValue();
                        newSpecGravity.Id = oldSpecGravity.Id;
                        bllValue.Update(newSpecGravity);

                        var oldShoreHBTest = bllValue.GetModel(oldPls.ShoreHBTestId.Value);
                        var newShoreHBTest = plastic.toShoreHBTestValue();
                        newShoreHBTest.Id = oldShoreHBTest.Id;
                        bllValue.Update(newShoreHBTest);

                        var oldApperanceQuality = bllValue.GetModel(oldPls.ApperanceQualityId.Value);
                        var newApperanceQuality = plastic.toApperanceQualityValue();
                        newApperanceQuality.Id = oldApperanceQuality.Id;
                        bllValue.Update(newApperanceQuality);

                        var oldPkgAndLabel = bllValue.GetModel(oldPls.PkgAndLabelId.Value);
                        var newPkgAndLabel = plastic.toPkgAndLabelValue();
                        newPkgAndLabel.Id = oldPkgAndLabel.Id;
                        bllValue.Update(newPkgAndLabel);

                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "更新塑料表成功";

                    }
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error(e);
            }

            return Json(retData);
        }



        /// <summary>
        /// 查询成品
        /// </summary>
        /// <param name="cond">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SearchProduct(VM_Repoprt_Product_Cond cond) {
            var retData = new VM_Result_Data();
            retData.Content = "查询失败";
            var bllPd = new MesWeb.BLL.T_Report_Product();
            List<T_Report_Product> pdList = new List<T_Report_Product>();
            bool isFirstSearch = true;

            //录入时间
            if(cond.startDate.HasValue && cond.endDate.HasValue) {
                isFirstSearch = false;
                pdList = bllPd.GetModelList("InputDate >=　'" + cond.startDate + "' and InputDate <= '" + cond.endDate + "'");
            }

            //规格型号
            if(!string.IsNullOrEmpty(cond.specNum)) {
                if(isFirstSearch) {
                    isFirstSearch = false;
                    pdList = bllPd.GetModelList("SpecNum = '" + cond.specNum + "'");                  
                } else {
                    pdList = (from p in pdList where p.SpecNum == cond.specNum select p).ToList();
                }
            }

            //批次号(表单编号)
            if(!string.IsNullOrEmpty(cond.batchNum)) {
                if(isFirstSearch) {
                    isFirstSearch = false;
                    pdList = bllPd.GetModelList("Code = '" + cond.batchNum + "'");
                } else {
                    pdList = (from p in pdList where p.Code == cond.batchNum select p).ToList();
                }
            }

            //供应商
            if(!string.IsNullOrEmpty(cond.supplier)) {
                if(isFirstSearch) {
                    pdList = bllPd.GetModelList("Supplier = '" + cond.supplier + "'");
                }else {
                    pdList = (from p in pdList where p.Supplier == cond.supplier select p).ToList();
                }
            }

            //列表信息
            var pdBrefList = new List<VM_Report_Product_Bref>();
            foreach(var pd in pdList) {
                pdBrefList.Add(new VM_Report_Product_Bref {
                    VolNum = pd.VolNum,
                    InputDate = pd.InputDate.Value.ToString("yyyy-MM-dd"),
                    Supplier = pd.Supplier,
                    Detail = "<a  onclick='showRPDetail("+pd.Id+")'>报表详情</a>"
                });
              
            }

            if(pdBrefList.Count > 0) {
                retData.Code = RESULT_CODE.OK;
                retData.Appendix = pdBrefList;
                retData.Content = "查询成功";

            }
            return Json(retData);
        }



        /// <summary>
        /// 通过成品Id获取成品报表详情
        /// </summary>
        /// <param name="id"> 成品 Id</param>
        /// <returns></returns>
        private VM_Report_Product getProductDetailById(int id) {
            var vmPd = new VM_Report_Product();
            var bllPd = new MesWeb.BLL.T_Report_Product();
            var bllReportStd = new MesWeb.BLL.T_Report_Product_Standard();
            var bllReportActual = new MesWeb.BLL.T_Report_Product_Actual();
            var pd = bllPd.GetModel(id);
            if(pd != null) {
                try {
                    vmPd.updateReportProduct(pd);
                    if(pd.StandardId.Value > 0) {
                        var std = bllReportStd.GetModel(pd.StandardId.Value);
                        vmPd.updateReportStd(std);
                    }
                    if(pd.ActualId.Value > 0) {
                        var actual = bllReportActual.GetModel(pd.ActualId.Value);
                        vmPd.updateReportActual(actual);
                    }


                } catch(Exception e) {
                    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                    log.Error(e);
                }            
            }
            return vmPd;
        }

        /// <summary>
        /// 搜索成品表
        /// </summary>
        /// <param name="volNum"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchProductByVolNumAction(string volNum) {
            var retData = new VM_Result_Data();
            var vmPd = new VM_Report_Product();
            var bllReportStd = new MesWeb.BLL.T_Report_Product_Standard();
            var bllReportActual = new MesWeb.BLL.T_Report_Product_Actual();
            retData.Content = "查询成品报表失败";
            var bllPd = new MesWeb.BLL.T_Report_Product();
            var pd = bllPd.GetModelList("VolNum = '" + volNum + "'").FirstOrDefault();
            if(pd != null) {
                try {
                    vmPd.updateReportProduct(pd);

                    if(pd.StandardId.Value > 0) {
                        var std = bllReportStd.GetModel(pd.StandardId.Value);
                        vmPd.updateReportStd(std);
                    }
                    if(pd.ActualId.Value > 0) {
                        var actual = bllReportActual.GetModel(pd.ActualId.Value);
                        vmPd.updateReportActual(actual);
                    }

                    retData.Code = RESULT_CODE.OK;
                    retData.Content = "查询成功";
                    retData.Appendix = vmPd;
                } catch(Exception e) {
                    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                    log.Error(e);
                }
            }


            return Json(retData);
        }

        /// <summary>
        /// 搜索塑料表
        /// </summary>
        /// <param name="specNum"></param>
        /// <returns></returns>
        public JsonResult SearchPlastictBySpecNumAction(string specNum) {
            var retData = new VM_Result_Data();
            retData.Content = "搜索塑料表失败";
            var bllPls = new MesWeb.BLL.T_Report_Plastic();
            var bllHeader = new MesWeb.BLL.T_Report_Header();
            var bllFooter = new MesWeb.BLL.T_Report_Footer();
            var header = bllHeader.GetModelList("SpecNum = '" + specNum + "'").First();

            if(header != null) {

                try {
                    var pls = bllPls.GetModelList("ReportHeaderId = " + header.Id).First();
                    if(pls != null) {
                        var vmPls = new VM_Report_Plastic();
                        var footer = bllFooter.GetModel(pls.ReportFooterId.Value);
                        ReportPlasticUpdate(out vmPls,pls,header,footer);
                        retData.Appendix = vmPls;
                        retData.Content = "查询塑料报表成功";
                        retData.Code = RESULT_CODE.OK;
                    }
                } catch(Exception e) {
                    log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                    log.Error(e);
                }
            }

            return Json(retData);
        }

        public void ReportPlasticUpdate(out VM_Report_Plastic vmPls,T_Report_Plastic pls,T_Report_Header rh,T_Report_Footer rf) {
            vmPls = new VM_Report_Plastic();
            var bllValue = new MesWeb.BLL.T_Report_Value();
            vmPls.updateReportHeader(rh);
            vmPls.updateReportFooter(rf);
            vmPls.updateReportPlastic(pls);
            vmPls.updateAgingCondition(bllValue.GetModel(pls.AgingConditionId.Value));
            vmPls.updateElecRate(bllValue.GetModel(pls.ElecRateId.Value));
            vmPls.updateElecStrength(bllValue.GetModel(pls.ElecStrengthId.Value));
            vmPls.updateMpaBefore(bllValue.GetModel(pls.MpaBeforeId.Value));
            vmPls.updateElongBefore(bllValue.GetModel(pls.ElongBeforeId.Value));
            vmPls.updateMpaAfter(bllValue.GetModel(pls.MpaAfterId.Value));
            vmPls.updateElongAfter(bllValue.GetModel(pls.ElongAfterId.Value));
            vmPls.updateMpaRateMax(bllValue.GetModel(pls.MpaRateMaxId.Value));
            vmPls.updateElongRateMax(bllValue.GetModel(pls.ElongRateMaxId.Value));
            vmPls.updateAgingQualityLoss(bllValue.GetModel(pls.AgingQualityLossId.Value));
            vmPls.updateThermalStablityTime(bllValue.GetModel(pls.ThermalStablityTimeId.Value));
            vmPls.updateBittleImpactTest(bllValue.GetModel(pls.BittleImpactTestId.Value));
            vmPls.updateThermalDeformation(bllValue.GetModel(pls.ThermalDeformationId.Value));
            vmPls.updateOxyIndex(bllValue.GetModel(pls.OxyIndexId.Value));
            vmPls.updateSpecGravity(bllValue.GetModel(pls.SpecGravityId.Value));
            vmPls.updateShoreHBTest(bllValue.GetModel(pls.ShoreHBTestId.Value));
            vmPls.updateApperanceQuality(bllValue.GetModel(pls.ApperanceQualityId.Value));
            vmPls.updatePkgAndLabel(bllValue.GetModel(pls.PkgAndLabelId.Value));

        }

        /// <summary>
        /// 将前端塑料报告数据转换成持久层模型
        /// </summary>
        /// <param name="vmPlastic"></param>
        /// <returns></returns>
        private T_Report_Plastic toPlasticModel(VM_Report_Plastic vmPlastic) {
            T_Report_Plastic rp = null;
            var bllRvalue = new MesWeb.BLL.T_Report_Value();
            var bllRheader = new MesWeb.BLL.T_Report_Header();
            var bllFooter = new MesWeb.BLL.T_Report_Footer();
            try {
                var headerId = bllRheader.Add(vmPlastic.toReportHeader());
                var footerId = bllFooter.Add(vmPlastic.toReportFooter());
                var elecRateId = bllRvalue.Add(vmPlastic.toElecRateValue());
                var elecStrengthId = bllRvalue.Add(vmPlastic.toElecStrengthValue());
                var mpaBeforeId = bllRvalue.Add(vmPlastic.toMpaAfterValue());
                var elongBeforeId = bllRvalue.Add(vmPlastic.toElongBeforeValue());
                var agingConditionId = bllRvalue.Add(vmPlastic.toAgingConditionValue());
                var mpaAfterId = bllRvalue.Add(vmPlastic.toMpaAfterValue());
                var elongAfterId = bllRvalue.Add(vmPlastic.toElongAfterValue());
                var mpaRateMaxId = bllRvalue.Add(vmPlastic.toMpaRateMaxValue());
                var elongRateMaxId = bllRvalue.Add(vmPlastic.toElongRateMaxValue());
                var agingQualityLossId = bllRvalue.Add(vmPlastic.toAgingQualityLossValue());
                var thermalStablityTimeId = bllRvalue.Add(vmPlastic.toThermalStablityTimeValue());
                var bittleImpactTestId = bllRvalue.Add(vmPlastic.toBittleImpactTestValue());
                var thermalDeformationId = bllRvalue.Add(vmPlastic.toThermalDeformationValue());
                var oxyIndexId = bllRvalue.Add(vmPlastic.toOxyIndexValue());
                var specGravityId = bllRvalue.Add(vmPlastic.toSpecGravityValue());
                var shoreHBTestId = bllRvalue.Add(vmPlastic.toShoreHBTestValue());
                var apperanceQualityId = bllRvalue.Add(vmPlastic.toApperanceQualityValue());
                var pkgAndLabeId = bllRvalue.Add(vmPlastic.toPkgAndLabelValue());

                rp = new T_Report_Plastic();
                rp.AgingConditionId = agingConditionId;
                rp.AgingQualityLossId = agingQualityLossId;
                rp.ApperanceQualityId = apperanceQualityId;
                rp.BittleImpactTestId = bittleImpactTestId;
                rp.Code = vmPlastic.Code;
                rp.ElecRateId = elecRateId;
                rp.ElecStrengthId = elecStrengthId;
                rp.ElongAfterId = elongAfterId;
                rp.ElongBeforeId = elongBeforeId;
                rp.ElongRateMaxId = elongRateMaxId;
                rp.MpaAfterId = mpaAfterId;
                rp.MpaBeforeId = mpaBeforeId;
                rp.MpaRateMaxId = mpaRateMaxId;
                rp.OxyIndexId = oxyIndexId;
                rp.PkgAndLabelId = pkgAndLabeId;
                rp.ReportFooterId = footerId;
                rp.ReportHeaderId = headerId;
                rp.ShoreHBTestId = shoreHBTestId;
                rp.SpecGravityId = specGravityId;
                rp.ThermalDeformationId = thermalDeformationId;
                rp.ThermalStablityTimeId = thermalStablityTimeId;

            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error(e);
            }

            return rp;
        }


    }
}