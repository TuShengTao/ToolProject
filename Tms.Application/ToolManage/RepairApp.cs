using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class RepairApp
    {
        private IRepair service = new RepairRepository();

        // 获取所有
        public List<RepairEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(RepairEntity repairEntity)
        {
            return service.Update(repairEntity);
        }
        public int Insert(RepairEntity repairEntity)
        {
            return service.Insert(repairEntity);
        }
        public int Delete(RepairEntity repairEntity)
        {
            return service.Delete(repairEntity);
        }
        public List<RepairEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<RepairEntity>();
            expression = expression.And(t => t.T_IsToRepair.ToString().Contains("true"));  //是去修理的
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));// 夹具实体id
                expression = expression.Or(t => t.T_RepairedDate.ToString().Contains(keyword));// 修复时间
                expression = expression.Or(t => t.T_Code.Contains(keyword));// 夹具代码
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
