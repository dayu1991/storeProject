//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbentity.toolstrackingsystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_ToolInfo
    {
        public long ToolId { get; set; }
        public long ToolBelongId { get; set; }
        public string ToolBelongName { get; set; }
        public Nullable<long> ToolCategoryId { get; set; }
        public string ToolCategoryName { get; set; }
        public string PackCode { get; set; }
        public string PackName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public string ToolModels { get; set; }
        public string ToolRemarks { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public string Location { get; set; }
        public bool IsDelete { get; set; }
        public long OperatorUserId { get; set; }
        public string OperatorUserName { get; set; }
        public System.DateTime AddTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}
