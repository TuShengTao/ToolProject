
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class RepairViewMap : EntityTypeConfiguration<RepairViewEntity>
    {
        public RepairViewMap()
        {
            this.ToTable("Tools_RepairView");
            this.HasKey(t => t.Id);
        }
    }
}