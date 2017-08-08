using Dapper;
using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public class ToolPrepairRecordService : IToolPrepairRecordService
    {
        private IToolPrepairRecordRepository _toolPrepairRecordRepository;
        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolPrepairRecordService(IToolPrepairRecordRepository toolPrepairRecordRepository, IMultiTableQueryRepository multiTableQueryRepository)
        {
            _toolPrepairRecordRepository = toolPrepairRecordRepository;
            _multiTableQueryRepository = multiTableQueryRepository;
        }
        public List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolPrepairRecord prepairInfo, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT TOP " + pageSize + @"
                                  tpr.[ToolCode]
                                  ,tpr.[ToolName]
                                  ,tpr.[PrepairTime]
                                  ,tpr.[BackTime]
                                  ,sui.UserName as [OptionPerson]
                                  ,sui1.UserName as [BackOptionPerson]
                                  ,[IsActive] = case tpr.IsActive WHEN 1 THEN '可用' WHEN 0 THEN '送修' END
                              FROM [t_ToolPrepairRecord] tpr join Sys_User_Info sui on tpr.OptionPerson = sui.UserCode join Sys_User_Info sui1 on tpr.BackOptionPerson = sui1.UserCode WHERE 1=1";
            string sqlNotStr = "tpr.[ID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [ID] FROM [t_ToolPrepairRecord] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [t_ToolPrepairRecord] WHERE IsAcTive=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(prepairInfo.ToolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", prepairInfo.ToolCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _multiTableQueryRepository.QueryList<ToolPrepairEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        public List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolPrepairRecord prepairInfo)
        {
            string sql = @"SELECT tpr.[ToolCode]
                                  ,tpr.[ToolName]
                                  ,tpr.[PrepairTime]
                                  ,tpr.[BackTime]
                                  ,sui.UserName as [OptionPerson]
                                  ,sui1.UserName as [BackOptionPerson]
                                  ,[IsActive] = case tpr.IsActive WHEN 1 THEN '可用' WHEN 0 THEN '送修' END
                              FROM [t_ToolPrepairRecord] tpr join Sys_User_Info sui on tpr.OptionPerson = sui.UserCode join Sys_User_Info sui1 on tpr.BackOptionPerson = sui1.UserCode WHERE 1=1";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(prepairInfo.ToolCode))
            {
                string str = " AND tpr.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", prepairInfo.ToolCode));
            }
            return _multiTableQueryRepository.QueryList<ToolPrepairEntity>(sql, parameters).ToList();
        }
    }
}
