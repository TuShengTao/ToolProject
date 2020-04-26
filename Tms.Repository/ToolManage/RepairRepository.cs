

using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class RepairRepository : RepositoryBase<RepairEntity>, IRepair
    {
        public int RepairCheck(RepairEntity repairEntity, ToolEntity toolEntity)
        {

            using (var db = new RepositoryBase().BeginTrans())
            {
                int flag = 0;
                db.Update(repairEntity);
                db.Update(toolEntity);
                flag = db.Commit();  //应该返回2
                return flag;
            }

        }
    }
}