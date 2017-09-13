using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbentity.toolstrackingsystem;
using Dapper;

namespace sqlserver.toolstrackingsystem
{
    public class OutBackStoreRepository : RepositoryBase<t_OutBackStore>, IOutBackStoreRepository
    {
        public t_OutBackStore GetToolOutByCode(string toolCode)
        {
            string sql = "select * from [dbo].[t_OutBackStore] where IsBack='0' AND [ToolCode]=@ToolCode ";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolCode", toolCode);
            return GetModel(sql, sqlDy);
        }

        public bool IsExistsByCode(string toolCode,string isReturn)
        {
            string sql = "select count(1) from t_ToolInfo where ToolCode=@ToolCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ToolCode", toolCode);
            if (string.IsNullOrWhiteSpace(isReturn))
            {
                sql += " AND IsBack =@IsBack";
                parameters.Add("@IsBack", isReturn);
            }
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
