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
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
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

            // 报废记录查询筛选条件判断 开始
            // 所有记录  '已废弃','未废弃','初审未通过','终审未通过'  未初审  未终审 
            //  666        6        7        8           9              10      11
            if (searchType == 6)
            {
                expression = expression.And(t => t.T_IsJunked == 1); //已废弃
            }
            else if (searchType == 7)
            {
                expression = expression.And(t => t.T_IsJunked == 0); //未废弃
            }
            else if (searchType == 8)
            {
                expression = expression.And(t => t.T_FirstDealResult == 0);  //初审未通过
            }
            else if (searchType == 10)
            {
                expression = expression.And(t => t.T_FirstDealResult == null);  //未初审
            }
            else if (searchType == 9) {
                expression = expression.And(t => t.T_LastDealResult == 0); //终审未通过
            }
            else if (searchType == 11)
            {
                expression = expression.And(t => t.T_LastDealResult == null); //未终审
            }
            else { 
            
            }


            // 结束
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
            else if (searchType == 4) //查询关于我的
            {
                expression = expression.And(t => t.T_ApplicantId.Equals(operatorProvider.UserId));//查出所有关于 我 的操作记录
                expression = expression.Or(t => t.T_FirstDealId.Equals(operatorProvider.UserId));
                expression = expression.Or(t => t.T_LastDealId.Equals(operatorProvider.UserId));
            }
            else
            {

            }
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));//各个workcell数据分离 
            return service.FindList(expression, pagination);
        }
    }
}
