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

        [HttpGet]
        // 根据账号查用户 
        public ActionResult GetFormByCode(string code)
        {
            var count = entityApp.GetFormByCode(code);

            return Content(count.ToJson());
        }

        [HttpPost]
        public ActionResult Update(ToolEntity toolEntity)
        {
            var data = entityApp.UpDate(toolEntity);
            //return Content(data.ToJson());
            return Success("修改成功。");
        }

        [HttpPost]
        public ActionResult Insert(ToolEntity toolEntity)
        {
            toolEntity.T_Id = Common.GuId();
            toolEntity.T_RegDate = DateTime.Now;
            toolEntity.T_UsedCount = 0;
            var data = entityApp.Insert(toolEntity);
            //return Content(data.ToJson());
            return Success("操作成功。");
        }

        /**[HttpPost]
        public ActionResult Delete(ToolEntity toolEntity)
        {
            var data = entityApp.Delete(toolEntity);
            return Content(data.ToJson());
        }*/
        [HttpPost]
        // [HandlerAjaxOnly]
        //   [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ToolEntity toolEntity, string keyValue, string keyNumber, string keyCode, string keySeqId)
        {
            entityApp.SubmitForm(toolEntity, keyValue, keyNumber, keyCode, keySeqId);
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
            entityApp.DeleteForm(keyValue);
            return Success("该用户删除成功!");
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
                rows = entityApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}