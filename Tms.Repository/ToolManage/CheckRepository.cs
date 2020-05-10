

using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class CheckRepository : RepositoryBase<CheckEntity>, ICheck
    {
        public List<CheckEntity> judgeIfExist(EntityDefineEntity Entity)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                StringBuilder strSql = new StringBuilder();
                int IsChecked = 0;
                strSql.Append(@"select * from Tools_Check where T_Id = @T_Id and T_IsChecked = @IsChecked and T_DepartmentId = @DId  ");
                DbParameter[] dbParameter =
                {
                    new SqlParameter("@IsChecked",IsChecked),
                    new SqlParameter("@T_Id",Entity.T_Id),
                    new SqlParameter("@DId",Entity.T_DepartmentId)

                };
                List<CheckEntity> list = db.FindList<CheckEntity>(strSql.ToString(), dbParameter); //执行查询

                return list; //正常返回1
            }

        }
    }
}
