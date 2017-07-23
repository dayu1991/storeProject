using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbentity.toolstrackingsystem;
using Dapper;

namespace sqlserver.toolstrackingsystem
{
    public class ToolCategoryInfoRepository : RepositoryBase<t_ToolCategoryInfo>, IToolCategoryInfoRepository
    {
        public List<t_ToolCategoryInfo> GetCategoryByClassify(int classifyType)
        {
            string sql = "select * from t_ToolCategoryInfo where 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (classifyType > 0)
            {
                sql += "AND [Classification]=@Classification  ";
                parameter.Add("Classification", classifyType);
            }
            var result = QueryList(sql, parameter);
            if (result.Any())
            {
                return result.ToList();
            }
            return new List<t_ToolCategoryInfo>();
        }
        public bool IsExistCategoryByName(string name, int classification)
        {
            string sql = "select count(1) from [t_ToolCategoryInfo] where [CategoryName]=@CategoryName ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CategoryName", name);
            if (classification > 0)
            {
                sql += " and [Classification]=@Classification";
                parameters.Add("@Classification", classification);
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
