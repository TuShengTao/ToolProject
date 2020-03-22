
using Tms.Data;
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.IRepository.SystemManage;
using Tms.Repository.SystemManage;
using System.Collections.Generic;

namespace Tms.Repository.SystemManage
{
    public class ModuleButtonRepository : RepositoryBase<ModuleButtonEntity>, IModuleButtonRepository
    {
        public void SubmitCloneButton(List<ModuleButtonEntity> entitys)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                foreach (var item in entitys)
                {
                    db.Insert(item);
                }
                db.Commit();
            }
        }
    }
}
