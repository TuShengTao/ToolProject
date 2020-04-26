using System.Collections.Generic;
using System.Data.Common;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IEntity : IRepositoryBase<ToolEntity>
    {
        void DeleteForm(string keyValue);
        void BatchDeleteForm(List<string> keyValues);
        int UpdateByJudge(object insertEntity, string toolId, int newStatus);
        int InsertToWareHouse(BuyToWareHouseEntity buyToWareHouseEntity, ToolEntity toolEntity);

    }
}
