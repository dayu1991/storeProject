using common.toolstrackingsystem;
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
    public class OutBackStoreService : IOutBackStoreService
    {
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        private readonly IOutBackStoreRepository _outBackStoreRepository;
        private readonly IToolInfoRepository _toolInfoRepository;
        public OutBackStoreService(IMultiTableQueryRepository multiTableQueryRepository, IOutBackStoreRepository outBackStoreRepository, IToolInfoRepository toolInfoRepository)
        {
            _mutiTableQueryRepository = multiTableQueryRepository;
            _outBackStoreRepository = outBackStoreRepository;
            _toolInfoRepository = toolInfoRepository;
        }
        /// <summary>
        /// 获取超时未归还的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT top " + pageSize + @" ti.TypeName,
	                                                    ti.ChildTypeName,
	                                                    ti.PackCode,
	                                                    ti.PackName,
	                                                    ti.ToolCode,
	                                                    ti.ToolName,
		                                                obs.PersonCode,
		                                                obs.PersonName,
	                                                    obs.UserTimeInfo,
	                                                    OptionPerson = case when sui.UserCode is null then tpi.PersonName else sui.UserName end,
	                                                    obs.OutStoreTime,
	                                                    obs.outdescribes
                                                    from t_OutBackStore obs 
                                                    left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
                                                    left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
                                                    left join t_PersonInfo tpi on obs.OptionPerson = tpi.PersonCode
                                                    where obs.IsBack='0' and obs.UserTimeInfo<GETDATE()  ";
            string sqlNotStr = "obs.OutBackStoreID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + @" obs.OutBackStoreID from t_OutBackStore obs 
                                left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
                                left join t_PersonInfo tpi on obs.OptionPerson = tpi.PersonCode
                                where obs.IsBack='0' and obs.UserTimeInfo<GETDATE() ";
            string sqlCount = @"SELECT COUNT(1) from t_OutBackStore obs 
                                left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
                                left join t_PersonInfo tpi on obs.OptionPerson = tpi.PersonCode
                                where obs.IsBack='0' and obs.UserTimeInfo<GETDATE() ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str; ;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrEmpty(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<NotBackToolEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();

        }
        /// <summary>
        /// 获取数据删除页面所需数据
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<OutBackInfoForDeleteEntity> GetOutBackInfoForDelete(string toolCode, string personCode, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT TOP " + pageSize + @" obs.[OutBackStoreID]
                                  ,obs.[ToolCode]
                                  ,obs.[ToolName]
                                  ,obs.[OutStoreTime]
                                  ,obs.[PersonCode]
                                  ,obs.[PersonName]
                                  ,obs.[UserTimeInfo]
                                  ,[IsBack] = case obs.[IsBack] WHEN '1' THEN '是' WHEN '0' THEN '否' END
                                  ,obs.[BackTime]
                                  ,obs.[BackPesonCode]
                                  ,obs.[BackPersonName]
                                  ,obs.[outdescribes]
                                  ,obs.[backdescribes]
                                  ,sui.UserName as [OptionPerson]
                              FROM [t_OutBackStore] obs join Sys_User_Info sui on obs.OptionPerson = sui.UserCode WHERE 1=1 ";
            string sqlNotStr = "obs.[OutBackStoreID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " obs.[OutBackStoreID] FROM [t_OutBackStore] obs join Sys_User_Info sui on obs.OptionPerson = sui.UserCode WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [t_OutBackStore] obs join Sys_User_Info sui on obs.OptionPerson = sui.UserCode WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.[ToolCode] LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.[PersonCode] LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str; ;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<OutBackInfoForDeleteEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        /// <summary>
        /// 删除某条领用信息
        /// </summary>
        /// <param name="OutBackStoreID"></param>
        /// <returns></returns>
        public bool DeleteOutBackInfo(string OutBackStoreID)
        {
            bool IsSuccess = false;
            //1.获取需要删除的信息
            t_OutBackStore outBackInfo = new t_OutBackStore();
            outBackInfo = GetOutBackStoreInfoByID(OutBackStoreID);
            if (outBackInfo != null)
            {
                if (outBackInfo.IsBack == "0")
                {
                    //1.更新工具信息为已归还
                    var toolInfo = GetToolInfoByToolCode(outBackInfo.ToolCode);
                    if(toolInfo!=null)
                    {                        
                        toolInfo.IsBack = "1";
                        IsSuccess = _toolInfoRepository.Update(toolInfo);
                    }
                }
            }
            string sql = "DELETE FROM t_OutBackStore WHERE OutBackStoreID=@outBackStoreID";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("outBackStoreID", OutBackStoreID);
            IsSuccess = _outBackStoreRepository.ExecuteSql(sql, parameter) > 0;
            return IsSuccess;
        }
        /// <summary>
        /// 获取领用查询所需的领用工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        public List<ToolBorrowEntity> GetToolBorrowList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo, int pageIndex, int pageSize, out long Count)
        {
            string sql = "select top " + pageSize + @" ti.TypeName,
		                                                ti.ChildTypeName,
		                                                ti.PackCode,
		                                                ti.PackName,
		                                                obs.ToolCode,
		                                                obs.ToolName,
		                                                obs.PersonCode,
		                                                obs.PersonName,
		                                                obs.OutStoreTime,
		                                                obs.outdescribes,
		                                                OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                                left join t_PersonInfo tpi on obs.PersonCode = tpi.PersonCode 
	                                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                                 where 1=1 ";
            string sqlNotStr = "obs.OutBackStoreID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + @" obs.OutBackStoreID
                                                                                                     from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                                                                                    left join t_PersonInfo tpi on obs.PersonCode = tpi.PersonCode 
	                                                                                                    left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                                                                                    left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                                                                                     where 1=1 ";
            string sqlCount = @"select	count(1)
                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                left join t_PersonInfo tpi on obs.PersonCode = tpi.PersonCode 
	                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                 where 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            sql += " order by obs.OutStoreTime";
            sqlNotStr += " order by obs.OutStoreTime";

            sqlNotStr += ")";

            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<ToolBorrowEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        /// <summary>
        /// 获取领用查询所需的领用工具导出信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        public List<ToolBorrowEntity> GetToolBorrowList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo)
        {
            string sql = @"select   ti.TypeName,
		                            ti.ChildTypeName,
		                            ti.PackCode,
		                            ti.PackName,
		                            obs.ToolCode,
		                            obs.ToolName,
		                            obs.PersonCode,
		                            obs.PersonName,
		                            obs.OutStoreTime,
		                            obs.outdescribes,
		                            OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                            left join t_PersonInfo tpi on obs.PersonCode = tpi.PersonCode 
	                            left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                            left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                where 1=1  ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            return _mutiTableQueryRepository.QueryList<ToolBorrowEntity>(sql, parameters).ToList();
        }

        /// <summary>
        /// 获取归还查询所需的归还工具导出信息（有分页）
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        public List<ToolReturnEntity> GetToolReturnList(string toolCode, string PersonCode, string dateTimeFrom, string dateTimeTo, int pageIndex, int pageSize, out long Count)
        {
            string sql = "select top " + pageSize + @"  ti.TypeName,
		                                                ti.ChildTypeName,
		                                                ti.PackCode,
		                                                ti.PackName,
		                                                obs.ToolCode,
		                                                obs.ToolName,
		                                                obs.PersonCode,
		                                                obs.PersonName,
		                                                obs.OutStoreTime,
		                                                obs.BackPesonCode,
		                                                obs.BackPersonName,
		                                                obs.BackTime,
		                                                obs.backdescribes,
		                                                OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                                 where 1=1 AND obs.IsBack='0' ";
            string sqlNotStr = "obs.OutBackStoreID NOT IN (SELECT TOP "+(pageIndex-1)*pageSize+@" obs.[OutBackStoreID]  from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
 where 1=1 AND obs.IsBack='0' ";
            string sqlCount = @"select	count(1)
                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                 where 1=1 AND obs.IsBack='0'";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(PersonCode))
            {
                string str = " AND obs.PesonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", PersonCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<ToolReturnEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();
        }
        /// <summary>
        /// 获取归还查询所需的归还工具导出信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        public List<ToolReturnEntity> GetToolReturnList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo)
        {
            string sql = @"select   ti.TypeName,
		                            ti.ChildTypeName,
		                            ti.PackCode,
		                            ti.PackName,
		                            obs.ToolCode,
		                            obs.ToolName,
		                            obs.PersonCode,
		                            obs.PersonName,
		                            obs.OutStoreTime,
		                            obs.BackPesonCode,
		                            obs.BackPersonName,
		                            obs.BackTime,
		                            obs.backdescribes,
		                            OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                            left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                            left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                where 1=1 AND obs.IsBack='0'  ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            return _mutiTableQueryRepository.QueryList<ToolReturnEntity>(sql, parameters).ToList();

        }
        /// <summary>
        /// 获取超时未归还的导出工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode)
        {
            string sql = @"SELECT   ti.TypeName,
	                                ti.ChildTypeName,
	                                ti.PackCode,
	                                ti.PackName,
	                                ti.ToolCode,
	                                ti.ToolName,
		                            obs.PersonCode,
		                            obs.PersonName,
	                                obs.UserTimeInfo,
	                                OptionPerson = case when sui.UserCode is null then tpi.PersonName else sui.UserName end,
	                                obs.OutStoreTime,
	                                obs.outdescribes
                                from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                            left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                            left join t_PersonInfo tpi on obs.OptionPerson = tpi.PersonCode
                                where 1=1 AND obs.IsBack='0'  ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrEmpty(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            return _mutiTableQueryRepository.QueryList<NotBackToolEntity>(sql, parameters).ToList();


        }
        /// <summary>
        /// 获取流水账分页信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<CurrentToolInfoEntity> GetCurrentToolInfoList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo, int pageIndex, int pageSize, out long Count)
        {
            string sql = "select top " + pageSize + @"  ti.TypeName,
		                                                ti.ChildTypeName,
		                                                ti.PackCode,
		                                                ti.PackName,
		                                                obs.ToolCode,
		                                                obs.ToolName,
		                                                IsBack = case obs.IsBack when '1' then '是' else '否' end,
		                                                obs.PersonCode,
		                                                obs.PersonName,
		                                                obs.OutStoreTime,
		                                                obs.outdescribes,
		                                                obs.BackPesonCode,
		                                                obs.BackPersonName,
		                                                obs.BackTime,
		                                                obs.backdescribes,
		                                                OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                                 where 1=1  ";
            string sqlNotStr = "obs.OutBackStoreID NOT IN (SELECT TOP " + (pageIndex - 1) * pageSize + @" obs.[OutBackStoreID]  from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
 where 1=1 ";
            string sqlCount = @"select	count(1)
                                 from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                                left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                                left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                 where 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            sqlNotStr += " order by obs.OutStoreTime";
            sql += " order by obs.OutStoreTime";

            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<CurrentToolInfoEntity>(sqlfinal, parameters, out Count, sqlCount, false).ToList();

        }
        /// <summary>
        /// 获取流水账信息(导出)
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<CurrentToolInfoEntity> GetCurrentToolInfoForExport(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo)
        {
            string sql = @"select   ti.TypeName,
		                            ti.ChildTypeName,
		                            ti.PackCode,
		                            ti.PackName,
		                            obs.ToolCode,
		                            obs.ToolName,
		                            IsBack = case obs.IsBack when '1' then '是' else '否' end,
		                            obs.PersonCode,
		                            obs.PersonName,
		                            obs.OutStoreTime,
		                            obs.outdescribes,
		                            obs.BackPesonCode,
		                            obs.BackPersonName,
		                            obs.BackTime,
		                            obs.backdescribes,
		                            OptionPerson = case when sui.UserName is null then tpi1.PersonName else sui.UserName end
                                from t_OutBackStore obs left join t_ToolInfo ti on obs.ToolCode = ti.ToolCode
	                            left join Sys_User_Info sui on obs.OptionPerson = sui.UserCode
	                            left join t_PersonInfo tpi1 on obs.OptionPerson = tpi1.PersonCode
                                where 1=1  ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                parameters.Add("dateTimeTo", dateTimeTo);
            }
            return _mutiTableQueryRepository.QueryList<CurrentToolInfoEntity>(sql, parameters).ToList();

        }
        public t_OutBackStore GetOutBackStoreInfoByID(string outBackStoreID)
        {
            string sql = "SELECT * FROM t_OutBackStore WHERE OutBackStoreID=@outBackStoreID";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("outBackStoreID", outBackStoreID);
            return _outBackStoreRepository.GetModel(sql, parameter);
        }
        public t_ToolInfo GetToolInfoByToolCode(string toolCode)
        {
            string sql = "SELECT * FROM t_ToolInfo WHERE ToolCode=@toolCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode",toolCode);
            return _mutiTableQueryRepository.QueryList<t_ToolInfo>(sql, parameter).FirstOrDefault();
        }
      
        /// <summary>
        /// 获取未归还的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public t_OutBackStore GetToolInfoNotBackByToolCode(string toolCode)
        {
            string sql = "SELECT * FROM t_OutBackStore WHERE IsBack='0' AND ToolCode=@toolCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode", toolCode);
            return _mutiTableQueryRepository.QueryList<t_OutBackStore>(sql, parameter).FirstOrDefault();
        }
        /// <summary>
        /// 根据包编码获取未归还的工具信息
        /// </summary>
        /// <param name="packCode"></param>
        /// <returns></returns>
        public List<t_OutBackStore> GetToolInfoNotBackByPackCode(string packCode)
        {
            string sql = "SELECT * FROM t_OutBackStore obs join t_ToolInfo ti on obs.ToolCode = ti.ToolCode where ti.PackCode= @packCode AND obs.IsBack='0'";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("packCode",packCode);
            return _mutiTableQueryRepository.QueryList<t_OutBackStore>(sql,parameter).ToList();
        }
    }
}
