using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolRepairRecordRepository : IRepositoryBase<t_ToolRepairRecord>
    {
        List<t_ToolRepairRecord> GetToolRepairRecordByToolCode(string toolCode, string TypeName,int pageIndex,int pageSize,out long Count);

        /// <summary>
        /// 获取送修工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="isReceived"></param>
        /// <returns></returns>
        t_ToolRepairRecord GetToolRepairByCodeNotReceived(string toolCode);
        /// <summary>
        /// 更新送修工具状态为接收
        /// </summary>
        /// <param name="repairInfo"></param>
        /// <returns></returns>
        bool UpdateToolReceiveStatus(t_ToolRepairRecord repairInfo);
        /// <summary>
        /// 根据工具编码和状态获取送修记录
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        t_ToolRepairRecord GetToolRepairByToolCodeAndStatus(string toolCode, int status = 0);

    }
}
