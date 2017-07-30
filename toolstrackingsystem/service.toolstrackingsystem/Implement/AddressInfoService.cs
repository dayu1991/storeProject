using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class AddressInfoService : IAddressInfoService
    {
        private readonly IAddressInfoRepository _addressInfoRepository;
        public AddressInfoService(IAddressInfoRepository addressInfoRepository)
        {
            this._addressInfoRepository = addressInfoRepository;
        }
        public List<Sys_AddressInfo> GetAddressList()
        {
            return _addressInfoRepository.GetAddressList();
        }
        public bool IsExistAddress(string address)
        {
            return _addressInfoRepository.GetAddressInfo(address);
        }
    }
}
