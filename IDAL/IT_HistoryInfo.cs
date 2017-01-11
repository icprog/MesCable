using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CodematicDemo.IDAL {
    public interface IT_HistoryInfo {
        MesWeb.Model.T_HisData GetModel(int CollectedDataParametersID);
        MesWeb.Model.T_HisData DataRowToModel(DataRow row);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top,string strWhere,string filedOrder);
    }

}