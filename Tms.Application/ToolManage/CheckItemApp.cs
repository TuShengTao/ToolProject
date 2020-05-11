using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class CheckItemApp
    {
        private ICheckItem service = new CheckItemRepository();

        // 获取所有
        public List<CheckItemEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(CheckItemEntity checkItemEntity)
        {
            return service.Update(checkItemEntity);
        }
        public int Insert(CheckItemEntity checkItemEntity)
        {
            return service.Insert(checkItemEntity);
        }
        public int Delete(CheckItemEntity checkItemEntity)
        {
            return service.Delete(checkItemEntity);
        }
        public List<CheckItemEntity> GetList(Pagination pagination, string keyword)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<CheckItemEntity>();
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));
            return service.FindList(expression, pagination);
        }

    }
}
