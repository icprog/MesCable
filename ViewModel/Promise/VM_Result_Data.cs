using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesWeb.ViewModel.Promise {


    public enum RESULT_CODE {
        OK,
        ERROR
    }

    public interface IResultData {
         RESULT_CODE Code { get; set; }
         object Content { get; set; }
         dynamic Appendix { get; set; }
    }

    public class VM_Result_Data:IResultData {
        private RESULT_CODE code = RESULT_CODE.ERROR;
        public RESULT_CODE Code { get { return code; } set { code = value; } }
        private object content = "加载失败！";
        public object Content { get { return content; } set { content = value; } }
        public dynamic Appendix { get; set; }
    }

    public class VM_Rsult_Callback:IResultData {
        private RESULT_CODE code = RESULT_CODE.ERROR;
        public RESULT_CODE Code { get { return code; } set { code = value; } }
        private object content = "加载成功！";
        public object Content { get { return content; } set { content = value; } }
        public object Appendix { get; set; }
        public JRaw Function { get; set; }
    }
}
