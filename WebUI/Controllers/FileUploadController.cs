using MesWeb.ViewModel.Promise;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class FileUploadController : BaseController
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase file) {
            log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName + ":" + MethodBase.GetCurrentMethod().Name);
            VM_Result_Data retData = new VM_Result_Data();
            retData.Code = RESULT_CODE.ERROR;
            retData.Content = "上传失败！";
            try {
                if(file != null && file.ContentLength > 0) {
                    var fileName = file.FileName;
                    var uploadPath = "/UploadFile/Images/";
                    var suffix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                    if("gif,jpg,jpeg,bmp,png".Contains(suffix)) {
                        var saveName = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + suffix;
                        var filePath = Path.Combine(Server.MapPath("~" + uploadPath),saveName);
                        file.SaveAs(filePath);
                        Image img = Image.FromFile(filePath);
                        retData.Code = RESULT_CODE.OK;
                        retData.Content = "上传成功！";
                        retData.Appendix = new { Url = uploadPath + saveName,PicWidth = img.Width,PicHeight = img.Height };
                    } else {
                        log.Error("上传的文件不是图片");
                        retData.Content = "这不是图片！";
                    }

                }
            } catch(Exception e) {
                log.Error("上图片传过程中发生意外错误",e);
                retData.Code = RESULT_CODE.ERROR;
                retData.Content = "意外错误！";
            }
            return Json(retData);
        }
    }
}