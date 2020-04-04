
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.IRepository.SystemManage;
using Tms.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Code;

namespace Tms.Application.SystemManage
{
    public class OrganizeApp
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<OrganizeEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public List<OrganizeEntity> GetLists(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<OrganizeEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                //expression = expression.Or(t => t.F_RealName.Contains(keyword));
            }
            //  在数据里查出的用户信息要筛选掉 admin这个管理员
            return service.FindList(expression, pagination);
        }
        public OrganizeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void BatchDeleteForm(List<string> keyValues)
        {
            service.BatchDeleteForm(keyValues);
        }
        public void SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);
                service.Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create();
                service.Insert(organizeEntity);
            }
        }
        // 判断父节点下是否已存在此名称
        public int GetFormByParent(string full_name, string parentId)
        {
            var expression = ExtLinq.True<OrganizeEntity>();
            expression = expression.And(t => t.F_ParentId.Contains(parentId));
            foreach (var item in service.IQueryable(expression))
            {
                if (item.F_FullName == full_name) return 1; 
            }
            return 0;

        }
    }
}
