using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 类型controller
    public class TypeController : ControllerBase
    {
        private TypeApp typeApp = new TypeApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = typeApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(TypeEntity typeEntity)
        {
            var data = typeApp.UpDate(typeEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(TypeEntity typeEntity)
        {
            // 要补全 T_Id 
            var data = typeApp.Insert(typeEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(TypeEntity typeEntity)
        {
            var data = typeApp.Delete(typeEntity);
            return Success("删除成功！");
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = typeApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}