
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IWareHouseFlow : IRepositoryBase<WareHouseFlowEntity>
    {
        int backTool(WareHouseFlowEntity houseFlowEntity,ToolEntity toolEntity);
    }
}
