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
        //根据夹具类型Id查点检项目
        public List<CheckItemEntity> GetListByTypeId(string toolTypeId)
        {   
            var expression = ExtLinq.True<CheckItemEntity>();
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));
            expression = expression.And(t => t.T_ToolTypeId.Equals(toolTypeId));
            return service.IQueryable(expression).ToList();

        }

        public int UpDate(CheckItemEntity checkItemEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            checkItemEntity.T_DepartmentId = operatorProvider.DepartmentId;
            return service.Update(checkItemEntity);
        }
        public int Insert(CheckItemEntity checkItemEntity)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            checkItemEntity.T_DepartmentId = operatorProvider.DepartmentId;
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
        public List<CheckItemEntity> GetCheckItem(Pagination pagination, string keyword)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<CheckItemEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_ToolTypeId.Contains(keyword));
                expression = expression.Or(t => t.T_CheckItemName.Contains(keyword));
            }
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));
            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
