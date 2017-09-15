using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    /// <summary>
    /// 用于送修工具待接收的实体类
    /// </summary>
    public class RepairedToolForReceiveEntity
    {
        public string ChildTypeName { get; set; }
        public string TypeName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public DateTime RepairedTime { get; set; }
        public string RepairedPerson { get; set; }
        public string RepairedRemark { get; set; }
    }
}
