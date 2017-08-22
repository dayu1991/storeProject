using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolPackManageRepository:IRepositoryBase<t_ToolInfo>
    {
        /// <summary>
        /// 更新工具的包编码，包名称
        /// </summary>
        /// <param name="toolInfo"></param>
        /// <returns></returns>
       bool UpdateToolPackInfo(t_ToolInfo toolInfo);
        /// <summary>
        /// 作废工具（更新工具的使用状态为0）
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
       bool UpdateToolStatus(string toolCode);
    }
}
