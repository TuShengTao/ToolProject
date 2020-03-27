using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class EntityApp
    {
        private IEntity service = new EntityRepository();
        public void BatchDeleteForm(List<string> keyValues)
        {
            service.BatchDeleteForm(keyValues);
        }

        // 获取所有
        public List<ToolEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(ToolEntity toolEntity)
        {
            return service.Update(toolEntity);
        }
        public int Insert(ToolEntity toolEntity)
        {
            return service.Insert(toolEntity);
        }
        public int Delete(ToolEntity toolEntity)
        {
            return service.Delete(toolEntity);
        }
        public List<ToolEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<ToolEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Hander.Contains(keyword));// 夹具经手人 关键字查询且分页
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
