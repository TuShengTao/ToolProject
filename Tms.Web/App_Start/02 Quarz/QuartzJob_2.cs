using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tms.Code;

namespace Tms.Web
{
    public class QuartzJob_2 : IJob
    {
 
        public void Execute(IJobExecutionContext context)
        {
            MailHelper mailHelper = new MailHelper();
            mailHelper.MailUserName = "1450190944@qq.com";//替换自己的qq邮箱： 需要去qq邮箱设置里开启smpt服务,验证后替换下方授权码
            mailHelper.MailName = "工夹具智能预警系统";
            mailHelper.MailPassword = "xvocfkdafxtvfhbe";//可替换自己qq邮箱的授权码
            mailHelper.MailServer = "smtp.qq.com";
            mailHelper.Send("1450190944@qq.com", "夹具预警提醒", "定时任务2", "UTF-8", false, false);

        }

    }

 
}