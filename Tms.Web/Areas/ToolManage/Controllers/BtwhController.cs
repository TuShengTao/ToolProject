using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 采购新增入库controller,BuyToWareHouse
    public class BtwhController : ControllerBase
    {
        private BuyToWareHouseApp btwhApp = new BuyToWareHouseApp();
        private BtwhViewApp btwhViewApp = new BtwhViewApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = btwhApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(BuyToWareHouseEntity btwhEntity)
        {
            var data = btwhApp.UpDate(btwhEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(BuyToWareHouseEntity btwhEntity)
        {
            var data = btwhApp.Insert(btwhEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(BuyToWareHouseEntity btwhEntity)
        {
            var data = btwhApp.Delete(btwhEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
       public ActionResult GetGridJson(Pagination pagination, string keyword,int searchFlag)
        {
         
            var data = new
            {
                rows = btwhViewApp.GetList(pagination,keyword, searchFlag),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

    }
}