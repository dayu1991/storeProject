using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class ToolScrapedEntity
    {
        public int Id { get; set; }
        public string ChildTypeName { get; set; }
        public string TypeName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public DateTime ToRepairedTime { get; set; }
        public string ToRepairedPerName { get; set; }
        public string ToRepairMemo { get; set; }
        public string HandlePerName { get; set; }
        public DateTime HandleTime { get; set; }
        public string ScrapMemo { get; set; }
    }
}
