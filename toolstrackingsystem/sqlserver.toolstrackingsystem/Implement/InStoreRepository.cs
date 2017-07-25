using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class InStoreRepository : RepositoryBase<t_InStore>, IInStoreRepository
    {
        public bool IsExistsInStoryByCode(string toolCode)
        {
            string sql = "select count(1) from [dbo].[t_InStore] where [ToolCode]=@ToolCode";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ToolCode", toolCode);
           
            var result = ExcuteScalar(sql, parameters);
            if (result != null && !string.IsNullOrWhiteSpace(result.ToString()))
            {
                int resultInt = 0;
                if (int.TryParse(result.ToString(), out resultInt))
                {
                    return resultInt > 0;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}
