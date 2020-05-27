using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tms.Code;
using Tms.Application.ToolManage;
using Tms.Application.SystemSecurity;
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.Entity.ToolManage;
using Tms_FrameworkML.Model;
using Tms.Domain.Entity.SystemSecurity;

namespace Tms.Web
{
    public class QuartzJob_3 : IJob
    {
        private static void sendMail(string mailMessage,string F_FileName)
        {
            MailHelper mailHelper = new MailHelper();
            mailHelper.MailUserName = "1450190944@qq.com";//替换自己的qq邮箱： 需要去qq邮箱设置里开启smpt服务,验证后替换下方授权码
            mailHelper.MailName = "工夹具全寿命智能管理系统";
            mailHelper.MailPassword = "xvocfkdafxtvfhbe";//可替换自己qq邮箱的授权码
            mailHelper.MailServer = "smtp.qq.com";
           // mailHelper.Send("1450190944@qq.com", "数据库备份", "单测试", "UTF-8", false, false);
            mailHelper.SendByThread(F_FileName, "1450190944@qq.com", "数据库备份", mailMessage, 25);
           
        }
        public void Execute(IJobExecutionContext context)
        {
            DbBackupApp dbBackupApp = new DbBackupApp();
            DbBackupEntity dbBackupEntity = new DbBackupEntity();
            dbBackupEntity.F_FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            // System.Web.Hosting.HostingEnvironment.MapPath("~/Resource/DbBackup/" + dbBackupEntity.F_FileName + ".bak");
            dbBackupEntity.F_FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Resource/DbBackup/" + dbBackupEntity.F_FileName + ".bak");
            dbBackupEntity.F_FileName = dbBackupEntity.F_FileName + ".bak";

            string filePath =   dbBackupApp.SubmitForm(dbBackupEntity);  // 备份数据库
            sendMail($"您好！今天备份的数据库文件已发送至您的邮箱，备份数据库文件请在附件接收！\n"+ $"备份文件名称："+ $"{dbBackupEntity.F_FileName}"
                , dbBackupEntity.F_FileName);
            
        }

    }

 
}