﻿using Dapper;
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
        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount)
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

            if (blongValue>0)
            {
                sqlWhere += " and  [ToolBelongId]=@ToolBelongId";
                parameters.Add("ToolBelongId", blongValue);

            }
            if (categoryValue > 0)
            {
                sqlWhere += " and [ToolCategoryId] =@ToolCategoryId";
                parameters.Add("ToolCategoryId", categoryValue);
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
            sql= string.Format(sql,sqlWhere);
            sqlCount = string.Format(sqlCount, sqlWhere);

            var result = base.QueryList(sql, parameters, out totalCount, sqlCount, false);
            return result.Any() ? result.ToList() : new List<t_ToolInfo>();
        }
        public t_ToolInfo GetToolById(long ToolId)
        { 
            string sql = "select * from [dbo].[t_ToolInfo] where [ToolId]=@ToolId";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolId",ToolId);
            return GetModel(sql, sqlDy);
        }

        public bool UpdateTool(t_ToolInfo entity)
        {
            return Update(entity);
           
        }
        public bool DelToolById(long ToolId)
        {
            string sql = "delete from [dbo].[t_ToolInfo] where [ToolId]=@ToolId";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolId", ToolId);
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

        public List<t_ToolInfo> GetToolList(int blongValue, int categoryValue, string toolCode, string toolName)
        {
            List<t_ToolInfo> list = new List<t_ToolInfo>();
            string sql = @"select * from [dbo].[t_ToolInfo]  where 1=1 {0} ORDER BY [ToolId] desc";
            string sqlWhere = "";
            DynamicParameters parameters = new DynamicParameters();          

            if (blongValue > 0)
            {
                sqlWhere += " and  [ToolBelongId]=@ToolBelongId";
                parameters.Add("ToolBelongId", blongValue);

            }
            if (categoryValue > 0)
            {
                sqlWhere += " and [ToolCategoryId] =@ToolCategoryId";
                parameters.Add("ToolCategoryId", categoryValue);
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
