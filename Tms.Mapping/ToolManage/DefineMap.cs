
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class DefineMap : EntityTypeConfiguration<DefineEntity>
    {
        public DefineMap()
        {
            this.ToTable("Tools_Define");
            this.HasKey(t => t.Id);
        }
    }
}

