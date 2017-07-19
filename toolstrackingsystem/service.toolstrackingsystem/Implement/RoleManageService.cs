using Dapper;
using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public class RoleManageService : IRoleManageService
    {
        private IRoleManageRepository _roleManageRepository;
        private IMultiTableQueryRepository _multiTableQueryRepository;
        public RoleManageService(IRoleManageRepository roleManageRepository, IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._roleManageRepository = roleManageRepository;
            this._multiTableQueryRepository = multiTableQueryRepository;
        }
        public List<Sys_User_Role> GetRoleInfoList()
        {
            return _roleManageRepository.GetRoleInfoList();
        }

        public List<RoleInfoEntity> GetRoleInfoList(string RoleCode, string RoleName)
        {
            string sql = "SELECT RoleCode,RoleName,MenuID FROM Sys_User_Role WHERE 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(RoleCode))
            {
                sql += "AND RoleCode like @RoleCode ";
                parameter.Add("RoleCode", string.Format("%{0}%",RoleCode));
            }
            if (!string.IsNullOrEmpty(RoleName))
            {
                sql += " AND RoleName = @RoleName";
                parameter.Add("RoleName", string.Format("%{0}%",RoleName));
            }
            return _multiTableQueryRepository.QueryList<RoleInfoEntity>(sql,parameter).ToList();
        }


        public bool InserUserRole(Sys_User_Role roleInfo)
        {
            //return _roleManageRepository.Add(roleInfo)>0;
            return _roleManageRepository.InsertRoleInfo(roleInfo);
        }
    }
}
