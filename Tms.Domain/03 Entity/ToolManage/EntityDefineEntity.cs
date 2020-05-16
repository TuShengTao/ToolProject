using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tms.Domain.Entity.ToolManage
{
    public class EntityDefineEntity
    {
        public string T_Code { get; set; }
        public int T_SeqId { get; set; }
        public string T_ToolType { get; set; }
        public int T_ToolStatus { get; set; }
        public string T_Id { get; set; }
        public string T_Img { get; set; }
        public string T_Hander { get; set; }
        public string T_RecPersonId { get; set; }
        public string T_BillNo { get; set; }
        public string T_Location { get; set; }
        public Nullable<int> T_UsedCount { get; set; }
        public int T_UsedTime { get; set; }
        public Nullable<System.DateTime> T_RegDate { get; set; }
        public Nullable<int> T_IsPassBuyToW { get; set; }
        public int T_RepairedCounts { get; set; }
        public Nullable<int> T_DefineId { get; set; }
        public Nullable<System.DateTime> T_ToolProductedDate { get; set; }
        public Nullable<System.DateTime> T_CreatorTime { get; set; }

        public Nullable<System.DateTime> T_LastCheckTime { get; set; }
        public string T_DepartmentId { get; set; }
        public bool T_IsDelete { get; set; }
        public Nullable<int> T_PmPeriod { get; set; }

        public string T_Name { get; set; }
        public string T_Family { get; set; }
        public string T_Model { get; set; }
        public string T_PartNo { get; set; }

    }
}
