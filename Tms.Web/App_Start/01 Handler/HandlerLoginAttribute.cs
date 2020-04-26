using Tms.Code;
using System.Web.Mvc;
using System.Web;

namespace Tms.Web
{  
  
    public class HandlerLoginAttribute : ActionFilterAttribute 
    {
        public bool Ignore { get; set; }
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                filterContext.HttpContext.Response.Headers.Add("LoginTime","Out");
                var data = new {
                    state = 200,
                    message= "LoginTimeOut",
                    data= ""
                };
                filterContext.Result = new ContentResult { Content = data.ToJson() };// 登录超时
            }
        }


    }

}