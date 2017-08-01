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
    public class CurrentCountInfoService : ICurrentCountInfoService
    {
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        public CurrentCountInfoService(IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._mutiTableQueryRepository = multiTableQueryRepository;
        }
        /// <summary>
        /// 获取符合条件的工具信息
        /// </summary>
        /// <returns></returns>
        public List<CurrentToolInfoEntity> GetCurrentCountToolList(t_CurrentCountInfo countInfo, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT TOP "+pageSize+ @"tci.[TypeName]
                                  ,tci.[ChildTypeName]
                                  ,tci.[PackCode]
                                  ,tci.[PackName]
                                  ,tci.[ToolCode]
                                  ,tci.[ToolName]
                                  ,tci.[Models]
                                  ,tci.[Location]
                                  ,tci.[Remarks]
                                  ,tci.[InStoreTime]
                                  ,tci.[OutStoreTime]
                                  ,tci.[BackTime]
                                  ,tci.[OptionType]
                                  ,tci.[PersonCode]
                                  ,tci.[PersonName]
                                  ,tci.[BackPesonCode]
                                  ,tci.[BackPersonName]
                                  ,tci.[describes]
                                  ,sui.UserName as [OptionPerson]
                              FROM [dbo].[t_CurrentCountInfo] tci JOIN Sys_User_Info  sui ON tci.[OptionPerson] = sui.UserCode WHERE 1=1 ";
            string sqlNotStr = "tci.CurrentCountID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " CurrentCountID FROM t_CurrentCountInfo tci JOIN Sys_User_Info  sui ON tci.[OptionPerson] = sui.UserCode WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM t_CurrentCountInfo tci JOIN Sys_User_Info  sui ON tci.[OptionPerson] = sui.UserCode WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(countInfo.OptionType))
            {
                string str = " AND tci.OptionType LIKE @optionType ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("optionType", string.Format("%{0}%", countInfo.OptionType));
            }
            if (!string.IsNullOrEmpty(countInfo.ToolCode))
            {
                string str = " AND tci.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", countInfo.ToolCode));
            }
            if (!string.IsNullOrEmpty(countInfo.PersonCode))
            {
                string str = " AND tci.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", countInfo.PersonCode));
            }
            if (!string.IsNullOrEmpty(countInfo.OptionPerson))
            {
                string str = " AND tci.OptionPerson LIKE @optionPerson ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("optionPerson", string.Format("%{0}%", countInfo.OptionPerson));
            }
            if (!string.IsNullOrEmpty(countInfo.OutStoreTime)&&!string.IsNullOrEmpty(countInfo.BackTime))
            {
                string str = " AND((tci.OutStoreTime>= @outStoreTime AND tci.OutStoreTime<=@backTime) OR (tci.BackTime>= @outStoreTime AND tci.BackTime<=@backTime))";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("outStoreTime", string.Format("%{0}%", countInfo.OutStoreTime));
                parameters.Add("backTime", string.Format("%{0}%", countInfo.BackTime));
            }
            else if (string.IsNullOrEmpty(countInfo.OutStoreTime) && !string.IsNullOrEmpty(countInfo.BackTime))
            {
                string str = " AND(tci.OutStoreTime<=@backTime OR tci.BackTime<=@backTime)";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("backTime", string.Format("%{0}%", countInfo.BackTime));
            }
            else if (!string.IsNullOrEmpty(countInfo.OutStoreTime) && string.IsNullOrEmpty(countInfo.BackTime)) 
            {
                string str = " AND(tci.OutStoreTime>=@outStoreTime OR tci.BackTime>=@outStoreTime)";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("outStoreTime", string.Format("%{0}%", countInfo.OutStoreTime));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<CurrentToolInfoEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        /// <summary>
        /// 入库查询所需的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public List<ToolInfoInStoreEntity> GetToolInfoInStoreList(string toolCode, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"select TOP " + pageSize + "ins.InStoreTime,tool.OptionPerson,tool.TypeName,tool.ChildTypeName,tool.Models,tool.Location,tool.PackCode,tool.PackName,tool.ToolCode,tool.ToolName,tool.Remarks,tool.CheckTime from t_InStore ins join t_ToolInfo tool on ins.ToolCode = tool.ToolCode WHERE 1=1 ";
            string sqlNotStr = "tool.toolID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " toolID FROM t_ToolInfo WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM t_ToolInfo tool WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                string str = " AND tool.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<ToolInfoInStoreEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        /// <summary>
        /// 入库查询导出所需的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public List<ToolInfoInStoreEntity> GetToolInfoInStoreList(string toolCode)
        {
            string sql = @"select ins.InStoreTime,tool.OptionPerson,tool.TypeName,tool.ChildTypeName,tool.Models,tool.Location,tool.PackCode,tool.PackName,tool.ToolCode,tool.ToolName,tool.Remarks,tool.CheckTime from t_InStore ins join t_ToolInfo tool on ins.ToolCode = tool.ToolCode WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                string str = " AND tool.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            return _mutiTableQueryRepository.QueryList<ToolInfoInStoreEntity>(sql, parameters).ToList();
        }
        /// <summary>
        /// 获取符合条件的导出工具信息
        /// </summary>
        /// <returns></returns>
        public List<CurrentToolInfoEntity> GeCurrentCountToolList(t_CurrentCountInfo countInfo)
        {
            string sql = @"SELECT tci.[TypeName]
                                  ,tci.[ChildTypeName]
                                  ,tci.[PackCode]
                                  ,tci.[PackName]
                                  ,tci.[ToolCode]
                                  ,tci.[ToolName]
                                  ,tci.[Models]
                                  ,tci.[Location]
                                  ,tci.[Remarks]
                                  ,tci.[InStoreTime]
                                  ,tci.[OutStoreTime]
                                  ,tci.[BackTime]
                                  ,tci.[OptionType]
                                  ,tci.[PersonCode]
                                  ,tci.[PersonName]
                                  ,tci.[BackPesonCode]
                                  ,tci.[BackPersonName]
                                  ,tci.[describes]
                                  ,sui.UserName as [OptionPerson]
                              FROM [dbo].[t_CurrentCountInfo] tci JOIN Sys_User_Info  sui ON tci.[OptionPerson] = sui.UserCode WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(countInfo.OptionType))
            {
                string str = " AND tci.OptionType LIKE @optionType ";
                sql += str;
                parameters.Add("optionType", string.Format("%{0}%", countInfo.OptionType));
            }
            if (!string.IsNullOrEmpty(countInfo.ToolCode))
            {
                string str = " AND tci.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", countInfo.ToolCode));
            }
            if (!string.IsNullOrEmpty(countInfo.PersonCode))
            {
                string str = " AND tci.PersonCode LIKE @personCode ";
                sql += str;
                parameters.Add("personCode", string.Format("%{0}%", countInfo.PersonCode));
            }
            if (!string.IsNullOrEmpty(countInfo.OptionPerson))
            {
                string str = " AND tci.OptionPerson LIKE @optionPerson ";
                sql += str;
                parameters.Add("optionPerson", string.Format("%{0}%", countInfo.OptionPerson));
            }
            if (!string.IsNullOrEmpty(countInfo.OutStoreTime) && !string.IsNullOrEmpty(countInfo.BackTime))
            {
                string str = " AND((tci.OutStoreTime>= @outStoreTime AND tci.OutStoreTime<=@backTime) OR (tci.BackTime>= @outStoreTime AND tci.BackTime<=@backTime))";
                sql += str;
                parameters.Add("outStoreTime", string.Format("%{0}%", countInfo.OutStoreTime));
                parameters.Add("backTime", string.Format("%{0}%", countInfo.BackTime));
            }
            else if (string.IsNullOrEmpty(countInfo.OutStoreTime) && !string.IsNullOrEmpty(countInfo.BackTime))
            {
                string str = " AND(tci.OutStoreTime<=@backTime OR tci.BackTime<=@backTime)";
                sql += str;
                parameters.Add("backTime", string.Format("%{0}%", countInfo.BackTime));
            }
            else if (!string.IsNullOrEmpty(countInfo.OutStoreTime) && string.IsNullOrEmpty(countInfo.BackTime))
            {
                string str = " AND(tci.OutStoreTime>=@outStoreTime OR tci.BackTime>=@outStoreTime)";
                sql += str;
                parameters.Add("outStoreTime", string.Format("%{0}%", countInfo.OutStoreTime));
            }

            return _mutiTableQueryRepository.QueryList<CurrentToolInfoEntity>(sql, parameters).ToList();

        }
    } 
}
