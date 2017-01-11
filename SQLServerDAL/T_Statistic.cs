using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using MesWeb.IDAL;
using MES.DBUtility;//Please add references
namespace MesWeb.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:T_Statistic
	/// </summary>
	public partial class T_Statistic:IT_Statistic
	{
		public T_Statistic()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(StatisticID)+1 from T_Statistic";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Statistic_Exists");
			db.AddInParameter(dbCommand, "StatisticID", DbType.Int32,StatisticID);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(MesWeb.Model.T_Statistic model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Statistic_ADD");
			db.AddOutParameter(dbCommand, "StatisticID", DbType.Int32, 4);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int32, model.TaskID);
			db.AddInParameter(dbCommand, "MachineType", DbType.Int32, model.MachineType);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "RunTime", DbType.Int32, model.RunTime);
			db.AddInParameter(dbCommand, "DownTime", DbType.Int32, model.DownTime);
			db.AddInParameter(dbCommand, "Velocity", DbType.Int32, model.Velocity);
			db.AddInParameter(dbCommand, "PPM", DbType.Double, model.PPM);
			db.AddInParameter(dbCommand, "PR", DbType.Double, model.PR);
			db.AddInParameter(dbCommand, "ORV", DbType.Double, model.ORV);
			db.AddInParameter(dbCommand, "QR", DbType.Double, model.QR);
			db.AddInParameter(dbCommand, "OEE", DbType.Double, model.OEE);
			db.AddInParameter(dbCommand, "ODEX", DbType.Double, model.ODEX);
			db.AddInParameter(dbCommand, "ODDX", DbType.Double, model.ODDX);
			db.AddInParameter(dbCommand, "ODkurts", DbType.Double, model.ODkurts);
			db.AddInParameter(dbCommand, "ODMax", DbType.Double, model.ODMax);
			db.AddInParameter(dbCommand, "ODMin", DbType.Double, model.ODMin);
			db.AddInParameter(dbCommand, "StressEX", DbType.Double, model.StressEX);
			db.AddInParameter(dbCommand, "StressDX", DbType.Double, model.StressDX);
			db.AddInParameter(dbCommand, "Stresskurts", DbType.Double, model.Stresskurts);
			db.AddInParameter(dbCommand, "StressMax", DbType.Double, model.StressMax);
			db.AddInParameter(dbCommand, "StressMin", DbType.Double, model.StressMin);
			db.AddInParameter(dbCommand, "SpeedEX", DbType.Double, model.SpeedEX);
			db.AddInParameter(dbCommand, "SpeeDX", DbType.Double, model.SpeeDX);
			db.AddInParameter(dbCommand, "Speekurts", DbType.Double, model.Speekurts);
			db.AddInParameter(dbCommand, "SpeeMax", DbType.Double, model.SpeeMax);
			db.AddInParameter(dbCommand, "SpeeMin", DbType.Double, model.SpeeMin);
			db.AddInParameter(dbCommand, "UnitPower", DbType.Double, model.UnitPower);
			db.AddInParameter(dbCommand, "UnitProduct", DbType.Double, model.UnitProduct);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.ExecuteNonQuery(dbCommand);
			return (int)db.GetParameterValue(dbCommand, "StatisticID");
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(MesWeb.Model.T_Statistic model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Statistic_Update");
			db.AddInParameter(dbCommand, "StatisticID", DbType.Int32, model.StatisticID);
			db.AddInParameter(dbCommand, "TaskID", DbType.Int32, model.TaskID);
			db.AddInParameter(dbCommand, "MachineType", DbType.Int32, model.MachineType);
			db.AddInParameter(dbCommand, "SpecificationID", DbType.Int32, model.SpecificationID);
			db.AddInParameter(dbCommand, "JobSheetID", DbType.Int32, model.JobSheetID);
			db.AddInParameter(dbCommand, "MachineID", DbType.Int32, model.MachineID);
			db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, model.EmployeeID);
			db.AddInParameter(dbCommand, "RunTime", DbType.Int32, model.RunTime);
			db.AddInParameter(dbCommand, "DownTime", DbType.Int32, model.DownTime);
			db.AddInParameter(dbCommand, "Velocity", DbType.Int32, model.Velocity);
			db.AddInParameter(dbCommand, "PPM", DbType.Double, model.PPM);
			db.AddInParameter(dbCommand, "PR", DbType.Double, model.PR);
			db.AddInParameter(dbCommand, "ORV", DbType.Double, model.ORV);
			db.AddInParameter(dbCommand, "QR", DbType.Double, model.QR);
			db.AddInParameter(dbCommand, "OEE", DbType.Double, model.OEE);
			db.AddInParameter(dbCommand, "ODEX", DbType.Double, model.ODEX);
			db.AddInParameter(dbCommand, "ODDX", DbType.Double, model.ODDX);
			db.AddInParameter(dbCommand, "ODkurts", DbType.Double, model.ODkurts);
			db.AddInParameter(dbCommand, "ODMax", DbType.Double, model.ODMax);
			db.AddInParameter(dbCommand, "ODMin", DbType.Double, model.ODMin);
			db.AddInParameter(dbCommand, "StressEX", DbType.Double, model.StressEX);
			db.AddInParameter(dbCommand, "StressDX", DbType.Double, model.StressDX);
			db.AddInParameter(dbCommand, "Stresskurts", DbType.Double, model.Stresskurts);
			db.AddInParameter(dbCommand, "StressMax", DbType.Double, model.StressMax);
			db.AddInParameter(dbCommand, "StressMin", DbType.Double, model.StressMin);
			db.AddInParameter(dbCommand, "SpeedEX", DbType.Double, model.SpeedEX);
			db.AddInParameter(dbCommand, "SpeeDX", DbType.Double, model.SpeeDX);
			db.AddInParameter(dbCommand, "Speekurts", DbType.Double, model.Speekurts);
			db.AddInParameter(dbCommand, "SpeeMax", DbType.Double, model.SpeeMax);
			db.AddInParameter(dbCommand, "SpeeMin", DbType.Double, model.SpeeMin);
			db.AddInParameter(dbCommand, "UnitPower", DbType.Double, model.UnitPower);
			db.AddInParameter(dbCommand, "UnitProduct", DbType.Double, model.UnitProduct);
			db.AddInParameter(dbCommand, "Axis_No", DbType.String, model.Axis_No);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Statistic_Delete");
			db.AddInParameter(dbCommand, "StatisticID", DbType.Int32,StatisticID);

			int rows=db.ExecuteNonQuery(dbCommand);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StatisticIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Statistic ");
			strSql.Append(" where StatisticID in ("+StatisticIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_Statistic GetModel(int StatisticID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("T_Statistic_GetModel");
			db.AddInParameter(dbCommand, "StatisticID", DbType.Int32,StatisticID);

			MesWeb.Model.T_Statistic model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MesWeb.Model.T_Statistic DataRowToModel(DataRow row)
		{
			MesWeb.Model.T_Statistic model=new MesWeb.Model.T_Statistic();
			if (row != null)
			{
				if(row["StatisticID"]!=null && row["StatisticID"].ToString()!="")
				{
					model.StatisticID=int.Parse(row["StatisticID"].ToString());
				}
				if(row["TaskID"]!=null && row["TaskID"].ToString()!="")
				{
					model.TaskID=int.Parse(row["TaskID"].ToString());
				}
				if(row["MachineType"]!=null && row["MachineType"].ToString()!="")
				{
					model.MachineType=int.Parse(row["MachineType"].ToString());
				}
				if(row["SpecificationID"]!=null && row["SpecificationID"].ToString()!="")
				{
					model.SpecificationID=int.Parse(row["SpecificationID"].ToString());
				}
				if(row["JobSheetID"]!=null && row["JobSheetID"].ToString()!="")
				{
					model.JobSheetID=int.Parse(row["JobSheetID"].ToString());
				}
				if(row["MachineID"]!=null && row["MachineID"].ToString()!="")
				{
					model.MachineID=int.Parse(row["MachineID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["RunTime"]!=null && row["RunTime"].ToString()!="")
				{
					model.RunTime=int.Parse(row["RunTime"].ToString());
				}
				if(row["DownTime"]!=null && row["DownTime"].ToString()!="")
				{
					model.DownTime=int.Parse(row["DownTime"].ToString());
				}
				if(row["Velocity"]!=null && row["Velocity"].ToString()!="")
				{
					model.Velocity=int.Parse(row["Velocity"].ToString());
				}
				if(row["PPM"]!=null && row["PPM"].ToString()!="")
				{
					model.PPM=decimal.Parse(row["PPM"].ToString());
				}
				if(row["PR"]!=null && row["PR"].ToString()!="")
				{
					model.PR=decimal.Parse(row["PR"].ToString());
				}
				if(row["ORV"]!=null && row["ORV"].ToString()!="")
				{
					model.ORV=decimal.Parse(row["ORV"].ToString());
				}
				if(row["QR"]!=null && row["QR"].ToString()!="")
				{
					model.QR=decimal.Parse(row["QR"].ToString());
				}
				if(row["OEE"]!=null && row["OEE"].ToString()!="")
				{
					model.OEE=decimal.Parse(row["OEE"].ToString());
				}
				if(row["ODEX"]!=null && row["ODEX"].ToString()!="")
				{
					model.ODEX=decimal.Parse(row["ODEX"].ToString());
				}
				if(row["ODDX"]!=null && row["ODDX"].ToString()!="")
				{
					model.ODDX=decimal.Parse(row["ODDX"].ToString());
				}
				if(row["ODkurts"]!=null && row["ODkurts"].ToString()!="")
				{
					model.ODkurts=decimal.Parse(row["ODkurts"].ToString());
				}
				if(row["ODMax"]!=null && row["ODMax"].ToString()!="")
				{
					model.ODMax=decimal.Parse(row["ODMax"].ToString());
				}
				if(row["ODMin"]!=null && row["ODMin"].ToString()!="")
				{
					model.ODMin=decimal.Parse(row["ODMin"].ToString());
				}
				if(row["StressEX"]!=null && row["StressEX"].ToString()!="")
				{
					model.StressEX=decimal.Parse(row["StressEX"].ToString());
				}
				if(row["StressDX"]!=null && row["StressDX"].ToString()!="")
				{
					model.StressDX=decimal.Parse(row["StressDX"].ToString());
				}
				if(row["Stresskurts"]!=null && row["Stresskurts"].ToString()!="")
				{
					model.Stresskurts=decimal.Parse(row["Stresskurts"].ToString());
				}
				if(row["StressMax"]!=null && row["StressMax"].ToString()!="")
				{
					model.StressMax=decimal.Parse(row["StressMax"].ToString());
				}
				if(row["StressMin"]!=null && row["StressMin"].ToString()!="")
				{
					model.StressMin=decimal.Parse(row["StressMin"].ToString());
				}
				if(row["SpeedEX"]!=null && row["SpeedEX"].ToString()!="")
				{
					model.SpeedEX=decimal.Parse(row["SpeedEX"].ToString());
				}
				if(row["SpeeDX"]!=null && row["SpeeDX"].ToString()!="")
				{
					model.SpeeDX=decimal.Parse(row["SpeeDX"].ToString());
				}
				if(row["Speekurts"]!=null && row["Speekurts"].ToString()!="")
				{
					model.Speekurts=decimal.Parse(row["Speekurts"].ToString());
				}
				if(row["SpeeMax"]!=null && row["SpeeMax"].ToString()!="")
				{
					model.SpeeMax=decimal.Parse(row["SpeeMax"].ToString());
				}
				if(row["SpeeMin"]!=null && row["SpeeMin"].ToString()!="")
				{
					model.SpeeMin=decimal.Parse(row["SpeeMin"].ToString());
				}
				if(row["UnitPower"]!=null && row["UnitPower"].ToString()!="")
				{
					model.UnitPower=decimal.Parse(row["UnitPower"].ToString());
				}
				if(row["UnitProduct"]!=null && row["UnitProduct"].ToString()!="")
				{
					model.UnitProduct=decimal.Parse(row["UnitProduct"].ToString());
				}
				if(row["Axis_No"]!=null)
				{
					model.Axis_No=row["Axis_No"].ToString();
				}
				if(row["Datetime"]!=null && row["Datetime"].ToString()!="")
				{
					model.Datetime=DateTime.Parse(row["Datetime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StatisticID,TaskID,MachineType,SpecificationID,JobSheetID,MachineID,EmployeeID,RunTime,DownTime,Velocity,PPM,PR,ORV,QR,OEE,ODEX,ODDX,ODkurts,ODMax,ODMin,StressEX,StressDX,Stresskurts,StressMax,StressMin,SpeedEX,SpeeDX,Speekurts,SpeeMax,SpeeMin,UnitPower,UnitProduct,Axis_No,Datetime ");
			strSql.Append(" FROM T_Statistic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StatisticID,TaskID,MachineType,SpecificationID,JobSheetID,MachineID,EmployeeID,RunTime,DownTime,Velocity,PPM,PR,ORV,QR,OEE,ODEX,ODDX,ODkurts,ODMax,ODMin,StressEX,StressDX,Stresskurts,StressMax,StressMin,SpeedEX,SpeeDX,Speekurts,SpeeMax,SpeeMin,UnitPower,UnitProduct,Axis_No,Datetime ");
			strSql.Append(" FROM T_Statistic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Statistic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StatisticID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Statistic T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "T_Statistic");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "StatisticID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<MesWeb.Model.T_Statistic> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StatisticID,TaskID,MachineType,SpecificationID,JobSheetID,MachineID,EmployeeID,RunTime,DownTime,Velocity,PPM,PR,ORV,QR,OEE,ODEX,ODDX,ODkurts,ODMax,ODMin,StressEX,StressDX,Stresskurts,StressMax,StressMin,SpeedEX,SpeeDX,Speekurts,SpeeMax,SpeeMin,UnitPower,UnitProduct,Axis_No,Datetime ");
			strSql.Append(" FROM T_Statistic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<MesWeb.Model.T_Statistic> list = new List<MesWeb.Model.T_Statistic>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public MesWeb.Model.T_Statistic ReaderBind(IDataReader dataReader)
		{
			MesWeb.Model.T_Statistic model=new MesWeb.Model.T_Statistic();
			object ojb; 
			ojb = dataReader["StatisticID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StatisticID=(int)ojb;
			}
			ojb = dataReader["TaskID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaskID=(int)ojb;
			}
			ojb = dataReader["MachineType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineType=(int)ojb;
			}
			ojb = dataReader["SpecificationID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpecificationID=(int)ojb;
			}
			ojb = dataReader["JobSheetID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.JobSheetID=(int)ojb;
			}
			ojb = dataReader["MachineID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MachineID=(int)ojb;
			}
			ojb = dataReader["EmployeeID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmployeeID=(int)ojb;
			}
			ojb = dataReader["RunTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RunTime=(int)ojb;
			}
			ojb = dataReader["DownTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DownTime=(int)ojb;
			}
			ojb = dataReader["Velocity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Velocity=(int)ojb;
			}
			ojb = dataReader["PPM"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PPM=(decimal)ojb;
			}
			ojb = dataReader["PR"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PR=(decimal)ojb;
			}
			ojb = dataReader["ORV"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ORV=(decimal)ojb;
			}
			ojb = dataReader["QR"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QR=(decimal)ojb;
			}
			ojb = dataReader["OEE"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OEE=(decimal)ojb;
			}
			ojb = dataReader["ODEX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ODEX=(decimal)ojb;
			}
			ojb = dataReader["ODDX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ODDX=(decimal)ojb;
			}
			ojb = dataReader["ODkurts"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ODkurts=(decimal)ojb;
			}
			ojb = dataReader["ODMax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ODMax=(decimal)ojb;
			}
			ojb = dataReader["ODMin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ODMin=(decimal)ojb;
			}
			ojb = dataReader["StressEX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StressEX=(decimal)ojb;
			}
			ojb = dataReader["StressDX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StressDX=(decimal)ojb;
			}
			ojb = dataReader["Stresskurts"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Stresskurts=(decimal)ojb;
			}
			ojb = dataReader["StressMax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StressMax=(decimal)ojb;
			}
			ojb = dataReader["StressMin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StressMin=(decimal)ojb;
			}
			ojb = dataReader["SpeedEX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpeedEX=(decimal)ojb;
			}
			ojb = dataReader["SpeeDX"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpeeDX=(decimal)ojb;
			}
			ojb = dataReader["Speekurts"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Speekurts=(decimal)ojb;
			}
			ojb = dataReader["SpeeMax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpeeMax=(decimal)ojb;
			}
			ojb = dataReader["SpeeMin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SpeeMin=(decimal)ojb;
			}
			ojb = dataReader["UnitPower"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UnitPower=(decimal)ojb;
			}
			ojb = dataReader["UnitProduct"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UnitProduct=(decimal)ojb;
			}
			model.Axis_No=dataReader["Axis_No"].ToString();
			ojb = dataReader["Datetime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Datetime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

