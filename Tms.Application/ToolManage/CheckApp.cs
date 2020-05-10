using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class CheckApp
    {
        private ICheck service = new CheckRepository();

        // 获取所有
        public List<CheckEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }

       // 判断此夹具 在点检表是否存在且未被处理
        public int judgeIfExist(EntityDefineEntity Entity)
        {
            int counts = service.judgeIfExist(Entity).Count;
            return counts;  

        }

        public int UpDate(CheckEntity checkEntity)
        {
            return service.Update(checkEntity);
        }
        public int Insert(CheckEntity checkEntity)
        {
            return service.Insert(checkEntity);
        }
        public int Delete(CheckEntity checkEntity)
        {
            return service.Delete(checkEntity);
        }
        public List<CheckEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<CheckEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
