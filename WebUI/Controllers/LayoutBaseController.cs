using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Ocx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Utils;

namespace WebUI.Controllers {
    public class LayoutBaseController:BaseController {
        protected enum LAYOUT_TPYE {
            MACHINE = 1,
            STORE_AREA = 3,
            WORK_AREA = 4,
            SENSOR_MODULE = 5,
            EXTRA_SENSOR = 6
        }
        protected struct PARAMETER_CODE_TYPE {
            public static int IDCARD_STAFF { get { return 0; } }
            public static int SENSOR_SITE { get { return 1; } }
            public static int SENSOR_MACHINE { get { return 2; } }
        }

        protected enum VIRTUAL_LAYOUT {
            VIRTUAL_MACHINE = 13
        }

        protected enum PARAM_TYPE {
            CHART_MACHINE = 2,
            CHART_SITE = 1,
            ID_CARD = 0
        }
        public enum SPEC_PARAM_CODE {
            METERS_COUNT_FACT = 32,
            MATERIAL_RFID = 11,
            LINEAR_SPEED = 37,
            //外径OD，线径OD
            OUTTER_OD = 2,
            //内径OD，铜线OD
            INNER_OD = 42,
            TESSION = 8,
            RPM = 34,
            METERS_COUNT = 5

        }

        protected enum CPK_PARAM_CODE {
            CPK_OUTTER_OD = 2,
            CPK_INNER_OD = 41,
            //CPK_PAYOFF_TENSION = 8,
            //  CPK_RPM = 34
        }

        protected enum RESULT_CHART_TYPE {
            LINE = 1,
            MSLINE = 2,
            LINE_MSLINE = 3
        }


        protected MesWeb.BLL.T_LayoutPicture bllLayout = new MesWeb.BLL.T_LayoutPicture();
        protected VM_LayoutPicture GetLayoutInfo(MesWeb.Model.T_LayoutPicture layoutPicture) {
            var vmLayoutView = new VM_LayoutPicture(layoutPicture);
            var subSpotItems = bllLayout.GetModelList("IsTop = 0 AND ParentLayoutPictureID = " + layoutPicture.LayoutPictureID);
            foreach(var item in subSpotItems) {
                var vmItem = new VM_LayoutPicture(item);
                vmLayoutView.SubSpotItems.Add(vmItem);
            }
            return vmLayoutView;
        }

        protected VM_LayoutPicture GetLayoutInfo(int layoutPictureID) {
            var layout = bllLayout.GetModel(layoutPictureID);
            if(layout != null) {
                return GetLayoutInfo(layout);
            } else {
                return null;
            }
        }
        protected MesWeb.Model.T_LayoutPicture GetParentLayout(int Id) {
            var layout = bllLayout.GetModel(Id);

            var parentLayout = bllLayout.GetModel((int)layout.ParentLayoutPictureID);
            return parentLayout;
        }

        protected int getTableRowID(int layoutID) {
            return (int)bllLayout.GetModel(layoutID).TableRowID;

        }





        /////////////////////
        protected VM_MachineProperty GetMachineProperty(int Id) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);

            var machLayout = bllLayout.GetModel(Id);
            var machPty = new VM_MachineProperty();
            if(machLayout != null) {
                if(machLayout.LayoutTypeID == (int)LAYOUT_TPYE.MACHINE) {
                    try {

                        var bllMach = new MesWeb.BLL.T_Machine();
                        var bllCurData = new MesWeb.BLL.T_CurrentData();
                        var bllEmployee = new MesWeb.BLL.T_Employee();
                        var bllSpec = new MesWeb.BLL.T_Specification();
                        var bllColData = new MesWeb.BLL.T_CollectedDataParameters();

                        var mach = bllMach.GetModel((int)machLayout.TableRowID);
                        if(mach == null) {
                            return null;
                        }
                        var curData = bllCurData.GetModelList("MachineID = " + mach.MachineID).FirstOrDefault();
                        if(curData == null) {
                            return null;
                        }
                        ///  var emmployee = bllEmployee.GetModel((int)curData.EmployeeID_Main);
                        var spec = bllSpec.GetModel((int)curData.SpecificationID);
                        var curMeters = bllColData.GetModelList("MachineID = " + mach.MachineID + " AND  ParameterCodeID = " + (int)SPEC_PARAM_CODE.METERS_COUNT_FACT).FirstOrDefault().CollectedValue;
                        var materialRFID = bllColData.GetModelList("MachineID = " + mach.MachineID + " AND  ParameterCodeID = " + (int)SPEC_PARAM_CODE.MATERIAL_RFID).FirstOrDefault().CollectedValue;
                        var linearSpeed = bllColData.GetModelList("MachineID = " + mach.MachineID + " AND  ParameterCodeID = " + (int)SPEC_PARAM_CODE.LINEAR_SPEED).FirstOrDefault().CollectedValue;

                        machPty.MachineName = mach.MachineName;
                        machPty.TaskNum = "4000";
                        machPty.AxisNum = curData.Axis_No;
                        //   machPty.ManuMan = emmployee.EmployeeName;
                        machPty.ManuMan = "张三";
                        machPty.SpecNum = spec.SpecificationName;
                        machPty.ODMax = spec.ODMax;
                        machPty.ODMin = spec.ODMin;
                        machPty.SpecColor = spec.SpecificationColor;
                        machPty.UnitPrice = spec.SpecificationPrice;
                        machPty.MaterialRFID = materialRFID;
                        machPty.CurrentMeters = curMeters;
                        machPty.BatchNum = "Na";
                        machPty.ContUnit = "Na";
                        machPty.JobNum = "Na";
                        machPty.EstTime = ((40000 - double.Parse(curMeters)) / double.Parse(linearSpeed) / 60).ToString("0.00") + "分钟";
                        machPty.ReachedNum = (double.Parse(curMeters) * 100 / 4000 + "%").ToString();
                    } catch(Exception e) {
                        log.Error("数据库操作失败",e);
                        return null;
                    }

                } else {
                    log.Error("该标志不属于机台");
                    return null;
                }
            } else {
                log.Error("查找机台失败!");
                return null;
            }
            return machPty;
        }
        protected List<VM_Fusioncharts_Line> getSensorLineChartList(int sensorModuleID,int machineID,int size = -1) {
            List<VM_Fusioncharts_Line> vmChartsList = new List<VM_Fusioncharts_Line>();
            var bllSensor = new MesWeb.BLL.T_SensorModule();
            var sensor = bllSensor.GetModel(sensorModuleID);
            if(sensor != null) {
                var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
                var bllParamCode = new MesWeb.BLL.T_ParameterCode();
                var sensorParamCodeList = bllSensorParamCode.GetModelList("SensorModuleID = " + sensor.SensorModuleID);
                var codeList = new List<MesWeb.Model.T_ParameterCode>();
                foreach(var sensorCode in sensorParamCodeList) {
                    var paramCode = bllParamCode.GetModel((int)sensorCode.ParameterCodeID);
                    codeList.Add(paramCode);
                }
                vmChartsList = getParamsChartList(machineID,codeList.ToArray());
            }
            return vmChartsList;
        }
        protected List<VM_Fusioncharts_Line> getParamsChartList(int machineID,params MesWeb.Model.T_ParameterCode[] paramCodeIDList) {
            List<VM_Fusioncharts_Line> vmChartsList = new List<VM_Fusioncharts_Line>();
            var bllParamData = new MesWeb.BLL.T_CollectedDataParameters();
            var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var bllParamSet = new MesWeb.BLL.T_ParametersCol();

            foreach(var code in paramCodeIDList) {
                var dataList = bllParamData.GetModelList("MachineID = " + machineID + "and ParameterCodeID = " + code.ParameterCodeID);
                var paramSetting = bllParamSet.GetModelList("ParameterCodeID = " + (int)code.ParameterCodeID).FirstOrDefault();
                var paramUnit = bllParamUnit.GetModel((int)code.ParameterUnitID);
                var vmFusion = new VM_Fusioncharts_Line();

                var chart = new FusionChart {
                    caption = code.ParameterName,
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

                vmFusion.chart = chart;
                vmFusion.trendlines.Add(trendline);

                for(int i = 0;i < dataList.Count;i++) {
                    vmFusion.data.Add(new FusionData {
                        //    label = ((DateTime)dataList[i].CollectedTime).ToUniversalTime().Subtract(
                        //                    //  new DateTime(1969,12,30,16,0,0,DateTimeKind.Utc)
                        label = dataList[i].CollectedTime.ToString(),
                        value = dataList[i].CollectedValue.ToString()
                    });

                };
                vmChartsList.Add(vmFusion);
            }
            return vmChartsList;
        }
        protected List<VM_Fusioncharts_Line> getParamsChartList(int machineID,params int[] paramCodeIDs) {
            List<VM_Fusioncharts_Line> vmChartsList = new List<VM_Fusioncharts_Line>();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var paramCodeList = new List<MesWeb.Model.T_ParameterCode>();
            foreach(var id in paramCodeIDs) {
                paramCodeList.Add(bllParamCode.GetModel(id));
            }
            vmChartsList = getParamsChartList(machineID,paramCodeList.ToArray());
            return vmChartsList;
        }
        protected VM_Fusioncharts_Line getSensorLineChart<T>(int machineID,int paramCodeID,int top = 12) where T : MesWeb.BLL.T_CollectedDataParameters, new() {
            var vmChart = new VM_Fusioncharts_Line();
            // var bllParamData = new MesWeb.BLL.T_CollectedDataParameters();
            var bllParamData = new T();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var bllParamSetting = new MesWeb.BLL.T_ParametersCol();
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var paramCode = bllParamCode.GetModel(paramCodeID);

            //   var dataList = bllParamData.GetModelList(top,"MachineID = " + machineID + "and ParameterCodeID = " + paramCode.ParameterCodeID,"ParameterCodeID Desc");
            var dataList = bllParamData.GetModelList("MachineID = " + machineID + "and ParameterCodeID = " + paramCode.ParameterCodeID);

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
                    //                    //  new DateTime(1969,12,30,16,0,0,DateTimeKind.Utc)
                    label = dataList[i].CollectedTime.ToString(),
                    value = dataList[i].CollectedValue.ToString()
                });

            };
            return vmChart;

        }
        protected List<MesWeb.Model.T_CollectedDataParameters> getMachineParamsDataList(int machineID,int paramCodeID = 0) {
            var bllColData = new MesWeb.BLL.T_CollectedDataParameters();
            var colDataList = new List<MesWeb.Model.T_CollectedDataParameters>();
            if(paramCodeID == 0) {
                colDataList = bllColData.GetModelList("MachineID = " + machineID);
            } else {
                colDataList = bllColData.GetModelList("ParameterCodeID = " + (int)paramCodeID + " AND MachineID = " + machineID);
            }
            return colDataList;
        }
        protected MesWeb.Model.T_ParametersCol getMachineParamSetting(int machineID,int paramCodeID) {
            var bllParamSetting = new MesWeb.BLL.T_ParametersCol();
            var paramSetting = bllParamSetting.GetModelList("MachineID = " + machineID + "AND ParameterCodeID = " + (int)paramCodeID).FirstOrDefault();
            return paramSetting;
        }
        protected VM_Fusioncharts_MSLine getMachineCPKMSLineData(int machineID,int CodeID,int dataCount = 12) {
            var bllParamCode = new MesWeb.BLL.T_ParameterCode();
            var code = bllParamCode.GetModel(CodeID);
            return getMachineCPKMSLineData(machineID,code,dataCount);
        }
        protected VM_Fusioncharts_MSLine getMachineCPKMSLineData(int machineID,MesWeb.Model.T_ParameterCode code,int dataCount = 12) {
            var msLine = new VM_Fusioncharts_MSLine();
            var bllParamData = new MesWeb.BLL.T_CollectedDataParameters();
            var bllSensorParamCode = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
            var bllParamUnit = new MesWeb.BLL.T_ParameterUnit();
            var bllParamSet = new MesWeb.BLL.T_ParametersCol();

            var dataList = bllParamData.GetModelList("MachineID = " + machineID + "and ParameterCodeID = " + code.ParameterCodeID);
            var paramSetting = bllParamSet.GetModelList("ParameterCodeID = " + (int)code.ParameterCodeID).FirstOrDefault();
            var paramUnit = bllParamUnit.GetModel((int)code.ParameterUnitID);

            var chart = new FusionChart {
                caption = code.ParameterName,
                numberSuffix = paramUnit.ParameterUnitSymbol,
                yAxisName = paramUnit.ParameterUnitName,
                xAxisName = "时间"
            };

            var maxLine = new FusionLine {
                startvalue = paramSetting.ParametersColMaxiumValue,
                displayvalue = "最大值",

            };
            var minLine = new FusionLine {
                startvalue = paramSetting.ParametersColMiniumValue,
                displayvalue = "最小值",

            };
            var maxCPKLine = new FusionLine {
                startvalue = "2.0",
                displayvalue = "CPK最大值"
            };
            var minCPKLine = new FusionLine {
                startvalue = "0.2",
                displayvalue = "CPK最小值"
            };

            var trendline = new FusionTrendLine();
            trendline.line.Add(maxLine);
            trendline.line.Add(minLine);
            trendline.line.Add(maxCPKLine);
            trendline.line.Add(minCPKLine);
            var cpkDataSet = new FusionMSDataset();
            var sensorDataSet = new FusionMSDataset();
            cpkDataSet.seriesname = "CPK";
            sensorDataSet.seriesname = code.ParameterName;
            var categories = new FusionMSCategories();
            for(int i = 0;i < dataList.Count;i++) {
                var data = dataList[i];
                categories.category.Add(new FusionMSCategorie { label = data.CollectedTime.ToString().Split(' ')[1] });
                sensorDataSet.data.Add(new MSlineValue { value = float.Parse(data.CollectedValue).ToString("0.00") });
                cpkDataSet.data.Add(new MSlineValue { value = GetCPKValue(code.ParameterCodeID,machineID).ToString("0.00") });
            }
            msLine.categories.Add(categories);
            msLine.chart = chart;
            msLine.trendlines.Add(trendline);
            msLine.dataset.Add(sensorDataSet);
            msLine.dataset.Add(cpkDataSet);
            return msLine;
        }
        protected float GetCPKValue(int paramCodeID,int machineID) {
            var bllColData = new MesWeb.BLL.T_CollectedDataParameters();
            var colData = bllColData.GetModelList("ParameterCodeID = " + (int)paramCodeID + " AND MachineID = " + machineID);
            if(colData.Count < 4) {
                return 1.6f;
            }
            List<float> dataList = new List<float>();
            foreach(var item in colData) {
                dataList.Add(float.Parse(item.CollectedValue));
            }
            var bllParamSetting = new MesWeb.BLL.T_ParametersCol();
            var paramSetting = bllParamSetting.GetModelList("MachineID = " + machineID + "AND ParameterCodeID = " + (int)paramCodeID).FirstOrDefault();
            CPK cpk = new CPK(float.Parse(paramSetting.ParametersColMaxiumValue),
                float.Parse(paramSetting.ParametersColMiniumValue),dataList,-1);
            return cpk.getCPK();
        }

    }
}