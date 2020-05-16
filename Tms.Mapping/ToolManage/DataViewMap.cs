
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class DataViewMap : EntityTypeConfiguration<DataViewEntity>
    {
        public DataViewMap()
        {
            this.ToTable("Tools_DataView");
            this.HasKey(t => t.Id);
        }
    }
}

