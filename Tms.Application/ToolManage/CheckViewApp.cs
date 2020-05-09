using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class CheckViewApp
    {
        private ICheckView service = new CheckViewRepository();

        // 获取所有
        public List<CheckViewEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(CheckViewEntity checkEntity)
        {
            return service.Update(checkEntity);
        }
        public int Insert(CheckViewEntity checkEntity)
        {
            return service.Insert(checkEntity);
        }
        public int Delete(CheckViewEntity checkEntity)
        {
            return service.Delete(checkEntity);
        }
        public List<CheckViewEntity> GetList(Pagination pagination, string keyword)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<CheckViewEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));

            }
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));
            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
