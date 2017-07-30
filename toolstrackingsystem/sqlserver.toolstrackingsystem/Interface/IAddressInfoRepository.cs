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
        /// 判断客户端地址是否存在列表里
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool GetAddressInfo(string address);
    }
}
