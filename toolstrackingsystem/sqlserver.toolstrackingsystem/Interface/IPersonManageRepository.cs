using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IPersonManageRepository:IRepositoryBase<t_PersonInfo>
    {
        bool InsertPersonInfo(t_PersonInfo personInfo);
        t_PersonInfo GetPersonInfoByPersonCode(string personCode);
        bool UpdatePersonInfo(t_PersonInfo personInfo);
        bool DeletePersonInfo(string peronCode);
    }
}
