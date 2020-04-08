
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Tms.Web.Areas.SystemManage.Controllers
{
    public class DutyController : ControllerBase
    {
        private DutyApp dutyApp = new DutyApp();

        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = dutyApp.GetList(keyword);
            return Content(data.ToJson());
        }
        //分页查询
        [HttpGet]
        // [HandlerAjaxOnly]
        public ActionResult GetGridListJson(Pagination pagination, string keyword)
        {
            //
            var data = new
            {
                rows = dutyApp.GetLists(pagination, keyword),
                total = pagination.total,  // 总页数
                page = pagination.page,  // 当前页
                records = pagination.records //  总行数
            };
            return Content(data.ToJson());
        }

        // 判断父节点下是否已存在此名称
        public ActionResult GetFormByParent(string full_name, string parentId)
        {
            var count = dutyApp.GetFormByParent(full_name, parentId);

            return Content(count.ToJson());
        }
        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = dutyApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        //[HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            dutyApp.SubmitForm(roleEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpGet]
        //[HandlerAjaxOnly]
        //[HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            dutyApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        //批量删除
        [HttpPost]
        public ActionResult BatchDeleteForm(List<string> keyValues)
        {

            dutyApp.BatchDeleteForm(keyValues);
            return Success("这些用户删除成功！");
        }
    }
}
