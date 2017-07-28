using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace common.toolstrackingsystem
{
    public class CommonHelper
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns>加密结果</returns>
        public static string GetMd5(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            string encoded = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(input))).Replace("-", "");
            return encoded;
        }
        /// <summary>
        /// 取得配置文件中的appSettings值
        /// </summary>
        /// <param name="sKey">appSettings key值</param>
        /// <returns>value值</returns>
        public static string GetConfigValue(string sKey)
        {
            string sValue = null;
            if ((sValue = System.Configuration.ConfigurationManager.AppSettings[sKey]) == null)
            {
                sValue = "";
            }
            return sValue;
        }
    }
}
