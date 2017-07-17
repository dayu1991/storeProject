using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    /// <summary>
    /// 仓库管理系统连接对象Connection
    /// </summary>
    public class CKConnection
    {
        private static string defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MPConnection"].ConnectionString;
        public static IDbConnection GetConnection()
        {
            return new SqlConnection(defaultConnectionString);
        }
        /// <summary>
        /// 自定义数据库连接字符串的Mysql库连接对象
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IDbConnection GetConnection(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                return (SqlConnection)null;
            }
            //return new MySql.Data.MySqlClient.MySqlConnection(defaultConnectionConfig);
        }
        /// <summary>
        /// 根据配置链接字符串的Key名称获取Mysql库连接对象
        /// </summary>
        /// <param name="connectionStringKeyName"></param>
        /// <returns></returns>
        public static IDbConnection GetConnectionByKey(string connectionStringKeyName)
        {
            if (!string.IsNullOrEmpty(connectionStringKeyName))
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringKeyName].ConnectionString;
                if (!string.IsNullOrEmpty(connString))
                {
                    return new SqlConnection(connectionStringKeyName);
                }
                return (SqlConnection)null;

            }
            else
            {
                return (SqlConnection)null;
            }
        }
    }
}
