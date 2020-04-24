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
    public class JunkedViewApp
    {
        private IJunkedView service = new JunkedViewRepository();

        //获取所有
        public List<JunkedViewEntity> getAll()
        {
            return service.IQueryable().ToList();
        }

        public List<JunkedViewEntity> GetList(Pagination pagination, string keyword,int searchType)
        {
            var expression = ExtLinq.True<JunkedViewEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));
            }
            if (searchType == 1)
            {
                expression = expression.And(t => t.T_FirstDealId == null); //查未初审的
            }
            else if (searchType == 2)
            {
                expression = expression.And(t => t.T_FirstDealResult == 1);  //查初审通过过的
            }
            else if(searchType == 3)
            {
                //查所有未处理的  searchType = 3
                expression = expression.And(t => t.T_FirstDealResult != 0 );
                expression = expression.And(t => t.T_LastDealResult == null);  //查出所有的报废请求
            }
            return service.FindList(expression, pagination);
        }
    }
}
