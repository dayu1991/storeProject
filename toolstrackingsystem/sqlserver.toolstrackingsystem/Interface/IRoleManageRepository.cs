using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IRoleManageRepository : IRepositoryBase<Sys_User_Role>
    {
        List<Sys_User_Role> GetRoleInfoList();
        List<Sys_User_Role> GetRoleInfoList(string RoleCode,string RoleName);
        bool InsertRoleInfo(Sys_User_Role roleInfo);
    }
}
