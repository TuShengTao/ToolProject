using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IEntity : IRepositoryBase<ToolEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(ToolEntity toolEntity, string keyValue);
        void BatchDeleteForm(List<string> keyValues);
    }
}
