using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbentity.toolstrackingsystem;
using Dapper;

namespace sqlserver.toolstrackingsystem
{
    public class AddressInfoRepository : RepositoryBase<Sys_AddressInfo>, IAddressInfoRepository
    {
        public List<Sys_AddressInfo> GetAddressList()
        {
            string sql = "SELECT * FROM Sys_AddressInfo WHERE IsActive=1";
            DynamicParameters parameter = new DynamicParameters();
            return base.QueryList(sql,parameter).ToList();
        }
        public bool GetAddressInfo(string address)
        {
            string sql = "SELECT * FROM Sys_AddressInfo WHERE IsActive=1 AND Address=@address";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("address",address);
            if (base.GetModel(sql, parameter) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 插入地址
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <returns></returns>
        public bool InsertAddressInfo(Sys_AddressInfo addressInfo)
        {
            return base.Add(addressInfo)>0;
        }
        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <returns></returns>
        public bool UpdateAddressInfo(Sys_AddressInfo addressInfo)
        {
            return base.Update(addressInfo);
        }
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public bool DeleteAddressInfo(string macAddress)
        {
            string sql = "DELETE FROM Sys_AddressInfo WHERE MacAddress = @macAddress";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("macAddress",macAddress);
            return base.ExecuteSql(sql,parameter)>0;
        }
        public Sys_AddressInfo GetAddressInfoByMac(string macAddress)
        {
            string sql = "SELECT * FROM Sys_AddressInfo WHERE MacAddress = @macAddress";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("macAddress", macAddress);
            return base.GetModel(sql,parameter);
        }
        public List<Sys_AddressInfo> GetAddressList(string macAddress)
        {
            string sql = @"SELECT [MacAddress]
                                  ,[Address]
                                  ,[IsActive] = case [IsActive] when 1 then '是' when 0 then '否' end
                            FROM [dbo].[Sys_AddressInfo] LIKE @macAddress";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(macAddress))
            {
                parameter.Add("macAddress", string.Format("%{0}%", macAddress));
            }
            return base.QueryList(sql, parameter).ToList();
        }
    }
}
