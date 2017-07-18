using Dapper;
using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public class MenuManageService:IMenuManageService
    {
        private IMenuManageRepository _menuManageRepository;
        public MenuManageService(IMenuManageRepository menuManageRepository)
        {
            this._menuManageRepository = menuManageRepository;
        }
        public List<Sys_Menu_Info> GetMenuInfoList() 
        {
            string sql = "SELECT * from Sys_Menu_Info WHERE 1=1";
            DynamicParameters parameters = new DynamicParameters();
            return _menuManageRepository.QueryList(sql, parameters).ToList() ;
        }
        public List<MenuInfoEntity> GetMenuTreeInfoList()
        {
            List<Sys_Menu_Info> MenuInfoList = new List<Sys_Menu_Info>();
            MenuInfoList = this.GetMenuInfoList();
            List<MenuInfoEntity> MenuInfoEntityList = new List<MenuInfoEntity>();
            var  result = from obj in MenuInfoList
                                          where obj.IsMain == "1"
                                          select obj;
            foreach (var item in result.ToList())
            {
                MenuInfoEntity menuInfoEntity = new MenuInfoEntity();
                menuInfoEntity.ParentMenuInfo = item;
                MenuInfoEntityList.Add(menuInfoEntity);
            }
            for (int i = 0; i < MenuInfoEntityList.Count; i++)
            {
                MenuInfoEntityList[i].ChildMenuInfoList = (from obj in MenuInfoList
                                                          where obj.GroupCode == MenuInfoEntityList[i].ParentMenuInfo.GroupCode&&obj.IsMain=="0"
                                                          select obj).ToList();
            }
                return MenuInfoEntityList;
        }
    }
}
