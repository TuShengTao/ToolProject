using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class DefineController : ControllerBase
    {
        private DefineApp entityApp = new DefineApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = entityApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(DefineEntity defineEntity)
        {
            var data = entityApp.UpDate(defineEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(DefineEntity defineEntity)
        {
            var data = entityApp.Insert(defineEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(DefineEntity defineEntity)
        {
            var data = entityApp.Delete(defineEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = entityApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}