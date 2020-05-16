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
    public class BigDataController : ControllerBase
    {
        JunkedApp junkedApp = new JunkedApp();
        RepairApp repairApp = new RepairApp();
        BuyToWareHouseApp buyToWareHouseApp = new BuyToWareHouseApp();
        WareHouseFlowApp houseFlowApp = new WareHouseFlowApp();

        [HttpGet]
        // 工作台 代办事项的数据展示 如待办事项里的 带归还夹具的数量
        public ActionResult GetWorkBenchCounts()
        {
            var data = new
            {
                backCounts = houseFlowApp.GetListByUserId() ,
                junkedCounts = junkedApp.GetListByUserId(),
                repairCounts = repairApp.GetListByUserId(),
                buyToWhfCounts = buyToWareHouseApp.GetListByUserId()
            };
            return Content(data.ToJson());
        }


    }
}