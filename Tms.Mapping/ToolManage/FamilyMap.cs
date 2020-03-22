

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class FamilyMap : EntityTypeConfiguration<FamilyEntity>
    {
        public FamilyMap()
        {
            this.ToTable("Tools_Family");
            this.HasKey(t => t.T_Id);
        }
    }
}
