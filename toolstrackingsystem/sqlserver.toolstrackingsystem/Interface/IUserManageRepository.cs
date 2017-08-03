using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IUserManageRepository : IRepositoryBase<Sys_User_Info>
    {
        Sys_User_Info GetUserInfo(string UserCode, string Password);
        Sys_User_Info GetUserInfo(string UserCode);
        int InsertUserInfo(string UserCode, string UserName, string Password, out Sys_User_Info userInfo);
        bool InsertUserInfo(Sys_User_Info userInfo);
        List<Sys_User_Info> GetUserInfoList(string UserCode, string DateTimeFrom, string DateTimeTo);
        bool UpdateUserInfo(Sys_User_Info userInfo);
        bool DeleteUser(Sys_User_Info userInfo);
        /// <summary>
        /// 根据角色代码获取用户列表
        /// </summary>
        /// <param name="UserRole"></param>
        /// <returns></returns>
        List<Sys_User_Info> GetUserList(string userRole);
    }
}
