using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class LocationApp
    {
        private ILocation service = new LocationRepository();

        // 获取所有 根据 typeId
        public List<LocationEntity> GetListByTpye(string typeId)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<LocationEntity>();
            expression = expression.And(t => t.ToolType.Equals(typeId));
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));//workcell索引

            return service.IQueryable(expression).ToList();
        }
        public int UpDate(LocationEntity locationEntity)
        {
            return service.Update(locationEntity);
        }
        public int Insert(LocationEntity locationEntity)
        {
            locationEntity.T_Id = Guid.NewGuid().ToString();
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            locationEntity.T_DepartmentId = operatorProvider.DepartmentId;
            return service.Insert(locationEntity);
        }
        public int Delete(string keyValue)
        {
            return service.Delete(t => t.T_Id == keyValue);
        }
        public List<LocationEntity> GetList(Pagination pagination, string keyword,string parentId,string typeId)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<LocationEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.Or(t => t.T_Name.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(typeId))
            {
                expression = expression.And(t => t.ToolType.Equals(typeId));
            }
            expression = expression.And(t => t.T_ParentId.Equals(parentId)); //区别 查询Counter、Location、Bin
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));//workcell索引
            return service.FindList(expression, pagination);
        }
        // 判断是否已存在此名称      
        public int GetFormByExit(string departmentId, string locationName)
        {
            var expression = ExtLinq.True<LocationEntity>();
            expression = expression.And(t => t.T_DepartmentId.Contains(departmentId));
            foreach (var item in service.IQueryable(expression))
            {
                if (item.T_Name == locationName) return 1;
            }
            return 0;
        }
    }
}
