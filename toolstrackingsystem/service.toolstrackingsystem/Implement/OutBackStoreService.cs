using Dapper;
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
        public OutBackStoreService(IMultiTableQueryRepository multiTableQueryRepository, IOutBackStoreRepository outBackStoreRepository)
        {
            _mutiTableQueryRepository = multiTableQueryRepository;
            _outBackStoreRepository = outBackStoreRepository;
        }
        /// <summary>
        /// 获取超时未归还的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode, int pageIndex, int pageSize, out long Count)
        {
            string sql = @"SELECT top " + pageSize + @" obs.ToolCode,obs.ToolName,obs.PersonCode,OBS.PersonName,obs.OutStoreTime,obs.OptionPerson,obs.UserTimeInfo,ti.TypeName,ti.ChildTypeName,ti.PackCode,ti.PackName from t_OutBackStore obs join t_ToolInfo ti on obs.ToolCode = ti.ToolCode where obs.IsBack='0' and obs.UserTimeInfo< GETDATE()  ";
            string sqlNotStr = "ti.ToolID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " ToolID FROM t_ToolInfo WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM t_ToolInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += " AND ToolCode LIKE @toolCode ";
                sqlNotStr += " AND ToolCode LIKE @toolCode "; ;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrEmpty(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += " AND PersonCode LIKE @personCode ";
                sqlNotStr += " AND PersonCode LIKE @personCode ";
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
            string sql = @"SELECT TOP " + pageSize + @"[OutBackStoreID]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[OutStoreTime]
                                  ,[PersonCode]
                                  ,[PersonName]
                                  ,[UserTimeInfo]
                                  ,[IsBack]= case [IsBack] WHEN '1' THEN '是' WHEN '0' THEN '否' END
                                  ,[BackTime]
                                  ,[BackPesonCode]
                                  ,[BackPersonName]
                                  ,[outdescribes]
                                  ,[backdescribes]
                                  ,[OptionPerson]
                              FROM [cangku_manage_db].[dbo].[t_OutBackStore] WHERE 1=1 ";
            string sqlNotStr = "[OutBackStoreID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [OutBackStoreID] FROM [cangku_manage_db].[dbo].[t_OutBackStore] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [cangku_manage_db].[dbo].[t_OutBackStore] WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND [ToolCode] LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND [PersonCode] LIKE @personCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<OutBackInfoForDeleteEntity>(sql, parameters, out Count, sqlCount, false).ToList();
        }

        /// <summary>
        /// 删除某条领用信息
        /// </summary>
        /// <param name="OutBackStoreID"></param>
        /// <returns></returns>
        public bool DeleteOutBackInfo(string OutBackStoreID)
        {
            string sql = "DELETE FROM t_OutBackStore WHERE OutBackStoreID=@outBackStoreID";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("outBackStoreID", OutBackStoreID);
            return _outBackStoreRepository.ExecuteSql(sql,parameter)>0;
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
            string sql = "select top " + pageSize + " tl.TypeName,tl.ChildTypeName,tl.PackCode,tl.PackName,obs.ToolCode,obs.ToolName,obs.PersonCode,obs.PersonName,obs.OutStoreTime,obs.outdescribes,sui.UserName as OptionPerson from t_OutBackStore obs join t_ToolInfo tl on obs.ToolCode = tl.ToolCode join Sys_User_Info sui on obs.OptionPerson=sui.UserCode  WHERE 1=1 ";
            string sqlNotStr = "ob.OutBackStoreID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [OutBackStoreID] FROM [cangku_manage_db].[dbo].[t_OutBackStore] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [cangku_manage_db].[dbo].[t_OutBackStore] WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND obs.ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += " AND ToolCode LIKE @toolCode ";
                sqlNotStr += " AND ToolCode LIKE @toolCode ";
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrWhiteSpace(personCode))
            {
                string str = " AND obs.PersonCode LIKE @personCode ";
                sql += str;
                sqlCount += " AND PersonCode LIKE @personCode ";
                sqlNotStr += " AND PersonCode LIKE @personCode ";
                parameters.Add("personCode", string.Format("%{0}%", personCode));
            }
            if (!string.IsNullOrWhiteSpace(dateTimeFrom))
            {
                string str = " AND obs.OutStoreTime >=  @dateTimeFrom ";
                sql += str;
                sqlCount += " AND OutStoreTime >=  @dateTimeFrom  ";
                sqlNotStr += " AND OutStoreTime >=  @dateTimeFrom  ";
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeTo))
            {
                string str = " AND obs.OutStoreTime <=  @dateTimeTo ";
                sql += str;
                sqlCount += " AND OutStoreTime <=  @dateTimeTo  ";
                sqlNotStr += " AND OutStoreTime <=  @dateTimeTo  ";
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _mutiTableQueryRepository.QueryList<ToolBorrowEntity>(sql, parameters, out Count, sqlCount, false).ToList();
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
            string sql = "select  tl.TypeName,tl.ChildTypeName,tl.PackCode,tl.PackName,obs.ToolCode,obs.ToolName,obs.PersonCode,obs.PersonName,obs.OutStoreTime,obs.outdescribes,sui.UserName as OptionPerson from t_OutBackStore obs join t_ToolInfo tl on obs.ToolCode = tl.ToolCode join Sys_User_Info sui on obs.OptionPerson=sui.UserCode  WHERE 1=1 ";
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
                parameters.Add("dateTimeFrom", dateTimeFrom);
            }
            return _mutiTableQueryRepository.QueryList<ToolBorrowEntity>(sql, parameters).ToList();
        }
    }
}
