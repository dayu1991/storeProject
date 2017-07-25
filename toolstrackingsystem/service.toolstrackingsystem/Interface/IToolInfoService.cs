using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem.view;

namespace service.toolstrackingsystem
{
    public interface IToolInfoService
    {
        /// <summary>
        /// 获取分类信息，配属信息
        /// </summary>
        /// <param name="classifyType">0:全部 1：分类信息 2：配属信息</param>
        /// <returns></returns>
        List<t_ToolType> GetCategoryByClassify(int classifyType);

        long AddToolInfo(t_ToolInfo toolInfo);

        /// <summary>
        /// 是否存在编号的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        bool IsExistsByCode(string toolCode);

        /// <summary>
        /// 获取工具列表
        /// </summary>
        /// <param name="blongValue"></param>
        /// <param name="categoryValue"></param>
        /// <param name="toolCode"></param>
        /// <param name="toolName"></param>
        /// <returns></returns>
        List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount);

        t_ToolInfo GetToolById(long ToolId);


        bool UpdateTool(t_ToolInfo entity);

        bool DelToolById(long ToolId);


        List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName);

        bool IsExistCategoryByName(string name, int classification);

        long AddCateGory(t_ToolType category);
    }
}
