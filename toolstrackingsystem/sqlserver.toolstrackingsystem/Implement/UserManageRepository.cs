using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class UserManageRepository : RepositoryBase<Sys_User_Info>, IUserManageRepository
    {
        /// <summary>
        /// 通过用户名，密码获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode, string Password)
        {
            Sys_User_Info entity = new Sys_User_Info();
            string sql = "SELECT * FROM Sys_User_Info WHERE UserCode=@UserCode AND PassWord = @Password";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@UserCode", UserCode);
            parameter.Add("@Password", Password);

            entity = base.GetModel(sql, parameter);

            return entity;
        }
        /// <summary>
        /// 通过用户名查询用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public Sys_User_Info GetUserInfo(string UserCode)
        {
            Sys_User_Info entity = new Sys_User_Info();
            string sql = "SELECT * FROM Sys_User_Info WHERE UserCode=@UserCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("UserCode", UserCode);

            entity = base.GetModel(sql, parameter);

            return entity;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int InsertUserInfo(string UserCode,string UserName, string Password, out Sys_User_Info userInfo)
        {
            Sys_User_Info userinfo = new Sys_User_Info();
            userinfo.UserName = UserName;
            userinfo.PassWord = Password;
            //userinfo.Create_Time = DateTime.Now;
            userinfo.IsActive = 1;
            userInfo = userinfo;
            //return base.ExecuteSql(sql,parameters);
            return (int)base.Add(userinfo);
        }
        /// <summary>
        /// 获取满足条件的所有用户列表
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public List<Sys_User_Info> GetUserInfoList(string UserCode, string DateTimeFrom, string DateTimeTo)
        {
            List<Sys_User_Info> list = new List<Sys_User_Info>();
            string sql = "SELECT * FROM Sys_User_Info WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(UserCode))
            {
                sql += string.Format(" AND UserCode LIKE '%{0}%'", UserCode);
            }
            if (!string.IsNullOrEmpty(DateTimeTo))
            {
                sql += " AND CreateTime<=@DateTimeTo";
                parameters.Add("DateTimeTo", DateTimeTo);
            }
            return base.QueryList(sql, parameters).ToList();
        }
        /// <summary>
        /// 更新对应的用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Sys_User_Info userInfo)
        {
            string sql = "UPDATE Sys_User_Info SET UserName = @username,UserRole=@userrole,Description = @description ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(userInfo.PassWord))
            {
                sql += ",Password = @Password ";
                parameters.Add("Password",userInfo.PassWord);
            }
            sql += "WHERE UserCode = @usercode";
            parameters.Add("username", userInfo.UserName);
            parameters.Add("userrole", userInfo.UserRole);
            parameters.Add("description", userInfo.Description);
            parameters.Add("usercode",userInfo.UserCode);
            return base.ExecuteSql(sql,parameters)>0;
        }
        /// <summary>
        /// 删除某个用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool DeleteUser(Sys_User_Info userInfo)
        {
            string sql = "DELETE FROM Sys_User_Info WHERE ID=@id";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("id", userInfo.UserCode);
            return base.ExecuteSql(sql, parameter) > 0;
        }


        public bool InsertUserInfo(Sys_User_Info userInfo)
        {
            return base.Add(userInfo)>0;
        }
    }
}
