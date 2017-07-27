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
    public class PersonCreditRecordService:IPersonCreditRecordService
    {
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        public PersonCreditRecordService(IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._mutiTableQueryRepository = multiTableQueryRepository;
        }
        /// <summary>
        /// 获取人员信用分页信息
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<PersonCreditRecordEntity> GetPersonCreditRecordList(t_PersonCreditRecord personInfo, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT TOP "+pageSize+@" [PackCode]
                                  ,[PackName]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[PersonCode]
                                  ,[PersonName]
                                  ,[OutStoreTime]
                                  ,[UserTimeInfo]
                                  ,[OptionPerson]
                                  ,[OptionTime]
                              FROM [dbo].[t_PersonCreditRecord] WHERE 1=1";
            string sqlNotStr = "CreditID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " CreditID FROM [dbo].[t_PersonCreditRecord] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [dbo].[t_PersonCreditRecord] WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(personInfo.PersonCode))
            {
                string str = " AND PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", personInfo.PersonCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<PersonCreditRecordEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();

        }
    }
}
