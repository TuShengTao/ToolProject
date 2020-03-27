
using System.Collections.Generic;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class DefineRepository : RepositoryBase<DefineEntity>,IDefine
    {
        // 批量删除用户
        public void BatchDeleteForm(List<int> keyValues)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                for (int i = 0; i < keyValues.Count; i++)
                {
                    int value = keyValues[i];
                    db.Delete<DefineEntity>(t => t.T_Id == value);
                    
                }
                db.Commit();
            }
        }

    }
}