using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {

    public class VM_Report_Plastic_Bref {
        public string InputDate { get; set; }
        public string SpecNum { get; set; }
        public string Detail { get; set; }
        public string Supplier { get; set; }
    }

    public class VM_Repoprt_Plastic_Cond {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string supplier { get; set; }
        public string specNum { get; set; }
        public string batchNum { get; set; }
    }
    public class VM_Report_Plastic {
        public  int Id { get; set; }
        public string Code { get; set; }
        public string Header_SpecNum { get; set; }
        public string Header_Supplier { get; set; }
        public string Header_SampleColor { get; set; }
        public string Header_BatchNum { get; set; }
        public string Header_IncomingQty { get; set; }
        public string Header_HasOutFactoryReport { get; set; }
        public string Header_SampleNum { get; set; }
        public string Header_CheckDate { get; set; }
        public string ElecRat_Std { get; set; }
        public string ElecRat_Actual1 { get; set; }
        public string ElecRat_Actual2 { get; set; }
        public string ElecRat_Actual3 { get; set; }
        public string ElecRat_Actual4 { get; set; }
        public string ElecRat_Actual5 { get; set; }
        public string ElecRat_Result { get; set; }
        public string ElecStrength_Std { get; set; }
        public string ElecStrength_Actual1 { get; set; }
        public string ElecStrength_Actual2 { get; set; }
        public string ElecStrength_Actual3 { get; set; }
        public string ElecStrength_Actual4 { get; set; }
        public string ElecStrength_Actual5 { get; set; }
        public string ElecStrength_Result { get; set; }
        public string MpaBefore_Std { get; set; }
        public string MpaBefore_Actual1 { get; set; }
        public string MpaBefore_Actual2 { get; set; }
        public string MpaBefore_Actual3 { get; set; }
        public string MpaBefore_Actual4 { get; set; }
        public string MpaBefore_Actual5 { get; set; }
        public string MpaBefore_Result { get; set; }
        public string ElongBefore_Std { get; set; }
        public string ElongBefore_Acutal1 { get; set; }
        public string ElongBefore_Acutal2 { get; set; }
        public string ElongBefore_Acutal3 { get; set; }
        public string ElongBefore_Acutal4 { get; set; }
        public string ElongBefore_Acutal5 { get; set; }
        public string ElongBefore_Result { get; set; }
        public string AgingCondition_Std { get; set; }
        public string AgingCondition_Actual1 { get; set; }
        public string AgingCondition_Actual2 { get; set; }
        public string AgingCondition_Actual3 { get; set; }
        public string AgingCondition_Actual4 { get; set; }
        public string AgingCondition_Actual5 { get; set; }
        public string AgingCondition_Result { get; set; }
        public string MpaAfter_Std { get; set; }
        public string MpaAfter_Actual1 { get; set; }
        public string MpaAfter_Actual2 { get; set; }
        public string MpaAfter_Actual3 { get; set; }
        public string MpaAfter_Actual4 { get; set; }
        public string MpaAfter_Actual5 { get; set; }
        public string MpaAfter_Result { get; set; }
        public string ElongAfter_Std { get; set; }
        public string ElongAfter_Actual1 { get; set; }
        public string ElongAfter_Actual2 { get; set; }
        public string ElongAfter_Actual3 { get; set; }
        public string ElongAfter_Actual4 { get; set; }
        public string ElongAfter_Actual5 { get; set; }
        public string ElongAfter_Result { get; set; }
        public string MpaRateMax_Std { get; set; }
        public string MpaRateMax_Actual1 { get; set; }
        public string MpaRateMax_Actual2 { get; set; }
        public string MpaRateMax_Actual3 { get; set; }
        public string MpaRateMax_Actual4 { get; set; }
        public string MpaRateMax_Actual5 { get; set; }
        public string MpaRateMax_Result { get; set; }
        public string ElongRateMax_Std { get; set; }
        public string ElongRateMax_Actual1 { get; set; }
        public string ElongRateMax_Actual2 { get; set; }
        public string ElongRateMax_Actual3 { get; set; }
        public string ElongRateMax_Actual4 { get; set; }
        public string ElongRateMax_Actual5 { get; set; }
        public string ElongRateMax_Result { get; set; }
        public string AgingQualityLoss_Std { get; set; }
        public string AgingQualityLoss_Actual1 { get; set; }
        public string AgingQualityLoss_Actual2 { get; set; }
        public string AgingQualityLoss_Actual3 { get; set; }
        public string AgingQualityLoss_Actual4 { get; set; }
        public string AgingQualityLoss_Actual5 { get; set; }
        public string AgingQualityLoss_Result { get; set; }
        public string ThermalStablityTime_Std { get; set; }
        public string ThermalStablityTime_Actual1 { get; set; }
        public string ThermalStablityTime_Actual2 { get; set; }
        public string ThermalStablityTime_Actual3 { get; set; }
        public string ThermalStablityTime_Actual4 { get; set; }
        public string ThermalStablityTime_Actual5 { get; set; }
        public string ThermalStablityTime_Result { get; set; }
        public string BittleImpactTes_Std { get; set; }
        public string BittleImpactTes_Actual1 { get; set; }
        public string BittleImpactTes_Actual2 { get; set; }
        public string BittleImpactTes_Actual3 { get; set; }
        public string BittleImpactTes_Actual4 { get; set; }
        public string BittleImpactTes_Actual5 { get; set; }
        public string BittleImpactTes_Result { get; set; }
        public string ThermalDeformation_Std { get; set; }
        public string ThermalDeformation_Actual1 { get; set; }
        public string ThermalDeformation_Actual2 { get; set; }
        public string ThermalDeformation_Actual3 { get; set; }
        public string ThermalDeformation_Actual4 { get; set; }
        public string ThermalDeformation_Actual5 { get; set; }
        public string ThermalDeformation_Result { get; set; }
        public string OxyIndex_Std { get; set; }
        public string OxyIndex_Actual1 { get; set; }
        public string OxyIndex_Actual2 { get; set; }
        public string OxyIndex_Actual3 { get; set; }
        public string OxyIndex_Actual4 { get; set; }
        public string OxyIndex_Actual5 { get; set; }
        public string OxyIndex_Result { get; set; }
        public string SpecGravity_Std { get; set; }
        public string SpecGravity_Actual1 { get; set; }
        public string SpecGravity_Actual2 { get; set; }
        public string SpecGravity_Actual3 { get; set; }
        public string SpecGravity_Actual4 { get; set; }
        public string SpecGravity_Actual5 { get; set; }
        public string SpecGravity_Result { get; set; }
        public string ShoreHBTestI_Std { get; set; }
        public string ShoreHBTestI_Actual1 { get; set; }
        public string ShoreHBTestI_Actual2 { get; set; }
        public string ShoreHBTestI_Actual3 { get; set; }
        public string ShoreHBTestI_Actual4 { get; set; }
        public string ShoreHBTestI_Actual5 { get; set; }
        public string ShoreHBTestI_Result { get; set; }
        public string ApperanceQuality_Actual1 { get; set; }
        public string ApperanceQuality_Actual2 { get; set; }
        public string ApperanceQuality_Actual3 { get; set; }
        public string ApperanceQuality_Actual4 { get; set; }
        public string ApperanceQuality_Actual5 { get; set; }
        public string ApperanceQuality_Result { get; set; }
        public string PkgAndLabel_Actual1 { get; set; }
        public string PkgAndLabel_Actual2 { get; set; }
        public string PkgAndLabel_Actual3 { get; set; }
        public string PkgAndLabel_Actual4 { get; set; }
        public string PkgAndLabel_Actual5 { get; set; }
        public string PkgAndLabel_Result { get; set; }
        public string Footer_PassNum { get; set; }
        public string Footer_DefectNum { get; set; }
        public string Footer_DefectCode { get; set; }
        public string Footer_Inspector { get; set; }
        public string Footer_Auditer { get; set; }
        public string Footer_Approver { get; set; }
        public int Footer_ICPReporter { get; set; }
        public int Footer_ZDEnvTestResult { get; set; }
        public int Footer_VerifyResult { get; set; }
        public DateTime? Header_InputDate { get; set; }

        public T_Report_Header toReportHeader() {
            var rh = new T_Report_Header();
            rh.BatchNum = this.Header_BatchNum;
            rh.CheckDate = this.Header_CheckDate;
            rh.HasOutFactoryReport = this.Header_HasOutFactoryReport;
            rh.InCommingQty = this.Header_IncomingQty;
            rh.SampleColor = this.Header_SampleColor;
            rh.SampleNum = this.Header_SampleNum;
            rh.SpecNum = this.Header_SpecNum;
            rh.Supplier = this.Header_Supplier;
            rh.InputDate = this.Header_InputDate;
            return rh;
        }

        public T_Report_Footer toReportFooter() {
            var rf = new T_Report_Footer();
            rf.Approver = this.Footer_Approver;
            rf.Auditer = this.Footer_Auditer;
            rf.DefectCode = this.Footer_DefectCode;
            rf.DefectNum = this.Footer_DefectNum;
            rf.ICPReporter = this.Footer_ICPReporter;
            rf.Inspector = this.Footer_Inspector;
            rf.PassNum = this.Footer_PassNum;
            rf.VerifyResult = this.Footer_VerifyResult;
            rf.ZDEnvTestResult = this.Footer_ZDEnvTestResult;          
            return rf;
        }

       

        public T_Report_Value toElecRateValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ElecRat_Std;
            rv.Actual1 = this.ElecRat_Actual1;
            rv.Actual2 = this.ElecRat_Actual2;
            rv.Actual3 = this.ElecRat_Actual3;
            rv.Actual4 = this.ElecRat_Actual4;
            rv.Actual5 = this.ElecRat_Actual5;
            rv.Result = this.ElecRat_Result;
            return rv;
        }

        public T_Report_Value toElecStrengthValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ElecStrength_Std;
            rv.Actual1 = this.ElecStrength_Actual1;
            rv.Actual2 = this.ElecStrength_Actual2;
            rv.Actual3 = this.ElecStrength_Actual3;
            rv.Actual4 = this.ElecStrength_Actual4;
            rv.Actual5 = this.ElecStrength_Actual5;
            rv.Result = this.ElecStrength_Result;
            return rv;
        }

        public T_Report_Value toMpaBeforeValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.MpaBefore_Std;
            rv.Actual1 = this.MpaBefore_Actual1;
            rv.Actual2 = this.MpaBefore_Actual2;
            rv.Actual3 = this.MpaBefore_Actual3;
            rv.Actual4 = this.MpaBefore_Actual4;
            rv.Actual5 = this.MpaBefore_Actual5;
            rv.Result = this.MpaBefore_Result;
            return rv;
        }
     
        public T_Report_Value toPkgAndLabelValue() {
            var rv = new T_Report_Value();
            rv.Standard = "";
            rv.Actual1 = this.PkgAndLabel_Actual1;
            rv.Actual2 = this.PkgAndLabel_Actual2;
            rv.Actual3 = this.PkgAndLabel_Actual3;
            rv.Actual4 = this.PkgAndLabel_Actual4;
            rv.Actual5 = this.PkgAndLabel_Actual5;
            rv.Result = this.PkgAndLabel_Result;
            return rv;
        }
        public T_Report_Value toApperanceQualityValue() {
            var rv = new T_Report_Value();
            rv.Standard = "";
            rv.Actual1 = this.ApperanceQuality_Actual1;
            rv.Actual2 = this.ApperanceQuality_Actual2;
            rv.Actual3 = this.ApperanceQuality_Actual3;
            rv.Actual4 = this.ApperanceQuality_Actual4;
            rv.Actual5 = this.ApperanceQuality_Actual5;
            rv.Result = this.ApperanceQuality_Result;
            return rv;
        }
        public T_Report_Value toShoreHBTestValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ShoreHBTestI_Std;
            rv.Actual1 = this.ShoreHBTestI_Actual1;
            rv.Actual2 = this.ShoreHBTestI_Actual2;
            rv.Actual3 = this.ShoreHBTestI_Actual3;
            rv.Actual4 = this.ShoreHBTestI_Actual4;
            rv.Actual5 = this.ShoreHBTestI_Actual5;
            rv.Result = this.ShoreHBTestI_Result;
            return rv;
        }
        public T_Report_Value toSpecGravityValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.SpecGravity_Std;
            rv.Actual1 = this.SpecGravity_Actual1;
            rv.Actual2 = this.SpecGravity_Actual2;
            rv.Actual3 = this.SpecGravity_Actual3;
            rv.Actual4 = this.SpecGravity_Actual4;
            rv.Actual5 = this.SpecGravity_Actual5;
            rv.Result = this.SpecGravity_Result;
            return rv;
        }
        public T_Report_Value toOxyIndexValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.OxyIndex_Std;
            rv.Actual1 = this.OxyIndex_Actual1;
            rv.Actual2 = this.OxyIndex_Actual2;
            rv.Actual3 = this.OxyIndex_Actual3;
            rv.Actual4 = this.OxyIndex_Actual4;
            rv.Actual5 = this.OxyIndex_Actual5;
            rv.Result = this.OxyIndex_Result;
            return rv;
        }
        public T_Report_Value toThermalDeformationValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ThermalDeformation_Std;
            rv.Actual1 = this.ThermalDeformation_Actual1;
            rv.Actual2 = this.ThermalDeformation_Actual2;
            rv.Actual3 = this.ThermalDeformation_Actual3;
            rv.Actual4 = this.ThermalDeformation_Actual4;
            rv.Actual5 = this.ThermalDeformation_Actual5;
            rv.Result = this.ThermalDeformation_Result;
            return rv;
        }

        public T_Report_Value toBittleImpactTestValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.BittleImpactTes_Std;
            rv.Actual1 = this.BittleImpactTes_Actual1;
            rv.Actual2 = this.BittleImpactTes_Actual2;
            rv.Actual3 = this.BittleImpactTes_Actual3;
            rv.Actual4 = this.BittleImpactTes_Actual4;
            rv.Actual5 = this.BittleImpactTes_Actual5;
            rv.Result = this.BittleImpactTes_Result;
            return rv;
        }
        public T_Report_Value toThermalStablityTimeValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ThermalStablityTime_Std;
            rv.Actual1 = this.ThermalStablityTime_Actual1;
            rv.Actual2 = this.ThermalStablityTime_Actual2;
            rv.Actual3 = this.ThermalStablityTime_Actual3;
            rv.Actual4 = this.ThermalStablityTime_Actual4;
            rv.Actual5 = this.ThermalStablityTime_Actual5;
            rv.Result = this.ThermalStablityTime_Result;
            return rv;
        }
        public T_Report_Value toAgingQualityLossValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.AgingQualityLoss_Std;
            rv.Actual1 = this.AgingQualityLoss_Actual1;
            rv.Actual2 = this.AgingQualityLoss_Actual2;
            rv.Actual3 = this.AgingQualityLoss_Actual3;
            rv.Actual4 = this.AgingQualityLoss_Actual4;
            rv.Actual5 = this.AgingQualityLoss_Actual5;
            rv.Result = this.AgingQualityLoss_Result;
            return rv;
        }

        public T_Report_Value toElongRateMaxValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ElongRateMax_Std;
            rv.Actual1 = this.ElongRateMax_Actual1;
            rv.Actual2 = this.ElongRateMax_Actual2;
            rv.Actual3 = this.ElongRateMax_Actual3;
            rv.Actual4 = this.ElongRateMax_Actual4;
            rv.Actual5 = this.ElongRateMax_Actual5;
            rv.Result = this.ElongRateMax_Result;
            return rv;
        }
        public T_Report_Value toMpaRateMaxValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.MpaRateMax_Std;
            rv.Actual1 = this.MpaRateMax_Actual1;
            rv.Actual2 = this.MpaRateMax_Actual2;
            rv.Actual3 = this.MpaRateMax_Actual3;
            rv.Actual4 = this.MpaRateMax_Actual4;
            rv.Actual5 = this.MpaRateMax_Actual5;
            rv.Result = this.MpaRateMax_Result;
            return rv;
        }
        public T_Report_Value toElongAfterValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ElongAfter_Std;
            rv.Actual1 = this.ElongAfter_Actual1;
            rv.Actual2 = this.ElongAfter_Actual2;
            rv.Actual3 = this.ElongAfter_Actual3;
            rv.Actual4 = this.ElongAfter_Actual4;
            rv.Actual5 = this.ElongAfter_Actual5;
            rv.Result = this.ElongAfter_Result;
            return rv;
        }
        public T_Report_Value toMpaAfterValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.MpaAfter_Std;
            rv.Actual1 = this.MpaAfter_Actual1;
            rv.Actual2 = this.MpaAfter_Actual2;
            rv.Actual3 = this.MpaAfter_Actual3;
            rv.Actual4 = this.MpaAfter_Actual4;
            rv.Actual5 = this.MpaAfter_Actual5;
            rv.Result = this.MpaAfter_Result;
            return rv;
        }
        public T_Report_Value toElongBeforeValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.ElongBefore_Std;
            rv.Actual1 = this.ElongBefore_Acutal1;
            rv.Actual2 = this.ElongBefore_Acutal2;
            rv.Actual3 = this.ElongBefore_Acutal3;
            rv.Actual4 = this.ElongBefore_Acutal4;
            rv.Actual5 = this.ElongBefore_Acutal5;
            rv.Result = this.ElongBefore_Result;
            return rv;
        }

        public T_Report_Value toAgingConditionValue() {
            var rv = new T_Report_Value();
            rv.Standard = this.AgingCondition_Std;
            rv.Actual1 = this.AgingCondition_Actual1;
            rv.Actual2 = this.AgingCondition_Actual2;
            rv.Actual3 = this.AgingCondition_Actual3;
            rv.Actual4 = this.AgingCondition_Actual4;
            rv.Actual5 = this.AgingCondition_Actual5;
            rv.Result = this.AgingCondition_Result;
            return rv;
        }

        public void updateReportPlastic(T_Report_Plastic rp) {
            this.Code = rp.Code;
            this.Id = rp.Id;
        }

        public T_Report_Plastic toReportPlastic() {
            var pls = new T_Report_Plastic();
            pls.Code = this.Code;
            return pls;
        }

        public void updateReportHeader(T_Report_Header rh) {
            if(rh == null) {
                return;
            }
            this.Header_BatchNum = rh.BatchNum;
            this.Header_CheckDate = rh.CheckDate;
            this.Header_HasOutFactoryReport = rh.HasOutFactoryReport;
            this.Header_IncomingQty = rh.InCommingQty;
            this.Header_SampleColor = rh.SampleColor;
            this.Header_SampleNum = rh.SampleNum;
            this.Header_SpecNum = rh.SpecNum;
            this.Header_Supplier = rh.Supplier;
            this.Header_InputDate = rh.InputDate;    
        }

        public void updateReportFooter(T_Report_Footer rf) {
            if(rf == null) {
                return;
            }
            this.Footer_Approver = rf.Approver;
            this.Footer_Auditer = rf.Auditer;
            this.Footer_DefectCode = rf.DefectCode;
            this.Footer_DefectNum = rf.DefectNum;
            this.Footer_ICPReporter = rf.ICPReporter.Value;
            this.Footer_Inspector = rf.Inspector;
            this.Footer_PassNum = rf.PassNum;
            this.Footer_VerifyResult = rf.VerifyResult.Value;
            this.Footer_ZDEnvTestResult = rf.ZDEnvTestResult.Value;
           
        }



       public void updateElecRate(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ElecRat_Actual1 = tv.Actual1;
            this.ElecRat_Actual2 = tv.Actual2;
            this.ElecRat_Actual3 = tv.Actual3;
            this.ElecRat_Actual4 = tv.Actual4;
            this.ElecRat_Actual5 = tv.Actual5;
            this.ElecRat_Result = tv.Result;
            this.ElecRat_Std = tv.Standard;
           
        }
        public void updateElecStrength(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ElecStrength_Actual1 = tv.Actual1;
            this.ElecStrength_Actual2 = tv.Actual2;
            this.ElecStrength_Actual3 = tv.Actual3;
            this.ElecStrength_Actual4 = tv.Actual4;
            this.ElecStrength_Actual5 = tv.Actual5;
            this.ElecStrength_Result = tv.Result;
            this.ElecStrength_Std = tv.Standard;

        }
        public void updateMpaBefore(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.MpaBefore_Actual1 = tv.Actual1;
            this.MpaBefore_Actual2 = tv.Actual2;
            this.MpaBefore_Actual3 = tv.Actual3;
            this.MpaBefore_Actual4 = tv.Actual4;
            this.MpaBefore_Actual5 = tv.Actual5;
            this.MpaBefore_Result = tv.Result;
            this.MpaBefore_Std = tv.Standard;

        }
        public void updateElongBefore(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ElongBefore_Acutal1 = tv.Actual1;
            this.ElongBefore_Acutal2 = tv.Actual2;
            this.ElongBefore_Acutal3 = tv.Actual3;
            this.ElongBefore_Acutal4 = tv.Actual4;
            this.ElongBefore_Acutal5 = tv.Actual5;
            this.ElongBefore_Result = tv.Result;
            this.ElongBefore_Std = tv.Standard;

        }
        public void updateAgingCondition(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.AgingCondition_Actual1 = tv.Actual1;
            this.AgingCondition_Actual2 = tv.Actual2;
            this.AgingCondition_Actual3 = tv.Actual3;
            this.AgingCondition_Actual4 = tv.Actual4;
            this.AgingCondition_Actual5 = tv.Actual5;
            this.AgingCondition_Result = tv.Result;
            this.AgingCondition_Std = tv.Standard;

        }
        public void updateMpaAfter(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.MpaAfter_Actual1 = tv.Actual1;
            this.MpaAfter_Actual2 = tv.Actual2;
            this.MpaAfter_Actual3 = tv.Actual3;
            this.MpaAfter_Actual4 = tv.Actual4;
            this.MpaAfter_Actual5 = tv.Actual5;
            this.MpaAfter_Result = tv.Result;
            this.MpaAfter_Std = tv.Standard;

        }
        public void updateElongAfter(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ElongAfter_Actual1 = tv.Actual1;
            this.ElongAfter_Actual2 = tv.Actual2;
            this.ElongAfter_Actual3 = tv.Actual3;
            this.ElongAfter_Actual4 = tv.Actual4;
            this.ElongAfter_Actual5 = tv.Actual5;
            this.ElongAfter_Result = tv.Result;
            this.ElongAfter_Std = tv.Standard;

        }
        public void updateMpaRateMax(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.MpaRateMax_Actual1 = tv.Actual1;
            this.MpaRateMax_Actual2 = tv.Actual2;
            this.MpaRateMax_Actual3 = tv.Actual3;
            this.MpaRateMax_Actual4 = tv.Actual4;
            this.MpaRateMax_Actual5 = tv.Actual5;
            this.MpaRateMax_Result = tv.Result;
            this.MpaRateMax_Std = tv.Standard;

        }
        public void updateElongRateMax(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ElongRateMax_Actual1 = tv.Actual1;
            this.ElongRateMax_Actual2 = tv.Actual2;
            this.ElongRateMax_Actual3 = tv.Actual3;
            this.ElongRateMax_Actual4 = tv.Actual4;
            this.ElongRateMax_Actual5 = tv.Actual5;
            this.ElongRateMax_Result = tv.Result;
            this.ElongRateMax_Std = tv.Standard;

        }
        public void updateAgingQualityLoss(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.AgingQualityLoss_Actual1 = tv.Actual1;
            this.AgingQualityLoss_Actual2 = tv.Actual2;
            this.AgingQualityLoss_Actual3 = tv.Actual3;
            this.AgingQualityLoss_Actual4 = tv.Actual4;
            this.AgingQualityLoss_Actual5 = tv.Actual5;
            this.AgingQualityLoss_Result = tv.Result;
            this.AgingQualityLoss_Std = tv.Standard;

        }
        public void updateThermalStablityTime(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ThermalStablityTime_Actual1 = tv.Actual1;
            this.ThermalStablityTime_Actual2 = tv.Actual2;
            this.ThermalStablityTime_Actual3 = tv.Actual3;
            this.ThermalStablityTime_Actual4 = tv.Actual4;
            this.ThermalStablityTime_Actual5 = tv.Actual5;
            this.ThermalStablityTime_Result = tv.Result;
            this.ThermalStablityTime_Std = tv.Standard;

        }
        public void updateBittleImpactTest(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.BittleImpactTes_Actual1 = tv.Actual1;
            this.BittleImpactTes_Actual2 = tv.Actual2;
            this.BittleImpactTes_Actual3 = tv.Actual3;
            this.BittleImpactTes_Actual4 = tv.Actual4;
            this.BittleImpactTes_Actual5 = tv.Actual5;
            this.BittleImpactTes_Result = tv.Result;
            this.BittleImpactTes_Std = tv.Standard;

        }
        public void updateThermalDeformation(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ThermalDeformation_Actual1 = tv.Actual1;
            this.ThermalDeformation_Actual2 = tv.Actual2;
            this.ThermalDeformation_Actual3 = tv.Actual3;
            this.ThermalDeformation_Actual4 = tv.Actual4;
            this.ThermalDeformation_Actual5 = tv.Actual5;
            this.ThermalDeformation_Result = tv.Result;
            this.ThermalDeformation_Std = tv.Standard;

        }
        public void updateOxyIndex(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.OxyIndex_Actual1 = tv.Actual1;
            this.OxyIndex_Actual2 = tv.Actual2;
            this.OxyIndex_Actual3 = tv.Actual3;
            this.OxyIndex_Actual4 = tv.Actual4;
            this.OxyIndex_Actual5 = tv.Actual5;
            this.OxyIndex_Result = tv.Result;
            this.OxyIndex_Std = tv.Standard;

        }
        public void updateSpecGravity(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.SpecGravity_Actual1 = tv.Actual1;
            this.SpecGravity_Actual2 = tv.Actual2;
            this.SpecGravity_Actual3 = tv.Actual3;
            this.SpecGravity_Actual4 = tv.Actual4;
            this.SpecGravity_Actual5 = tv.Actual5;
            this.SpecGravity_Result = tv.Result;
            this.SpecGravity_Std = tv.Standard;

        }
        public void updateShoreHBTest(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ShoreHBTestI_Actual1 = tv.Actual1;
            this.ShoreHBTestI_Actual2 = tv.Actual2;
            this.ShoreHBTestI_Actual3 = tv.Actual3;
            this.ShoreHBTestI_Actual4 = tv.Actual4;
            this.ShoreHBTestI_Actual5 = tv.Actual5;
            this.ShoreHBTestI_Result = tv.Result;
            this.ShoreHBTestI_Std = tv.Standard;

        }
        public void updateApperanceQuality(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.ApperanceQuality_Actual1 = tv.Actual1;
            this.ApperanceQuality_Actual2 = tv.Actual2;
            this.ApperanceQuality_Actual3 = tv.Actual3;
            this.ApperanceQuality_Actual4 = tv.Actual4;
            this.ApperanceQuality_Actual5 = tv.Actual5;
            this.ApperanceQuality_Result = tv.Result;


        }
        public void updatePkgAndLabel(T_Report_Value tv) {
            if(tv == null) {
                return;
            }
            this.PkgAndLabel_Actual1 = tv.Actual1;
            this.PkgAndLabel_Actual2 = tv.Actual2;
            this.PkgAndLabel_Actual3 = tv.Actual3;
            this.PkgAndLabel_Actual4 = tv.Actual4;
            this.PkgAndLabel_Actual5 = tv.Actual5;
            this.PkgAndLabel_Result = tv.Result;

        }
      

    }



}
