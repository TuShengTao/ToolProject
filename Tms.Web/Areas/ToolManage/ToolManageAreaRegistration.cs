using System.Web.Mvc;

namespace Tms.Web.Areas.SystemManage
{
    public class ToolManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ToolManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "Tms.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
