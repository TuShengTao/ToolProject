
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.IRepository.SystemManage;
using Tms.Repository.SystemManage;

namespace Tms.Repository.SystemManage
{
    public class OrganizeRepository : RepositoryBase<OrganizeEntity>, IOrganizeRepository
    {
        // 批量删除机构
        public void BatchDeleteForm(List<string> keyValues)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                for (int i = 0; i < keyValues.Count; i++)
                {
                    string value = keyValues[i];
                    db.Delete<OrganizeEntity>(t => t.F_Id == value);
                }
                db.Commit();
            }
        }
    }
}
