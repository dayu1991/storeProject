using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;
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
        List<t_ToolType> GetCategoryByClassify(int classifyType, string name = "");

        long AddToolInfo(t_ToolInfo toolInfo, string OptionType);

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
        List<ToolInfoExtend> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName, bool is_Out_checkBox, bool is_OutTime_checkBox, bool is_ToRepare_checkBox, string cbCheckTime, int pageIndex, int pageSize, out long totalCount);

        t_ToolInfo GetToolByCode(string Toolcode);
        List<t_ToolInfo> GetToolByCodeOrPackCode(string code);


        bool UpdateTool(t_ToolInfo entity);

        bool DelToolByCode(string ToolId);


        List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName);

        bool IsExistCategoryByName(string name, int classification);

        long AddCateGory(t_ToolType category);


        bool OutStore(t_ToolInfo entity, t_PersonInfo person, string userCode, string toDate, string describ);

        t_OutBackStore GetToolOutByCode(string toolCode);

        bool IsExistsOutStoreByCode(string toolcode, string isBack);

        bool BackStore(OutBackStoreEntity entity, t_PersonInfo person, string opeartPerson, string desc);
        List<ToolInfoForStockInfoEntity> GetToolInfoListForStock(t_ToolInfo toolInfo, int pageIndex, int pageSize, out long totalCount);
        List<CountToolInfoEntity> GetCountInToolInfo(t_ToolInfo toolInfo);
        List<ToolInfoForStockInfoEntity> GetToolInfoListForStock(t_ToolInfo toolInfo);
        List<ToolInfoForRepairEntity> GetToolInfoForRepair(string toolCode, int pageIndex, int pageSize, out long totalCount);
        bool UpdateToolRepared(string toolCode, string userCode);
        bool UpdateToolReparedIsActive(string toolCode, string userCode);

        /// <summary>
        /// 导入工具
        /// </summary>
        /// <param name="InfoList"></param>
        /// <returns></returns>
        bool ImportToolInfoExcel(List<t_ToolInfo> InfoList);


        bool UpdateType(t_ToolType type);


        bool DelTypeById(string SelectedToolCode);

        t_ToolType GetCategoryById(string SelectedToolCode);

        bool IsExistToolByType(string p1, int p2);
        /// <summary>
        /// 查询工具包的分页信息
        /// </summary>
        /// <param name="packCode"></param>
        /// <param name="packName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<ToolPackViewEntity> GetPackInfoList(string packCode, string packName, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 查询工具包的导出信息
        /// </summary>
        /// <param name="packCode"></param>
        /// <param name="packName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<ToolPackViewEntity> GetPackInfoList(string packCode, string packName);


        ToolInfoExtend GetToolInfoExtend(string toolCode);


        bool ToRepaireTool(t_ToolInfo tool);
    }
}