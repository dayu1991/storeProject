using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolPrepairRecordRepository:IRepositoryBase<t_ToolRepairRecord>
    {
        t_ToolRepairRecord GetToolPrepairRecordByToolCode(string toolCode);
    }
}
