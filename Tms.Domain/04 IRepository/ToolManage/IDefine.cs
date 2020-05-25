
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IDefine : IRepositoryBase<DefineEntity>
    {
        void BatchDeleteForm(List<int> keyValues);
        void Delete(int keyValue);
    }
}

