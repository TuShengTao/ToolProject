
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface ICheck : IRepositoryBase<CheckEntity>
    {
        List<CheckEntity> judgeIfExist(EntityDefineEntity Entity);
    }
}
