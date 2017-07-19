using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbentity.toolstrackingsystem;

namespace sqlserver.toolstrackingsystem
{
    public class ToolCategoryInfoRepository : RepositoryBase<t_ToolCategoryInfo>, IToolCategoryInfoRepository
    {
        public List<t_ToolCategoryInfo> GetCategoryByClassify(int classifyType)
    {
        return new List<t_ToolCategoryInfo>();
    }

    }
}
