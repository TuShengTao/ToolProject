using System;
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IData : IRepositoryBase<DataEntity>
    {
        List<DataEntity> judgeExist(string T_Id);
        int  SelfInsert(string Did,string Tid, DateTime time);
    }
}
