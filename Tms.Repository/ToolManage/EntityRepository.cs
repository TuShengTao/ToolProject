
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tms.Code;
using Tms.Data;
using Tms.Domain.Entity.ToolManage;
using Tms.Domain.IRepository.ToolManage;
using System.Linq;

namespace Tms.Repository.ToolManage
{
    public class EntityRepository : RepositoryBase<ToolEntity>, IEntity
    {
        public void BatchDeleteForm(List<string> keyValues)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                for (int i = 0; i < keyValues.Count; i++)
                {
                    string value = keyValues[i];
                    db.Delete<ToolEntity>(t => t.T_Id == value);

                }
                db.Commit();
            }
        }
        
        public int UpdateByJudge(object insertEntity,string toolId,int newStatus,int oldStatus)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append(@"update Tools_Entity set T_ToolStatus = @NewStatus  where T_Id = @T_Id and T_ToolStatus = @OldStatus ");
                DbParameter[] dbParameter =
                {
                    new SqlParameter("@NewStatus",newStatus),
                    new SqlParameter("@OldStatus",oldStatus),
                    new SqlParameter("@T_Id",toolId),

                };
                int flag = db.ExecuteSql(strSql.ToString(), dbParameter); //执行sql语句 返回影响行数
                if (flag == 1 )  //说明状态符合 修改成功  
                {
                    db.Insert(insertEntity); //添加 进记录  / 领用记录 
                        
                }
                db.Commit();
                return flag; //正常返回1
            }
            
        }
       // 采购入库的仓储实现 需要添加两个表 
        public int InsertToWareHouse(BuyToWareHouseEntity buyToWareHouseEntity,ToolEntity toolEntity)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                int ToolSeqId = 0;  // 入库夹具的seqId
                int resultFlag = 0;  //添加返回的结果
                StringBuilder strSelectSql = new StringBuilder(); 
                
                strSelectSql.Append(@"select * from Tools_CodeSeqId  where  T_Code = @Code and T_DepartmentId = @DepartMentId order by T_SeqId");
                DbParameter[] dbParameter ={ new SqlParameter("@Code",toolEntity.T_Code), new SqlParameter("@DepartMentId", toolEntity.T_DepartmentId) };
                List<CodeSeqIdEntity> codeSeqIdList = db.FindList<CodeSeqIdEntity>(strSelectSql.ToString(),dbParameter); //查询code下所有seqId
                int seqIdCount = codeSeqIdList.Count; //code下的seqId总数
                if (seqIdCount >0)  
                {
                    List<CodeSeqIdEntity> newCodeSeqIdList = codeSeqIdList.Where(t => t.T_Occupy == 0).OrderByDescending(t => t.T_SeqId).ToList(); //筛选出未使用的seqId

                    if (newCodeSeqIdList.Count > 0)
                    {
                        int Id = newCodeSeqIdList[0].T_Id;  // 把主键赋值给 Id 用于修改条件的主键

                        StringBuilder strUpdateSql = new StringBuilder();
                        strUpdateSql.Append(@"update Tools_CodeSeqId set T_Occupy = @NewState where T_Id = @Id and T_Occupy = @State ");
                        int state = 0;
                        int newstate = 1;
                        DbParameter[] dbParameterUpdate = { 
                            new SqlParameter("@Id", Id), new SqlParameter("@State", state),new SqlParameter("@NewState", newstate)

                        };
                        int flagUpdate = db.ExecuteSql(strUpdateSql.ToString(), dbParameterUpdate); //执行sql语句 返回影响行数
                        if (flagUpdate == 1) { ToolSeqId = newCodeSeqIdList[0].T_SeqId; }  //赋值为 seqIdCount + 1

                    }
                    else
                    {
                        StringBuilder strInsertSql = new StringBuilder();
                        strInsertSql.Append(@"insert into Tools_CodeSeqId(T_Code,T_SeqId,T_Occupy,T_DepartmentId) values (@CodeInsert,@SeqId,@State,@DepartMentId)");
                        int seqId = seqIdCount + 1;
                        int state = 1;
                        DbParameter[] dbParameterInsert = { 
                            new SqlParameter("@CodeInsert", toolEntity.T_Code), 
                            new SqlParameter("@DepartMentId", toolEntity.T_DepartmentId),
                            new SqlParameter("@SeqId",seqId) ,
                            new SqlParameter("@State", state)

                        };
                        int flagInsert = db.ExecuteSql(strInsertSql.ToString(), dbParameterInsert); //执行sql语句 返回影响行数
                        if (flagInsert == 1) { ToolSeqId = seqIdCount + 1; }  //赋值为 seqIdCount + 1
                    }

                }
                else
                {
                    //  如果没有数据说明库里还没有此code的夹具，然后在Tools_CodeSeqId表新建
                    StringBuilder strInsertSql = new StringBuilder();
                    strInsertSql.Append(@"insert into Tools_CodeSeqId(T_Code,T_SeqId,T_Occupy,T_DepartmentId ) values(@CodeInsert@SeqId,@State,@DepartMentId)");
                    int seqId = 1;
                    int state = 1;
                    DbParameter[] dbParameterInsert = { 
                        new SqlParameter("@CodeInsert", toolEntity.T_Code), new SqlParameter("@DepartMentId", toolEntity.T_DepartmentId),
                        new SqlParameter("@SeqId",seqId) ,
                        new SqlParameter("@State",state)

                    };
                    int flagInsert = db.ExecuteSql(strInsertSql.ToString(), dbParameterInsert); //执行sql语句 返回影响行数
                    if (flagInsert == 1) { ToolSeqId = 1 ; }  //赋值为1
                }
                if (ToolSeqId != 0)
                {
                    toolEntity.T_SeqId = ToolSeqId;  //补全 SeqId
                    // 补全实体后做添加 
                    db.Insert<ToolEntity>(toolEntity); //添加实体表
                    db.Insert<BuyToWareHouseEntity>(buyToWareHouseEntity);            
                }
                resultFlag = db.Commit();  // 如果失败就回滚
                return resultFlag; 
            }

        }


    public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<ToolEntity>(t => t.T_Id == keyValue);
                db.Commit();
            }
        }

    }
}