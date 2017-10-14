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
using ViewEntity.toolstrackingsystem.view;

namespace service.toolstrackingsystem
{
   public class ToolInfoService:IToolInfoService
    {
        private IToolCategoryInfoRepository _toolCategoryInfoRepository;
        private IToolInfoRepository _toolInfoRepository;

        private ICurrentCountInfoRepository _currentCountInfoRepository;
        private IOutBackStoreRepository _outBackStoreRepository;
        private IToolRepairRecordRepository _toolPrepairRecordRepository;
        private IToolPackManageRepository _toolPackManageRepository;

        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolInfoService(IToolCategoryInfoRepository toolCategoryInfoRepository,
            IToolInfoRepository toolInfoRepository, 
            IMultiTableQueryRepository multiTableQueryRepository,
            ICurrentCountInfoRepository currentCountInfoRepository,
            IOutBackStoreRepository outBackStoreRepository,IToolRepairRecordRepository toolPrepairRecordRepository,
            IToolPackManageRepository toolPackManageRepository)
       {
           _toolCategoryInfoRepository = toolCategoryInfoRepository;
           _toolInfoRepository = toolInfoRepository;
           _multiTableQueryRepository = multiTableQueryRepository;
            _currentCountInfoRepository = currentCountInfoRepository;
            _outBackStoreRepository = outBackStoreRepository;
            _toolPrepairRecordRepository = toolPrepairRecordRepository;
            _toolPackManageRepository = toolPackManageRepository;
       }

        public List<t_ToolType> GetCategoryByClassify(int classifyType, string name = "")
        {
            return _toolCategoryInfoRepository.GetCategoryByClassify(classifyType,name);
        }
        public long AddToolInfo(t_ToolInfo toolInfo, string OptionType)
        {
            //_toolInfoRepository.Add(toolInfo);
            if (_toolInfoRepository.GetToolByCode(toolInfo.ToolCode) == null)
            {
                _toolInfoRepository.InsertToolInfo(toolInfo);

                var entity1 = new t_CurrentCountInfo();
                entity1.TypeName = toolInfo.TypeName;
                entity1.ChildTypeName = toolInfo.ChildTypeName;
                entity1.ToolCode = toolInfo.ToolCode;
                entity1.ToolName = toolInfo.ToolName;
                entity1.Models = toolInfo.Models;
                entity1.Location = toolInfo.Location;
                entity1.Remarks = toolInfo.Remarks;
                entity1.InStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                entity1.OptionType = OptionType;
                entity1.OptionPerson = toolInfo.OptionPerson;
                return _currentCountInfoRepository.Add(entity1);
            }
            return 0;
        }

        /// <summary>
        /// 是否存在编号的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public bool IsExistsByCode(string toolCode)
        {
            return _toolInfoRepository.IsExistsByCode(toolCode);
        }
        /// <summary>
        /// 获取工具列表
        /// </summary>
        /// <param name="blongValue"></param>
        /// <param name="categoryValue"></param>
        /// <param name="toolCode"></param>
        /// <param name="toolName"></param>
        /// <returns></returns>
        public List<ToolInfoExtend> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName, bool is_Out_checkBox, bool is_OutTime_checkBox, bool is_ToRepare_checkBox, string cbCheckTime, int pageIndex, int pageSize, string orderBy, string orderByType, out long totalCount)
        {
            if (is_OutTime_checkBox)//要链接借用表
            {
                List<ToolInfoExtend> list = new List<ToolInfoExtend>();
                string sql = @"select *,(case [IsBack] when '0' then '是' else '否' end) as IsBackString,(case [IsRepaired] when 1 then '是' else '否' end) as IsRepairedString from (
       select top 100 PERCENT t.*, o.[UserTimeInfo],o.[PersonCode],o.[PersonName], ROW_NUMBER() OVER ( {0}) as rank from [dbo].[t_ToolInfo] as t 
left join  [dbo].[t_OutBackStore] o on t.ToolCode = o.ToolCode where t.IsBack=0 and  o.IsBack=0 {1}
)  as t where  t.rank between @startPos and @endPos ";
                string sqlCount = @"select count(1) from [dbo].[t_ToolInfo] as t 
left join  [dbo].[t_OutBackStore] o on t.ToolCode = o.ToolCode where t.IsBack=0 and  o.IsBack=0 {0}";
                string sqlWhere = "";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("startPos", ((pageIndex - 1) * pageSize + 1));
                parameters.Add("endPos", pageIndex * pageSize);

                if (!string.IsNullOrWhiteSpace(blongValue))
                {
                    sqlWhere += " and  t.[TypeName]=@TypeName";
                    parameters.Add("TypeName", blongValue);

                }
                if (!string.IsNullOrWhiteSpace(categoryValue))
                {
                    sqlWhere += " and t.[ChildTypeName] =@ChildTypeName";
                    parameters.Add("ChildTypeName", categoryValue);
                }
                if (!string.IsNullOrWhiteSpace(toolCode))
                {
                    sqlWhere += " and t.[ToolCode] LIKE @ToolCode";
                    parameters.Add("ToolCode", string.Format("%{0}%", toolCode));

                }
                if (!string.IsNullOrEmpty(toolName))
                {
                    sqlWhere += " and t.[ToolName] LIKE @ToolName";
                    parameters.Add("ToolName", string.Format("%{0}%", toolName));
                }
                
                if (is_ToRepare_checkBox) //如果已经送修
                {
                    sqlWhere += " and t.[IsRepaired] = 1";
                }

                sqlWhere += " and o.[UserTimeInfo]<>'' and o.[UserTimeInfo] <@UserTimeInfo";
                parameters.Add("UserTimeInfo", DateTime.Now);
                
                if (cbCheckTime != "0") //如果不为0，过滤检测时间
                {
                    int daysLevel = int.Parse(cbCheckTime);
                    if (daysLevel == -1)//已过检修时间
                    {
                        sqlWhere += " and t.[CheckTime]<>''  and t.[CheckTime] <@thisSetTime ";
                        parameters.Add("thisSetTime", DateTime.Now);

                    }
                    else
                    {
                        sqlWhere += " and t.[CheckTime]<>'' and t.[CheckTime]>=@thisSetTimeNow and t.[CheckTime] <=@thisSetTime";
                        parameters.Add("thisSetTime", DateTime.Now.AddDays(daysLevel));
                        parameters.Add("thisSetTimeNow", DateTime.Now);

                    }
                }
                string sqlOrderBy = "";

                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    sqlOrderBy = string.Format(" order by t.{0} {1}", orderBy, orderByType);
                }
                else
                {
                    sqlOrderBy = string.Format(" order by t.ToolCode asc");
                }

                sql = string.Format(sql,sqlOrderBy,sqlWhere + sqlOrderBy);
                sqlCount = string.Format(sqlCount, sqlWhere);

                var result = _multiTableQueryRepository.QueryList<ToolInfoExtend>(sql, parameters, out totalCount, sqlCount, false);
                return result.Any() ? result.ToList() : new List<ToolInfoExtend>();
            }
            else //不用链接            
            {
                List<ToolInfoExtend> list = new List<ToolInfoExtend>();
                string sql = @"select *,(case [IsBack] when '0' then '是' else '否' end) as IsBackString,(case [IsRepaired] when 1 then '是' else '否' end) as IsRepairedString from (
       select top 100 PERCENT *,ROW_NUMBER() OVER ( {0}) as rank from [dbo].[t_ToolInfo]  where 1=1 {1}
)  as t where  t.rank between @startPos and @endPos ";
                string sqlCount = "select count(1) from [dbo].[t_ToolInfo] where 1=1 {0}";
                string sqlWhere = "";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("startPos", ((pageIndex - 1) * pageSize + 1));
                parameters.Add("endPos", pageIndex * pageSize);

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
                if (is_Out_checkBox) //如果已经借出
                {
                    sqlWhere += " and [IsBack] = 0";
                }
                if (is_ToRepare_checkBox) //如果已经送修
                {
                    sqlWhere += " and [IsRepaired] = 1";
                }
                if (cbCheckTime != "0") //如果不为0，过滤检测时间
                {
                    int daysLevel = int.Parse(cbCheckTime);
                    if (daysLevel == -1)//已过检修时间
                    {
                        sqlWhere += " and [CheckTime]<>''  and [CheckTime] <@thisSetTime";
                        parameters.Add("thisSetTime", DateTime.Now);

                    }
                    else
                    {
                        sqlWhere += " and [CheckTime]<>'' and [CheckTime]>=@thisSetTimeNow and [CheckTime] <=@thisSetTime";
                        parameters.Add("thisSetTime", DateTime.Now.AddDays(daysLevel));
                        parameters.Add("thisSetTimeNow", DateTime.Now);

                    }
                }
                string sqlOrderBy ="";
                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    sqlOrderBy = string.Format(" order by {0} {1}", orderBy, orderByType);
                }
                else {
                    sqlOrderBy = string.Format(" order by ToolCode asc");
                }
                  sql = string.Format(sql,sqlOrderBy,sqlWhere + sqlOrderBy);
                sqlCount = string.Format(sqlCount, sqlWhere);

                var result = _multiTableQueryRepository.QueryList<ToolInfoExtend>(sql, parameters, out totalCount, sqlCount, false);
                return result.Any() ? result.ToList() : new List<ToolInfoExtend>();
            }
           
        }
        public t_ToolInfo GetToolByCode(string toolCode)
        {
            return _toolInfoRepository.GetToolByCode(toolCode);
        }
        public List<t_ToolInfo> GetToolByCodeOrPackCode(string code)
        {
            var list = new List<t_ToolInfo>();
//            var entity = _toolInfoRepository.GetToolByCode(code);
//            if (entity != null && !string.IsNullOrWhiteSpace(entity.ToolCode))
//            {
//                list.Add(entity);
//            }
//            else {
//                string sql = @"SELECT *
//                              FROM [t_ToolInfo] WHERE 1=1 AND [PackCode]=@PackCode AND [IsActive]=1";
               
//                DynamicParameters parameters = new DynamicParameters();
//                parameters.Add("PackCode", code);
//                var result = _multiTableQueryRepository.QueryList<t_ToolInfo>(sql, parameters);
//                if(result!=null&&result.Any())
//                {
//                    list.AddRange(result.ToList());
//                }
//            }
            string sql = @"SELECT *
                              FROM [t_ToolInfo] WHERE 1=1 AND [PackCode]=@PackCode AND [IsActive]=1";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PackCode", code);
            var result = _multiTableQueryRepository.QueryList<t_ToolInfo>(sql, parameters);
            if (result != null && result.Any())
            {
                list.AddRange(result.ToList());
            }
            return list;
        }
        public bool UpdateTool(t_ToolInfo entity)
        {
            return _toolPackManageRepository.Update(entity);
        }
        public bool DelToolByCode(string ToolCode)
        {
            return _toolInfoRepository.DelToolByCode(ToolCode);
        }

        public bool DelTypeById(string SelectedToolCode)
        {
            return _toolCategoryInfoRepository.DelTypeById(SelectedToolCode);
        }
        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName);
        }
        public bool IsExistCategoryByName(string name, int classification)
        {
            return _toolCategoryInfoRepository.IsExistCategoryByName(name, classification);

        }
        public long AddCateGory(t_ToolType category)
        {
            return _toolCategoryInfoRepository.Add(category);

        }
        public bool OutStore(t_ToolInfo entity, t_PersonInfo person, string userCode,string toDate,string describ)
        {
            //1.删除库存
            entity.IsBack = "0";
            _toolInfoRepository.Update(entity);

            var outBackStore = new t_OutBackStore();
            outBackStore.ToolCode = entity.ToolCode;
            outBackStore.ToolName = entity.ToolName;
            outBackStore.OutStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            outBackStore.PersonCode = person.PersonCode;
            outBackStore.PersonName = person.PersonName;

            outBackStore.UserTimeInfo = toDate;
            outBackStore.IsBack = "0";
            outBackStore.outdescribes = describ;
            outBackStore.OptionPerson = userCode;
            outBackStore.IsCredit = "1";

            _outBackStoreRepository.Add(outBackStore);

            var currentCount = new t_CurrentCountInfo();
            currentCount.TypeName = entity.TypeName;
            currentCount.ChildTypeName = entity.ChildTypeName;
            currentCount.PackCode = entity.PackCode;
            currentCount.PackName = entity.PackName;
            currentCount.ToolCode = entity.ToolCode;


            currentCount.ToolName = entity.ToolName;
            currentCount.Models = entity.Models;
            currentCount.Location = entity.Location;
            currentCount.Remarks = entity.Remarks;
            currentCount.OutStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            currentCount.OptionType = "领用";
            currentCount.PersonCode = person.PersonCode;
            currentCount.PersonName = person.PersonName;
            currentCount.describes = describ;
            currentCount.OptionPerson = userCode;
            //2.outbackstore表增加领用记录
            return _currentCountInfoRepository.Add(currentCount)>0;

        }

        public t_OutBackStore GetToolOutByCode(string toolCode)
        {
            return _outBackStoreRepository.GetToolOutByCode(toolCode);
        }
        public bool IsExistsOutStoreByCode(string toolcode, string isBack)
        {
            return _outBackStoreRepository.IsExistsByCode(toolcode, isBack);
        }
        public bool BackStore(OutBackStoreEntity entity, t_PersonInfo person, string opeartPerson, string desc)
        {
           
            _toolInfoRepository.SetToolIsBack(entity.ToolCode, "1"); //设置工具信息为已归还

            t_OutBackStore entityOut = _outBackStoreRepository.GetToolOutByCode(entity.ToolCode);
            if (entityOut != null)
            {
                entityOut.IsBack = "1";
                entityOut.BackTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                entityOut.BackPesonCode = person.PersonCode;
                entityOut.BackPersonName = person.PersonName;
                entityOut.backdescribes = desc;
                _outBackStoreRepository.Update(entityOut);
            }
           

            var entity1 = new t_CurrentCountInfo();
            entity1.TypeName = entity.TypeName;
            entity1.ChildTypeName = entity.ChildTypeName;
            entity1.ToolCode = entity.ToolCode;
            entity1.ToolName = entity.ToolName;
            entity1.Models = entity.Models;
            entity1.Location = entity.Location;
            entity1.Remarks = entity.Remarks;
            entity1.BackTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity1.OptionType = "归还";
            entity1.PersonCode = entity.PersonCode;
            entity1.PersonName = entity.PersonName;

            entity1.BackPesonCode = person.PersonCode;
            entity1.BackPersonName = person.PersonName;

            entity1.describes = desc;

            entity1.OptionPerson = opeartPerson;
            return _currentCountInfoRepository.Add(entity1)>0;
        }
       /// <summary>
       /// 获取库存中的工具信息
       /// </summary>
       /// <param name="toolInfo"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="totalCount"></param>
       /// <returns></returns>
        public List<ToolInfoForStockInfoEntity> GetToolInfoListForStock(t_ToolInfo toolInfo, int pageIndex, int pageSize, out long totalCount)
        {
            string sql = @"SELECT TOP "+pageSize+ @" [TypeName]
                                  ,[ChildTypeName]
                                  ,[ToolCode]
                                  ,[ToolName]
                              FROM [t_ToolInfo] WHERE (IsBack='1' or IsBack is null) ";
            string sqlNotStr = "[ToolID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [ToolID] FROM [dbo].[t_ToolInfo] WHERE (IsBack='1' or IsBack is null)  ";
            string sqlCount = "SELECT COUNT(*) FROM [dbo].[t_ToolInfo]  WHERE  (IsBack='1' or IsBack is null) ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolInfo.TypeName))
            {
                string str = " AND TypeName LIKE @typeName ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("typeName", string.Format("%{0}%", toolInfo.TypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ChildTypeName))
            {
                string str = " AND ChildTypeName LIKE @childTypeName ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("childTypeName", string.Format("%{0}%", toolInfo.ChildTypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolInfo.ToolCode));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolName))
            {
                string str = " AND ToolName LIKE @toolName ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolName", string.Format("%{0}%", toolInfo.ToolName));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _multiTableQueryRepository.QueryList<ToolInfoForStockInfoEntity>(sqlfinal, parameters, out totalCount, sqlCount, false).ToList();
        }
       /// <summary>
       /// 总库存查询
       /// </summary>
       /// <returns></returns>
        public List<CountToolInfoEntity> GetCountInToolInfo(t_ToolInfo toolInfo)
        {
            string sql = "SELECT ChildTypeName AS TypeName, COUNT(1) as Quantity FROM t_ToolInfo WHERE 1=1 AND (IsBack='1' or IsBack is null) ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolInfo.TypeName))
            {
                string str = " AND TypeName LIKE @typeName ";
                sql += str;
                parameters.Add("typeName", string.Format("%{0}%", toolInfo.TypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ChildTypeName))
            {
                string str = " AND ChildTypeName LIKE @childTypeName ";
                sql += str;
                parameters.Add("childTypeName", string.Format("%{0}%", toolInfo.ChildTypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolInfo.ToolCode));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolName))
            {
                string str = " AND ToolName LIKE @toolName ";
                sql += str;
                parameters.Add("toolName", string.Format("%{0}%", toolInfo.ToolName));
            }
            sql += " GROUP BY ChildTypeName";
            return _multiTableQueryRepository.QueryList<CountToolInfoEntity>(sql, parameters).ToList();
        }
       /// <summary>
       /// 获取导出的库存数据
       /// </summary>
       /// <param name="toolInfo"></param>
       /// <returns></returns>
        public List<ToolInfoForStockInfoEntity> GetToolInfoListForStock(t_ToolInfo toolInfo)
        {
            string sql = @"SELECT  [TypeName]
                                  ,[ChildTypeName]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[OptionPerson]
                              FROM [t_ToolInfo] WHERE (IsBack='1' or IsBack is null)  ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolInfo.TypeName))
            {
                string str = " AND TypeName LIKE @typeName ";
                sql += str;
                parameters.Add("typeName", string.Format("%{0}%", toolInfo.TypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ChildTypeName))
            {
                string str = " AND ChildTypeName LIKE @childTypeName ";
                sql += str;
                parameters.Add("childTypeName", string.Format("%{0}%", toolInfo.ChildTypeName));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolInfo.ToolCode));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.ToolName))
            {
                string str = " AND ToolName LIKE @toolName ";
                sql += str;
                parameters.Add("toolName", string.Format("%{0}%", toolInfo.ToolName));
            }
            return _multiTableQueryRepository.QueryList<ToolInfoForStockInfoEntity>(sql, parameters).ToList();

        }
       /// <summary>
       /// 获取保修所需的实体信息（分页）
       /// </summary>
       /// <param name="toolCode"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="totalCount"></param>
       /// <returns></returns>
        public List<ToolInfoForRepairEntity> GetToolInfoForRepair(string toolCode, int pageIndex, int pageSize, out long totalCount)
        {
            string sql = @"SELECT TOP " + pageSize + @" [TypeName]
                                  ,[ChildTypeName]
                                  ,[PackCode]
                                  ,[PackName]
                                  ,[ToolCode]
                                  ,[ToolName]
                                  ,[Models]
                                  ,[Location]
                                  ,[Remarks]
                                  ,[CheckTime]
                                  ,[IsActive] = case IsActive WHEN '0' THEN '否' WHEN '1' THEN '有' WHEN '2' THEN '送修' END
                                  ,[OptionPerson]
                              FROM [t_ToolInfo] WHERE 1=1";
            string sqlNotStr = "[ToolID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [ToolID] FROM [dbo].[t_ToolInfo] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [dbo].[t_ToolInfo] WHERE IsAcTive=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(toolCode))
            {
                string str = " AND ToolCode LIKE @toolCode ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _multiTableQueryRepository.QueryList<ToolInfoForRepairEntity>(sqlfinal, parameters, out totalCount, sqlCount, false).ToList();

        }
       /// <summary>
       /// 设置工具为保修
       /// </summary>
       /// <param name="toolCode"></param>
       /// <returns></returns>
        public bool UpdateToolRepared(string toolCode,string userCode)
        {
            bool IsSuccess = false;
            t_ToolInfo toolInfo = GetToolByCode(toolCode);
            //if (toolInfo == null)
            //{
            //    return IsSuccess;
            //}
            //toolInfo.IsActive = "2";//2为送修状态
            //IsSuccess = UpdateTool(toolInfo);
            ////往送修表插入一条记录
            t_ToolRepairRecord prepairInfo = new t_ToolRepairRecord();
            //if(!IsSuccess)
            //{
            //    return IsSuccess;
            //}
            //prepairInfo.ToolCode = toolInfo.ToolCode;
            //prepairInfo.ToolName = toolInfo.ToolName;
            //prepairInfo.OptionPerson = userCode;
            //prepairInfo.PrepairTime = DateTime.Now.ToString();
            //prepairInfo.IsActive = 0;
            return IsSuccess =  _toolPrepairRecordRepository.Add(prepairInfo)>0;
        }

       /// <summary>
       /// 设置工具维修状态改为正常
       /// </summary>
       /// <param name="toolCode"></param>
       /// <returns></returns>
        public bool UpdateToolReparedIsActive(string toolCode,string userCode)
        {
            bool IsSuccess = false;
            //t_ToolRepairRecord toolPrepairInfo = new t_ToolRepairRecord();
            //toolPrepairInfo = _toolPrepairRecordRepository.GetToolPrepairRecordByToolCode(toolCode);
            //if (toolPrepairInfo == null)
            //{
            //    return IsSuccess;
            //}
            //toolPrepairInfo.BackTime = DateTime.Now.ToString();
            //toolPrepairInfo.BackOptionPerson = userCode;
            //toolPrepairInfo.IsActive = 1;
            //IsSuccess = _toolPrepairRecordRepository.Update(toolPrepairInfo);
            //if (!IsSuccess)
            //{
            //    return IsSuccess;
            //}
            t_ToolInfo toolInfo = GetToolByCode(toolCode);
            //toolInfo.IsActive = "1";//2为送修状态
            return IsSuccess = UpdateTool(toolInfo);
        }
        /// <summary>
        /// 导入工具
        /// </summary>
        /// <param name="InfoList"></param>
        /// <returns></returns>
        public bool ImportToolInfoExcel(List<t_ToolInfo> InfoList)
        {
            foreach (var toolInfo in InfoList)
            {
                AddToolInfo(toolInfo, "导入");
            }
            return true;
        }

        public t_ToolType GetCategoryById(string SelectedToolCode)
        {
            return _toolCategoryInfoRepository.GetModelById(SelectedToolCode);

        }

        public bool UpdateType(t_ToolType type)
        {
            return _toolCategoryInfoRepository.Update(type);
        }

        public bool IsExistToolByType(string typeName, int type)
        {
            return _toolInfoRepository.IsExistToolByType(typeName, type);
        }
       /// <summary>
       /// 查询所有的包分页信息
       /// </summary>
       /// <param name="packCode"></param>
       /// <param name="packName"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="Count"></param>
       /// <returns></returns>
        public List<ToolPackViewEntity> GetPackInfoList(string packCode, string packName, int pageIndex, int pageSize, out long Count)
        {
            DynamicParameters parameters = new DynamicParameters();
            string sql = @"select top "+pageSize+" a.PackCode,a.PackName from (select  ROW_NUMBER() OVER(ORDER BY PackCode ASC) as ID ,PackCode,PackName, COUNT(1) as Number from t_ToolInfo where packcode !=''  group by PackCode,PackName) a where 1=1 ";
            string sqlCount = "SELECT COUNT(1) FROM (select  ROW_NUMBER() OVER(ORDER BY PackCode ASC) as ID ,PackCode,PackName, COUNT(1) as Number from t_ToolInfo where packcode !=''  group by PackCode,PackName) a where 1=1 ";
            if (!string.IsNullOrEmpty(packCode))
            {
                sql += " AND a.PackCode LIKE @packCode ";
                sqlCount += " AND a.PackCode LIKE @packCode ";
                parameters.Add("packCode",string.Format("%{0}%",packCode));
            }
            if (!string.IsNullOrEmpty(packName))
            {
                sql += " AND a.PackName LIKE @packName ";
                sqlCount += " AND a.PackName LIKE @packName ";
                parameters.Add("packName", string.Format("%{0}%", packName));
            }
            sql += "AND a.ID>"+(pageIndex-1)*pageSize;
            return _multiTableQueryRepository.QueryList<ToolPackViewEntity>(sql, parameters, out Count, sqlCount).ToList();
        }
       /// <summary>
       /// 查询导出的包信息
       /// </summary>
       /// <param name="packCode"></param>
       /// <param name="packName"></param>
       /// <returns></returns>
        public List<ToolPackViewEntity> GetPackInfoList(string packCode, string packName)
        {
            string sql = "SELECT  a.PackCode,a.PackName from (select  ROW_NUMBER() OVER(ORDER BY PackCode ASC) as ID ,PackCode,PackName, COUNT(1) as Number from t_ToolInfo where packcode !=''  group by PackCode,PackName) a where 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(packCode))
            {
                sql += " AND a.PackCode LIKE @packCode ";
                parameters.Add("packCode", string.Format("%{0}%", packCode));
            }
            if (!string.IsNullOrEmpty(packName))
            {
                sql += " AND a.PackName LIKE @packName ";
                parameters.Add("packName", string.Format("%{0}%", packName));
            }
            return _multiTableQueryRepository.QueryList<ToolPackViewEntity>(sql, parameters).ToList();
        }

        public ToolInfoExtend GetToolInfoExtend(string toolCode)
        {
            var result = new ToolInfoExtend();
            var toolInfo = GetToolByCode(toolCode);
            if (toolInfo != null)
            {
                result.ToolID = toolInfo.ToolID;
                result.ToolCode = toolInfo.ToolCode;
                result.TypeName = toolInfo.TypeName;
                result.ChildTypeName = toolInfo.ChildTypeName;
                result.PackCode = toolInfo.PackCode;
                result.PackName = toolInfo.PackName;
                result.CarGroupInfo = toolInfo.CarGroupInfo;
                result.ToolName = toolInfo.ToolName;
                result.Models = toolInfo.Models;
                result.Location = toolInfo.Location;
                result.Remarks = toolInfo.Remarks;
                result.CheckTime = toolInfo.CheckTime;
                result.IsRepaired = toolInfo.IsRepaired;
                result.OptionPerson = toolInfo.OptionPerson;
                result.IsBack = toolInfo.IsBack;

                if (toolInfo.IsBack == "0")//未归还
                {
                    var OutEntity = _outBackStoreRepository.GetToolOutByCode(toolCode);
                    if (OutEntity != null && !string.IsNullOrWhiteSpace(OutEntity.ToolCode))
                    {
                        result.UserTimeInfo = OutEntity.UserTimeInfo;
                        result.PersonCode = OutEntity.PersonCode;
                        result.PersonName = OutEntity.PersonName;
                    }
                }

                if (toolInfo.IsRepaired == 1)//如果已经送修啦
                {
                    var repaireInfo = _toolPrepairRecordRepository.GetToolRepairByCodeNotReceived(toolCode);
                        if(repaireInfo!=null)
                        {
                            result.RepairedTime = repaireInfo.ToRepairedTime??DateTime.MinValue;
                        }
                }
            }
            return result;
        }
        public bool ToRepaireTool(t_ToolInfo tool)
        {
            if (tool.IsRepaired == 1)
            {
                return false;
            }
            tool.IsRepaired = 1;
            _toolInfoRepository.Update(tool);
            var toolRepair = new t_ToolRepairRecord();

            toolRepair.TypeName = tool.TypeName;
            toolRepair.ChildTypeName = tool.ChildTypeName;
            toolRepair.PackCode = tool.PackCode;
            toolRepair.PackName = tool.PackName;
            toolRepair.ToolCode = tool.ToolCode;
            toolRepair.ToolName = tool.ToolName;
            toolRepair.ToRepairedTime = DateTime.Now;
            toolRepair.ToRepairedPerCode =LoginHelper.UserCode;
            toolRepair.ToRepairedPerName = LoginHelper.UserName;
            toolRepair.ToolStatus = 1;

            _toolPrepairRecordRepository.Add(toolRepair);
            
            return true;
        }

    }
}
