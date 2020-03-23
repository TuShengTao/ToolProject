using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class RepairController : ControllerBase
    {
        private RepairApp repairApp = new RepairApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = repairApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(RepairEntity repairEntity)
        {
            var data = repairApp.UpDate(repairEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(RepairEntity repairEntity)
        {
            var data = repairApp.Insert(repairEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(RepairEntity repairEntity)
        {
            var data = repairApp.Delete(repairEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = repairApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}