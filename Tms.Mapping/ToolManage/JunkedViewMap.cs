

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class JunkedViewMap : EntityTypeConfiguration<JunkedViewEntity>
    {
        public JunkedViewMap()
        {
            this.ToTable("Tools_JunkedView");
            this.HasKey(t => t.Id);
        }
    }
}