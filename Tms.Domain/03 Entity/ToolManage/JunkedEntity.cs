//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
namespace Tms.Domain.Entity.ToolManage
{

    public  class JunkedEntity : IEntity<JunkedEntity
        >
    {
        public string T_Id { get; set; }
        public string T_DepartmentId { get; set; }
        public Nullable<int> T_LifeTime { get; set; }
        public string T_JunkedReason { get; set; }
        public string T_ApplicantId { get; set; }
        public Nullable<System.DateTime> T_ApplicantDate { get; set; }
        public string T_Img { get; set; }
        public string T_FirstDealId { get; set; }
        public Nullable<System.DateTime> T_FirstDealDate { get; set; }
        public string T_LastDealId { get; set; }
        public Nullable<System.DateTime> T_LastDealDate { get; set; }
        public Nullable<System.DateTime> T_CreatorTime { get; set; }
        public Nullable<bool> T_FirstDealResult { get; set; }
        public Nullable<bool> T_LaststDealResult { get; set; }
        public string T_Description { get; set; }
        public Nullable<bool> T_IsJunked { get; set; }
    }
}