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
    public class WhfViewApp
    {
        private IWhfView service = new WhfViewRepository();

        //获取所有
        public List<WhfViewEntity> getAll()
        {
            return service.IQueryable().ToList();
        }

        public List<WhfViewEntity> GetList(Pagination pagination, string keyword, string searchType )
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<WhfViewEntity>();
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId)); //各个workcell数据分离 

            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));
            }
            if (searchType == "back")  //查询 待归还夹具 
            {
                expression = expression.And(t => t.T_ToolStatus == 0);
                expression = expression.And(t => t.T_RecPersonId.Equals(operatorProvider.UserId));

            }
            if (searchType == "myRecord")
            {
                expression = expression.And(t => t.T_RecPersonId.Equals(operatorProvider.UserId));//查出所有关于 我 的操作记录
            }

            return service.FindList(expression, pagination);
        }
    }
}
