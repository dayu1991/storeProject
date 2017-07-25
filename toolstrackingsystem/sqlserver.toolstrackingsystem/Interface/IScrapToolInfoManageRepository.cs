using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IScrapToolInfoManageRepository:IRepositoryBase<t_ScrapToolInfo>
    {
        bool InsertScrapToolInfo(t_ScrapToolInfo scrapToolInfo);
    }
}
