using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface ICurrentCountInfoService
    {
        /// <summary>
        /// 获取符合条件的工具信息
        /// </summary>
        /// <returns></returns>
        List<CurrentToolInfoEntity> GeCurrentCountToolList(t_CurrentCountInfo countInfo, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 获取符合条件的导出工具信息
        /// </summary>
        /// <returns></returns>
        List<CurrentToolInfoEntity> GeCurrentCountToolList(t_CurrentCountInfo countInfo);
        /// <summary>
        /// 入库查询所需的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        List<ToolInfoInStoreEntity> GetToolInfoInStoreList(string toolCode, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 导出入库查询所需的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        List<ToolInfoInStoreEntity> GetToolInfoInStoreList(string toolCode);
    }
}
