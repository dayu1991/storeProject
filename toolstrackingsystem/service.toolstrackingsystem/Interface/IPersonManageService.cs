using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
     public interface IPersonManageService
    {
         /// <summary>
         /// 获取所有查找结果
         /// </summary>
         /// <param name="personInfo"></param>
         /// <returns></returns>
         List<PersonInfoEntity> GetPersonInfoList(PersonInfoEntity personInfo);
         /// <summary>
         /// 获取分页结果
         /// </summary>
         /// <param name="personInfo"></param>
         /// <returns></returns>
         List<PersonInfoEntity> GetPersonInfoList(PersonInfoEntity personInfo,int pageIndex,int pageSize,out long Count);
         bool InsertPersonInfo(t_PersonInfo personInfo);
         t_PersonInfo GetPersonInfo(string personCode);
         bool UpdatePersonInfo(t_PersonInfo personInfo);
         bool DeletePersonInfo(string personCode);

    }
}
