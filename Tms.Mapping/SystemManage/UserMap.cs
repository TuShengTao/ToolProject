
using Tms.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.SystemManage
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(t => t.F_Id);
        }
    }
}
