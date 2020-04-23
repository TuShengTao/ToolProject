
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class EntityDefineMap : EntityTypeConfiguration<EntityDefineEntity>
    {
        public EntityDefineMap()
        {
           
            this.ToTable("Tools_EntityDefine");
            this.HasKey(t => t.T_Id);
        }
    }
}

