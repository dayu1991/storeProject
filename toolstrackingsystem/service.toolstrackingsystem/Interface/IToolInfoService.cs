using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public interface IToolInfoService
    {
        /// <summary>
        /// 获取分类信息，配属信息
        /// </summary>
        /// <param name="classifyType">1：分类信息 2：配属信息</param>
        /// <returns></returns>
        List<t_ToolCategoryInfo> GetCategoryByClassify(int classifyType);
    }
}
