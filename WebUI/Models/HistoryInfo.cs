using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    public class HisData {

        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string MachineType { get; set; }
        public string TableName { get; set; }
        public string AxisNumStr { get; set; }
        public string MachineTypeId { get; set; }
        public string MachineId { get; set; }
        public string LSH { get; set; }
        public HisData(string year,string month,string machineType) {
            Year = year;
            Month = month;
            MachineType = machineType;
            this.TableName = GetHisDataTableName();
        }

        public HisData(string axisNumStr) {
            if(axisNumStr.EndsWith(",")) {
                axisNumStr = axisNumStr.Replace(",","");
            }
            this.AxisNumStr = axisNumStr;
            init(axisNumStr);
            this.TableName = GetHisDataTableName();

        }


        private void init(string axisNumStr) {
            axisNumStr = axisNumStr.Trim();
            if (!axisNumStr.StartsWith("CP"))

            {
                Year = axisNumStr.Substring(2, 4);
                Month = axisNumStr.Substring(6, 2);
                MachineTypeId = "5";
                Day = axisNumStr.Substring(8, 2);
                return;
            }
            try {
                MachineTypeId = axisNumStr.Substring(2,2);
                Year = axisNumStr.Substring(4,4);
                Month = axisNumStr.Substring(8,2);
                Day = axisNumStr.Substring(10,2);
                if(MachineTypeId.StartsWith("0")) {
                    MachineTypeId = MachineTypeId.Substring(1);
                }
                if(axisNumStr.Length == 18) {
                    MachineId = axisNumStr.Substring(12,2);
                    LSH = axisNumStr.Substring(14,4);
                } else {
                    MachineId = axisNumStr.Substring(12,3);
                    LSH = axisNumStr.Substring(15,4);
                }
            } catch(Exception e) {
                throw e;
            }
        }
        public string GetHisDataTableName() {

            return GetHisDataTableName(this.Year,this.Month,this.MachineTypeId);
        }

        public static bool IsCorrectTabName(string tabStr) {
            if(!tabStr.Contains("HISDATA") || tabStr.Trim().Length > 15) {
                return false;
            }
            return true;
        }

        public static string GetHisDataTableName(DateTime dateTime,int machineTypeId) {
            return "HISDATA" + dateTime.Year.ToString() + dateTime.Month.ToString("00") + machineTypeId.ToString();
        }
        public string GetHisDataTableName(string year,string month,string machineTypeId) {
            return "HISDATA" + Year.ToString() + month + machineTypeId;

        }



    }
}