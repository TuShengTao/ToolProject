
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class EntityMap : EntityTypeConfiguration<ToolEntity>
    {
        public EntityMap()
        {
            this.ToTable("Tools_Entity");
            this.HasKey(t => t.T_Id);
        }
    }
}
