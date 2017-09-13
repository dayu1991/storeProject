using common.toolstrackingsystem;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    /// <summary>
    /// 仓库管理系统连接对象Connection
    /// </summary>
    public class CKConnection
    {
        private static string defaultConnectionString = MemoryCacheHelper.GetConnectionStr();
        public static IDbConnection GetConnection()
        {
            #region 判断cache里是否有设置好的客户端连接字符串
            if (MemoryCache.Default.Get("clientName") != null)
            {
                string connName = MemoryCache.Default.Get("clientName").ToString();
                defaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            #endregion
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
