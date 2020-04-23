

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class JunkedMap : EntityTypeConfiguration<JunkedEntity>
    {
        public JunkedMap()
        {
            this.ToTable("Tools_Junked");
            this.HasKey(t => t.Id);
        }
    }
}