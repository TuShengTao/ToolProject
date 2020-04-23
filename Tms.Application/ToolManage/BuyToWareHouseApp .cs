using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class BuyToWareHouseApp
    {
        private IBuyToWareHouse service = new BuyToWareHouseRepository();

        // 获取所有
        public List<BuyToWareHouseEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(BuyToWareHouseEntity buyToWareHouseEntity)
        {
            return service.Update(buyToWareHouseEntity);
        }
        public int Insert(BuyToWareHouseEntity buyToWareHouseEntity)
        {
            return service.Insert(buyToWareHouseEntity);
        }
        public int Delete(BuyToWareHouseEntity buyToWareHouseEntity)
        {
            return service.Delete(buyToWareHouseEntity);
        }
        public List<BuyToWareHouseEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<BuyToWareHouseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
               // expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.And(t =>t.T_ApplicantId.Contains(keyword)); // 申请人
                expression = expression.And(t => t.T_LastDealDate.ToString().Contains(keyword)); // 
                expression = expression.And(t => t.T_FirstDealId.Contains(keyword));  // 初审人
                expression = expression.And(t => t.T_LastDealId.Contains(keyword));  // 终审人
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
