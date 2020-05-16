

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;


namespace Tms.Repository.ToolManage
{
    public class DataRepository : RepositoryBase<DataEntity>, IData
    {
        public List<DataEntity> judgeExist(string T_Id)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append(@"select * from Tools_Data  where T_Id = @T_Id and T_DealStatus = @Status ");
                int status = 0;
                DbParameter[] dbParameter =
                {
                    new SqlParameter("@Status",status),
                    new SqlParameter("@T_Id",T_Id),

                };
                List<DataEntity> entityList = db.FindList<DataEntity>(strSql.ToString(), dbParameter); //查询code下所有seqId

                return entityList; //正常返回1
            }
        }

        public int SelfInsert(string Did, string Tid, DateTime time)
        {
            int flag = 0;
            using (var db = new RepositoryBase().BeginTrans())
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append(@"insert into Tools_Data(T_Id,T_DepartmentId,T_CreateTime) values(@T_Id,@DId,@Time)");
                int status = 0;
                DbParameter[] dbParameter =
                {
                    new SqlParameter("@DId",Did),
                    new SqlParameter("@T_Id",Tid),
                    new SqlParameter("@Time",time),
                };
                flag = db.ExecuteSql(strSql.ToString(),dbParameter);
                db.Commit();
                return flag;  
            }

           
        }
    }
}