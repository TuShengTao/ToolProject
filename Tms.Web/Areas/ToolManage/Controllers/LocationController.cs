using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具库位管理定义controller
    public class LocationController : ControllerBase
    {
        private LocationApp locationApp = new LocationApp();
        //  // 获取所有 根据 typeId
        [HttpGet]
        public ActionResult GetListByTypeId(string typeId)
        {
            var data = locationApp.GetListByTpye(typeId);
            return Content(data.ToJson());
        }
        //  // 获取所有 根据 typeId
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = locationApp.GetAll();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(LocationEntity locationEntity)
        {
            var data = locationApp.UpDate(locationEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult getByPAndT(LocationEntity locationEntity)
        {
            var data = locationApp.getByPAndT(locationEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(LocationEntity locationEntity)
        {
            var data = locationApp.Insert(locationEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(string keyValue)
        {
            var data = locationApp.Delete(keyValue);
            return Success("删除成功。");
        }
        [HttpGet]
        // 判断是否已存在此名称
        public ActionResult judgeByExit(string departmentId, string locationName)
        {
            var count = locationApp.GetFormByExit(departmentId, locationName);

            return Content(count.ToJson());
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword, string parentId,string typeId)
        {
         
            var data = new
            {
                rows = locationApp.GetList(pagination,keyword,parentId, typeId),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}