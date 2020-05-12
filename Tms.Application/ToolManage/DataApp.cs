using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class DataApp
    {


        private IData service = new DataRepository();
        // 获取所有
        public List<DataEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }

        // 判断是否已存在此名称      
        public int GetFormByExit(string T_Id)
        {
            var entityList = new { 
                data = service.judgeExist(T_Id) 
            };
            if (entityList.data.Count > 0)
            {
                return 1;  // 存在
            }
            else 
            {
                return 0;
            }
            
        }
        public int UpDate(DataEntity dataEntity)
        {
            return service.Update(dataEntity);
        }
        public int SelfInsert(string Did,string Tid, DateTime time)
        {
            return service.SelfInsert(Did,Tid,time);
        }
        public int Insert(DataEntity dataEntity)
        {
            return service.Insert(dataEntity);
        }
        public int Delete(DataEntity dataEntity)
        {
            return service.Delete(dataEntity);
        }
        public List<DataEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<DataEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.T_Id.ToString().Contains(keyword));
                expression = expression.Or(t => t.T_TypeName.Contains(keyword));
                expression = expression.Or(t => t.T_DepartmentId.Contains(keyword));
            }
         /*   expression = expression.And(t => t.F_Account != "admin");*/
            return service.FindList(expression, pagination);
        }

    }
}
