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
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            fanilyEntity.T_DepartmentId = operatorProvider.DepartmentId;
            return service.Insert(fanilyEntity);
        }
        public int Delete(string keyValue)
        {
            return service.Delete(t => t.T_Id == keyValue);
        }
        public List<FamilyEntity> GetList(Pagination pagination, string keyword,string parentId)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<FamilyEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.Or(t => t.T_Name.Contains(keyword));
            }
           expression = expression.And(t => t.T_ParentId.Equals(parentId)); //区别 查询family、model、partNo
           
           expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));//workcell索引
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
