
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class DataMap : EntityTypeConfiguration<DataEntity>
    {
        public DataMap()
        {
            this.ToTable("Tools_Data");
            this.HasKey(t => t.Id);
        }
    }
}

