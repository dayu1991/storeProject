using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace common.toolstrackingsystem
{
    public class MemoryCacheHelper
    {
        private static object clientName = MemoryCache.Default["clientName"];
        public static string GetConnectionStr() {
            if (clientName != null)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[clientName.ToString()].ConnectionString;
            }
            return System.Configuration.ConfigurationManager.ConnectionStrings[CommonHelper.GetConfigValue("defaultDataBase")].ConnectionString;
            //return System.Configuration.ConfigurationManager.ConnectionStrings["ShiJiaZhuang"].ConnectionString;
        }
        public static bool SetMemoryCache(string connName) {
            if (string.IsNullOrEmpty(connName))
            {
                return false;
            }
            else {
                ObjectCache oCache = MemoryCache.Default;
                object fileContents = oCache["clientName"];
                CacheItemPolicy policy = new CacheItemPolicy();
                //policy.AbsoluteExpiration = DateTime.Now.AddMinutes(120);//取得或设定值，这个值会指定是否应该在指定期间过后清除

                fileContents = connName; //这里赋值;
                oCache.Set("clientName", fileContents, policy);
                return true;
            }
        }
    }
}
