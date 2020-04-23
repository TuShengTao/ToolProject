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
        public int UpDate(JunkedEntity junkedEntity)
        {
            return service.Update(junkedEntity);
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
            expression = expression.And(t => t.T_IsJunked !=false);
            return service.FindList(expression, pagination);
        }

    }
}
