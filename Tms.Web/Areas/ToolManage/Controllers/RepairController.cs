using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具报修controller
    public class RepairController : ControllerBase
    {
        private RepairApp repairApp = new RepairApp();
        private EntityApp entityApp = new EntityApp();
        private RepairViewApp repairViewApp = new RepairViewApp();

        [HttpGet]
        public ActionResult Get()
        {
            var data = repairApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(RepairEntity repairEntity)
        {
            var data = repairApp.UpDate(repairEntity);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(RepairEntity repairEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            repairEntity.T_ApplicantId = operatorProvider.UserId;
            repairEntity.T_DepartmentId = operatorProvider.DepartmentId;
            repairEntity.T_ApplicantTime = DateTime.Now;
            var data = repairApp.Insert(repairEntity);
            //修改实体表夹具状态 
            ToolEntity toolEntity = new ToolEntity();
            toolEntity.T_Id = repairEntity.T_Id;   //主键
            toolEntity.T_ToolStatus = 4; //报修申请中
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(RepairEntity repairEntity)
        {
            var data = repairApp.Delete(repairEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword,int searchType)
        {
         
            var data = new
            {
                rows = repairViewApp.GetList(pagination,keyword, searchType),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}