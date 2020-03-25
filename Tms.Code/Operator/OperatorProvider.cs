
using System;
using System.Web;

namespace Tms.Code
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "Tms_UserSession";
        private string LoginProvider = Configs.GetValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            else
            {
                // 这里要做异常处理 当用户登录30分钟后 就会空指针 目前未处理
                // 目前用户超过session设置的过期时间（在WebHelper里设置时间）内没有再次请求，超过时间再请求就会catch到异常
                // 后台返回Catch的错误信息，前台应该进行处理，再次跳转到登录页面
                try
                {
                    operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();

                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("服务器错误,Error:" + ex.Message);// 返回前台消息应该为 登录超时
                    return operatorModel;
                }
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            //  系统是把用户信息存入 cookie 还是 session，在这里进行判断（Configs文件夹里的system.config里进行设置）
            //cookie 时间是 10080分钟 一个星期 、 session过期时间是30分钟
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 10080); 
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
            }
            //WebHelper.WriteCookie("nfine_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
            //WebHelper.WriteCookie("nfine_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
