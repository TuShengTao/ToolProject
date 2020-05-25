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
    public class EntityApp
    {
        private IEntity service = new EntityRepository();
        private IBuyToWareHouse buyService = new BuyToWareHouseRepository();
        public int InsertToWareHouse(BuyToWareHouseEntity buyToWareHouseEntity,ToolEntity toolEntity)
        {
            toolEntity.T_IsPassBuyToW = 0;//默认为 未入库
            toolEntity.T_UsedCount = 0;//使用次数为0
            toolEntity.T_UsedTime = 0; //使用时间 0秒
            toolEntity.T_RepairedCounts = 0;//维修次数 
            int result = service.InsertToWareHouse(buyToWareHouseEntity,toolEntity);
           
            if(result != 0)
            {
                buyService.Insert(buyToWareHouseEntity);
                return result;
            }
            else
            {
                return 0;
            }
        }
        public int  UseUpdateInsert(WareHouseFlowEntity insertEntity)
        {
            return service.UpdateByJudge(insertEntity,insertEntity.T_Id,2);
        }

        public int JunkedUpdateInsert(JunkedEntity insertEntity)
        {
            return service.UpdateByJudge(insertEntity, insertEntity.T_Id, 3);
        }

        public int RepairUpdateInsert(RepairEntity insertEntity)
        {
            return service.UpdateByJudge(insertEntity, insertEntity.T_Id, 4);
        }
        public void BatchDeleteForm(List<string> keyValues)
        {
            service.BatchDeleteForm(keyValues);
        }

        // 获取所有
        public List<ToolEntity> GetList()
        {

            return service.IQueryable().ToList();

        }
        public int UpDate(ToolEntity toolEntity)
        {
            return service.Update(toolEntity);
        }
        public int Insert(ToolEntity toolEntity)
        {
            return service.Insert(toolEntity);
        }
        public int Delete(ToolEntity toolEntity)
        {
            return service.Delete(toolEntity);
        }

        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public List<ToolEntity> VerifyIfExist(ToolEntity toolEntity)
        {
            // 员工手动发起报修和报废 夹具应该是已经入库的
            var sql = "select * from Tools_Entity where T_Code = '" + toolEntity.T_Code + "'and T_SeqId = '" + toolEntity.T_SeqId + "' and T_ToolStatus = 1 ";  

            // var sql = "select * from Tools_Entity where T_Code = '" + toolEntity.T_Code + "'and T_SeqId = '"+toolEntity.T_SeqId+"' and T_ToolStatus in(1,2) ";
            var list = service.FindList(sql);
            if(list.Count == 1)
            {
                return list;
            }
            return null;

        }
     

        public List<ToolEntity> GetFormByCode(string code)
        {
            var expression = ExtLinq.True<ToolEntity>();
            expression = expression.And(t => t.T_Code.Contains(code));
            if (service.FindEntity(expression) != null)
            {
                
                var sql1 = "select * from Tools_Entity where T_Code = '" + code + "'";
                var list1 = service.FindList(sql1);
                var sql2 = "select * from Tools_Entity where T_Code = '" + code + "' and T_IsDelete = 1";
                var list2 = service.FindList(sql2);
                if (list2.Count != 0) return list2;
                else return list1;  //存在
            }
            else
            {
                return null; // 不存在
            }

        }

        public void SubmitForm(ToolEntity toolEntity, string keyValue, string keyNumber, string keyCode, string keySeqId)
        {
            if (!string.IsNullOrEmpty(keyValue) && string.IsNullOrEmpty(keyNumber))
            {
                toolEntity.T_Id = keyValue; //  如果 keyValue 是空 就去执行修改 否则去创建
                toolEntity.T_Code = keyCode;
                toolEntity.T_SeqId = int.Parse(keySeqId);
                service.Update(toolEntity);
            }
            else if (string.IsNullOrEmpty(keyValue) && string.IsNullOrEmpty(keyNumber))
            {
                toolEntity.T_Id = Guid.NewGuid().ToString();
                toolEntity.T_RegDate = DateTime.Now;
                toolEntity.T_UsedCount = 0;
                toolEntity.T_SeqId = 1;
                service.Insert(toolEntity);
            }
            else
            {
                toolEntity.T_Id = Guid.NewGuid().ToString();
                toolEntity.T_RegDate = DateTime.Now;
                toolEntity.T_UsedCount = 0;
                toolEntity.T_SeqId = int.Parse(keyNumber);
                service.Insert(toolEntity);
            }
        }

        public List<ToolEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<ToolEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Hander.Contains(keyword));// 夹具经手人 关键字查询且分页
                expression = expression.Or(t => t.T_ToolType.Contains(keyword));
                expression = expression.Or(t => t.T_Code.Contains(keyword));
            }
            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }
        public List<long> GetStatus()
        {
            var expression = ExtLinq.True<ToolEntity>();
            List<long> list1 = new List<long>();
            for (int i = -1; i < 6; i++)
            {
                expression = expression.And(t => t.T_ToolStatus == i);
                list1.Add(service.IQueryable(expression).ToList().Count);
            }

            /*   expression = expression.And(t => t.F_Account != "admin");*/
            return list1;
        }
    }
}
