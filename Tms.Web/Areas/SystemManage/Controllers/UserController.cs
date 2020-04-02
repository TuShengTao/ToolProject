
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Tms.Web.Areas.SystemManage.Controllers
{
    public class UserController : ControllerBase
    {
        private UserApp userApp = new UserApp();
        private UserLogOnApp userLogOnApp = new UserLogOnApp();

        [HttpGet]
       // [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            //
         var data = new
            {
                rows = userApp.GetList(pagination, keyword),
                total = pagination.total,  // 总页数
                page = pagination.page,  // 当前页
                records = pagination.records //  总行数
            };
            return Content(data.ToJson());
        }
        //查询所有用户
        [HttpGet]
        public ActionResult GetAllUser()
        {
            var data = userApp.GetAllList();

            return Content(data.ToJson());
        }

        [HttpGet]
        // 根据账号查用户 
        public ActionResult GetFormByAccount(string account)
        {
            var count = userApp.GetFormByAccount(account);
            
            return Content(count.ToJson());
        }
        [HttpGet]
        // 根据ID查密码 
        public ActionResult GetPasswordById(string Id)
        {
            var count = userLogOnApp.GetForm(Id);

            return Content(count.ToJson());
        }

        [HttpGet]
        // [HandlerAjaxOnly]
        public ActionResult GetGridJsonBySql(Pagination pagination, string keyword)
        {
            //
            var data = new
            {
                rows = userApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
       // [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = userApp.GetFormByAccount(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
       // [HandlerAjaxOnly]
     //   [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            userApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpGet]
        // 权限验证暂时关闭
        //[HandlerAuthorize]
       // [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            //  删除用户的时候 要去判断该用户有没有登录  登录了 不能进行删除 （还未实现）
            userApp.DeleteForm(keyValue);
            return Success("该用户删除成功!");
        }

        [HttpPost]

        public ActionResult BatchDeleteForm(List<string> keyValues)
        {
           
            userApp.BatchDeleteForm(keyValues);
            return Success("这些用户删除成功！");
        }
        [HttpGet]
        public ActionResult RevisePassword()
        {
            return View();
        }
        [HttpPost]
       // [HandlerAjaxOnly]
       //[HandlerAuthorize]
       // [ValidateAntiForgeryToken]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            userLogOnApp.RevisePassword(userPassword, keyValue);
            return Success("重置密码成功。");
        }
        [HttpPost]
       // [HandlerAjaxOnly]
      //  [HandlerAuthorize]
      //  [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = false;
            userApp.UpdateForm(userEntity);
            return Success("账户禁用成功。");
        }
        [HttpPost]
      //  [HandlerAjaxOnly]
       // [HandlerAuthorize]
       // [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = true;
            userApp.UpdateForm(userEntity);
            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
