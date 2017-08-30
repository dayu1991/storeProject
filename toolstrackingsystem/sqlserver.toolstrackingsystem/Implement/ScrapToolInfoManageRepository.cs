using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class ScrapToolInfoManageRepository : RepositoryBase<t_ScrapToolInfo>,IScrapToolInfoManageRepository
    {
        public bool InsertScrapToolInfo(t_ScrapToolInfo scrapToolInfo)
        {
            string sql = "INSERT INTO t_ScrapToolInfo (TypeName,ChildTypeName,ToolCode,ToolName,PackCode,PackName,ScrapTime,Remarks,OptionPerson)VALUES(@typeName,@childType,@toolCode,@toolName,@packCode,@packName,@scrapTime,@remarks,@optionPerson)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("typeName", scrapToolInfo.TypeName);
            parameters.Add("childType", scrapToolInfo.ChildTypeName);
            parameters.Add("toolCode",scrapToolInfo.ToolCode);
            parameters.Add("toolName",scrapToolInfo.ToolName);
            parameters.Add("packCode", scrapToolInfo.PackCode);
            parameters.Add("packName", scrapToolInfo.PackName);
            parameters.Add("scrapTime",scrapToolInfo.ScrapTime);
            parameters.Add("remarks",scrapToolInfo.Remarks);
            parameters.Add("optionPerson",scrapToolInfo.OptionPerson);
            return base.ExecuteSql(sql,parameters)>0;
        }
    }
}
