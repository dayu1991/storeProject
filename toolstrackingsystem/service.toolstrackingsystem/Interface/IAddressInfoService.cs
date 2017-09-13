using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IAddressInfoService
    {
        List<Sys_AddressInfo> GetAddressList();
        bool IsExistAddress(string address);
        /// <summary>
        /// 插入地址
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <returns></returns>
        bool InsertAddressInfo(Sys_AddressInfo addressInfo);
        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <returns></returns>
        bool UpdateAddressInfo(Sys_AddressInfo addressInfo);
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        bool DeleteAddressInfo(string macAddress);
        Sys_AddressInfo GetAddressInfoByMac(string macAddress);
        List<AddressInfoEntity> GetAddressList(string macAddress);
    }
}
