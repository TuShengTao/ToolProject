using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tms.Application.SystemManage;
using Tms.Application.ToolManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.Entity.ToolManage;


namespace Tms.Web
{
    public class QuartzJob_1 : IJob
    {
 
        public void Execute(IJobExecutionContext context)
        {
            checkTools();  // 定时点检任务

        }
        private static void checkTools()
        {
            // 做定时点检任务
            

            CheckViewApp checkViewApp = new CheckViewApp();
            CheckApp checkApp = new CheckApp();
            EntityDefineApp entityApp = new EntityDefineApp();
            List<EntityDefineEntity> toolsList = new List<EntityDefineEntity>();
            toolsList = entityApp.getAll(); // 查询所有
            int counts = toolsList.Count;
          //  Console.WriteLine($"记录总数：" + $"{counts}\n");
            DateTime nowTime = DateTime.Now; // 现在的时间 
            string nowDateTime = nowTime.ToDateTimeString();//转换
            for (int i = 0; i < counts; i++)
            {
                string lastTime = toolsList[i].T_LastCheckTime.ToDateTimeString();//这是次夹具上次点检时间

                TimeSpan ts = DateTime.Parse(nowDateTime) - DateTime.Parse(lastTime);  //可转为各种单位
                int days = ts.Days;  //相隔的天数
                //Console.WriteLine($"{i}" + "相隔天数：" + $"{days}" + " 点检周期：" + $"{toolsList[i].T_PmPeriod}");
                if (days >= toolsList[i].T_PmPeriod)
                {
                    // 如果大于等于 就加入点检表 然后发邮件去提醒用户 
                    CheckEntity checkEntity = new CheckEntity();
                    checkEntity.T_Id = toolsList[i].T_Id;
                    checkEntity.T_CreateTime = nowTime;
                    checkEntity.T_LastCheckTime = toolsList[i].T_LastCheckTime;
                    checkEntity.T_IsChecked = 0; // 未点检 / 未处理  ;1处理
                    checkEntity.T_DepartmentId = toolsList[i].T_DepartmentId;
                    checkEntity.T_CheckType = 0;
                    // 如果是每天定时点检提醒，前一天提醒，但前一天未处理点检，第二天点检添加需要做判断
                    // 判断该夹具是否已经提醒过
                    if (checkApp.judgeIfExist(toolsList[i]) > 0 == false)
                    {
                       
                        checkApp.Insert(checkEntity);  // 添加进 点检表
                        string msg = $"夹具定时点检提醒，详细信息：\n" + $"夹具代码：" + $"{toolsList[i].T_Code}" + $"-" +
                            $"{toolsList[i].T_SeqId}\n" + $"夹具名称：" + $"{toolsList[i].T_Name}\n" + $"夹具位置：" +
                            $"{toolsList[i].T_Location}"
                            ;
                        sendMail(msg); // 发送点检任务提醒邮件
                    }
                }
            }
        }

      
        private static void sendMail(string mailMessage)
        {
            MailHelper mailHelper = new MailHelper();
            mailHelper.MailUserName = "1450190944@qq.com";//替换自己的qq邮箱： 需要去qq邮箱设置里开启smpt服务,验证后替换下方授权码
            mailHelper.MailName = "工夹具智能管理系统";
            mailHelper.MailPassword = "xvocfkdafxtvfhbe";//可替换自己qq邮箱的授权码
            mailHelper.MailServer = "smtp.qq.com";
            mailHelper.Send("1450190944@qq.com", "夹具点检", mailMessage, "UTF-8", false, false);
        }
    }

}