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

        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }

        // 根据 账号查用户 防止添加账号时重复
        public int GetFormByCodeAndSeqId(string code,int seqId)
        {
            var expression = ExtLinq.True<ToolEntity>();
            expression = expression.And(t => t.T_Code.Contains(code));
            expression = expression.And(t => t.T_SeqId.ToString().Contains(seqId.ToString()));
            if (service.FindEntity(expression) != null)
            {
                return 1;  // 存在
            }
            else
            {
                return 0; // 不存在
            }

        }

        public void SubmitForm(ToolEntity toolEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                toolEntity.Modify(keyValue); //  如果 keyValue 是空 就去执行修改 否则去创建
            }
            else
            {
                toolEntity.Create();
            }
            service.SubmitForm(toolEntity, keyValue);
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
