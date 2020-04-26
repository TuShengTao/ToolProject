

using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class WareHouseFlowRepository : RepositoryBase<WareHouseFlowEntity>, IWareHouseFlow
    {
        public int backTool(WareHouseFlowEntity houseFlowEntity, ToolEntity toolEntity)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                int flag = 0;
                db.Update(houseFlowEntity);
                db.Update(toolEntity);
                flag = db.Commit();  //应该返回2
                return flag;
            }
        }
    }
}