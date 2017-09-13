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
        private IUserManageRepository _userManageRepository;
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
            string sql = "INSERT INTO Sys_User_Role(RoleCode,RoleName,MenuID)VALUES(@roleCode,@roleName,@menuID)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("roleCode", roleInfo.RoleCode);
            parameters.Add("roleName",roleInfo.RoleName);
            parameters.Add("menuID",roleInfo.MenuID);
            return _roleManageRepository.ExecuteSql(sql,parameters)>0;
            //return _roleManageRepository.Add(roleInfo)>0;
        }
        /// <summary>
        /// 根据角色code获取角色信息
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        public Sys_User_Role GetRoleInfo(string roleCode)
        {
            string sql = "SELECT * FROM Sys_User_Role WHERE RoleCode=@roleCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("roleCode",roleCode);
            return _roleManageRepository.GetModel(sql,parameter);
        }
        public bool UpdateRoleInfo(Sys_User_Role roleInfo)
        {
            string sql = "UPDATE Sys_User_Role SET RoleName=@roleName,MenuID=@menuID WHERE RoleCode=@roleCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("roleName",roleInfo.RoleName);
            parameters.Add("menuID",roleInfo.MenuID);
            parameters.Add("roleCode",roleInfo.RoleCode);
            return _roleManageRepository.ExecuteSql(sql,parameters)>0;
        }
        public bool DeleteRoleInfo(string roleCode)
        {
            string sql = "DELETE FROM Sys_User_Role WHERE RoleCode=@roleCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("roleCode", roleCode);
            return _roleManageRepository.ExecuteSql(sql, parameters) > 0;
        }
    }
}
