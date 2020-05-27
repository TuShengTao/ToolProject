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
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.Entity.ToolManage;
using Tms_FrameworkML.Model;

namespace Tms.Web
{
    public class QuartzJob_2 : IJob
    {

        private static void sendMail(string mailMessage)
        {
            MailHelper mailHelper = new MailHelper();
            mailHelper.MailUserName = "1450190944@qq.com";//替换自己的qq邮箱： 需要去qq邮箱设置里开启smpt服务,验证后替换下方授权码
            mailHelper.MailName = "工夹具全寿命智能管理系统";
            mailHelper.MailPassword = "xvocfkdafxtvfhbe";//可替换自己qq邮箱的授权码
            mailHelper.MailServer = "smtp.qq.com";
            mailHelper.Send("1450190944@qq.com", "夹具预警", mailMessage, "UTF-8", false, false);
        }
        public void Execute(IJobExecutionContext context)
        {
            DataApp dataApp = new DataApp();
            DataEntity dataEntity = new DataEntity();
            EntityDefineApp entityDefineApp = new EntityDefineApp();
            List<EntityDefineEntity> entityDefineList = entityDefineApp.getAll();
            List<int> listInt = new List<int>();
            for (int i = 0; i < entityDefineList.Count; i++)
            {
               //去预测
                 ModelOutput output = ToolPredict(entityDefineList[i].T_RepairedCounts,entityDefineList[i].T_UsedTime);
                bool predictFlag = output.Prediction;
                float score = output.Score;
                if (predictFlag != true)  // 如果 未通过 去提醒
                {
                    string T_DepartmentId = entityDefineList[i].T_DepartmentId;
                    string T_Id = entityDefineList[i].T_Id;
                    DateTime T_CreateTime = DateTime.Now;
                    string Id = entityDefineList[i].T_Id;
                    int result = dataApp.GetFormByExit(Id);  // 判断是否已经在 预警表里
                 
                    if (result != 1)
                    {
                        dataApp.SelfInsert(T_DepartmentId,T_Id,T_CreateTime);  // 添加进数据库  ：预警记录

                        string msg = $"您好！您有一条夹具预警提醒，不要忘记登录系统去处理喔！点击 http://192.168.43.187:81 去处理\n夹具详细信息：\n" + $"夹具代码：" + $"{entityDefineList[i].T_Code}" + $"-" +
                            $"{entityDefineList[i].T_SeqId}\n" + $"夹具名称：" + $"{entityDefineList[i].T_Name}\n" + $"夹具位置：" +
                            $"{entityDefineList[i].T_Location}" + "\nScore: "+score
                            ;
                        sendMail(msg);  // 发送邮件提醒
                    }
                }

            }
        }
        static ModelOutput ToolPredict(int repairCounts,int usedTime)
        {
            // 做预警任务 
            //ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);
            ModelInput sampleData = new ModelInput();
            sampleData.RepairCounts = repairCounts;    // 维修次数
            sampleData.UseTime = usedTime;  // 使用时间 
            var predictionResult = ConsumeModel.Predict(sampleData);
           
            return predictionResult;
        }

    }

 
}