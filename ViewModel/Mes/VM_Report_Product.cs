using MesWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Mes {


    public class VM_Repoprt_Product_Cond {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string supplier { get; set; }
        public string specNum { get; set; }
        public string batchNum { get; set; }
    }

    public class VM_Report_Product_Bref {
        public string InputDate { get; set; }
        public string VolNum { get; set; }
        public string Detail { get; set; }
        public string Supplier { get; set; }
    }

    public class VM_Report_Product {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Supplier { get; set; }
        public string Std_ConductorStruct { get; set; }
        public string Std_VerticalDia { get; set; }
        public string Std_EdgeDiaAvg { get; set; }
        public string Std_EdgeDiaMin { get; set; }
        public string Std_SheathAvg { get; set; }
        public string Std_SheathMin { get; set; }
        public string Std_Resistance { get; set; }
        public string Std_VoltageTest { get; set; }
        public string Actual_ConductorStruct { get; set; }
        public string Actual_VerticalDiaHeader1 { get; set; }
        public string Actual_VerticalDiaHeader2 { get; set; }
        public string Actual_VerticalDiaFooter1 { get; set; }
        public string Actual_VerticalDiaFooter2 { get; set; }
        public string Actual_EdgeDiaAvgHeader { get; set; }
        public string Actual_EdgeDiaAvgFooter { get; set; }
        public string Actual_EdgeDiaMinHeader { get; set; }
        public string Actual_EdgeDiaMinFooter { get; set; }
        public string Actual_SheathAvgHeader { get; set; }
        public string Actual_SheathAvgFooter { get; set; }
        public string Actual_SheathMinHeader { get; set; }
        public string Actual_SheathMinFooter { get; set; }
        public string Actual_Resistance { get; set; }
        public string Actual_VoltageTest { get; set; }
        public string VolNum { get; set; }
        public string SpecNum { get; set; }
        public string Num { get; set; }
        public string Appearance { get; set; }
        public string CheckResult { get; set; }
        public DateTime? InputDate { get; set; }

        private T_Report_Product _reportProduct;
        public T_Report_Product ReportProduct {
            get {
                if(_reportProduct == null) {
                    _reportProduct = toReportProduct();
                }
                return _reportProduct;
            }
        }

        private T_Report_Product_Actual _reportProductActual;

        public T_Report_Product_Actual ReportProductActual {
            get {
                if(_reportProductActual == null) {
                    _reportProductActual = toReportProductActual();
                }
                return _reportProductActual;
            }
        }

        private T_Report_Product_Standard _reportProductStd;

        public T_Report_Product_Standard ReportProductStd {
            get {
                if(_reportProductStd == null) {
                    _reportProductStd = toReportProductStd();
                }

                return _reportProductStd;
            }

        }




        private T_Report_Product toReportProduct() {
            var rp = new T_Report_Product();
            rp.Code = this.Code;
            rp.Num = this.Num;
            rp.SpecNum = this.SpecNum;
            rp.VolNum = this.VolNum;
            rp.Appearance = this.Appearance;
            rp.CheckResult = this.CheckResult;
            rp.InputDate = this.InputDate;
            rp.Supplier = this.Supplier;
            return rp;
        }

        private T_Report_Product_Actual toReportProductActual() {
            var rpa = new T_Report_Product_Actual();
            rpa.ConductorStruct = this.Actual_ConductorStruct;
            rpa.EdgeDiaAvgFooter = this.Actual_EdgeDiaAvgFooter;
            rpa.EdgeDiaAvgHeader = this.Actual_EdgeDiaAvgHeader;
            rpa.EdgeDiaMinFooter = this.Actual_EdgeDiaMinFooter;
            rpa.EdgeDiaMinHeader = this.Actual_EdgeDiaMinHeader;
            rpa.Resistance = this.Actual_Resistance;
            rpa.SheathAvgFooter = this.Actual_SheathAvgFooter;
            rpa.SheathAvgHeader = this.Actual_SheathAvgHeader;
            rpa.SheathMinFooter = this.Actual_SheathMinFooter;
            rpa.SheathMinHeader = this.Actual_SheathMinHeader;
            rpa.VerticalDiaFooter1 = this.Actual_VerticalDiaFooter1;
            rpa.VerticalDiaFooter2 = this.Actual_VerticalDiaFooter2;
            rpa.VerticalDiaHeader1 = this.Actual_VerticalDiaHeader1;
            rpa.VerticalDiaHeader2 = this.Actual_VerticalDiaHeader2;
            rpa.VoltageTest = this.Actual_VoltageTest;
            return rpa;
        }

        private T_Report_Product_Standard toReportProductStd() {
            var rps = new T_Report_Product_Standard();
            rps.ConductorStruct = this.Std_ConductorStruct;
            rps.EdgeDiaAvg = this.Std_EdgeDiaAvg;
            rps.EdgeDiaMin = this.Std_EdgeDiaMin;
            rps.Resistance = this.Std_Resistance;
            rps.SheathAvg = this.Std_SheathAvg;
            rps.SheathMin = this.Std_SheathMin;
            rps.VerticalDia = this.Std_VerticalDia;
            rps.VoltageTest = this.Std_VoltageTest;
            return rps;
        }

        public void updateReportProduct(T_Report_Product rp) {
            if(rp == null) {
                return;
            }
            this.Code = rp.Code;
            this.SpecNum = rp.SpecNum;
            this.VolNum = rp.VolNum;
            this.Num = rp.Num;
            this.Appearance = rp.Appearance;
            this.CheckResult = rp.CheckResult;
            this.InputDate = rp.InputDate;
            this.Supplier = rp.Supplier;
        }

        public void updateReportStd(T_Report_Product_Standard psd) {
            if(psd != null) {
                this.Std_ConductorStruct = psd.ConductorStruct;
                this.Std_EdgeDiaAvg = psd.EdgeDiaAvg;
                this.Std_EdgeDiaMin = psd.EdgeDiaMin;
                this.Std_Resistance = psd.Resistance;
                this.Std_SheathAvg = psd.SheathAvg;
                this.Std_SheathMin = psd.SheathMin;
                this.Std_VerticalDia = psd.VerticalDia;
                this.Std_VoltageTest = psd.VoltageTest;
            }
        }
        public void updateReportActual(T_Report_Product_Actual pactual) {
            if(pactual == null) {
                return;
            }
            this.Actual_ConductorStruct = pactual.ConductorStruct;
            this.Actual_EdgeDiaAvgFooter = pactual.EdgeDiaAvgFooter;
            this.Actual_EdgeDiaAvgHeader = pactual.EdgeDiaAvgHeader;
            this.Actual_EdgeDiaMinFooter = pactual.EdgeDiaMinFooter;
            this.Actual_EdgeDiaMinHeader = pactual.EdgeDiaMinHeader;
            this.Actual_Resistance = pactual.Resistance;
            this.Actual_SheathAvgFooter = pactual.SheathAvgFooter;
            this.Actual_SheathAvgHeader = pactual.SheathAvgHeader;
            this.Actual_SheathMinFooter = pactual.SheathMinFooter;
            this.Actual_SheathMinHeader = pactual.SheathMinHeader;
            this.Actual_VerticalDiaFooter1 = pactual.VerticalDiaFooter1;
            this.Actual_VerticalDiaFooter2 = pactual.VerticalDiaFooter2;
            this.Actual_VerticalDiaHeader1 = pactual.VerticalDiaHeader1;
            this.Actual_VerticalDiaHeader2 = pactual.VerticalDiaHeader2;
            this.Actual_VoltageTest = pactual.VoltageTest;
        }
    }

}

