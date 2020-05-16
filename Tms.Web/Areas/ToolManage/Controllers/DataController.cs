using System.Diagnostics;
using System.Web.Mvc;
using Tms.Application.ToolManage;
using Tms.Domain.Entity.ToolManage;
using Tms.Code;
namespace Tms.Web.Areas.ToolManage.Controllers
{
    public class DataController : ControllerBase
    {
        private DataViewApp dataViewApp = new DataViewApp();
        private DataApp dataApp = new DataApp();

        [HttpPost]
        public ActionResult Update(DataEntity dataEntity)
        {
            var data = dataApp.UpDate(dataEntity);
            return Content(data.ToJson());
        }

        [HttpGet]
        // 分页查询
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = dataViewApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}