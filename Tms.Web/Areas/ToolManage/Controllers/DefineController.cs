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
        [HttpPost]
        public ActionResult Update(DefineEntity defineEntity)
        {
            defineEntity.T_EditedTime = DateTime.Now;
            var data = defineApp.UpDate(defineEntity);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult Insert(DefineEntity defineEntity)
        {
            defineEntity.T_CreatorTime = DateTime.Now;
            var data = defineApp.Insert(defineEntity);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DeleteForm(int keyValue)
        {
            defineApp.DeleteForm(keyValue);
            return Success("夹具定义删除成功！");
        }
        [HttpPost]
        // 批量删除
        public ActionResult BatchDeleteForm(List<int> keyValues)
        {
            defineApp.BatchDeleteForm(keyValues);
            return Success("这些夹具定义删除成功！");
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
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        // 根据账号查用户 
        public ActionResult GetFormByDefine(string code)
        {
            var count = defineApp.GetFormByDefine(code);

            return Content(count.ToJson());
        }

     

    }
}