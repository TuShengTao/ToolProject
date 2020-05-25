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
        private EntityApp entityApp = new EntityApp();

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
        // 在点检界面 定时点检类型 需要修改点检状态 
        public ActionResult Update(CheckEntity updateCheckEntity)
        {
            updateCheckEntity.T_ThisCheckTime = DateTime.Now;
            updateCheckEntity.T_IsChecked = 1; // 已经点检过

            ToolEntity toolEntity = new ToolEntity();
            toolEntity.T_Id = updateCheckEntity.T_Id;
            toolEntity.T_LastCheckTime = updateCheckEntity.T_ThisCheckTime;
            entityApp.UpDate(toolEntity);  //修改夹具实体里的 上次点检时间
            //定时点检完毕 以后 需要修改 实体表最后的点检时间
            var data = checkApp.UpDate(updateCheckEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(CheckEntity checkEntity)
        {

            // 如果是入库和出库点检   //夹具预警界面 点检
            if (checkEntity.T_CheckType == 1 || checkEntity.T_CheckType == 2 || checkEntity.T_CheckType == 3 || checkEntity.T_CheckType == 6) {
                var operatorProvider = OperatorProvider.Provider.GetCurrent();
                checkEntity.T_CheckPerson = operatorProvider.UserId;
                checkEntity.T_DepartmentId = operatorProvider.DepartmentId;
                checkEntity.T_EditedPerson = operatorProvider.UserId;
                checkEntity.T_ThisCheckTime = DateTime.Now;
                checkEntity.T_CreateTime = checkEntity.T_ThisCheckTime;
                checkEntity.T_IsChecked = 1; // 已经点检过

                ToolEntity toolEntity = new ToolEntity();
                toolEntity.T_Id = checkEntity.T_Id;
                toolEntity.T_LastCheckTime = checkEntity.T_ThisCheckTime;
                entityApp.UpDate(toolEntity);  //修改夹具实体里的 上次点检时间
            }
            
      

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
       public ActionResult GetGridJson(Pagination pagination, string keyword,int checkType)
        {
         
            var data = new
            {
                rows = checkViewApp.GetList(pagination,keyword,checkType),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}