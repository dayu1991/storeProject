using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class ScrapToolInfoService : IScrapToolInfoService
    {
        private readonly IScrapToolInfoManageRepository _scrapToolInfoManageRepository;
        public ScrapToolInfoService(IScrapToolInfoManageRepository scrapToolInfoManageRepository)
        {
            this._scrapToolInfoManageRepository = scrapToolInfoManageRepository;
        }
    }
}
