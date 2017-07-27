using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class ToolTypeService : IToolTypeService
    {
        private readonly IToolTypeRepository _toolTypeRepository;
        public ToolTypeService(IToolTypeRepository toolTypeRepository)
        {
            _toolTypeRepository = toolTypeRepository;
        }
        /// <summary>
        /// 获取工具配属信息
        /// </summary>
        /// <returns></returns>
        public List<t_ToolType> GetToolTypeList()
        {
            return _toolTypeRepository.GetToolTypeList();
        }
        /// <summary>
        /// 获取工具类别信息
        /// </summary>
        /// <returns></returns>
        public List<t_ToolType> GetToolChildTypeList()
        {
            return _toolTypeRepository.GetToolChildTypeList();
        }
    }
}
