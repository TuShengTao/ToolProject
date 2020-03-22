
using Tms.Data;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Tms.Domain.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailEntity>
    {
        List<ItemsDetailEntity> GetItemList(string enCode);
    }
}
