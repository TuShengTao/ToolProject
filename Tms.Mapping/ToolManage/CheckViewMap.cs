
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class CheckViewMap : EntityTypeConfiguration<CheckViewEntity>
    {
        public CheckViewMap()
        {
            this.ToTable("Tools_CheckView");
            this.HasKey(t => t.Id);
        }
    }
}