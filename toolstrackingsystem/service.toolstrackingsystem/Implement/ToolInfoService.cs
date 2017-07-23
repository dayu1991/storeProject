using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem.view;

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
        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName,pageIndex,pageSize,out totalCount);
        }
        public t_ToolInfo GetToolById(long ToolId)
        {
            return _toolInfoRepository.GetToolById(ToolId);
        }
        public bool UpdateTool(t_ToolInfo entity)
        {
            return _toolInfoRepository.UpdateTool(entity);
        }

        public bool DelToolById(long ToolId)
        {
            return _toolInfoRepository.DelToolById(ToolId);
        }
        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName);
        }
        public bool IsExistCategoryByName(string name, int classification)
        {
            return _toolCategoryInfoRepository.IsExistCategoryByName(name, classification);

        }
        public long AddCateGory(t_ToolCategoryInfo category)
        {
            return _toolCategoryInfoRepository.Add(category);

        }



    }
}
