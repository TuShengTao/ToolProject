using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class TypeApp
    {
        private IType service = new TypeRepository();

        // 获取所有
        public List<TypeEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(TypeEntity typeEntity)
        {
            return service.Update(typeEntity);
        }
        public void DeleteForm(string keyValue)
        {
             service.Delete(keyValue);
        }
        public int Insert(TypeEntity typeEntity)
        {

            typeEntity.T_Id = Common.GuId();//主键
            return service.Insert(typeEntity);
        }
        public int Delete(TypeEntity typeEntity)
        {
            return service.Delete(typeEntity);
        }
        public List<TypeEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<TypeEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.ToString().Contains(keyword));
                expression = expression.Or(t => t.T_TypeName.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }
        public int GetFormByDefine(string typeName)
        {
            var expression = ExtLinq.True<TypeEntity>();
            expression = expression.And(t => t.T_TypeName.Contains(typeName));
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
