using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem.view;

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
        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount)
        {
            List<t_ToolInfo> list = new List<t_ToolInfo>();
            string sql = @"select * from (
       select *,ROW_NUMBER() OVER (ORDER BY [ToolId] desc) as rank from [dbo].[t_ToolInfo]  where 1=1 {0}
)  as t where  t.rank between @startPos and @endPos ";
            string sqlCount = "select count(1) from [dbo].[t_ToolInfo] where 1=1 {0}";
            string sqlWhere = "";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("startPos", ((pageIndex - 1) * pageSize + 1));
            parameters.Add("endPos", pageIndex*pageSize);

            if (!string.IsNullOrWhiteSpace(blongValue))
            {
                sqlWhere += " and  [TypeName]=@TypeName";
                parameters.Add("TypeName", blongValue);

            }
            if (!string.IsNullOrWhiteSpace(categoryValue))
            {
                sqlWhere += " and [ChildTypeName] =@ChildTypeName";
                parameters.Add("ChildTypeName", categoryValue);
            }
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                //sqlWhere += string.Format(" and [ToolCode] LIKE '%{0}%'", "@ToolCode");
                //parameters.Add("ToolCode", toolCode);
                #region 解决工具编码查询不到数据的问题
                sqlWhere += " and [ToolCode] LIKE @ToolCode";
                parameters.Add("ToolCode", string.Format("%{0}%", toolCode));
                #endregion

            }
            if (!string.IsNullOrEmpty(toolName))
            {
                //sqlWhere += string.Format(" and [ToolName] LIKE '%{0}%'", "@ToolName");
                //parameters.Add("ToolName", toolName);
                #region 解决工具编码查询不到数据的问题
                sqlWhere += " and [ToolName] LIKE @ToolName";
                parameters.Add("ToolName", string.Format("%{0}%", toolName));
                #endregion
            }
            sql= string.Format(sql,sqlWhere);
            sqlCount = string.Format(sqlCount, sqlWhere);

            var result = base.QueryList(sql, parameters, out totalCount, sqlCount, false);
            return result.Any() ? result.ToList() : new List<t_ToolInfo>();
        }
        public t_ToolInfo GetToolByCode(string ToolCode)
        {
            string sql = "select * from [dbo].[t_ToolInfo] where [ToolCode]=@ToolCode";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolCode", ToolCode);
            return GetModel(sql, sqlDy);
        }

        public bool UpdateTool(t_ToolInfo entity)
        {
            return Update(entity);
           
        }
        public bool DelToolByCode(string ToolCode)
        {
            string sql = "delete from [dbo].[t_ToolInfo] where [ToolCode]=@ToolCode";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolCode", ToolCode);
            var result =  ExcuteScalar(sql, sqlDy);
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

        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName)
        {
            List<t_ToolInfo> list = new List<t_ToolInfo>();
            string sql = @"select * from [dbo].[t_ToolInfo]  where 1=1 {0} ORDER BY [ToolId] desc";
            string sqlWhere = "";
            DynamicParameters parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(blongValue))
            {
                sqlWhere += " and  [TypeName]=@TypeName";
                parameters.Add("TypeName", blongValue);

            }
            if (!string.IsNullOrWhiteSpace(categoryValue))
            {
                sqlWhere += " and [ChildTypeName] =@ChildTypeName";
                parameters.Add("ChildTypeName", categoryValue);
            }
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                sqlWhere += string.Format(" and [ToolCode] LIKE '%{0}%'", "@ToolCode");
                parameters.Add("ToolCode", toolCode);

            }
            if (!string.IsNullOrEmpty(toolName))
            {
                sqlWhere += string.Format(" and [ToolName] LIKE '%{0}%'", "@ToolName");
                parameters.Add("ToolName", toolName);
            }
            sql = string.Format(sql, sqlWhere);

            var result = base.QueryList(sql, parameters);
            return result.Any() ? result.ToList() : new List<t_ToolInfo>();
        }



    }
}
