using Tms.Data;
using Tms.Domain.Entity.ToolManage;
namespace Tms.Domain.IRepository.ToolManage
{
    public interface IJunked : IRepositoryBase<JunkedEntity>
    {
       int JunkedCheck(JunkedEntity junkedEntity, ToolEntity toolEntity, string type);
    }
}
