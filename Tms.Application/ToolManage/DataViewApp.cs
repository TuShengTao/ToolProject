using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class DataViewApp
    {


        private IDataView service = new DataViewRepository();
        // 获取所有
        public List<DataViewEntity> GetAllList()
        {

            return service.IQueryable().ToList();

        }

        public List<DataViewEntity> GetList(Pagination pagination, string keyword,int searchType)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();

            var expression = ExtLinq.True<DataViewEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.ToString().Contains(keyword));
                //expression = expression.Or(t => t.T_TypeName.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
            if (searchType !=666) {
                expression = expression.And(t => t.T_DealStatus.Equals(searchType));
            }
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));

            return service.FindList(expression, pagination);
        }
    }
}
