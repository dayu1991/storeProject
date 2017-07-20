using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class ToolInfoRepository : RepositoryBase<t_ToolInfo>, IToolInfoRepository
    {
        public bool IsExistsByCode(string toolCode)
        {
            string sql = "select count(1) from t_ToolInfo where ToolCode=@ToolCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ToolCode", toolCode);
            var result = ExcuteScalar(sql, parameters);
            if (result != null && !string.IsNullOrWhiteSpace(result.ToString()))
            {
                int resultInt =0;
                if (int.TryParse(result.ToString(),out resultInt))
                {
                    return resultInt > 0;
                }
                else{
                    return false;
                }
            }
            return false;
        }
        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName)
        {
            List<t_ToolInfo> list = new List<t_ToolInfo>();
            string sql = @"select * from [dbo].[t_ToolInfo] where 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (blongValue>0)
            {
                sql += " and  [ToolBelongId]=@ToolBelongId";
                parameters.Add("ToolBelongId", blongValue);

            }
            if (categoryValue > 0)
            {
                sql += " and [ToolCategoryId] =@ToolCategoryId";
                parameters.Add("ToolCategoryId", categoryValue);
            }
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                sql += string.Format(" and [ToolCode] LIKE '%{0}%'", "@ToolCode");
                parameters.Add("ToolCode", toolCode);

            }
            if (!string.IsNullOrEmpty(toolName))
            {
                sql += string.Format(" and [ToolName] LIKE '%{0}%'", "@ToolName");
                parameters.Add("ToolName", toolName);
            }
            sql += "order by [AddTime] desc";
            return base.QueryList(sql, parameters).ToList();
        }

    }
}
