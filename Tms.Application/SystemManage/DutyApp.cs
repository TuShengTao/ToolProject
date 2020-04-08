
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using Tms.Domain.IRepository.SystemManage;
using Tms.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace Tms.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = new RoleRepository();

        public List<RoleEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.F_Category == 2);
            return service.IQueryable(expression).OrderBy(t => t.F_SortCode).ToList();
        }
        public List<RoleEntity> GetLists(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
                
            }
            //  在数据里查出的用户信息要筛选掉系统岗位
            expression = expression.And(t => t.F_Category != 1);
            return service.FindList(expression, pagination);
        }
        public RoleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                service.Update(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.F_Category = 2;
                service.Insert(roleEntity);
            }
        }

        public void BatchDeleteForm(List<string> keyValues)
        {
            service.BatchDeleteForm(keyValues);
        }

        // 判断父节点下是否已存在此名称
        public int GetFormByParent(string full_name, string parentId)
        {
            var expression = ExtLinq.True<RoleEntity>();
            expression = expression.And(t => t.F_OrganizeId.Contains(parentId));
            foreach (var item in service.IQueryable(expression))
            {
                if (item.F_FullName == full_name) return 1;
            }
            return 0;

        }
    }
}
