using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IToolPrepairRecordService
    {
        List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo, int pageIndex, int pageSize, out long Count);
        List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo);

    }
}
