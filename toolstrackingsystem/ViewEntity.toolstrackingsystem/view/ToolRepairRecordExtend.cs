using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem.view
{
    public class ToolRepairRecordExtend 
    {
        public string TypeName { get; set; }
        public string ChildTypeName { get; set; }
        public string PackCode { get; set; }
        public string PackName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public Nullable<System.DateTime> ToRepairedTime { get; set; }
        public Nullable<System.DateTime> ReceiveTime { get; set; }
        public Nullable<System.DateTime> CompleteTime { get; set; }
        public Nullable<System.DateTime> PullTime { get; set; }
        public Nullable<System.DateTime> HandleTime { get; set; }

        public string StatusStr { get; set; }
    }
}
