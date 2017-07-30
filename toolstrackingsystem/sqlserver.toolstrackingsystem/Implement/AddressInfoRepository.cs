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
    }
}
