using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class EntityController : ControllerBase
    {
        private EntityApp entityApp = new EntityApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = entityApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(ToolEntity toolEntity)
        {
            var data = entityApp.UpDate(toolEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(ToolEntity toolEntity)
        {
            var data = entityApp.Insert(toolEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(ToolEntity toolEntity)
        {
            var data = entityApp.Delete(toolEntity);
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