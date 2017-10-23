using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class ToolRepairConditions
    {
        public string TypeName { get; set; }
        public string ChildTypeName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
