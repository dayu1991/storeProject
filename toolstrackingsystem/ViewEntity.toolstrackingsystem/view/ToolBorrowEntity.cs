using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class ToolBorrowEntity
    {
        public string TypeName { get; set; }
        public string ChildTypeName { get; set; }
        public string PackCode { get; set; }
        public string PackName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string OutStoreTime { get; set; }
        public string outdescribes { get; set; }
        public string OptionPerson { get; set; }
    }
}
