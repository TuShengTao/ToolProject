using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class WareHouseFlowApp
    {
        private IWareHouseFlow service = new WareHouseFlowRepository();

        // 获取所有
        public List<WareHouseFlowEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(WareHouseFlowEntity wareHouseFlowEntity)
        {
            return service.Update(wareHouseFlowEntity);
        }
        public int Insert(WareHouseFlowEntity wareHouseFlowEntity)
        {
            return service.Insert(wareHouseFlowEntity);
        }
        public int Delete(WareHouseFlowEntity wareHouseFlowEntity)
        {
            return service.Delete(wareHouseFlowEntity);
        }
        public List<WareHouseFlowEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WareHouseFlowEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.And(t => t.T_RecPersonId.Contains(keyword)); // 记录人
                expression = expression.And(t => t.T_ProductLineId.ToString().Contains(keyword)); // 生产线
               
                expression = expression.And(t => t.T_Classes.Contains(keyword)); // 班次

            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
