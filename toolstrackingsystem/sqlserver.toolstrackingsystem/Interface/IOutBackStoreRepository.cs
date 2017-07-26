using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbentity.toolstrackingsystem;
using Dapper;

namespace sqlserver.toolstrackingsystem
{
    public interface IOutBackStoreRepository:IRepositoryBase<t_OutBackStore>
    {
        t_OutBackStore GetToolOutByCode(string toolCode);
        bool IsExistsByCode(string toolCode, string isReturn);

    }
}
