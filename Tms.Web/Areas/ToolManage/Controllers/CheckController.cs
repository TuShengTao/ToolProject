using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 生产线controller
    public class CheckController : ControllerBase
    {
        private CheckApp checkApp = new CheckApp();
        private CheckItemApp checkItemApp = new CheckItemApp();
        private CheckViewApp checkViewApp = new CheckViewApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = checkApp.GetList();
            return Content(data.ToJson());
        }
       //  根据夹具类型Id获取该夹具类型的点检项
        [HttpGet]
        public ActionResult GetCheckItems(string typeId)
        {
            var data = checkItemApp.GetListByTypeId(typeId);
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(CheckEntity checkEntity)
        {
            var data = checkApp.UpDate(checkEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(CheckEntity checkEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            checkEntity.T_CheckPerson = operatorProvider.UserId;
            checkEntity.T_DepartmentId = operatorProvider.DepartmentId;
            checkEntity.T_EditedPerson = operatorProvider.UserId;
            checkEntity.T_ThisCheckTime = DateTime.Now;
            checkEntity.T_CreateTime = checkEntity.T_ThisCheckTime;
            checkEntity.T_IsChecked = 1; // 已经点检过


            var data = checkApp.Insert(checkEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult Delete(CheckEntity checkEntity)
        {
            var data = checkApp.Delete(checkEntity);
            return Success("删除成功！");
        }
        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
         
            var data = new
            {
                rows = checkViewApp.GetList(pagination,keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}