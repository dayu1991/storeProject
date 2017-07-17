using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class MultiTableQueryRepository : IMultiTableQueryRepository
    {
        public IEnumerable<T> QueryList<T>(string strSql, Dapper.DynamicParameters dynamicParams, out long recordCount, string strSqlCount, bool limitResultSetMaxCount = true) where T : class
        {
            RepositoryBase<T> repositoryBase = new RepositoryBase<T>();
            return repositoryBase.QueryList(strSql, dynamicParams, out  recordCount, strSqlCount, limitResultSetMaxCount);

        }

        public IEnumerable<T> QueryList<T>(string strSql, Dapper.DynamicParameters dynamicParams, bool limitResultSetMaxCount = true) where T : class
        {
            RepositoryBase<T> repositoryBase = new RepositoryBase<T>();
            return repositoryBase.QueryList(strSql, dynamicParams, limitResultSetMaxCount);
        }

        public object ExcuteScalar(string strSql, Dapper.DynamicParameters dynamicParams)
        {
            RepositoryBase<object> repositoryBase = new RepositoryBase<object>();
            return repositoryBase.ExcuteScalar(strSql, dynamicParams);
        }

        public int ExcuteProcedure(string procedureName, Dapper.DynamicParameters dynamicParams)
        {
            RepositoryBase<object> repositoryBase = new RepositoryBase<object>();
            return repositoryBase.ExcuteProcedure(procedureName, dynamicParams);
        }
    }
}
