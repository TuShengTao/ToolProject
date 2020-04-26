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

        public int UpDate(BtwhViewEntity btwhViewEntity, string type)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            BuyToWareHouseEntity buyEntity = new BuyToWareHouseEntity();
            ToolEntity toolEntity = new ToolEntity();
            toolEntity.T_Id = btwhViewEntity.T_Id; //主键
            buyEntity.Id = btwhViewEntity.Id; //主键
            if (type == "First")
            {
                buyEntity.T_FirstDealId = operatorProvider.UserId;
                buyEntity.T_FirstDealDate = DateTime.Now;
                buyEntity.T_FirstDealResult = btwhViewEntity.T_FirstDealResult;
                buyEntity.T_FirstFeedBack = btwhViewEntity.T_FirstFeedBack;
                
            }
            else if (type == "End")
            {
                if (btwhViewEntity.T_LastDealResult == 1)//通过入库
                {
                    toolEntity.T_ToolStatus = 1; // 未出库即入库
                    toolEntity.T_IsPassBuyToW = 1;//通过入库
                    toolEntity.T_RegDate = DateTime.Now;
                    buyEntity.T_IsInWarehouse = 1; //已在库中
                  
                }
                else
                {
                    toolEntity.T_ToolStatus = 2; //出库状态
                    buyEntity.T_IsInWarehouse = 0; //不在库中
                }
                buyEntity.T_LastDealResult = btwhViewEntity.T_LastDealResult;
                buyEntity.T_LastDealId = operatorProvider.UserId;
                buyEntity.T_LastDealDate = DateTime.Now;
                buyEntity.T_LastFeedBack = btwhViewEntity.T_LastFeedBack;
            }
            else
            {

            }
            return service.BuyCheck(buyEntity, toolEntity, type);
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
               // expression = expression.And(t => t.T_LastDealDate.ToString().Contains(keyword)); // 
                expression = expression.And(t => t.T_FirstDealId.Contains(keyword));  // 初审人
                expression = expression.And(t => t.T_LastDealId.Contains(keyword));  // 终审人
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
