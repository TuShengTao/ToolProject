
using Tms.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.SystemManage
{
    public class RoleAuthorizeMap : EntityTypeConfiguration<RoleAuthorizeEntity>
    {
        public RoleAuthorizeMap()
        {
            this.ToTable("Sys_RoleAuthorize");
            this.HasKey(t => t.F_Id);
        }
    }
}
