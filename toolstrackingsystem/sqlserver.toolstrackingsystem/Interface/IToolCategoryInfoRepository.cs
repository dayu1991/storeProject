using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolCategoryInfoRepository:IRepositoryBase<t_ToolCategoryInfo>
    {
        List<t_ToolCategoryInfo> GetCategoryByClassify(int classifyType);
    }
}
