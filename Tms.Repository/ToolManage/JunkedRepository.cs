
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class JunkedRepository : RepositoryBase<JunkedEntity>, IJunked
    {
        public int JunkedCheck(JunkedEntity junkedEntity,ToolEntity toolEntity,string type) 
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                int flag = 0;
                if (type == "End")
                {
                    int newState = 0;
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"update Tools_CodeSeqId set T_Occupy = @NewStatus  where T_Code = @Code and T_SeqId = @SeqId and T_DepartmentId= @DId ");
                    DbParameter[] dbParameter =
                    {
                        new SqlParameter("@NewStatus",newState),
                        new SqlParameter("@Code",toolEntity.T_Code),
                        new SqlParameter("@SeqId",toolEntity.T_SeqId),
                        new SqlParameter("@DId",toolEntity.T_DepartmentId)
                    };
                    db.ExecuteSql(strSql.ToString(), dbParameter); //执行sql语句 返回影响行数
                    db.Update(toolEntity);
                }
                db.Update(junkedEntity);
                flag = db.Commit();
                return flag; 
            }

        }

    }
}