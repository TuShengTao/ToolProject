using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tms.Web
{
    public class QuarzJobScheduler_1
    {
        public static void Start()
        {
            // 任务1  点检任务
            IScheduler scheduler_1 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler_1.Start();

            IJobDetail job_1 = JobBuilder.Create<QuartzJob_1>().Build();
            ITrigger trigger_1 = TriggerBuilder.Create()
              .WithIdentity("triggerName_1", "groupName_1")
              .WithSimpleSchedule(t =>
                t.WithIntervalInSeconds(3) //设置时间
                 .RepeatForever())
                 .Build();

            scheduler_1.ScheduleJob(job_1, trigger_1);

        }
    }
}