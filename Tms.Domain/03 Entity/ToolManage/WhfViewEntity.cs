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


    public class WhfViewEntity
    {
        public string T_Name { get; set; }
        public string T_Family { get; set; }
        public string T_Model { get; set; }
        public string T_PartNo { get; set; }
        public string T_Code { get; set; }
        public int T_SeqId { get; set; }
        public string T_ToolType { get; set; }
        public Nullable<int> T_DefineId { get; set; }

        public int Id { get; set; }
        public string T_Id { get; set; }
        public string T_Hander { get; set; }
        public string T_RecPersonId { get; set; }

        public int T_ProductLineId { get; set; }
        public string T_Description { get; set; }
        public Nullable<System.DateTime> T_OutDate { get; set; }
        public Nullable<System.DateTime> T_BackDate { get; set; }
        public int T_ToolStatus { get; set; }
        public string T_Classes { get; set; }
        public string T_DepartmentId { get; set; }
    }
}