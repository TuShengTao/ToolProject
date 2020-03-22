
using Tms.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.SystemManage
{
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButtonEntity>
    {
        public ModuleButtonMap()
        {
            this.ToTable("Sys_ModuleButton");
            this.HasKey(t => t.F_Id);
        }
    }
}
