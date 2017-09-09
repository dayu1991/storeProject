using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem.view
{
    public class ToolInfoExtend : t_ToolInfo
    {
        public string UserTimeInfo { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }

        public string IsBackString { get; set; }
        public string IsRepairedString { get; set; }



    }
}
