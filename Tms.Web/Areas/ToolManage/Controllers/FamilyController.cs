using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具所属大类定义controller
    public class FamilyController : ControllerBase
    {
        private FamilyApp familyApp = new FamilyApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = familyApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(FamilyEntity familyEntity)
        {
            var data = familyApp.UpDate(familyEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(FamilyEntity familyEntity)
        {
            var data = familyApp.Insert(familyEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(string keyValue)
        {
            var data = familyApp.Delete(keyValue);
            return Success("删除成功。");
        }
        [HttpGet]
        // 判断是否已存在此名称
        public ActionResult judgeByExit(string departmentId, string familyName)
        {
            var count = familyApp.GetFormByExit(departmentId, familyName);

            return Content(count.ToJson());
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword, string parentId)
        {
         
            var data = new
            {
                rows = familyApp.GetList(pagination,keyword,parentId),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}