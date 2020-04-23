using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Code;
namespace Tms.Web.Controllers
{
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public ActionResult UploadImg()
        {
            List<string> paths = new List<string>();

            //多张图片上传
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                var fileName = Guid.NewGuid().ToString("N") + "_" + file.FileName;
                var filePath = Server.MapPath("~/Content/TmsContent/TmsImage/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                paths.Add("/Content/TmsContent/TmsImage/" + fileName);
                file.SaveAs(Path.Combine(filePath, fileName));
            }
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "上传成功!" ,data = paths}.ToJson());
        }
    }

    
}