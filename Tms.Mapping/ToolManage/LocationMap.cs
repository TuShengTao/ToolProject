

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class LocationMap : EntityTypeConfiguration<LocationEntity>
    {
        public LocationMap()
        {
            this.ToTable("Tools_Location");
            this.HasKey(t => t.T_Id);
        }
    }
}
