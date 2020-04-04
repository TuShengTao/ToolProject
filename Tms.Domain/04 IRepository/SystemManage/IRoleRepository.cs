
using Tms.Data;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Tms.Domain.IRepository.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<RoleEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue);
        void BatchDeleteForm(List<string> keyValues);
    }
}
