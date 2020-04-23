
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Tms.Web.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}
