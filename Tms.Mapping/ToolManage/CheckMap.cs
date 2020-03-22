
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class CheckMap : EntityTypeConfiguration<CheckEntity>
    {
        public CheckMap()
        {
            this.ToTable("Tools_Check");
            this.HasKey(t => t.T_Id);
        }
    }
}
