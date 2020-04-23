
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class WhfViewMap : EntityTypeConfiguration<WhfViewEntity>
    {
        public WhfViewMap()
        {
            this.ToTable("Tools_WhfView");
            this.HasKey(t => t.Id);
        }
    }
}