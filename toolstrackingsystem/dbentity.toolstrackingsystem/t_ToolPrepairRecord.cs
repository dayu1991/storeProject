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
    
    public partial class t_ToolPrepairRecord
    {
        public long ID { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public string PrepairTime { get; set; }
        public string BackTime { get; set; }
        public string OptionPerson { get; set; }
        public int IsActive { get; set; }
        public string BackOptionPerson { get; set; }
    }
}
