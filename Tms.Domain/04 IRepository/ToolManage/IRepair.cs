using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IRepair : IRepositoryBase<RepairEntity>
    {
        int RepairCheck(RepairEntity repairEntity, ToolEntity toolEntity);
    }
}
