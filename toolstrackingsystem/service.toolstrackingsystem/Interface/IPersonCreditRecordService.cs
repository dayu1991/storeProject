using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IPersonCreditRecordService
    {
        /// <summary>
        /// 获取人员信用分页信息
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<PersonCreditRecordEntity> GetPersonCreditRecordList(t_PersonCreditRecord personInfo,int pageIndex,int pageSize,out long Count);
        /// <summary>
        /// 获取人员信用导出信息
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<PersonCreditRecordEntity> GetPersonCreditRecordList(t_PersonCreditRecord personInfo);
    }
}
