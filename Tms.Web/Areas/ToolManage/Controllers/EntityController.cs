using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具实体controller
    public class EntityController : ControllerBase
    {
        private EntityApp entityApp = new EntityApp();
   

        [HttpGet]
        public ActionResult Get()
        {
            var data = entityApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(ToolEntity toolEntity)
        {
            var data = entityApp.UpDate(toolEntity);
            return Content(data.ToJson());
        }

        [HttpPost]

        public ActionResult Insert(ToolEntity toolEntity)
        {
            toolEntity.T_Id = Common.GuId();
            toolEntity.T_RegDate = DateTime.Now;
            var data = entityApp.Insert(toolEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(ToolEntity toolEntity)
        {
            var data = entityApp.Delete(toolEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        // 批量删除
        public ActionResult BatchDeleteForm(List<string> keyValues)
        {

            entityApp.BatchDeleteForm(keyValues);
            return Success("这些用户删除成功！");
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = entityApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}