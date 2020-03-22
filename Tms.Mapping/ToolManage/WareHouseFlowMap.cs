

using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage 
{ 
 
    public class WareHouseFlowMap : EntityTypeConfiguration<WareHouseFlowEntity>
    {
        public WareHouseFlowMap()
        {
            this.ToTable("Tool_WareHouseFlow");
            this.HasKey(t => t.T_Id);
        }
    }
}