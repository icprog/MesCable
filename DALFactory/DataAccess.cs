using System;
using System.Reflection;
using System.Configuration;
namespace MesWeb.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="MES.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess 
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];        
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);	
				return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
				return null;
			}			
			
        }
		//使用缓存
		private static object CreateObject(string AssemblyPath,string classNamespace)
		{			
			object objType = DataCache.GetCache(classNamespace);
			if (objType == null)
			{
				try
				{
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);					
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
				}
				catch(Exception e)//(System.Exception ex)
				{
                    Console.WriteLine(e);	//string str=ex.Message;// 记录错误日志
				}
			}
			return objType;
		}

      
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        public static MesWeb.IDAL.ISysManage CreateSysManage()
		{
			//方式1			
			//return (MesWeb.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

			//方式2 			
			string classNamespace = AssemblyPath+".SysManage";	
			object objType=CreateObject(AssemblyPath,classNamespace);
            return (MesWeb.IDAL.ISysManage)objType;		
		}
		#endregion
             
        
   
		/// <summary>
		/// 创建T_Application数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Application CreateT_Application()
		{

			string ClassNamespace = AssemblyPath +".T_Application";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Application)objType;
		}


		/// <summary>
		/// 创建T_ApplicationItem数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ApplicationItem CreateT_ApplicationItem()
		{

			string ClassNamespace = AssemblyPath +".T_ApplicationItem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ApplicationItem)objType;
		}


		/// <summary>
		/// 创建T_Authentic数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Authentic CreateT_Authentic()
		{

			string ClassNamespace = AssemblyPath +".T_Authentic";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Authentic)objType;
		}


		/// <summary>
		/// 创建T_AxisTask数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_AxisTask CreateT_AxisTask()
		{

			string ClassNamespace = AssemblyPath +".T_AxisTask";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_AxisTask)objType;
		}


		/// <summary>
		/// 创建T_CheckParsRef数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CheckParsRef CreateT_CheckParsRef()
		{

			string ClassNamespace = AssemblyPath +".T_CheckParsRef";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CheckParsRef)objType;
		}


		/// <summary>
		/// 创建T_CheckSheet数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CheckSheet CreateT_CheckSheet()
		{

			string ClassNamespace = AssemblyPath +".T_CheckSheet";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CheckSheet)objType;
		}


		/// <summary>
		/// 创建T_CheckType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CheckType CreateT_CheckType()
		{

			string ClassNamespace = AssemblyPath +".T_CheckType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CheckType)objType;
		}


		/// <summary>
		/// 创建T_Code数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Code CreateT_Code()
		{

			string ClassNamespace = AssemblyPath +".T_Code";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Code)objType;
		}


		/// <summary>
		/// 创建T_CodeRule数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CodeRule CreateT_CodeRule()
		{

			string ClassNamespace = AssemblyPath +".T_CodeRule";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CodeRule)objType;
		}


		/// <summary>
		/// 创建T_CodeType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CodeType CreateT_CodeType()
		{

			string ClassNamespace = AssemblyPath +".T_CodeType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CodeType)objType;
		}


		/// <summary>
		/// 创建T_CodeUsed数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CodeUsed CreateT_CodeUsed()
		{

			string ClassNamespace = AssemblyPath +".T_CodeUsed";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CodeUsed)objType;
		}


		/// <summary>
		/// 创建T_CollectedDataParameters数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CollectedDataParameters CreateT_CollectedDataParameters()
		{

			string ClassNamespace = AssemblyPath +".T_CollectedDataParameters";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CollectedDataParameters)objType;
		}


		/// <summary>
		/// 创建T_CollectedParameter数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CollectedParameter CreateT_CollectedParameter()
		{

			string ClassNamespace = AssemblyPath +".T_CollectedParameter";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CollectedParameter)objType;
		}


		/// <summary>
		/// 创建T_Company数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Company CreateT_Company()
		{

			string ClassNamespace = AssemblyPath +".T_Company";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Company)objType;
		}


		/// <summary>
		/// 创建T_CurrentData数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_CurrentData CreateT_CurrentData()
		{

			string ClassNamespace = AssemblyPath +".T_CurrentData";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_CurrentData)objType;
		}


		/// <summary>
		/// 创建T_Department数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Department CreateT_Department()
		{

			string ClassNamespace = AssemblyPath +".T_Department";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Department)objType;
		}


		/// <summary>
		/// 创建T_Dumpling数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Dumpling CreateT_Dumpling()
		{

			string ClassNamespace = AssemblyPath +".T_Dumpling";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Dumpling)objType;
		}


		/// <summary>
		/// 创建T_DumplingType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_DumplingType CreateT_DumplingType()
		{

			string ClassNamespace = AssemblyPath +".T_DumplingType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_DumplingType)objType;
		}


		/// <summary>
		/// 创建T_DumplingZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_DumplingZone CreateT_DumplingZone()
		{

			string ClassNamespace = AssemblyPath +".T_DumplingZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_DumplingZone)objType;
		}


		/// <summary>
		/// 创建T_Duty数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Duty CreateT_Duty()
		{

			string ClassNamespace = AssemblyPath +".T_Duty";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Duty)objType;
		}


		/// <summary>
		/// 创建T_ElectricityPrice数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ElectricityPrice CreateT_ElectricityPrice()
		{

			string ClassNamespace = AssemblyPath +".T_ElectricityPrice";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ElectricityPrice)objType;
		}


		/// <summary>
		/// 创建T_Employee数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Employee CreateT_Employee()
		{

			string ClassNamespace = AssemblyPath +".T_Employee";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Employee)objType;
		}


		/// <summary>
		/// 创建T_EmployeeArrangement数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_EmployeeArrangement CreateT_EmployeeArrangement()
		{

			string ClassNamespace = AssemblyPath +".T_EmployeeArrangement";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_EmployeeArrangement)objType;
		}


		/// <summary>
		/// 创建T_EmployeeState数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_EmployeeState CreateT_EmployeeState()
		{

			string ClassNamespace = AssemblyPath +".T_EmployeeState";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_EmployeeState)objType;
		}


		/// <summary>
		/// 创建T_Fault数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Fault CreateT_Fault()
		{

			string ClassNamespace = AssemblyPath +".T_Fault";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Fault)objType;
		}


		/// <summary>
		/// 创建T_Flow数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Flow CreateT_Flow()
		{

			string ClassNamespace = AssemblyPath +".T_Flow";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Flow)objType;
		}


		/// <summary>
		/// 创建T_Flow_Info数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Flow_Info CreateT_Flow_Info()
		{

			string ClassNamespace = AssemblyPath +".T_Flow_Info";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Flow_Info)objType;
		}


		/// <summary>
		/// 创建T_FlowRelation数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_FlowRelation CreateT_FlowRelation()
		{

			string ClassNamespace = AssemblyPath +".T_FlowRelation";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_FlowRelation)objType;
		}


		/// <summary>
		/// 创建T_Half_Product数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Half_Product CreateT_Half_Product()
		{

			string ClassNamespace = AssemblyPath +".T_Half_Product";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Half_Product)objType;
		}


		/// <summary>
		/// 创建T_Half_ProductZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Half_ProductZone CreateT_Half_ProductZone()
		{

			string ClassNamespace = AssemblyPath +".T_Half_ProductZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Half_ProductZone)objType;
		}


		/// <summary>
		/// 创建T_HumanEfficience数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_HumanEfficience CreateT_HumanEfficience()
		{

			string ClassNamespace = AssemblyPath +".T_HumanEfficience";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_HumanEfficience)objType;
		}


		/// <summary>
		/// 创建T_JobSheet数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_JobSheet CreateT_JobSheet()
		{

			string ClassNamespace = AssemblyPath +".T_JobSheet";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_JobSheet)objType;
		}


		/// <summary>
		/// 创建T_JobSheetItem数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_JobSheetItem CreateT_JobSheetItem()
		{

			string ClassNamespace = AssemblyPath +".T_JobSheetItem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_JobSheetItem)objType;
		}


		/// <summary>
		/// 创建T_JobSheetItemDetail数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_JobSheetItemDetail CreateT_JobSheetItemDetail()
		{

			string ClassNamespace = AssemblyPath +".T_JobSheetItemDetail";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_JobSheetItemDetail)objType;
		}


		/// <summary>
		/// 创建T_LeaveApplication数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_LeaveApplication CreateT_LeaveApplication()
		{

			string ClassNamespace = AssemblyPath +".T_LeaveApplication";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_LeaveApplication)objType;
		}


		/// <summary>
		/// 创建T_LeaveApplicationType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_LeaveApplicationType CreateT_LeaveApplicationType()
		{

			string ClassNamespace = AssemblyPath +".T_LeaveApplicationType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_LeaveApplicationType)objType;
		}


		/// <summary>
		/// 创建T_Log数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Log CreateT_Log()
		{

			string ClassNamespace = AssemblyPath +".T_Log";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Log)objType;
		}


		/// <summary>
		/// 创建T_LogDetail数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_LogDetail CreateT_LogDetail()
		{

			string ClassNamespace = AssemblyPath +".T_LogDetail";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_LogDetail)objType;
		}


		/// <summary>
		/// 创建T_LogType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_LogType CreateT_LogType()
		{

			string ClassNamespace = AssemblyPath +".T_LogType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_LogType)objType;
		}


		/// <summary>
		/// 创建T_Machine数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Machine CreateT_Machine()
		{

			string ClassNamespace = AssemblyPath +".T_Machine";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Machine)objType;
		}


		/// <summary>
		/// 创建T_MachineAblity数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineAblity CreateT_MachineAblity()
		{

			string ClassNamespace = AssemblyPath +".T_MachineAblity";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineAblity)objType;
		}


		/// <summary>
		/// 创建T_MachineEfficience数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineEfficience CreateT_MachineEfficience()
		{

			string ClassNamespace = AssemblyPath +".T_MachineEfficience";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineEfficience)objType;
		}


		/// <summary>
		/// 创建T_MachineMaintain数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineMaintain CreateT_MachineMaintain()
		{

			string ClassNamespace = AssemblyPath +".T_MachineMaintain";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineMaintain)objType;
		}


		/// <summary>
		/// 创建T_MachineMaintainPlan数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineMaintainPlan CreateT_MachineMaintainPlan()
		{

			string ClassNamespace = AssemblyPath +".T_MachineMaintainPlan";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineMaintainPlan)objType;
		}


		/// <summary>
		/// 创建T_MachineParameter数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineParameter CreateT_MachineParameter()
		{

			string ClassNamespace = AssemblyPath +".T_MachineParameter";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineParameter)objType;
		}


		/// <summary>
		/// 创建T_MachineState数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineState CreateT_MachineState()
		{

			string ClassNamespace = AssemblyPath +".T_MachineState";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineState)objType;
		}


		/// <summary>
		/// 创建T_MachineStateType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineStateType CreateT_MachineStateType()
		{

			string ClassNamespace = AssemblyPath +".T_MachineStateType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineStateType)objType;
		}


		/// <summary>
		/// 创建T_MachineType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineType CreateT_MachineType()
		{

			string ClassNamespace = AssemblyPath +".T_MachineType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineType)objType;
		}


		/// <summary>
		/// 创建T_MachineZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MachineZone CreateT_MachineZone()
		{

			string ClassNamespace = AssemblyPath +".T_MachineZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MachineZone)objType;
		}


		/// <summary>
		/// 创建T_Material数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Material CreateT_Material()
		{

			string ClassNamespace = AssemblyPath +".T_Material";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Material)objType;
		}


		/// <summary>
		/// 创建T_MaterialConsumption数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MaterialConsumption CreateT_MaterialConsumption()
		{

			string ClassNamespace = AssemblyPath +".T_MaterialConsumption";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MaterialConsumption)objType;
		}


		/// <summary>
		/// 创建T_MaterialOutput数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MaterialOutput CreateT_MaterialOutput()
		{

			string ClassNamespace = AssemblyPath +".T_MaterialOutput";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MaterialOutput)objType;
		}


		/// <summary>
		/// 创建T_MaterialType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MaterialType CreateT_MaterialType()
		{

			string ClassNamespace = AssemblyPath +".T_MaterialType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MaterialType)objType;
		}


		/// <summary>
		/// 创建T_MaterialUsed数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MaterialUsed CreateT_MaterialUsed()
		{

			string ClassNamespace = AssemblyPath +".T_MaterialUsed";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MaterialUsed)objType;
		}


		/// <summary>
		/// 创建T_MaterialZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MaterialZone CreateT_MaterialZone()
		{

			string ClassNamespace = AssemblyPath +".T_MaterialZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MaterialZone)objType;
		}


		/// <summary>
		/// 创建T_Menu数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Menu CreateT_Menu()
		{

			string ClassNamespace = AssemblyPath +".T_Menu";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Menu)objType;
		}


		/// <summary>
		/// 创建T_MergeAxis数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MergeAxis CreateT_MergeAxis()
		{

			string ClassNamespace = AssemblyPath +".T_MergeAxis";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MergeAxis)objType;
		}


		/// <summary>
		/// 创建T_MergeJobSheet数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MergeJobSheet CreateT_MergeJobSheet()
		{

			string ClassNamespace = AssemblyPath +".T_MergeJobSheet";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MergeJobSheet)objType;
		}


		/// <summary>
		/// 创建T_MergeJobSheetStatistic数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MergeJobSheetStatistic CreateT_MergeJobSheetStatistic()
		{

			string ClassNamespace = AssemblyPath +".T_MergeJobSheetStatistic";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MergeJobSheetStatistic)objType;
		}


		/// <summary>
		/// 创建T_ModelMaintain数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ModelMaintain CreateT_ModelMaintain()
		{

			string ClassNamespace = AssemblyPath +".T_ModelMaintain";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ModelMaintain)objType;
		}


		/// <summary>
		/// 创建T_Mould数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Mould CreateT_Mould()
		{

			string ClassNamespace = AssemblyPath +".T_Mould";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Mould)objType;
		}


		/// <summary>
		/// 创建T_MouldReturn数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MouldReturn CreateT_MouldReturn()
		{

			string ClassNamespace = AssemblyPath +".T_MouldReturn";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MouldReturn)objType;
		}


		/// <summary>
		/// 创建T_MouldType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MouldType CreateT_MouldType()
		{

			string ClassNamespace = AssemblyPath +".T_MouldType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MouldType)objType;
		}


		/// <summary>
		/// 创建T_MouldUsed数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MouldUsed CreateT_MouldUsed()
		{

			string ClassNamespace = AssemblyPath +".T_MouldUsed";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MouldUsed)objType;
		}


		/// <summary>
		/// 创建T_MouldZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_MouldZone CreateT_MouldZone()
		{

			string ClassNamespace = AssemblyPath +".T_MouldZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_MouldZone)objType;
		}


		/// <summary>
		/// 创建T_OEE数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_OEE CreateT_OEE()
		{

			string ClassNamespace = AssemblyPath +".T_OEE";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_OEE)objType;
		}


		/// <summary>
		/// 创建T_OpenMachineCondition数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_OpenMachineCondition CreateT_OpenMachineCondition()
		{

			string ClassNamespace = AssemblyPath +".T_OpenMachineCondition";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_OpenMachineCondition)objType;
		}


		/// <summary>
		/// 创建T_ParametersCol数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ParametersCol CreateT_ParametersCol()
		{

			string ClassNamespace = AssemblyPath +".T_ParametersCol";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ParametersCol)objType;
		}


		/// <summary>
		/// 创建T_ParametersRef数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ParametersRef CreateT_ParametersRef()
		{

			string ClassNamespace = AssemblyPath +".T_ParametersRef";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ParametersRef)objType;
		}


		/// <summary>
		/// 创建T_Port数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Port CreateT_Port()
		{

			string ClassNamespace = AssemblyPath +".T_Port";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Port)objType;
		}


		/// <summary>
		/// 创建T_ProdictAblity数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ProdictAblity CreateT_ProdictAblity()
		{

			string ClassNamespace = AssemblyPath +".T_ProdictAblity";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ProdictAblity)objType;
		}


		/// <summary>
		/// 创建T_ProdictMachine数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ProdictMachine CreateT_ProdictMachine()
		{

			string ClassNamespace = AssemblyPath +".T_ProdictMachine";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ProdictMachine)objType;
		}


		/// <summary>
		/// 创建T_Product数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Product CreateT_Product()
		{

			string ClassNamespace = AssemblyPath +".T_Product";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Product)objType;
		}


		/// <summary>
		/// 创建T_ProductZone数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ProductZone CreateT_ProductZone()
		{

			string ClassNamespace = AssemblyPath +".T_ProductZone";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ProductZone)objType;
		}


		/// <summary>
		/// 创建T_Protocol数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Protocol CreateT_Protocol()
		{

			string ClassNamespace = AssemblyPath +".T_Protocol";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Protocol)objType;
		}


		/// <summary>
		/// 创建T_QRCode数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_QRCode CreateT_QRCode()
		{

			string ClassNamespace = AssemblyPath +".T_QRCode";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_QRCode)objType;
		}


		/// <summary>
		/// 创建T_ReDoReson数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ReDoReson CreateT_ReDoReson()
		{

			string ClassNamespace = AssemblyPath +".T_ReDoReson";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ReDoReson)objType;
		}


		/// <summary>
		/// 创建T_ReDoSheet数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_ReDoSheet CreateT_ReDoSheet()
		{

			string ClassNamespace = AssemblyPath +".T_ReDoSheet";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_ReDoSheet)objType;
		}


		/// <summary>
		/// 创建T_Right数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Right CreateT_Right()
		{

			string ClassNamespace = AssemblyPath +".T_Right";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Right)objType;
		}


		/// <summary>
		/// 创建T_Salary数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Salary CreateT_Salary()
		{

			string ClassNamespace = AssemblyPath +".T_Salary";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Salary)objType;
		}


		/// <summary>
		/// 创建T_Specification数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Specification CreateT_Specification()
		{

			string ClassNamespace = AssemblyPath +".T_Specification";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Specification)objType;
		}


		/// <summary>
		/// 创建T_SpecificationType数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_SpecificationType CreateT_SpecificationType()
		{

			string ClassNamespace = AssemblyPath +".T_SpecificationType";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_SpecificationType)objType;
		}


		/// <summary>
		/// 创建T_Statistic数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Statistic CreateT_Statistic()
		{

			string ClassNamespace = AssemblyPath +".T_Statistic";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Statistic)objType;
		}


		/// <summary>
		/// 创建T_Task数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Task CreateT_Task()
		{

			string ClassNamespace = AssemblyPath +".T_Task";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Task)objType;
		}


		/// <summary>
		/// 创建T_TaskFinished数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_TaskFinished CreateT_TaskFinished()
		{

			string ClassNamespace = AssemblyPath +".T_TaskFinished";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_TaskFinished)objType;
		}


		/// <summary>
		/// 创建T_Technique数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Technique CreateT_Technique()
		{

			string ClassNamespace = AssemblyPath +".T_Technique";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_Technique)objType;
		}


		/// <summary>
		/// 创建T_User数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_User CreateT_User()
		{

			string ClassNamespace = AssemblyPath +".T_User";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (MesWeb.IDAL.IT_User)objType;
		}

        /// <summary>
        /// 创建Sys_App数据层接口。
        /// </summary>
        public static MesWeb.IDAL.ISys_App CreateSys_App() {

            string ClassNamespace = AssemblyPath + ".Sys_App";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.ISys_App)objType;
        }

        /// <summary>
        /// 创建Sys_Menu数据层接口。
        /// </summary>
        public static MesWeb.IDAL.ISys_Menu CreateSys_Menu() {

            string ClassNamespace = AssemblyPath + ".Sys_Menu";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.ISys_Menu)objType;
        }
        /// <summary>
        /// 创建T_SpotDist数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SpotDist CreateT_SpotDist() {

            string ClassNamespace = AssemblyPath + ".T_SpotDist";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SpotDist)objType;
        }


        /// <summary>
        /// 创建T_SpotDist_SpotInfo数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SpotDist_SpotInfo CreateT_SpotDist_SpotInfo() {

            string ClassNamespace = AssemblyPath + ".T_SpotDist_SpotInfo";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SpotDist_SpotInfo)objType;
        }


        /// <summary>
        /// 创建T_SpotInfo数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SpotInfo CreateT_SpotInfo() {

            string ClassNamespace = AssemblyPath + ".T_SpotInfo";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SpotInfo)objType;
        }



        /// <summary>
        /// 创建T_SpotDistType数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SpotDistType CreateT_SpotDistType() {

            string ClassNamespace = AssemblyPath + ".T_SpotDistType";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SpotDistType)objType;
        }

        /// <summary>
        /// 创建T_ParameterUnit数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_ParameterUnit CreateT_ParameterUnit() {

            string ClassNamespace = AssemblyPath + ".T_ParameterUnit";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_ParameterUnit)objType;
        }

        /// <summary>
        /// 创建T_LayoutPicture数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_LayoutPicture CreateT_LayoutPicture() {

            string ClassNamespace = AssemblyPath + ".T_LayoutPicture";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_LayoutPicture)objType;
        }


        /// <summary>
        /// 创建T_LayoutType数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_LayoutType CreateT_LayoutType() {

            string ClassNamespace = AssemblyPath + ".T_LayoutType";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_LayoutType)objType;
        }

        /// <summary>
        /// 创建T_TCP数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_TCP CreateT_TCP() {

            string ClassNamespace = AssemblyPath + ".T_TCP";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_TCP)objType;
        }

        /// <summary>
        /// 创建T_SensorModule数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SensorModule CreateT_SensorModule() {

            string ClassNamespace = AssemblyPath + ".T_SensorModule";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SensorModule)objType;
        }

        /// <summary>
        /// 创建T_SensorModule_T_ParameterCode数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_SensorModule_T_ParameterCode CreateT_SensorModule_T_ParameterCode() {

            string ClassNamespace = AssemblyPath + ".T_SensorModule_T_ParameterCode";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_SensorModule_T_ParameterCode)objType;
        }
        /// <summary>
        /// 创建T_ParameterCode数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_ParameterCode CreateT_ParameterCode() {

            string ClassNamespace = AssemblyPath + ".T_ParameterCode";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_ParameterCode)objType;
        }

        /// <summary>
        /// 创建T_MapMachineAddress数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_MapMachineAddress CreateT_MapMachineAddress() {

            string ClassNamespace = AssemblyPath + ".T_MapMachineAddress";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_MapMachineAddress)objType;
        }

        /// <summary>
        /// 创建T_ServerLog数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_ServerLog CreateT_ServerLog() {

            string ClassNamespace = AssemblyPath + ".T_ServerLog";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_ServerLog)objType;
        }
        /// <summary>
        /// 创建T_ServerLog数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_HistoryData CreateT_HistoryData() {

            string ClassNamespace = AssemblyPath + ".T_History";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_HistoryData)objType;
        }
 
        /// <summary>
        /// 创建T_FaultModule数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_FaultModule CreateT_FaultModule() {

            string ClassNamespace = AssemblyPath + ".T_FaultModule";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_FaultModule)objType;
        }
        /// <summary>
        /// 创建T_Axis数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Axis CreateT_Axis() {

            string ClassNamespace = AssemblyPath + ".T_Axis";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Axis)objType;
        }
        //}
        /// <summary>
        /// 创建T_CodeUsing数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_CodeUsing CreateT_CodeUsing() {

            string ClassNamespace = AssemblyPath + ".T_CodeUsing";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_CodeUsing)objType;
        }
        /// <summary>
        /// 创建T_PARCODE数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_PARCODE CreateT_PARCODE() {

            string ClassNamespace = AssemblyPath + ".T_PARCODE";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_PARCODE)objType;
        }
        /// <summary>
		/// 创建T_Employee_DeleteBak数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Employee_DeleteBak CreateT_Employee_DeleteBak() {

            string ClassNamespace = AssemblyPath + ".T_Employee_DeleteBak";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Employee_DeleteBak)objType;
        }
        /// <summary>
		/// 创建T_Report_Footer数据层接口。
		/// </summary>
		public static MesWeb.IDAL.IT_Report_Footer CreateT_Report_Footer() {

            string ClassNamespace = AssemblyPath + ".T_Report_Footer";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Footer)objType;
        }


        /// <summary>
        /// 创建T_Report_Header数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Header CreateT_Report_Header() {

            string ClassNamespace = AssemblyPath + ".T_Report_Header";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Header)objType;
        }


        /// <summary>
        /// 创建T_Report_Plastic数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Plastic CreateT_Report_Plastic() {

            string ClassNamespace = AssemblyPath + ".T_Report_Plastic";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Plastic)objType;
        }


        /// <summary>
        /// 创建T_Report_Product数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Product CreateT_Report_Product() {

            string ClassNamespace = AssemblyPath + ".T_Report_Product";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Product)objType;
        }


        /// <summary>
        /// 创建T_Report_Product_Actual数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Product_Actual CreateT_Report_Product_Actual() {

            string ClassNamespace = AssemblyPath + ".T_Report_Product_Actual";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Product_Actual)objType;
        }


        /// <summary>
        /// 创建T_Report_Product_Standard数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Product_Standard CreateT_Report_Product_Standard() {

            string ClassNamespace = AssemblyPath + ".T_Report_Product_Standard";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Product_Standard)objType;
        }


        /// <summary>
        /// 创建T_Report_Value数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_Report_Value CreateT_Report_Value() {

            string ClassNamespace = AssemblyPath + ".T_Report_Value";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_Report_Value)objType;
        }

        /// <summary>
        /// 创建T_AllReport数据层接口。
        /// </summary>
        public static MesWeb.IDAL.IT_AllReport CreateT_AllReport() {

            string ClassNamespace = AssemblyPath + ".T_AllReport";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (MesWeb.IDAL.IT_AllReport)objType;
        }


    }
}