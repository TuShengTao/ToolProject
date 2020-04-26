
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class BuyToWareHouseRepository : RepositoryBase<BuyToWareHouseEntity>, IBuyToWareHouse
    {
        public int BuyCheck(BuyToWareHouseEntity buyEntity, ToolEntity toolEntity, string type)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                int flag = 0;
                 db.Update(toolEntity);
                 db.Update(buyEntity);
                flag = db.Commit();
                return flag;
            }
        }
    }
}