using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class MenuInfoEntity
    {
        public Sys_Menu_Info ParentMenuInfo { get; set; }
        public List<Sys_Menu_Info> ChildMenuInfoList { get; set; }
    }
}
