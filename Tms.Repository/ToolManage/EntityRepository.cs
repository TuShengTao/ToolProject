
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class EntityRepository : RepositoryBase<ToolEntity>, IEntity
    {
        public void BatchDeleteForm(List<string> keyValues)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                for (int i = 0; i < keyValues.Count; i++)
                {
                    string value = keyValues[i];
                    db.Delete<ToolEntity>(t => t.T_Id == value);

                }
                db.Commit();
            }
        }

        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<ToolEntity>(t => t.T_Id == keyValue);
                db.Commit();
            }
        }

    }
}