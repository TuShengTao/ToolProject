
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class CheckItemMap : EntityTypeConfiguration<CheckItemEntity>
    {
        public CheckItemMap()
        {
            this.ToTable("Tools_CheckItem");
            this.HasKey(t => t.Id);
        }
    }
}
