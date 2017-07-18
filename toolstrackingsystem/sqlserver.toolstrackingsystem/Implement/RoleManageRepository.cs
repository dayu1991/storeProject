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
        
        public List<Sys_User_Role> GetRoleInfoList(string RoleCode, string RoleName)
        {
            string sql = "SELECT RoleCode,RoleName,MenuID FROM Sys_User_Role WHERE 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if(!string.IsNullOrEmpty(RoleCode))
            {
                sql += "AND RoleCode=@RoleCode ";
                parameter.Add("RoleCode", RoleCode);
            }
            if (!string.IsNullOrEmpty(RoleName))
            {
                sql += " AND RoleName = @RoleName";
                parameter.Add("RoleName", RoleName);
            }
            return base.QueryList(sql,parameter).ToList();
        }
    }
}
