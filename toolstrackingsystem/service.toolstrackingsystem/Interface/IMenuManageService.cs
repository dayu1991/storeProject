using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IMenuManageService
    {
        List<MenuInfoEntity> GetMenuTreeInfoList();
        List<MenuInfoEntity> GetUserMenuInfoList(string MenuID);
    }
}
