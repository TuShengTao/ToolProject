using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tms.Web
{
    public class QuarzJobScheduler_3
    {
        public static void Start()
        {
            // 任务3 做数据库备份
            IScheduler scheduler_3 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler_3.Start();

            IJobDetail job_3 = JobBuilder.Create<QuartzJob_3>().Build();
            ITrigger trigger_3 = TriggerBuilder.Create()
              .WithIdentity("triggerName_3", "groupName_3")
              .WithSimpleSchedule(t =>
                t.WithIntervalInSeconds(3600*24) //设置时间
                 .RepeatForever())
                 .Build();

            scheduler_3.ScheduleJob(job_3, trigger_3);

        }
    }
}