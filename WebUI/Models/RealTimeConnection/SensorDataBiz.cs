using DataDisplay;
using MesWeb.Model;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using MesWeb.ViewModel.Promise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebUI.Models.RealTimeConnection {
    public class SensorDataBiz:ISensorDataBiz {

        /// <summary>
        /// 获取机台传感器数据
        /// </summary>
        /// <param name="dpData">原始所有数据</param>
        /// <returns></returns>
        public VM_Result_Data GetSensorData(SensorData data) {
            //int calcMs = 0;
            //按参数类型分组
            var groupData = (from d in data.CollectedData group d by d.ParameterCodeID into g select g);
            var sensorOnlines = new List<VM_Sensor_Online>();
            foreach(var specGp in groupData) {
                var sensorOnline = new VM_Sensor_Online();
                var paramCodeId = specGp.Key;
                if(paramCodeId == null) {
                    continue;
                }

                //获取参数 ID
                sensorOnline.ParamCodeId = paramCodeId;
                sensorOnline.SeriesData = new List<VM_Sensor_Data>();
                //获取参数值
                foreach(var spec in specGp) {
                    //防止速度过快数据重叠
               //     calcMs += 5;
                 //   Random rand = new Random();
                 //   var randMs = rand.Next(calcMs,calcMs + 4); 
           //         var x = ((DateTime)(spec.CollectedTime)).AddMilliseconds(randMs);
                 //   //设置精度到毫秒级别
                    //f表示保留一位小数，即精度为 0.5s = 500ms;
                    //重新生成时间保证时间不重叠
                       var m =DateTime.Now. ToString("yyyy-MM-dd HH:mm:ss.ffff");
                   // var m = x.ToString();
                    sensorOnline.SeriesData.Add(new VM_Sensor_Data { X = m,Y = float.Parse(spec.CollectedValue) });
                    sensorOnline.Message = spec.CollectedValue.ToString();
                }
                sensorOnlines.Add(sensorOnline);
            }
            var retData = new VM_Result_Data();
            if(sensorOnlines.Count > 0) {
                retData.Appendix = sensorOnlines;
                retData.Code = RESULT_CODE.OK;
                retData.Content = "更新实时数据成功";
            }
            return retData;
        }


        protected VM_Fusioncharts_Line getSensorLineChart(int paramCodeId,List<T_CollectedDataParameters> dataList) {
            var vmChart = new VM_Fusioncharts_Line();
            var bllParamData = new MesWeb.BLL.T_CollectedDataParameters();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var bllParamSetting = new MesWeb.BLL.T_ParametersCol();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var paramCode = bllParamCode.GetModel(paramCodeId);


            var paramSetting = bllParamSetting.GetModelList("ParameterCodeID = " + (int)paramCode.ParameterCodeID).FirstOrDefault();

            var paramUnit = bllParamUnit.GetModel((int)paramCode.ParameterUnitID);
            var chart = new FusionChart {
                caption = paramCode.ParameterName,
                numberSuffix = paramUnit.ParameterUnitSymbol,
                yAxisName = paramUnit.ParameterUnitName,
                xAxisName = "时间"
            };

            var maxLine = new FusionLine {
                startvalue = paramSetting.ParametersColMaxiumValue,
                displayvalue = "最大值"
            };
            var minLine = new FusionLine {
                startvalue = paramSetting.ParametersColMiniumValue,
                displayvalue = "最小值"
            };
            var trendline = new FusionTrendLine();
            trendline.line.Add(maxLine);
            trendline.line.Add(minLine);

            vmChart.chart = chart;
            vmChart.trendlines.Add(trendline);

            for(int i = 0;i < dataList.Count;i++) {
                vmChart.data.Add(new FusionData {
                    //    label = ((DateTime)dataList[i].CollectedTime).ToUniversalTime().Subtract(
                    //   //  new DateTime(1969,12,30,16,0,0,DateTimeKind.Utc)
                    label = dataList[i].CollectedTime.ToString(),
                    value = dataList[i].CollectedValue.ToString()
                });

            };
            vmChart.paramCodeId = paramCodeId;
            return vmChart;

        }

    }


}