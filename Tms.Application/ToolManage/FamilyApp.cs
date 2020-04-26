using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class FamilyApp
    {
        private IFamily service = new FamilyRepository();

        // 获取所有
        public List<FamilyEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(FamilyEntity fanilyEntity)
        {
            return service.Update(fanilyEntity);
        }
        public int Insert(FamilyEntity fanilyEntity)
        {
            fanilyEntity.T_Id = Common.GuId();
            return service.Insert(fanilyEntity);
        }
        public int Delete(string keyValue)
        {
            return service.Delete(t => t.T_Id == keyValue);
        }
        public List<FamilyEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<FamilyEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.Or(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        // 判断是否已存在此名称
        public int GetFormByExit(string departmentId, string familyName)
        {
            var expression = ExtLinq.True<FamilyEntity>();
            expression = expression.And(t => t.T_DepartmentId.Contains(departmentId));
            foreach (var item in service.IQueryable(expression))
            {
                if (item.T_Name == familyName) return 1;
            }
            return 0;
        }

    }
}
