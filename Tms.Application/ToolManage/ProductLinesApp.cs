using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class ProductLinesApp
    {
        private IProductLines service = new ProductLinesRepository();

        // 获取所有
        public List<ProductLineEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(ProductLineEntity lineEntity)
        {
            return service.Update(lineEntity);
        }
        public int Insert(ProductLineEntity lineEntity)
        {
            return service.Insert(lineEntity);
        }
        public int Delete(ProductLineEntity lineEntity)
        {
            return service.Delete(lineEntity);
        }
        public List<ProductLineEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<ProductLineEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.ToString().Contains(keyword));
                expression = expression.Or(t => t.T_LineName.Contains(keyword));
               
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
