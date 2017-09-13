using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class ToolInfoInStoreEntity
    {
        public string TypeName { get; set; }
        public string ChildTypeName { get; set; }
        public string PackCode { get; set; }
        public string PackName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public string Models { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
        public string InStoreTime { get; set; }
        public string OptionPerson { get; set; }
    }
}
