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

    public  class FamilyEntity 
    {
        public string T_Id { get; set; }
        public string T_DepartmentId { get; set; }
        public string T_Name { get; set; }

        public string T_ParentId { get; set; }
        public int T_IsModel { get; set; }

        public int T_IsPartNo { get; set; }
        public int T_IsFamily { get; set; }
    }
}
