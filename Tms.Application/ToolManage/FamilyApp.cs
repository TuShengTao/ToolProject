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
            return service.Insert(fanilyEntity);
        }
        public int Delete(FamilyEntity fanilyEntity)
        {
            return service.Delete(fanilyEntity);
        }
        public List<FamilyEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<FamilyEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.Or(t => t.T_FamilyName.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
       
            return service.FindList(expression, pagination);
        }

    }
}
