using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace sqlserver.toolstrackingsystem
{
    public class ToolCategoryInfoRepository : RepositoryBase<t_ToolType>, IToolCategoryInfoRepository
    {
        public List<t_ToolType> GetCategoryByClassify(int classifyType)
        {
            string sql = "select * from t_ToolType where 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (classifyType > 0)
            {
                sql += "AND [classification]=@Classification  ";
                parameter.Add("Classification", classifyType);
            }
            var result = QueryList(sql, parameter);
            if (result.Any())
            {
                return result.ToList();
            }
            return new List<t_ToolType>();
        }
        public bool IsExistCategoryByName(string name, int classification)
        {
            string sql = "select count(1) from [t_ToolType] where [TypeName]=@TypeName ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TypeName", name);
            if (classification > 0)
            {
                sql += " and [classification]=@classification";
                parameters.Add("@classification", classification);
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
