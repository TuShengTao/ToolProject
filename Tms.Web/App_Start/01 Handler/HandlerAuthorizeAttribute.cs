﻿using Tms.Application.SystemManage;
using Tms.Code;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tms.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 判断是否是系统管理员 是就放行 然后返回，不是就继续往下走 if判断  
            // 超过 30 分钟 一段时间 会失效 然后为null 报错 目前未解决 有bug  要进行异常处理  目前是
            bool isSystem = OperatorProvider.Provider.GetCurrent().IsSystem;

            if (isSystem != null && isSystem)
            {

                return;  // 是管理员 就放行全部的接口
            }
            if (Ignore == false)
            {
                return;
            }
             // 后台权限 关键代码 调用下面方法
            if (!this.ActionAuthorize(filterContext))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }
        //权限控制关键代码
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var roleId = operatorProvider.RoleId;   
            // moduleId 是界面级别功能模块Id
            var moduleId = WebHelper.GetCookie("NFine_currentmoduleid");  // 前端发起某个模块页面的请求时把这个模块页面的Id存进cookie
            // 此方法教程 ： https://www.xin3721.com/ArticlecSharp/c12656.html
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();  // 获取 执行脚本的名称
            var RequestUrl = HttpContext.Current.Request.ServerVariables["Path_Info"].ToString(); // 请求的url 如查询用户url： /SystemManage/User/GetGridJson
            //  从 cookie 里面取具有的权限模块名 与当前 请求的action
            return new RoleAuthorizeApp().ActionValidate(roleId, moduleId, action);
           // return new RoleAuthorizeApp().ActionValidate(roleId, moduleId, RequestUrl);
        }
    }
}