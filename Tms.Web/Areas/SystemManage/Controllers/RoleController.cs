
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Tms.Web.Areas.SystemManage.Controllers
{
    public class RoleController : ControllerBase
    {
        private RoleApp roleApp = new RoleApp();
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        [HttpGet]
       // [HandlerAjaxOnly]
        public ActionResult GetGridJson()
        {

            var data = roleApp.GetList();

            return Content(data.ToJson());
        }
        [HttpGet]
        // [HandlerAjaxOnly]
        public ActionResult GetRoleList(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = roleApp.GetRoleList(pagination, keyword),
                total = pagination.total,  // 总页数
                page = pagination.page,  // 当前页
                records = pagination.records //  总行数
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = roleApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        //[HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
       
        public ActionResult SubmitForm(RoleEntity roleEntity,string permissionIds, string keyValue)
        {   
            
            //  F_Type 是角色类型 1系统角色 2是业务角色
            roleApp.SubmitForm(roleEntity, permissionIds.Split(','), keyValue);// 修改角色的权限
            return Success("操作成功。");
        }
        [HttpPost]
        //[HandlerAjaxOnly]
        //[HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            roleApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
