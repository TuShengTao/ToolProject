
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class TypeMap : EntityTypeConfiguration<TypeEntity>
    {
        public TypeMap()
        {
            this.ToTable("Tools_Type");
            this.HasKey(t => t.T_Id);
        }
    }
}