
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.SystemManage;

namespace Tms.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
        void BatchDeleteForm(List<string> keyValues);
    }
}
