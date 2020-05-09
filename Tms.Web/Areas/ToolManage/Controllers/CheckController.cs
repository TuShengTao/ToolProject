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
    public class CheckController : ControllerBase
    {
        private CheckApp checkApp = new CheckApp();
        private CheckViewApp checkViewApp = new CheckViewApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = checkApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(CheckEntity checkEntity)
        {
            var data = checkApp.UpDate(checkEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(CheckEntity checkEntity)
        {
            var data = checkApp.Insert(checkEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(CheckEntity checkEntity)
        {
            var data = checkApp.Delete(checkEntity);
            return Success("删除成功！");
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = checkViewApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}