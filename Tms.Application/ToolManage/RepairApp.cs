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
            public int UpDate(RepairViewEntity repairViewEntity,string type)
        {
            if (type == "myApply")
            {
                ToolEntity toolEntity = new ToolEntity();
                RepairEntity repairEntity = new RepairEntity();
                repairEntity.Id = repairViewEntity.Id; //主键
                toolEntity.T_Id = repairViewEntity.T_Id; //主键
                toolEntity.T_ToolStatus = 1;//入库
                toolEntity.T_RepairedCounts = repairViewEntity.T_RepairedCounts + 1;
                repairEntity.T_RepairedStatus = 1;//维修状态 完成
                
                repairEntity.T_RepairPerson = repairViewEntity.T_RepairPerson;//修复人
                return service.RepairCheck(repairEntity, toolEntity);
            }
            else
            {
                var operatorProvider = OperatorProvider.Provider.GetCurrent();

                ToolEntity toolEntity = new ToolEntity();
                RepairEntity repairEntity = new RepairEntity();
                toolEntity.T_Id = repairViewEntity.T_Id; //主键
                toolEntity.T_SeqId = repairViewEntity.T_SeqId;
                toolEntity.T_Code = repairViewEntity.T_Code;
                repairEntity.T_DealTime = DateTime.Now;
                repairEntity.T_DealId = operatorProvider.UserId;
                repairEntity.Id = repairViewEntity.Id; //主键

                if (repairViewEntity.T_Stauts == -1)  // 不通过
                {
                    toolEntity.T_ToolStatus = 1;  // 未出库状态
                    repairEntity.T_IsToRepair = 0;//不去维修
                    repairEntity.T_Stauts = -1;
                }
                else if (repairViewEntity.T_Stauts == 1) //通过
                {
                    toolEntity.T_ToolStatus = 0;  //维修中
                    repairEntity.T_IsToRepair = 1;//去维修
                    repairEntity.T_RepairedStatus = 0;//维修状态 未完成
                    repairEntity.T_Stauts = 1;
                }
                else
                {
                    //
                }
                repairEntity.T_FeedBack = repairViewEntity.T_FeedBack;
                return service.RepairCheck(repairEntity, toolEntity);
            }

            
            
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
