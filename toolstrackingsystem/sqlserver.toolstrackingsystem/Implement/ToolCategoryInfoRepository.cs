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
        public List<t_ToolType> GetCategoryByClassify(int classifyType, string name = "")
        {
            string sql = "select * from t_ToolType where 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (classifyType > 0)
            {
                sql += "AND [classification]=@Classification  ";
                parameter.Add("Classification", classifyType);
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += " and [TypeName] LIKE @TypeName";
                parameter.Add("TypeName", string.Format("%{0}%", name));
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
        public t_ToolType GetModelById(string SelectedToolCode)
        {
            string sql = "select * from [dbo].[t_ToolType] where [TypeID]=@TypeID";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("TypeID", SelectedToolCode);
            return GetModel(sql, sqlDy);
        }

        public bool DelTypeById(string SelectedToolCode)
        {
            string sql = "delete from [dbo].[t_ToolType] where [TypeID]=@TypeID";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("TypeID", SelectedToolCode);
            var result = ExcuteScalar(sql, sqlDy);
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
