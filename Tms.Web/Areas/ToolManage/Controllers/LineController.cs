using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 生产线controller
    public class LineController : ControllerBase
    {
        private ProductLinesApp lineApp = new ProductLinesApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = lineApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(ProductLineEntity lineEntity)
        {
            var data = lineApp.UpDate(lineEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(ProductLineEntity lineEntity)
        {
            var data = lineApp.Insert(lineEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(ProductLineEntity lineEntity)
        {
            var data = lineApp.Delete(lineEntity);
            return Success("删除成功！");
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = lineApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}