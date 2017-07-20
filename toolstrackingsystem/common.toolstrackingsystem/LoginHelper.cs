using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using dbentity.toolstrackingsystem;

namespace common.toolstrackingsystem
{

    public class LoginHelper
    {

        private static Sys_User_Info userInfo = MemoryCache.Default["userinfo"] as Sys_User_Info;

        public static int ID { get { return userInfo.ID; } }
        public static string UserCode { get { return userInfo.UserCode; } }
        public static string UserName { get { return userInfo.UserName; } }
        public static string Description { get { return userInfo.Description; } }
        public static Nullable<System.DateTime> CreateTime { get { return userInfo.CreateTime; } }
        public static string UserRole { get { return userInfo.UserRole; } }
    }
}
