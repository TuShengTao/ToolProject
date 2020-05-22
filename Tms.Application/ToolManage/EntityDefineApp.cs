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
    public class EntityDefineApp
    {
        private IEntityDefine service = new EntityDefineRepository();

        //获取所有
        public List<EntityDefineEntity> getAll()
        {
            return service.IQueryable().ToList();
        }

        public List<EntityDefineEntity> GetList(Pagination pagination, string keyword,int searchType)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();

            var expression = ExtLinq.True<EntityDefineEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Name.Contains(keyword));
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
                expression = expression.Or(t => t.T_Model.Contains(keyword));
                expression = expression.Or(t => t.T_PartNo.Contains(keyword));
                expression = expression.Or(t => t.T_Family.Contains(keyword));
            }
            if (searchType != 666)
            {
                expression = expression.And(t => t.T_ToolStatus == searchType);  //查询根据夹具状态类型
            }
            
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId));

            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }
    }
}
