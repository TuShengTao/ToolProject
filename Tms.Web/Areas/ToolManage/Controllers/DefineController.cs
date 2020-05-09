using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;


namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具定义controller
    public class DefineController : ControllerBase
    {
        private DefineApp defineApp = new DefineApp();



        [HttpGet]
        public ActionResult Get()
        {
            var data = defineApp.GetList();
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult getFormByCode(string code)
        {
            var data = defineApp.getFormByCode(code);
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(DefineEntity defineEntity)
        {
            var data = defineApp.UpDate(defineEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(DefineEntity defineEntity)
        {
            var data = defineApp.Insert(defineEntity);
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult InsertList(List<DefineEntity> defineEntity)
        {
            var data = defineApp.InsertList(defineEntity);
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Delete(DefineEntity defineEntity)
        {
            var data = defineApp.Delete(defineEntity);
            return Content(data.ToJson());
        }
        [HttpPost]
        // 批量删除
        public ActionResult BatchDeleteForm(List<int> keyValues)
        {
            defineApp.BatchDeleteForm(keyValues);
            return Success("这些用户删除成功！");
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {

           
            var data = new
            {
                rows = defineApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            
            };
            return Content(data.ToJson());
        }


    }
}