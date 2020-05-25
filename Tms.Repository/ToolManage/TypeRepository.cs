

using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class TypeRepository : RepositoryBase<TypeEntity>, IType
    {
        public void Delete(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<TypeEntity>(t => t.T_Id == keyValue);
                db.Commit();
            }
        }

    }
}