using MES.DBUtility;
using MesWeb.Model;
using MesWeb.ViewModel.Mes;
using MesWeb.ViewModel.Promise;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using WebUI.Controllers;
using WebUI.Utils;
using static WebUI.Controllers.LayoutBaseController;

namespace WebUI.Models.RealTimeConnection {
    public class SensorUpdater {
        protected LogHelper log;

        protected enum CPK_PARAM_CODE {
            CPK_OD = 2,
            CPK_PAYOFF_TENSION = 8,
            CPK_RPM = 34
        }
        #region 缓存
        //当前米数，主键为机台号
        ConcurrentDictionary<int,string> curMetersDic = new ConcurrentDictionary<int,string>();

        //当前轴号，主键为机台号
        ConcurrentDictionary<int,string> curAxisNumDic = new ConcurrentDictionary<int,string>();

        //当前状态，主键为机台号
        //次字典的主键为模块号，值为模块对应的参数列表
        ConcurrentDictionary<int,ConcurrentDictionary<string,List<Param>>> curModuleStateDic =
            new ConcurrentDictionary<int,ConcurrentDictionary<string,List<Param>>>();

        //参数值映射，服务器发送的是 Type ,我用的是 ID
        //T_ParamCode.Type -----> T_ParamCode.ParamCodeId
        ConcurrentDictionary<int,int> paramCodeDic = new ConcurrentDictionary<int,int>();

        /// <summary>
        /// 机台属性缓存
        /// </summary>
        ConcurrentDictionary<int,VM_MachineProperty> curMachPtyDic = new ConcurrentDictionary<int,VM_MachineProperty>();
        /// <summary>
        /// 初始化模块状态缓存字典
        /// </summary>
        private void initCurModuelStateDic() {
            var bllMachine = new MesWeb.BLL.T_Machine();
            var machList = bllMachine.GetModelList("");
            var bllSensor = new MesWeb.BLL.T_SensorModule();
            var bllParam = new MesWeb.BLL.T_ParameterCode();
            var bllSensor_Param = new MesWeb.BLL.T_SensorModule_T_ParameterCode();
            //遍历所有机台
            foreach(var machine in machList) {
                var machineId = machine.MachineID;
                //为每个机台的所有模块生成一个字典
                var moduleDic = new ConcurrentDictionary<string,List<Param>>();
                //添加机台
                if(curModuleStateDic.TryAdd(machineId,moduleDic)) {
                    var sensors = bllSensor.GetModelList("MachineID = " + machineId);
                    //遍历模块
                    foreach(var sensor in sensors) {
                        //初始化每个模块的参数列表
                        var paramList = new List<Param>();
                        //添加模块
                        if(moduleDic.TryAdd(sensor.SerialNum,paramList)) {
                            var sensor_param = bllSensor_Param.GetModelList("SensorModuleID = " + sensor.SensorModuleID);
                            //遍历模块对应的参数
                            foreach(var sp in sensor_param) {
                                //获得参数
                                var param = bllParam.GetModel(sp.ParameterCodeID.Value);
                                //添加参数
                                paramList.Add(new Param {
                                    ParamCodeID = param.ParameterCodeID.ToString(),
                                    ParamCode = param.ParameterCode.ToString(),
                                    ParamName = param.ParameterName
                                });
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 初始化参数映射字典
        /// </summary>
        private void initParamCodeDic() {
            var bllParam = new MesWeb.BLL.T_ParameterCode();
            var paramList = bllParam.GetModelList("");
            foreach(var param in paramList) {
                paramCodeDic.TryAdd(param.Type.Value,param.ParameterCodeID);
            }
        }
        class Param {
            /// <summary>
            /// 参数ID 2
            /// </summary>
            public string ParamCodeID { get; set; }
            /// <summary>
            /// 下位机的参数编码 502
            /// </summary>
            public string ParamCode { get; set; }
            /// <summary>
            /// 参数名字
            /// </summary>
            public string ParamName { get; set; }
            /// <summary>
            /// 状态
            /// </summary>
            public string FaultValue { get; set; }
            /// <summary>
            /// 更新时间
            /// </summary>
            public DateTime? UpdateTime { get; set; }
        }
        #endregion
        #region 注入Hub与Connection
        //  public static readonly ConcurrentDictionary<string,int> clientsDic = new ConcurrentDictionary<string,int>();
        //MacineID 1:----->:N Web
        public static readonly ConcurrentDictionary<int,List<string>> clientsDic = new ConcurrentDictionary<int,List<string>>();

        private readonly static Lazy<SensorUpdater> instance =
            new Lazy<SensorUpdater>(()
            => new SensorUpdater(
                GlobalHost.ConnectionManager.GetHubContext<SensorUpdateHub>(),
                ConnectionHelper.GetConnection()));

        private IConnection connection;
        private readonly ISensorDataBiz sensorDataBiz = SensorDataBizHelper.GetSensorDataBiz();
        public IConnection Connection {
            get {
                if(connection == null) {
                    return ConnectionHelper.GetConnection();
                }
                return connection;
            }
            set {

                connection = value;
            }
        }
        private Timer timer;

        private bool isDebug = true;

        #endregion

        private readonly IHubContext context;
        public static SensorUpdater Instance {
            get {
                return instance.Value;
            }
        }
        public SensorUpdater(IHubContext context,IConnection connection) {
            bool.TryParse(ConfigurationManager.AppSettings["DebugOnlineData"],out isDebug);
            this.context = context;
            this.connection = connection;
            if(true == isDebug) {
                //定时模拟
                timer = new Timer(testTimerHub,null,2000,500);
            } else {
                //调用服务器处理
                Connection.ProcessData += UpdateSensorData;
            }
            //初始化 curModuelStateDic 缓存
            initCurModuelStateDic();
            //初始化参数映射
            initParamCodeDic();
        }

        int ins = 0;
        public void testTimerHub(object state) {
            ins++;
           
            var sensorData = new SensorData();
            sensorData.CollectedData = new List<T_CollectedDataParameters>();

            Random random = new Random();
            foreach(var machineItem in curMachPtyDic) {
                //OD值
                sensorData.CollectedData.Add(new T_CollectedDataParameters {
                    MachineID = machineItem.Key,
                    CollectedTime = DateTime.Now,
                    CollectedValue = (random.NextDouble() * 8 + 15).ToString(),
                    ParameterCodeID = 2

                });
                sensorData.CollectedData.Add(new T_CollectedDataParameters {
                    MachineID = machineItem.Key,
                    CollectedTime = DateTime.Now,
                    CollectedValue = (random.NextDouble() * 8 + 10).ToString(),
                    ParameterCodeID = 41

                });
                if(ins >= 5) {
                    ins = 0;
                    //一段温度显示值
                    sensorData.CollectedData.Add(new T_CollectedDataParameters {
                        MachineID = machineItem.Key,
                        CollectedTime = DateTime.Now,
                        CollectedValue = (random.NextDouble() * 20 + 185).ToString(),
                        ParameterCodeID = 12
                    });
                    //二段温度显示值
                    sensorData.CollectedData.Add(new T_CollectedDataParameters {
                        MachineID = machineItem.Key,
                        CollectedTime = DateTime.Now,
                        CollectedValue = (random.NextDouble() * 20 + 185).ToString(),
                        ParameterCodeID = 14
                    });
                    //三段温度显示值
                    sensorData.CollectedData.Add(new T_CollectedDataParameters {
                        MachineID = machineItem.Key,
                        CollectedTime = DateTime.Now,
                        CollectedValue = (random.NextDouble() * 20 + 185).ToString(),
                        ParameterCodeID = 16
                    });
                    //四段温度显示值
                    sensorData.CollectedData.Add(new T_CollectedDataParameters {
                        MachineID = machineItem.Key,
                        CollectedTime = DateTime.Now,
                        CollectedValue = (random.NextDouble() * 20 + 185).ToString(),
                        ParameterCodeID = 18
                    });
                }
            }

            sensorData.CodeUsing = new List<T_CodeUsing>();
            TestUpdateSensorData(sensorData);
        }

        #region 与前端交互的方法
        /// <summary>
        /// 初始化字典缓存
        /// </summary>
        /// <param name="machineId"></param>
        /// <param name="axisNum"></param>
        /// <param name="meters"></param>
        private void initDicCache(int machineId,out string axisNum,out string meters) {
            var bllMachine = new MesWeb.BLL.T_Machine();
            var machine = bllMachine.GetModel(machineId);

            //历史采集数据表 
            var hisDatablaName = HisData.GetHisDataTableName(DateTime.Now,machine.MachineTypeID.Value);
            var bllHisData = new MesWeb.BLL.T_HisData(hisDatablaName);
            //历史轴号表
            var hisMainTableName = HisMain.GetHisMainTableName(DateTime.Now,machine.MachineTypeID.Value);
            var bllHisMain = new MesWeb.BLL.T_HisMain(hisMainTableName);
            //缓存中没有该机台的轴号
            if(!curAxisNumDic.TryGetValue(machineId,out axisNum)) {
                //从当月历史数据更新缓存
                var hisMain = bllHisMain.GetModelList("MachineID = " + machineId).FirstOrDefault();
                //当月数据存在，则更新缓存
                if(hisMain != null) {
                    axisNum = hisMain.Axis_No;
                    curAxisNumDic.AddOrUpdate(machineId,hisMain.Axis_No,
                        (key,oldValue) => { return hisMain.Axis_No; });
                } else {
                    //当月数据不存在，则从上月数据查找 TODO

                }
            }

            //缓存中没有当前米数值
            if(!curMetersDic.TryGetValue(machineId,out meters)) {
                //从当月历史数据更新缓存
                //var data = bllHisData.GetModelList("ParameterCodeID = " + (int)SPEC_PARAM_CODE.METERS_COUNT + " group by CollectedTime desc").FirstOrDefault();
                var ds1 = DbHelperSQL.Query("select top 1 * from "
                      + bllHisData.TabName + " where ParameterCodeID = "
                      + (int)SPEC_PARAM_CODE.METERS_COUNT
                      + " AND machineID = " + machineId
                      + " order by CollectedTime desc");
                //找到数据库最后一条数据
                var recentData = bllHisData.DataTableToList(ds1.Tables[0]).FirstOrDefault();
                //当月数据存在，则更新缓存
                if(recentData != null) {
                    //获取数据的轴号
                    var axisNo = recentData.Axis_No;
                    //找到该轴号的米数的最大值
                    var ds2 = DbHelperSQL.
                        Query("SELECT   MAX(CollectedValue) AS CollectedValue, CollectedTime, MachineID, ParameterCodeID, Axis_No" +
                        " FROM  " + bllHisData.TabName +
                        " WHERE (ParameterCodeID = " + (int)SPEC_PARAM_CODE.METERS_COUNT + ") AND (Axis_No = '" + axisNo + "')" +
                        " GROUP BY MachineID,Axis_No,CollectedTime,ParameterCodeID");
                    var row = ds2.Tables[0].Rows[0];
                    var maxMeter = row["CollectedValue"].ToString();
                    meters = maxMeter;
                    //更新缓存
                    curMetersDic.AddOrUpdate(machineId,maxMeter,(key,oldValue) => {
                        return maxMeter;
                    });
                } else {
                    //当月数据不存在，则从上月数据查找
                }

            }
        }

        public string InitAllSensors(int machineId,string connectionId) {
            // 保存连接信息
            if(!AddClient(machineId,connectionId)) {
                return "connected server faild";
            }
            string curAxisNum = "";
            string curMeters = "";
            try {
                initDicCache(machineId,out curAxisNum,out curMeters);
            } catch(Exception e) {
                Debug.Write(e.ToString());
            }
            var bllMach = new MesWeb.BLL.T_Machine();
            var machine = bllMach.GetModel(machineId);
            VM_MachineProperty pty = null;
            try {
                //缓存中数据存在，则从缓存中读取
                if(curMachPtyDic.TryGetValue(machineId,out pty)) {

                } else {
                    pty = new VM_MachineProperty();
                    pty.MachineName = machine.MachineName;
                    pty.CurrentMeters = curMeters;
                    pty.AxisNum = curAxisNum;
                    pty.ODMax = decimal.MinValue;
                    pty.ODMin = decimal.MaxValue;
                    //添加到缓存中去
                    curMachPtyDic.TryAdd(machineId,pty);
                }
            } catch(Exception e) {
                log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
                log.Error("获取机台属性失败",e);
            }


            return "axis: " + curAxisNum + " meters: " + curMeters;
        }


        private void TestUpdateSensorData(SensorData sensorData) {
            //将接受的数据封装成需要的数据
            var retData = sensorDataBiz.GetSensorData(sensorData);
            //按机台分组，即接受到的数据所包含的机台
            var groupData = (from d in sensorData.CollectedData group d by d.MachineID into g select g);
            //取出机台收到的参数
            foreach(var data in groupData) {
                var machineId = data.Key.Value;
                string curMeters = "";
                string curAxisNum = "";


                //更新字典缓存
                updateDicCache(machineId,sensorData,out curMeters,out curAxisNum,
                    //轴号变动则通知前端浏览器清空数据
                    //相当于在线重新进行初始化数据
                    () => {
                        //TODO
                    });

                VM_MachineProperty pty;
                //获取到该机台的属性
                if(curMachPtyDic.TryGetValue(machineId,out pty)) {
                    //更新参数
                    pty.CurrentMeters = curMeters;
                    pty.AxisNum = curAxisNum;
                    //最大最小线径
                    try {
                        var maxOd = (from d in data where d.ParameterCodeID == (int)SPEC_PARAM_CODE.OUTTER_OD select d).Max(d => decimal.Parse(d.CollectedValue));
                        var minOd = (from d in data where d.ParameterCodeID == (int)SPEC_PARAM_CODE.OUTTER_OD select d).Min(d => decimal.Parse(d.CollectedValue));
                        if(pty.ODMax.Value < maxOd) {
                            pty.ODMax = maxOd;
                        }
                        if(pty.ODMin > minOd) {
                            pty.ODMin = minOd;
                        }
                    } catch {

                    }

                }



                //拥有相同机台的前端连接
                var sameMachConnectionIds = new List<string>();
                if(clientsDic.TryGetValue(machineId,out sameMachConnectionIds)) {
                    //挨个推送机台的实时数据
                    ConcurrentDictionary<string,List<Param>> moduleStateTab;
                    curModuleStateDic.TryGetValue(machineId,out moduleStateTab);
                    foreach(var conenctionId in sameMachConnectionIds) {
                        //更新曲线参数
                        context.Clients.Client(conenctionId).
                            updateSensorData(
                             //数据
                             retData,
                            //当前米数
                            curMeters,
                            //该机台的错误表
                            moduleStateTab);

                        //更新机台属性
                        context.Clients.Client(conenctionId).updateMachinePty(pty);

                    }
                }
            }
        }

        int testMeters = 0;
        int testMetersTrigger = 0;
        public void UpdateSensorData(DataDisplay.StructData dpData) {
            var sensorData = new SensorData();

            List<T_CollectedDataParameters> colData = new List<T_CollectedDataParameters>();
            List<T_CodeUsing> code = new List<T_CodeUsing>();
            try {
                if(!string.IsNullOrEmpty(dpData.datamain)) {
                    dpData.datamain = dpData.datamain.Replace(":abc123",":\"\"").Replace("\"abc123\"","\"\"");
                    code = JsonConvert.DeserializeObject<List<T_CodeUsing>>(dpData.datamain);
                }
                if(!string.IsNullOrEmpty(dpData.datadetail)) {
                    dpData.datadetail = dpData.datadetail.Replace(":abc123",":\"\"").Replace("\"abc123\"","\"\"");
                    colData = JsonConvert.DeserializeObject<List<T_CollectedDataParameters>>(dpData.datadetail);
                }
                if(!string.IsNullOrEmpty(dpData.faultdata)) {
                    sensorData.Fault = JsonConvert.DeserializeObject<T_FaultModule>(dpData.faultdata);

                }
                sensorData.CodeUsing = code;
                sensorData.CollectedData = colData;
                updateCurModuleStateDic(sensorData);

            } catch(Exception e) {
                Debug.Write(e.ToString());
                return;
            }
            mapParamCode(sensorData);
            #region 来自于中心服务器测试数据
            ////++testMeters;
            //Random random = new Random();
            //timer = new Timer(testTimerHub,null,random.Next(1000,5000),0);
            //List<T_CollectedDataParameters> colData = new List<T_CollectedDataParameters> {
            //    //现场温度
            //    new T_CollectedDataParameters {
            //        CollectedTime =DateTime.UtcNow,
            //        CollectedValue =  random.Next(-20,100).ToString(),
            //        ParameterCodeID = 3,
            //        MachineID = 22
            //    },
            //    //六段温度
            //  new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(1,3).ToString(),
            //        ParameterCodeID = (int) SPEC_PARAM_CODE.INNER_OD,
            //        MachineID = 22
            //    },
            // new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(2,5).ToString(),
            //        ParameterCodeID = (int)SPEC_PARAM_CODE.OUTTER_OD,
            //        MachineID = 22
            //    },
            // new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(-20,100).ToString(),
            //        ParameterCodeID = 16,
            //        MachineID = 22
            //    },
            // new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(-20,100).ToString(),
            //        ParameterCodeID = 18,
            //        MachineID = 22
            //    },
            // new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(-20,100).ToString(),
            //        ParameterCodeID = 20,
            //        MachineID = 22
            //    },
            // new T_CollectedDataParameters {
            //        CollectedTime = DateTime.Now.AddMilliseconds(500),
            //        CollectedValue =  random.Next(-20,100).ToString(),
            //        ParameterCodeID = 22,
            //        MachineID = 22
            //    },};
            ////收到米数
            //if(testMetersTrigger % 5 == 0) {
            //    ++testMeters;
            //    //colData.Add(new T_CollectedDataParameters {
            //    //    CollectedTime = DateTime.Now.AddMilliseconds(500),
            //    //    CollectedValue = testMeters.ToString(),
            //    //    ParameterCodeID = (int)SPEC_PARAM_CODE.METERS_COUNT,
            //    //    MachineID = 22
            //    //});
            //}
            //List<T_CodeUsing> code = new List<T_CodeUsing>();
            ////模拟每100米更换一次轴号
            //if(testMeters % 2 == 0) {
            //    //code.Add(new T_CodeUsing {
            //    //    Axis_No = "CPXXtestxxxxyyy",
            //    //    GeneratorTime = DateTime.Now,
            //    //    MachineID = 22,
            //    //    CodeNumber = "12456464650"

            //    //});
            //}

            //反序列化的数据
            //sensorData.CodeUsing = code;
            //sensorData.CollectedData = colData;
            #endregion

            //将接受的数据封装成需要的数据
            var retData = sensorDataBiz.GetSensorData(sensorData);
            //按机台分组，即接受到的数据所包含的机台
            var groupData = (from d in sensorData.CollectedData group d by d.MachineID into g select g);
            //取出机台收到的参数
            foreach(var data in groupData) {
                var machineId = data.Key.Value;
                string curMeters = "";
                string curAxisNum = "";


                //更新字典缓存
                updateDicCache(machineId,sensorData,out curMeters,out curAxisNum,
                    //轴号变动则通知前端浏览器清空数据
                    //相当于在线重新进行初始化数据
                    () => {
                        //TODO
                    });

                VM_MachineProperty pty = new VM_MachineProperty();
                //获取到该机台的属性
                if(curMachPtyDic.TryGetValue(machineId,out pty)) {
                    //更新参数
                    pty.CurrentMeters = curMeters;
                    pty.AxisNum = curAxisNum;
                    //最大最小线径
                    try {
                        var maxOd = (from d in data where d.ParameterCodeID == (int)SPEC_PARAM_CODE.OUTTER_OD select d).Max(d => decimal.Parse(d.CollectedValue));
                        var minOd = (from d in data where d.ParameterCodeID == (int)SPEC_PARAM_CODE.OUTTER_OD select d).Min(d => decimal.Parse(d.CollectedValue));
                        if(pty.ODMax.Value < maxOd) {
                            pty.ODMax = maxOd;
                        }
                        if(pty.ODMin > minOd) {
                            pty.ODMin = minOd;
                        }
                    } catch(Exception e) {

                    }

                }



                //拥有相同机台的前端连接
                var sameMachConnectionIds = new List<string>();
                if(clientsDic.TryGetValue(machineId,out sameMachConnectionIds)) {
                    //挨个推送机台的实时数据
                    ConcurrentDictionary<string,List<Param>> moduleStateTab;
                    curModuleStateDic.TryGetValue(machineId,out moduleStateTab);
                    foreach(var conenctionId in sameMachConnectionIds) {
                        //更新曲线参数
                        context.Clients.Client(conenctionId).
                            updateSensorData(
                             //数据
                             retData,
                            //当前米数
                            curMeters,
                            //该机台的错误表
                            moduleStateTab);

                        //更新机台属性
                        context.Clients.Client(conenctionId).updateMachinePty(pty);

                    }
                }
            }
        }

        /// <summary>
        /// 参数ID映射
        /// </summary>
        /// <param name="sensorData"></param>
        private void mapParamCode(SensorData sensorData) {
            try {
                foreach(var data in sensorData.CollectedData) {
                    var typeId = data.ParameterCodeID.Value;
                    int paramCodeId = 0;
                    paramCodeDic.TryGetValue(typeId,out paramCodeId);
                    data.ParameterCodeID = paramCodeId;
                }
            } catch(Exception e) {
                Debug.Write(e);
            }
        }
        /// <summary>
        /// 更新模块状态缓存
        /// </summary>
        /// <param name="sensorData">模块数据</param>
        private void updateCurModuleStateDic(SensorData sensorData) {
            ConcurrentDictionary<string,List<Param>> moduleDicCacheOk;
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            var fault = sensorData.Fault;
            //消除异常错误
            //将数据按机台分组
            //发来的数据是 机台 -----> 参数,而我的数据结构是 机台 ------->模块------>参数
            //所以要遍历多次
            var d = from s in sensorData.CollectedData group s by s.MachineID into t select t;
            try {
                //遍历机台
                foreach(var realParamList in d) {
                    //获取机台 Id
                    var machineId = realParamList.Key.Value;
                    //从缓存中找到机台
                    if(curModuleStateDic.TryGetValue(machineId,out moduleDicCacheOk)) {
                        //遍历实时参数
                        foreach(var realParam in realParamList) {
                            //遍历缓存模块
                            foreach(var module in moduleDicCacheOk) {
                                //遍历缓存参数
                                foreach(var param in module.Value) {
                                    //  realParam.ParameterCodeID = 2;
                                    //找到缓存中的参数对象
                                    if(param.ParamCodeID == realParam.ParameterCodeID.ToString()) {
                                        //参数正常，更新缓存值
                                        param.FaultValue = "1";
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                //添加异常错误
                ConcurrentDictionary<string,List<Param>> moduleDicCacheError;
                //有异常情况
                if(fault != null) {
                    var faultMachId = fault.MachineID;
                    //找该机台的出错到缓存
                    if(curModuleStateDic.TryGetValue(faultMachId.Value,out moduleDicCacheError)) {
                        //出错的模块
                        var faultSerialNum = fault.SerialNum;
                        List<Param> faultParamList;
                        //找到出错的模块
                        if(moduleDicCacheError.TryGetValue(faultSerialNum,out faultParamList)) {
                            var faultState = fault.State.Split('-');
                            //不满足出错格式则不做任何处理
                            if(faultState.Length != 3) {
                                log.Debug("更新错误缓存的错误状态值长度出错 " + faultState.Length);

                            } else {
                                //取出出错的状态码
                                var faultCode = faultState[1];
                                var faultValue = faultState[2];
                                //遍历模块下面的参数
                                foreach(var faultParam in faultParamList) {
                                    //找到出错的参数
                                    if(faultParam.ParamCode == faultCode) {
                                        //更新出错参数的错误值
                                        faultParam.FaultValue = faultValue;
                                        break;
                                    }
                                }
                                log.Debug("更新错误缓存中没有该参数 " + faultCode);

                            }
                        } else {
                            log.Debug("更新错误缓存中没有该模块 " + faultSerialNum);
                        }

                    } else {
                        log.Debug("更新错误缓存中没有该机台 " + faultMachId);
                    }
                }
            } catch(Exception e) {
                log.Error("更新错误状态失败",e);
            }


        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="machineId">机台ID</param>
        /// <param name="sensorData">传感器数据</param>
        /// <param name="curMeters">当前米数</param>
        /// <param name="curAxisNum">当前轴号</param>
        /// <param name="changeAxisNum">变动的轴号</param>
        private void updateDicCache(int machineId,SensorData sensorData,out string curMeters,out string curAxisNum,Action changeAxisNum) {
            //中心服务器发来的数据含有米数
            var updateMetersColData = (from d in sensorData.CollectedData where (d.MachineID == machineId && d.ParameterCodeID == (int)SPEC_PARAM_CODE.METERS_COUNT) select d).FirstOrDefault();
            if(updateMetersColData != null) {
                curMeters = updateMetersColData.CollectedValue;
                //更新米数缓存
                curMetersDic.AddOrUpdate(machineId,updateMetersColData.CollectedValue,
                    (key,oldValue) => {
                        //如果缓存中的米数大于接受到数据
                        //则认为数据没有清零，则进行做差运算
                        if(float.Parse(oldValue) > float.Parse(updateMetersColData.CollectedValue)) {
                            return (float.Parse(updateMetersColData.CollectedValue) - float.Parse(oldValue)).ToString();
                        }
                        return updateMetersColData.CollectedValue;
                    });
                //数据不含米数
            } else {
                //取出缓存数据
                if(!curMetersDic.TryGetValue(machineId,out curMeters)) {
                    //缓存中也没有数据
                    curMeters = "无数据";
                }
            }

            //实时数据含有轴号
            var updateAxisCode = (from s in sensorData.CodeUsing where s.MachineID == machineId select s).FirstOrDefault();
            if(updateAxisCode != null) {
                curAxisNum = updateAxisCode.Axis_No;
                //更新缓存
                curAxisNumDic.AddOrUpdate(machineId,curAxisNum,(key,oldValue) => {
                    if(oldValue != updateAxisCode.Axis_No) {
                        //TODO 落轴信号，提示web 清空数据
                        changeAxisNum();
                    }
                    return updateAxisCode.Axis_No;
                });
                //实时数据不含有轴号
            } else {
                if(!curAxisNumDic.TryGetValue(machineId,out curAxisNum)) {
                    curAxisNum = " 无数据";
                }
            }
        }
        #endregion

        #region 管理前端的连接
        public int GetClientsCount() {
            return clientsDic.Count;
        }

        public bool AddClient(int machineID,string connectionId) {
            var connectionIds = new List<string>();
            if(clientsDic.TryGetValue(machineID,out connectionIds)) {
                connectionIds.Add(connectionId);
                if(clientsDic.TryGetValue(machineID,out connectionIds)) {
                    return connectionIds.Contains(connectionId);
                }
            } else {
                connectionIds = new List<string>();
                connectionIds.Add(connectionId);
                return clientsDic.TryAdd(machineID,connectionIds);
            }
            return false;
        }

        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public bool RemoveClient(string connectionId) {
            var connectionIds = new List<string>();
            int machineID = 0;
            //找到该链接的机台
            foreach(var cs in clientsDic) {
                if(cs.Value.Contains(connectionId)) {
                    machineID = cs.Key;
                    break;
                }
            }
            if(clientsDic.TryGetValue(machineID,out connectionIds)) {
                connectionIds.Remove(connectionId);
                //如果该机台的所有连接都断开，从字典中删除
                if(connectionIds.Count <= 0) {
                    clientsDic.TryRemove(machineID,out connectionIds);
                }
                return true;
            }
            return false;
        }



        #endregion

        #region 管理与数据服务器的连接
        public void StartServerConnection() {
            Connection.StartConnection();
        }

        public void StopServerConnection() {
            Connection.StopConnection();
        }

        public bool IsClosed() {
            return Connection.IsClosed();

        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public void ClearCache() {
            //清空米数缓存
            curMetersDic.Clear();
            //清空轴号缓存
            curAxisNumDic.Clear();
            //清空状态缓存
            //  curModuleStateDic.Clear();
        }
        #endregion

    }
}