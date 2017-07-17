using common.toolstrackingsystem;
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
    public class UserManageService : IUserManageService
    {
        private readonly IUserManageRepository _userManageRepository;
        private readonly IMultiTableQueryRepository _mltiTableQueryRepository;
        public UserManageService(IUserManageRepository userManageRepository, IMultiTableQueryRepository multiTableQueryRepository)
	    {
            this._userManageRepository = userManageRepository;
            this._mltiTableQueryRepository = multiTableQueryRepository;
	    }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode, string Pwd)
        {
            Pwd = CommonHelper.GetMd5(Pwd);
            return _userManageRepository.GetUserInfo(UserCode, Pwd);
        }
        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode)
        {
            return _userManageRepository.GetUserInfo(UserCode);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int InsertUserInfo(string UserCode,string UserName, string Password, out Sys_User_Info userinfo)
        {
            return _userManageRepository.InsertUserInfo(UserCode,UserName, Password, out userinfo);
        }
        /// <summary>
        /// 获取所有满足条件的用户列表
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="DateTimeFrom"></param>
        /// <param name="DateTimeTo"></param>
        /// <returns></returns>
        public List<Sys_User_Info> GetUserInfoList(string UserCode, string DateTimeFrom, string DateTimeTo)
        {
            return _userManageRepository.GetUserInfoList(UserCode, DateTimeFrom, DateTimeTo);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Sys_User_Info userInfo)
        {
            if (!string.IsNullOrEmpty(userInfo.PassWord))
            {
                userInfo.PassWord = CommonHelper.GetMd5(userInfo.PassWord);
            }
            return _userManageRepository.UpdateUserInfo(userInfo);
        }
        /// <summary>
        /// 删除某个用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool DeleteUser(Sys_User_Info userInfo)
        {
            return _userManageRepository.DeleteUser(userInfo);
        }

        public List<UserInfoEntity> GetUserInfo(string UserCode, string UserName, int IsActive)
        {
            string sql = "select ui.UserCode,ui.UserName,ur.RoleName,ui.Description,IsActive = case ui.IsActive when 1 then '是' when 0 then '否' end  from Sys_User_Info ui join Sys_User_Role ur on ui.UserRole = ur.RoleCode where 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if(!string.IsNullOrEmpty(UserCode))
            {
                sql += " AND ui.UserCode LIKE @UserCode ";
                
                parameter.Add("UserCode", string.Format("%{0}%",UserCode));
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                sql += " AND ui.UserName LIKE @UserName";
                parameter.Add("UserName", string.Format("%{0}%", UserName));
            }
            return _mltiTableQueryRepository.QueryList<UserInfoEntity>(sql, parameter).ToList();
        }
        public bool InsertUserInfo(Sys_User_Info userInfo)
        {
            userInfo.PassWord = CommonHelper.GetMd5(userInfo.PassWord);
            return _userManageRepository.InsertUserInfo(userInfo);
        }
    }
}
