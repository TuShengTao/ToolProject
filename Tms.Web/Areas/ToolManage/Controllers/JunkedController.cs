using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using System.Web.Mvc;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    // 夹具报废申请接口
    // 查询个人申请记录接口
    // 查询 新建报废的申请 根据角色 判断
    // 前台输入报废的 code时 需要在后台验证再提交 使用 computed

        

    // 夹具报废controller
    public class JunkedController : ControllerBase
    {
        private JunkedApp junkedApp = new JunkedApp();
        private EntityApp entityApp = new EntityApp();
        private JunkedViewApp JunkedViewApp = new JunkedViewApp(); 
  
        [HttpGet]
        public ActionResult Get()
        {
            var data = junkedApp.GetList();
            return Content(data.ToJson());
        }
        [HttpPost]
        public ActionResult Update(JunkedViewEntity junkedViewEntity ,string type)
        {
            var data = junkedApp.UpDate(junkedViewEntity, type);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Insert(JunkedEntity junkedEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            junkedEntity.T_ApplicantId = operatorProvider.UserId;
            junkedEntity.T_DepartmentId = operatorProvider.DepartmentId;
            junkedEntity.T_ApplicantDate = DateTime.Now;

            //修改实体表夹具状态 
            ToolEntity toolEntity = new ToolEntity();
            toolEntity.T_Id = junkedEntity.T_Id;   //主键
            toolEntity.T_ToolStatus = 3; //报废申请中 夹具状态
            entityApp.UpDate(toolEntity);//更新

            var data = junkedApp.Insert(junkedEntity);
            
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(JunkedEntity junkedEntity)
        {
            var data = junkedApp.Delete(junkedEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
       public ActionResult GetGridJson(Pagination pagination, string keyword,int searchType)
        {
         
            var data = new
            {
                rows = JunkedViewApp.GetList(pagination,keyword,searchType),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


    }
}