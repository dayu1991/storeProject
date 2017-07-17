using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class RoleManageRepository : RepositoryBase<Sys_User_Role>, IRoleManageRepository
    {
        public List<Sys_User_Role> GetRoleInfoList()
        {
            string sql = "select * from Sys_User_Role";
            DynamicParameters parameters = new DynamicParameters();
            return base.QueryList(sql,parameters).ToList();
        }
    }
}
