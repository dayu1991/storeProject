using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IMultiTableQueryRepository
    {
        IEnumerable<T> QueryList<T>(string strSql, DynamicParameters dynamicParams, out long recordCount, string strSqlCount, bool limitResultSetMaxCount = true) where T : class;
        IEnumerable<T> QueryList<T>(string strSql, DynamicParameters dynamicParams, bool limitResultSetMaxCount = true) where T : class;
        object ExcuteScalar(string strSql, Dapper.DynamicParameters dynamicParams);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        int ExcuteProcedure(string procedureName, Dapper.DynamicParameters dynamicParams);
    }
}
