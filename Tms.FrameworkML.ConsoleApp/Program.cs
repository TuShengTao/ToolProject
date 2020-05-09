// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.ML;
using Tms_FrameworkML.Model;
using Tms.Code;
using Tms.Application.ToolManage;
using Tms.Domain.Entity.ToolManage;
using System.Collections.Generic;

namespace Tms_FrameworkML.ConsoleApp
{
    class Program
    {
        //Dataset to use for predictions 
        private const string DATA_FILEPATH = @"C:\Users\tushengtao\AppData\Local\Temp\f878d682-ab9b-4dad-a137-750b3d9a4128.tsv";
        DataApp dataApp = new DataApp();
        static void Main(string[] args)
        {
            //发送邮件
            sendMail();
            // 定时任务 
            Timer timerClock1;
            timerClock1 = new Timer(new TimerCallback(timerCall_1), null, 0, 5000);
            Timer timerClock2;
            timerClock2 = new Timer(new TimerCallback(timerCall_2), null, 0, 20000);
            /*
            //Timer构造函数参数说明：
            Callback：一个 TimerCallback 委托，表示要执行的方法。
            State：一个包含回调方法要使用的信息的对象，或者为空引用（Visual Basic 中为 Nothing）。
            dueTime：调用 callback 之前延迟的时间量（以毫秒为单位）。指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。
            Period：调用 callback 的时间间隔（以毫秒为单位）。指定 Timeout.Infinite 可以禁用定期终止。
            */
            Console.ReadKey();
        }
        private static void sendMail()
        {
            MailHelper mailHelper = new MailHelper();
            mailHelper.MailUserName = "1450190944@qq.com";//替换自己的qq邮箱： 需要去qq邮箱设置里开启smpt服务,验证后替换下方授权码
            mailHelper.MailName = "工夹具系统-屠圣涛";
            mailHelper.MailPassword = "xvocfkdafxtvfhbe";//可替换自己qq邮箱的授权码
            mailHelper.MailServer = "smtp.qq.com";
            mailHelper.Send("1450190944@qq.com", "我的测试", "工夹具测试的邮件", "UTF-8", false, false);
        }
        private static void timerCall_1(object obj)
        {
            // 做预警任务 

            //ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);
            ModelInput sampleData = new ModelInput();
            sampleData.RepairCounts = 3;    // 维修次数
            sampleData.UseTime = 5677;  // 使用时间 
            var predictionResult = ConsumeModel.Predict(sampleData);
            Console.WriteLine($"\n{predictionResult.Prediction}\n\n");
        }

        private static void timerCall_2(object obj)
        {
            // 做定时点检任务

            CheckViewApp checkViewApp = new CheckViewApp();
            CheckApp checkApp = new CheckApp();
            EntityApp entityApp = new EntityApp();

            List<ToolEntity> toolsList = new List<ToolEntity>();
            toolsList = entityApp.GetList(); // 查询所有
            int counts = toolsList.Count;
            DateTime nowTime = DateTime.Now; // 现在的时间 
            string nowDateTime = nowTime.ToDateTimeString();//转换
            for ( int i=0;i < counts;i++ )
            {
                string lastTime = toolsList[i].T_LastCheckTime.ToDateTimeString();//这是次夹具上次点检时间
                
                TimeSpan ts = DateTime.Parse(nowDateTime) - DateTime.Parse(lastTime);  //可转为各种单位
                int days = ts.Days;  //相隔的天数
                if (days >= toolsList[i].T_PmPeriod)
                {
                    // 如果大于等于 就加入点检表 然后发邮件去提醒用户 
                    CheckEntity checkEntity = new CheckEntity();
                    checkEntity.T_Id = toolsList[i].T_Id;
                    checkEntity.T_CreateTime = nowTime;
                    checkEntity.T_LastCheckTime = toolsList[i].T_LastCheckTime;
                    checkEntity.T_IsChecked = 0; // 未点检 / 未处理  ;1处理
                    checkEntity.T_DepartmentId = toolsList[i].T_DepartmentId;
                    // 如果是每天定时点检提醒，前一天提醒，但前一天未处理点检，第二天点检添加需要做判断
                    checkApp.Insert(checkEntity);  // 添加进 点检表


                }
            }           
            Console.WriteLine($"第二个定时任务");
        }

        // Change this code to create your own sample data
        #region CreateSingleDataSample
        // Method to load single row of dataset to try a single prediction
        private static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: '\t',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }
        #endregion
    }
}
