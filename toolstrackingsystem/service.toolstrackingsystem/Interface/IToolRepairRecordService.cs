using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IToolRepairRecordService
    {
        List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo, int pageIndex, int pageSize, out long Count);
        List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo);
        /// <summary>
        /// 获取送修工具待接收的信息
        /// </summary>
        /// <param name="t_ToolRepairRecord"></param>
        /// <returns></returns>
        List<RepairedToolForReceiveEntity> GetRepairedToolForReceive(t_ToolRepairRecord repairedInfo);
        /// <summary>
        /// 获取报废的工具列表
        /// </summary>
        /// <param name="repairedInfo"></param>
        /// <returns></returns>
        List<ToolScrapedEntity> GetRepairedToolRorScrap(t_ToolRepairRecord repairedInfo);
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
        /// <summary>
        /// 更新维修表工具信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateToolRepairInfo(t_ToolRepairRecord entity);
        /// <summary>
        /// 通过主键ID获取维修工具信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        t_ToolRepairRecord GetToolRepairByToolCodeById(int id);
    }
}
