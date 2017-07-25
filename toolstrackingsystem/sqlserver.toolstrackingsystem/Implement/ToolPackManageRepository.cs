using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace sqlserver.toolstrackingsystem
{
    public class ToolPackManageRepository : RepositoryBase<t_ToolInfo>, IToolPackManageRepository
    {
    }
}
