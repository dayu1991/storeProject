using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IScrapToolInfoService
    {
        /// <summary>
        /// 通过工具编码精确查找工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        List<ToolInfoForScrapFrmEntity> GetToolInfoForScrapList(string toolCode);
        /// <summary>
        /// 作废单个工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        t_ScrapToolInfo ScrapTool(string toolCode, string optionPerson);
        /// <summary>
        /// 查找满足条件的废除的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        List<ScrapToolInfoEntity> GetScrapToolInfoList(string toolCode);
    }
}
