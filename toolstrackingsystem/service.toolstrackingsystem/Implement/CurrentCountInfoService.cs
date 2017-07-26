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
    public class CurrentCountInfoService : ICurrentCountInfoService
    {
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        public CurrentCountInfoService(IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._mutiTableQueryRepository = multiTableQueryRepository;
        }
        /// <summary>
        /// 获取符合条件的工具信息
        /// </summary>
        /// <returns></returns>
        public List<CurrentToolInfoEntity> GeCurrentCountToolList(t_CurrentCountInfo countInfo, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT [TypeName]
                                  ,[ChildTypeName]
                                  ,[PackCode]
                                  ,[PackName]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[Models]
                                  ,[Location]
                                  ,[Remarks]
                                  ,[InStoreTime]
                                  ,[OutStoreTime]
                                  ,[BackTime]
                                  ,[OptionType]
                                  ,[PersonCode]
                                  ,[PersonName]
                                  ,[BackPesonCode]
                                  ,[BackPersonName]
                                  ,[describes]
                                  ,[OptionPerson]
                              FROM [dbo].[t_CurrentCountInfo] WHERE 1=1 ";
            string sqlNotStr = "CurrentCountID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " CurrentCountID FROM t_CurrentCountInfo WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM t_CurrentCountInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(countInfo.OptionType))
            {
                string str = " AND OptionType LIKE @optionType ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("optionType", string.Format("%{0}%", countInfo.OptionType));
            }
            if (!string.IsNullOrEmpty(countInfo.ToolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", countInfo.ToolCode));
            }
            if (!string.IsNullOrEmpty(countInfo.PersonCode))
            {
                string str = " AND PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", countInfo.PersonCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<CurrentToolInfoEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
    } 
}
