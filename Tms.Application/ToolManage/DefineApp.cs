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

        //根据code查夹具定义 返回一个夹具定义
        public DefineEntity getFormByCode(string code)
        {
            var expression = ExtLinq.True<DefineEntity>();
            expression = expression.And(t => t.T_Code.Equals(code));
            var data = service.FindEntity(expression);
            return data;
        }
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
        public int Delete(DefineEntity defineEntity)
        {
            return service.Delete(defineEntity);
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

    }
}
