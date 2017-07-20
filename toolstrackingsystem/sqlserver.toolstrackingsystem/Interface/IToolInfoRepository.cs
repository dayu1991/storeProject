using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolInfoRepository : IRepositoryBase<t_ToolInfo>
    {
        /// <summary>
        /// 是否存在编号的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        bool IsExistsByCode(string toolCode);

        List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName);
    }
}
