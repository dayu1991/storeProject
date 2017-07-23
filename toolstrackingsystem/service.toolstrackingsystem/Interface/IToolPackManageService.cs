using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IToolPackManageService
    {
        List<ToolInfoForPackEntity> GetToolInfoForPack(t_ToolInfo toolInfo);
        bool DeletePackInfo(string packCode);
        t_ToolInfo GetToolInfoByToolCode(string toolCode);
        bool CompleteToolPack();
    }
}
