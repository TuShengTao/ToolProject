using Tms.Code;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using Tms.Repository.ToolManage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tms.Application.ToolManage
{
    public class CodeSeqIdApp
    {
        private ICodeSeqId service = new CodeSeqIdRepository();

        // 获取所有
        public List<CodeSeqIdEntity> GetList()
        {
            
            return service.IQueryable().ToList();

        }
        public int UpDate(CodeSeqIdEntity codeSeqIdEntity)
        {
            return service.Update(codeSeqIdEntity);
        }
        public int Insert(CodeSeqIdEntity codeSeqIdEntity)
        {
            return service.Insert(codeSeqIdEntity);
        }
        public int Delete(CodeSeqIdEntity codeSeqIdEntity)
        {
            return service.Delete(codeSeqIdEntity);
        }

    }
}
