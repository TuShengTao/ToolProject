
using Tms.Domain.Entity.ToolManage;
using System.Data.Entity.ModelConfiguration;

namespace Tms.Mapping.ToolManage
{
    public class CodeSeqIdMap : EntityTypeConfiguration<CodeSeqIdEntity>
    {
        public CodeSeqIdMap()
        {
            this.ToTable("Tools_CodeSeqId");
            this.HasKey(t => t.T_Id);
        }
    }
}