
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IBuyToWareHouse : IRepositoryBase<BuyToWareHouseEntity>
    {
        int BuyCheck(BuyToWareHouseEntity buyEntity, ToolEntity toolEntity, string type);
    }
}
