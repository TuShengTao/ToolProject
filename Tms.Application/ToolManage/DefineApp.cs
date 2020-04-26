using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class DefineApp
    {
        private IDefine service = new DefineRepository();
        // 批量删除
        public void BatchDeleteForm(List<int> keyValues)
        {
            service.BatchDeleteForm(keyValues);
        }

        // 获取所有
        public List<DefineEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(DefineEntity defineEntity)
        {
            return service.Update(defineEntity);
        }
        public int Insert(DefineEntity defineEntity)
        {
            return service.Insert(defineEntity);
        }
        public void DeleteForm(int keyValue)
        {
             service.Delete(keyValue);
        }
        public List<DefineEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<DefineEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));// 夹具经手人 关键字查询且分页
                expression = expression.Or(t => t.T_FamilyId.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }
        public int GetFormByDefine(string code)
        {
            var expression = ExtLinq.True<DefineEntity>();
            expression = expression.And(t => t.T_Code.Contains(code));
            if (service.FindEntity(expression) != null)
            {
                return 1;  // 存在
            }
            else
            {
                return 0; // 不存在
            }

        }
        

    }
}
