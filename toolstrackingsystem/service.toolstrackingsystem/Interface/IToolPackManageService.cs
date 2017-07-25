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
        List<t_ToolInfo> GetToolInfoInPack(t_ToolInfo toolInfo);
        t_ToolInfo GetToolInfoByToolCode(string toolCode);
        bool CompleteToolPack(List<ToolInfoForPackEntity> toolInfoList,string packCode,string packName);
    }
}
