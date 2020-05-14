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
        public void Execute(IJobExecutionContext context)
        {
            DbBackupApp dbBackupApp = new DbBackupApp();
            DbBackupEntity dbBackupEntity = new DbBackupEntity();
            dbBackupApp.SubmitForm(dbBackupEntity);  // 备份数据库
        }

    }

 
}