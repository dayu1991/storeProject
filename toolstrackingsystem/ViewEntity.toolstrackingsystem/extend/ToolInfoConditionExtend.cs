using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class ToolInfoConditionExtend
    {
        public string blongValue { get; set; }
        public string categoryValue { get; set; }
        public string toolCode { get; set; }
        public string toolName { get; set; }
        public bool IsCheck { get; set; }
        public bool IsOut { get; set; }
        public bool IsRepair { get; set; }
        public string CheckTime { get; set; }
    }
}
