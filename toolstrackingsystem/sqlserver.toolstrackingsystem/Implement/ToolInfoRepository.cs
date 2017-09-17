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
        public bool IsExistToolByType(string typeName, int type)
        {
            string sql="";
            DynamicParameters parameters = new DynamicParameters();

            if (type == 1)
            {
                sql = "select count(1) from t_ToolInfo where [TypeName]=@TypeName";
                parameters.Add("@TypeName", typeName);
            }
            else {
                sql = "select count(1) from t_ToolInfo where [ChildTypeName]=@ChildTypeName";
                parameters.Add("@ChildTypeName", typeName);
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
             sqlWhere +=" and [ToolCode] LIKE @ToolCode";
                parameters.Add("ToolCode", string.Format("%{0}%", toolCode));

            }
            if (!string.IsNullOrEmpty(toolName))
            {
               sqlWhere += " and [ToolName] LIKE @ToolName";
                parameters.Add("ToolName", string.Format("%{0}%", toolName));
            }
            sql = string.Format(sql, sqlWhere);

            var result = base.QueryList(sql, parameters);
            return result.Any() ? result.ToList() : new List<t_ToolInfo>();
        }
        public bool InsertToolInfo(t_ToolInfo toolInfo)
        {
            string sql = @"INSERT INTO [dbo].[t_ToolInfo]
                                           ([TypeName]
                                           ,[ChildTypeName]
                                           ,[PackCode]
                                           ,[PackName]
                                           ,[CarGroupInfo]
                                           ,[ToolCode]
                                           ,[ToolName]
                                           ,[Models]
                                           ,[Location]
                                           ,[Remarks]
                                           ,[CheckTime]
                                           ,[IsActive]
                                           ,[OptionPerson])
                                     VALUES
                                           (@typeName,@childTypeName,@packCode,@packName,@carGroupInfo,@toolCode,@toolName,@models,@location,@remarks,@checkTime,@isActive,@optionPerson)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("typeName",toolInfo.TypeName);
            parameters.Add("childTypeName", toolInfo.ChildTypeName);
            parameters.Add("packCode", toolInfo.PackCode);
            parameters.Add("packName", toolInfo.PackName);
            parameters.Add("carGroupInfo", toolInfo.CarGroupInfo);
            parameters.Add("toolCode", toolInfo.ToolCode);
            parameters.Add("toolName", toolInfo.ToolName);
            parameters.Add("models", toolInfo.Models);
            parameters.Add("location", toolInfo.Location);
            parameters.Add("remarks", toolInfo.Remarks);
            parameters.Add("checkTime", toolInfo.CheckTime);
            parameters.Add("isActive", toolInfo.IsActive);
            parameters.Add("optionPerson", toolInfo.OptionPerson);
            return base.ExecuteSql(sql,parameters)>0;
        }


        public int SetToolIsBack(string toolCode, string isBack)
        {
            string sql = "update [t_ToolInfo] set [IsBack]=@IsBack where [ToolCode] = @ToolCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("IsBack", isBack);
            parameters.Add("ToolCode", toolCode);
            return base.ExecuteSql(sql, parameters);

        }

    }
}
