using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolCategoryInfoRepository:IRepositoryBase<t_ToolType>
    {
        List<t_ToolType> GetCategoryByClassify(int classifyType, string name = "");

        bool IsExistCategoryByName(string name, int classification);

        t_ToolType GetModelById(string SelectedToolCode);

        bool DelTypeById(string SelectedToolCode);
    }
}
