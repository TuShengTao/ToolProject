

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class ProductLinesMap : EntityTypeConfiguration<ProductLineEntity>
    {
        public ProductLinesMap()
        {
            this.ToTable("Tools_ProductLines");
            this.HasKey(t => t.T_Id);
        }
    }
}