using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace sqlserver.toolstrackingsystem
{
    public class ToolPackManageRepository : RepositoryBase<t_ToolInfo>, IToolPackManageRepository
    {
        /// <summary>
        /// 更新工具的包编码，包名称
        /// </summary>
        /// <param name="toolInfo"></param>
        /// <returns></returns>
        public bool UpdateToolPackInfo(t_ToolInfo toolInfo)
        {
            string sql = "UPDATE t_ToolInfo SET PackCode=@packCode,PackName=@packName WHERE IsActive='1' AND ToolCode=@toolCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("packName",toolInfo.PackName);
            parameters.Add("packCode",toolInfo.PackCode);
            parameters.Add("toolCode",toolInfo.ToolCode);
            return base.ExecuteSql(sql,parameters)>0;
        }
        /// <summary>
        /// 作废工具（更新工具的使用状态为0）
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public bool UpdateToolStatus(string toolCode)
        {
            string sql = "UPDATE t_ToolInfo SET IsActive='0' WHERE ToolCode=@toolCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("toolCode", toolCode);
            return base.ExecuteSql(sql, parameters) > 0;
        }
    }
}
