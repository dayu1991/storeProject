using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IAddressInfoRepository:IRepositoryBase<Sys_AddressInfo>
    {
        /// <summary>
        /// 获取加密地址列表
        /// </summary>
        /// <returns></returns>
        List<Sys_AddressInfo> GetAddressList();
        /// <summary>
        /// 获取加密地址列表
        /// </summary>
        /// <returns></returns>
        List<Sys_AddressInfo> GetAddressList(string macAddress);
        /// <summary>
        /// 判断客户端地址是否存在列表里
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool GetAddressInfo(string address);
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
    }
}
