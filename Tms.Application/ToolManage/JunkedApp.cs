using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class JunkedApp
    {
        private IJunked service = new JunkedRepository();

        // 获取所有
        public List<JunkedEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }

        public int GetListByUserId()
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var expression = ExtLinq.True<JunkedEntity>();
            expression = expression.And(t => t.T_DepartmentId.Equals(operatorProvider.DepartmentId)); //各个workcell数据分离 
            expression = expression.And(t => t.T_FirstDealResult != 0);
            expression = expression.And(t => t.T_LastDealResult == null);  //查出所有的报废请求
            return service.IQueryable(expression).ToList().Count;

        }
        public int UpDate(JunkedViewEntity junkedViewEntity, string type)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            JunkedEntity junkedEntity = new JunkedEntity();
            ToolEntity toolEntity = new ToolEntity();
            toolEntity.T_Id = junkedViewEntity.T_Id; //主键
            toolEntity.T_SeqId = junkedViewEntity.T_SeqId;
            toolEntity.T_Code = junkedViewEntity.T_Code;
            toolEntity.T_DepartmentId = junkedViewEntity.T_DepartmentId;
            junkedEntity.Id = junkedViewEntity.Id; //主键
            if (type == "First")
            {
                junkedEntity.T_FirstDealId = operatorProvider.UserId;
                junkedEntity.T_FirstDealDate = DateTime.Now;
                junkedEntity.T_FirstDealResult = junkedViewEntity.T_FirstDealResult;
                junkedEntity.T_FirstFeedBack = junkedViewEntity.T_FirstFeedBack;
                
            }
            else if (type == "End")
            {
                if (junkedViewEntity.T_LastDealResult == 1)
                {
                    toolEntity.T_ToolStatus = -1; //废弃了
                    junkedEntity.T_IsJunked = 1;
                }
                else
                {
                    toolEntity.T_ToolStatus = 2; //出库状态
                }
                junkedEntity.T_LastDealResult = junkedViewEntity.T_LastDealResult;
                junkedEntity.T_LastDealId = operatorProvider.UserId;
                junkedEntity.T_LastDealDate = DateTime.Now;
                junkedEntity.T_LastFeedBack = junkedViewEntity.T_LastFeedBack;
            }
            else 
            { 
            
            }
            return service.JunkedCheck(junkedEntity,toolEntity,type);
            //return service.Update(junkedEntity);
        }
        public int Insert(JunkedEntity junkedEntity)
        {
            return service.Insert(junkedEntity);
        }
        public int Delete(JunkedEntity junkedEntity)
        {
            return service.Delete(junkedEntity);
        }
        public List<JunkedEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<JunkedEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.Contains(keyword));
                expression = expression.And(t =>t.T_LifeTime.ToString().Contains(keyword));
                expression = expression.And(t => t.T_LastDealDate.ToString().Contains(keyword));
                expression = expression.And(t => t.T_FirstDealId.Contains(keyword));  // 初审人
                expression = expression.And(t => t.T_LastDealId.Contains(keyword));  // 终审人
            }
           //expression = expression.And(t => t.T_IsJunked !=0);
            return service.FindList(expression, pagination);
        }

    }
}
