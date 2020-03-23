using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具报废controller
    public class JunkedController : ControllerBase
    {
        private JunkedApp junkedApp = new JunkedApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = junkedApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(JunkedEntity junkedEntity)
        {
            var data = junkedApp.UpDate(junkedEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(JunkedEntity junkedEntity)
        {
            var data = junkedApp.Insert(junkedEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(JunkedEntity junkedEntity)
        {
            var data = junkedApp.Delete(junkedEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = junkedApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}