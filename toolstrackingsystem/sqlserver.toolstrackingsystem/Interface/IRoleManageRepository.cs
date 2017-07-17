using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IRoleManageRepository
    {
        List<Sys_User_Role> GetRoleInfoList();
    }
}
