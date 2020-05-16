using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;

namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class TypeController : ControllerBase
    {
        private TypeApp typeApp = new TypeApp();
        //
        // GET: /ToolManage/Type/

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
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult Insert(TypeEntity typeEntity)
        {
            var data = typeApp.Insert(typeEntity);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            typeApp.DeleteForm(keyValue);
            return Success("夹具类型删除成功！");
        }

        [HttpGet]
        // 分页查询
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {

            var data = new
            {
                rows = typeApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        // 根据账号查用户 
        public ActionResult GetFormByType(string typeName)
        {
            var count = typeApp.GetFormByDefine(typeName);

            return Content(count.ToJson());
        }

    }
}
