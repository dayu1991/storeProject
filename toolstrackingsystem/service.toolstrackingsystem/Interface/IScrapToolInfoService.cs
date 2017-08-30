using Dapper;
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
        List<ToolInfoForScrapFrmEntity> GetToolInfoForScrapList(string toolCode,string packCode);
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
        List<t_ScrapToolInfo> GetScrapToolInfoList(string toolCode,string childTypeName);
        /// <summary>
        /// 查找满足条件的废除的工具信息(有分页)
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        List<t_ScrapToolInfo> GetScrapToolInfoList(string toolCode, string childTypeName, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 更新报废的工具备注
        /// </summary>
        /// <param name="scrapID"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        bool SetScrapToolRemark(string scrapID,string remark,string userCode);

    }
}
