
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class BuyToWareHouseMap : EntityTypeConfiguration<BuyToWareHouseEntity>
    {
        public BuyToWareHouseMap()
        {
            this.ToTable("Tools_BuyToWareHouse");
            this.HasKey(t => t.Id);
        }
    }
}
