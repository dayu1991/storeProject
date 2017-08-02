using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
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
        /// <summary>
        /// 获取当前的mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return mac;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }
        /// <summary>
        /// list转换为DataSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSet<T>(this List<T> list)
        {
            Type elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable();
            ds.Tables.Add(t);
            elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
            foreach (T item in list)
            {
                var row = t.NewRow();
                elementType.GetProperties().ToList().ForEach(propInfo => row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value);
                t.Rows.Add(row);
            }
            return ds;
        }
    }
}
