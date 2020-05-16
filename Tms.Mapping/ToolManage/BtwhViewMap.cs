
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class BtwhViewMap : EntityTypeConfiguration<BtwhViewEntity>
    {
        public BtwhViewMap()
        {
            this.ToTable("Tools_BtwhView");
            this.HasKey(t => t.Id);
        }
    }
}