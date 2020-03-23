using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具领用controller
    public class WhfController : ControllerBase
    {
        private WareHouseFlowApp whfApp = new WareHouseFlowApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = whfApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(WareHouseFlowEntity whfEntity)
        {
            var data = whfApp.UpDate(whfEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(WareHouseFlowEntity whfEntity)
        {
            var data = whfApp.Insert(whfEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(WareHouseFlowEntity whfEntity)
        {
            var data = whfApp.Delete(whfEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = whfApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}