using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.toolstrackingsystem
{
    /// <summary>
    /// 仓库管理系统连接对象Connection
    /// </summary>
    public class ConnectionHelper
    {
        public static string defaultConnectionString = MemoryCacheHelper.GetConnectionStr();
      
    }
}
