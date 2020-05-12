using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tms.Web
{
    public class QuarzJobScheduler_2
    {
        public static void Start()
        {
            // 任务1 预警任务
            IScheduler scheduler_2 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler_2.Start();

            IJobDetail job_2 = JobBuilder.Create<QuartzJob_2>().Build();
            ITrigger trigger_2 = TriggerBuilder.Create()
              .WithIdentity("triggerName_2", "groupName_2")
              .WithSimpleSchedule(t =>
                t.WithIntervalInSeconds(6) //设置时间
                 .RepeatForever())
                 .Build();

            scheduler_2.ScheduleJob(job_2, trigger_2);

        }
    }
}