
using Tms.Data;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Tms.Domain.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
