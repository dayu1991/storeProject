using Dapper;
using dbentity.toolstrackingsystem;
using sqlserver.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;
using ViewEntity.toolstrackingsystem.view;

namespace service.toolstrackingsystem
{
    public class ToolRepairRecordService : IToolRepairRecordService
    {
        private IToolRepairRecordRepository _toolPrepairRecordRepository;
        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolRepairRecordService(IToolRepairRecordRepository toolPrepairRecordRepository, IMultiTableQueryRepository multiTableQueryRepository)
        {
            _toolPrepairRecordRepository = toolPrepairRecordRepository;
            _multiTableQueryRepository = multiTableQueryRepository;
        }
        public List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo, int pageIndex, int pageSize, out long Count)
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
        public List<ToolPrepairEntity> GetToolPrepairRecordList(t_ToolRepairRecord prepairInfo)
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
        /// <summary>
        /// 获取送修工具各个状态的信息
        /// </summary>
        /// <param name="t_ToolRepairRecord"></param>
        /// <returns></returns>
        public List<RepairedToolForReceiveEntity> GetRepairedToolForReceive(t_ToolRepairRecord repairedInfo)
        {
            string sql = @"SELECT trr.Id,
	                            trr.[TypeName]
                              ,trr.[ChildTypeName]
                              ,trr.[ToolCode]
                              ,trr.[ToolName]
                              ,trr.[ToRepairedTime]
                              ,trr.[ToRepairedPerName]
                              ,trr.[ToRepairMemo]
  FROM [dbo].[t_ToolRepairRecord] trr WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            sql += " AND trr.ToolStatus = @toolStatus ";
            parameters.Add("toolStatus",repairedInfo.ToolStatus);
            if (!string.IsNullOrEmpty(repairedInfo.TypeName))
            {
                sql += " AND trr.TypeName = @typeName ";
                parameters.Add("typeName",repairedInfo.TypeName);
            }
            if (!string.IsNullOrEmpty(repairedInfo.ChildTypeName))
            {
                sql += " AND trr.ChildTypeName = @childTypeName ";
                parameters.Add("childTypeName", repairedInfo.ChildTypeName);
            }
            if (!string.IsNullOrEmpty(repairedInfo.ToolCode))
            {
                sql += " AND trr.ToolCode LIKE @toolCode ";
                parameters.Add("toolCode", string.Format("%{0}%", repairedInfo.ToolCode));
            }
            if (!string.IsNullOrEmpty(repairedInfo.ToolName))
            {
                sql += " AND trr.ToolName LIKE @toolName ";
                parameters.Add("toolName", string.Format("%{0}%", repairedInfo.ToolName));
            }
            sql += " ORDER BY trr.ToRepairedTime DESC ";
            return _multiTableQueryRepository.QueryList<RepairedToolForReceiveEntity>(sql, parameters).ToList();

        }
        /// <summary>
        /// 获取报废的工具列表
        /// </summary>
        /// <param name="repairedInfo"></param>
        /// <returns></returns>
        public List<ToolScrapedEntity> GetRepairedToolRorScrap(t_ToolRepairRecord repairedInfo) 
        {
            string sql = @"SELECT trr.Id,
	                            trr.[TypeName]
                              ,trr.[ChildTypeName]
                              ,trr.[ToolCode]
                              ,trr.[ToolName]
                              ,trr.[ToRepairedTime]
                              ,trr.[ToRepairedPerName]
                              ,trr.[ToRepairMemo]
                              ,trr.[HandleTime]
                              ,trr.[HandlePerName]
                              ,trr.[ScrapMemo]
  FROM [dbo].[t_ToolRepairRecord] trr WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            sql += " AND trr.ToolStatus = @toolStatus ";
            parameters.Add("toolStatus", repairedInfo.ToolStatus);
            if (!string.IsNullOrEmpty(repairedInfo.TypeName))
            {
                sql += " AND trr.TypeName = @typeName ";
                parameters.Add("typeName", repairedInfo.TypeName);
            }
            if (!string.IsNullOrEmpty(repairedInfo.ChildTypeName))
            {
                sql += " AND trr.ChildTypeName = @childTypeName ";
                parameters.Add("childTypeName", repairedInfo.ChildTypeName);
            }
            if (!string.IsNullOrEmpty(repairedInfo.ToolCode))
            {
                sql += " AND trr.ToolCode LIKE @toolCode ";
                parameters.Add("toolCode", string.Format("%{0}%", repairedInfo.ToolCode));
            }
            if (!string.IsNullOrEmpty(repairedInfo.ToolName))
            {
                sql += " AND trr.ToolName LIKE @toolName ";
                parameters.Add("toolName", string.Format("%{0}%", repairedInfo.ToolName));
            }
            sql += " ORDER BY trr.ToRepairedTime DESC ";
            return _multiTableQueryRepository.QueryList<ToolScrapedEntity>(sql, parameters).ToList();


        }
        /// <summary>
        /// 更新送修工具状态为接收
        /// </summary>
        /// <param name="repairInfo"></param>
        /// <returns></returns>
        public bool UpdateToolReceiveStatus(t_ToolRepairRecord repairInfo)
        {
            return _toolPrepairRecordRepository.UpdateToolReceiveStatus(repairInfo);
        }
        /// <summary>
        /// 根据工具编码和状态获取送修记录
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public t_ToolRepairRecord GetToolRepairByToolCodeAndStatus(string toolCode, int status = 1)
        {
            return _toolPrepairRecordRepository.GetToolRepairByToolCodeAndStatus(toolCode,status);
        }


        public List<ToolRepairRecordExtend> GetListForQuery(string blongValue, string categoryValue, string toolCode, string toolName,
            DateTime statTime, DateTime endTime, int pageindex, int pagesize, out long totalCount)
        {
            string sql = @"select *,(case ToolStatus when 1 then '已送修' when 2 then '已接收' when 3 then '已修复' when 4 then '已领回' when 5 then '已报废' else '未知' end) as StatusStr from (
       select *,ROW_NUMBER() OVER (ORDER BY ChildTypeName,[Id] desc) as rank from [t_ToolRepairRecord]  where 1=1 {0}
)  as t where  t.rank between @startPos and @endPos ";
            string sqlCount = "select count(1) from [dbo].[t_ToolRepairRecord] where 1=1 {0}";
            string sqlWhere = "";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("startPos", ((pageindex - 1) * pagesize + 1));
            parameters.Add("endPos", pageindex * pagesize);

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
                sqlWhere += " and [ToolCode] LIKE @ToolCode";
                parameters.Add("ToolCode", string.Format("%{0}%", toolCode));

            }
            if (!string.IsNullOrEmpty(toolName))
            {
                sqlWhere += " and [ToolName] LIKE @ToolName";
                parameters.Add("ToolName", string.Format("%{0}%", toolName));
            }
            sqlWhere += " and [ToRepairedTime]>@startTime and [ToRepairedTime]<@endTime ";
            parameters.Add("startTime", statTime);
            parameters.Add("endTime", endTime);


            sql = string.Format(sql, sqlWhere);
            sqlCount = string.Format(sqlCount, sqlWhere);

            var result = _multiTableQueryRepository.QueryList<ToolRepairRecordExtend>(sql, parameters, out totalCount, sqlCount, false);
            return result.Any() ? result.ToList() : new List<ToolRepairRecordExtend>();
        }

        /// <summary>
        /// 更新维修表工具信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateToolRepairInfo(t_ToolRepairRecord entity)
        {
            return _toolPrepairRecordRepository.Update(entity);
        }
        /// <summary>
        /// 通过主键ID获取维修工具信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public t_ToolRepairRecord GetToolRepairByToolCodeById(int id)
        {
            string sql = "SELECT * FROM t_ToolRepairRecord WHERE Id = @id";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("id",id);
            return _toolPrepairRecordRepository.GetModel(sql,parameter);
        }
    }
}
