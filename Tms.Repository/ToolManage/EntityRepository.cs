
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

        public void SubmitForm(ToolEntity toolEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(toolEntity); // 修改
                }
                else
                {
                    db.Insert(toolEntity);
                }
                db.Commit();
            }
        }
    }
}