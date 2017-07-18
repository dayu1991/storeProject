using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IRoleManageService
    {
        List<Sys_User_Role> GetRoleInfoList();
        List<RoleInfoEntity> GetRoleInfoList(string RoleCode, string RoleName);
        bool InserUserRole(Sys_User_Role roleInfo);
    }
}
