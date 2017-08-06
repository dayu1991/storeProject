using Dapper;
using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public class AddressInfoService : IAddressInfoService
    {
        private readonly IAddressInfoRepository _addressInfoRepository;
        private readonly IMultiTableQueryRepository _multiTableQueryRepository;
        public AddressInfoService(IAddressInfoRepository addressInfoRepository, IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._addressInfoRepository = addressInfoRepository;
            this._multiTableQueryRepository = multiTableQueryRepository;
        }
        public List<Sys_AddressInfo> GetAddressList()
        {
            return _addressInfoRepository.GetAddressList();
        }
        public List<AddressInfoEntity> GetAddressList(string macAddress)
        {
            string sql = @"SELECT [MacAddress]
                                  ,[Address]
                                  ,[IsActive] = case [IsActive] when 1 then '是' when 0 then '否' end
                            FROM [dbo].[Sys_AddressInfo] WHERE 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(macAddress))
            {
                sql += " AND LIKE @macAddress";
                parameter.Add("macAddress", string.Format("%{0}%", macAddress));
            }
            return _multiTableQueryRepository.QueryList<AddressInfoEntity>(sql,parameter).ToList();
        }
        public bool IsExistAddress(string address)
        {
            return _addressInfoRepository.GetAddressInfo(address);
        }
        public bool InsertAddressInfo(Sys_AddressInfo addressInfo)
        {
            return _addressInfoRepository.InsertAddressInfo(addressInfo);
        }
        public bool UpdateAddressInfo(Sys_AddressInfo addressInfo)
        {
            return _addressInfoRepository.Update(addressInfo);
        }
        public bool DeleteAddressInfo(string macAddress)
        {
            return _addressInfoRepository.DeleteAddressInfo(macAddress);
        }
        public Sys_AddressInfo GetAddressInfoByMac(string macAddress)
        {
            return _addressInfoRepository.GetAddressInfoByMac(macAddress);
        }
    }
}
