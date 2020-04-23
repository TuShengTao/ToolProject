
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class RepairMap : EntityTypeConfiguration<RepairEntity>
    {
        public RepairMap()
        {
            this.ToTable("Tools_Repair");
            this.HasKey(t => t.Id);
        }
    }
}