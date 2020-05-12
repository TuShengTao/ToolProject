
using System.Web.Mvc;
using System.Web.Routing;

namespace Tms.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 启动应用程序
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            QuarzJobScheduler_1.Start(); //定时任务1
            QuarzJobScheduler_2.Start();// 定时任务2
        }
    }
}