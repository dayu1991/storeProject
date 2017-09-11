using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolRepairRecordRepository:IRepositoryBase<t_ToolRepairRecord>
    {
        List<t_ToolRepairRecord> GetToolRepairRecordByToolCode(string toolCode, string TypeName,int pageIndex,int pageSize,out long Count);

        /// <summary>
        /// 获取送修工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="isReceived"></param>
        /// <returns></returns>
        t_ToolRepairRecord GetToolRepairByCodeNotReceived(string toolCode);

    }
}
