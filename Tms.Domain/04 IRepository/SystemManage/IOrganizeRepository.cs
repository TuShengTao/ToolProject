
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.SystemManage;

namespace Tms.Domain.IRepository.SystemManage
{
    public interface IOrganizeRepository : IRepositoryBase<OrganizeEntity>
    {
        void BatchDeleteForm(List<string> keyValues);
    }
}
