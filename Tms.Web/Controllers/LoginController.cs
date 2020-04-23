
using Tms.Domain.Entity.SystemSecurity;
using Tms.Application.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Domain.Entity.SystemManage;
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Application;

namespace Tms.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });
            Session.Abandon(); // 取消会话
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent(); // 
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        //登录超时验证 不验证此登录接口
        [HandlerLogin(false)]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                //if (Session["Tms_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["Tms_session_verifycode"].ToString())
                //{
                //    throw new Exception("验证码错误，请重新输入");
                //}
                String roleToken = "";//接口返回的token
                UserEntity userEntity = new UserApp().CheckLogin(username, password);// 去数据库查用户信息
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;  
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());//  token生成
                    roleToken = operatorModel.LoginToken;  // 要返回给前端  

                    //  判断此用户的账号是否是 admin  如果是，则在后续的权限判断拦截中直接放行 ，不进行权限的后续判断拦截
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    //权限的关键  
                    OperatorProvider.Provider.AddCurrent(operatorModel);  //cookie/session 添加当前用户的 roleId等 
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功!",data = roleToken }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败!" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
