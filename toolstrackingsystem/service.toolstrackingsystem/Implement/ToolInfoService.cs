using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
   public class ToolInfoService:IToolInfoService
    {
       private IToolCategoryInfoRepository _toolCategoryInfoRepository;
       private IToolInfoRepository _toolInfoRepository;
        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolInfoService(IToolCategoryInfoRepository toolCategoryInfoRepository,
            IToolInfoRepository toolInfoRepository, 
            IMultiTableQueryRepository multiTableQueryRepository)
       {
           _toolCategoryInfoRepository = toolCategoryInfoRepository;
           _toolInfoRepository = toolInfoRepository;
           _multiTableQueryRepository = multiTableQueryRepository;
       }

        public List<t_ToolCategoryInfo> GetCategoryByClassify(int classifyType)
        {
            return _toolCategoryInfoRepository.GetCategoryByClassify(classifyType);
        }
        public long AddToolInfo(t_ToolInfo toolInfo)
        {
            return _toolInfoRepository.Add(toolInfo);
        }

        /// <summary>
        /// 是否存在编号的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public bool IsExistsByCode(string toolCode)
        {
            return _toolInfoRepository.IsExistsByCode(toolCode);
        }

        /// <summary>
        /// 获取工具列表
        /// </summary>
        /// <param name="blongValue"></param>
        /// <param name="categoryValue"></param>
        /// <param name="toolCode"></param>
        /// <param name="toolName"></param>
        /// <returns></returns>
        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName);
        }
    }
}
