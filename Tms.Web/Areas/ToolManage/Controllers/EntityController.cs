using System;
using System.Collections.Generic;
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
        private EntityDefineApp entityDefineApp = new EntityDefineApp();
        
        [HttpPost]
        public ActionResult InsertToWareHouse(BuyToWareHouseEntity buyToWareHouseEntity, ToolEntity toolEntity)
        {
            string T_Id = Guid.NewGuid().ToString();
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            buyToWareHouseEntity.T_Id = T_Id;  //外键
            buyToWareHouseEntity.T_ApplicantId = operatorProvider.UserId;
            buyToWareHouseEntity.T_ApplicantPerson = operatorProvider.UserName;
            buyToWareHouseEntity.T_DepartmentId = operatorProvider.DepartmentId;
            buyToWareHouseEntity.T_CreateTime = DateTime.Now;
           
            toolEntity.T_Id = T_Id; //主键 
            toolEntity.T_ToolStatus = 5;  //申请采购入库状态
            toolEntity.T_CreatorTime = buyToWareHouseEntity.T_CreateTime;
            toolEntity.T_DepartmentId = operatorProvider.DepartmentId;
            toolEntity.T_RecPersonId = operatorProvider.UserId;

            int result = entityApp.InsertToWareHouse(buyToWareHouseEntity, toolEntity);

            if (result != 0 )
            {
                return Success("提交成功!");
            }
            else
            {
                return Error("提交失败！请刷新重试！");
            }
        }

        [HttpPost]
        public ActionResult UseUpdateInsert(WareHouseFlowEntity useEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            useEntity.T_OutDate = DateTime.Now;
            useEntity.T_RecPersonId = operatorProvider.UserId;
            useEntity.T_DepartmentId = operatorProvider.DepartmentId;
            useEntity.T_ToolStatus = 0;//未归还标记
            int flag = entityApp.UseUpdateInsert(useEntity);
            if(flag == 1)
            {
                return Success("领用成功!");
            }
            else
            {
                return Error("领用失败！请刷新重试！");
            }

        }
        [HttpPost]
        public ActionResult JunkedUpdateInsert(JunkedEntity junkedEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            junkedEntity.T_ApplicantId = operatorProvider.UserId;
            junkedEntity.T_DepartmentId = operatorProvider.DepartmentId;
            junkedEntity.T_ApplicantDate = DateTime.Now;

            int flag = entityApp.JunkedUpdateInsert(junkedEntity);
            if (flag == 1)
            {
                return Success("提交成功!");
            }
            else
            {
                return Error("提交失败！请刷新重试！");
            }

        }
        // 报修申请
        [HttpPost]
        public ActionResult RepairUpdateInsert(RepairEntity repairEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            repairEntity.T_ApplicantId = operatorProvider.UserId;
            repairEntity.T_DepartmentId = operatorProvider.DepartmentId;
            repairEntity.T_ApplicantTime = DateTime.Now;

            int flag = entityApp.RepairUpdateInsert(repairEntity);
            if (flag == 1)
            {
                return Success("提交成功!");
            }
            else
            {
                return Error("提交失败！请刷新重试！");
            }

        }


        [HttpGet]
        
        public ActionResult Get()
        {
            var data = entityApp.GetList();
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetFormByCode(string code)
        {
            var count = entityApp.GetFormByCode(code);

            return Content(count.ToJson());
        }

        [HttpPost]
        public ActionResult VerifyIfExist(ToolEntity toolEntity)
        {
            var flag = entityApp.VerifyIfExist(toolEntity);
            return Content(flag.ToJson()); // 前台为1 则通过 
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
            toolEntity.T_Id = Guid.NewGuid().ToString();
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
        public ActionResult GetGridJson(Pagination pagination, string keyword,int searchType)
        {
            var data = new
            {
                rows = entityDefineApp.GetList(pagination, keyword,searchType),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}