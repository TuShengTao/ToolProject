using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Tms.Application.ToolManage
{
    public class RepairViewApp
    {
        private IRepairView service = new RepairViewRepository();

        //获取所有
        public List<RepairViewEntity> getAll()
        {
            return service.IQueryable().ToList();
        }

        public List<RepairViewEntity> GetList(Pagination pagination, string keyword,string searchType)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<RepairViewEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));
            }
            if(searchType == "dealRepair")
            {
                expression = expression.And(t => t.T_Stauts.Equals(0));  
            }
            if (searchType == "myRecordRepair")
            {
                expression = expression.And(t => t.T_ApplicantId.Equals(operatorProvider.UserId));//查出所有关于 我 的操作记录
                expression = expression.Or(t => t.T_DealId.Equals(operatorProvider.UserId));
            }
             expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId)); //各个workcell数据分离 
            return service.FindList(expression, pagination);
        }
    }
}
