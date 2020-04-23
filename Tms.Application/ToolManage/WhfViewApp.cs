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

        public List<WhfViewEntity> GetList(Pagination pagination, string keyword,int searchType)
        {
            var expression = ExtLinq.True<WhfViewEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));
            }
            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }
    }
}
