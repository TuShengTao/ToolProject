
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
            QuarzJobScheduler_1.Start(); //定时任务1  夹具定时点检任务
            QuarzJobScheduler_2.Start();// 定时任务2  夹具预警任务
            // 使用阿里云RDS无法进行备份 暂时停止改定时任务 修改为本地数据库再开启任务
           // QuarzJobScheduler_3.Start();// 定时任务2  数据库定时备份任务
        }
    }
}