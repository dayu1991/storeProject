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
              private IInStoreRepository _inStoreRepository;

              private ICurrentCountInfoRepository _currentCountInfoRepository;
              private IOutBackStoreRepository _outBackStoreRepository;


        private IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolInfoService(IToolCategoryInfoRepository toolCategoryInfoRepository,
            IToolInfoRepository toolInfoRepository, 
            IMultiTableQueryRepository multiTableQueryRepository,
            IInStoreRepository inStoreRepository,
            ICurrentCountInfoRepository currentCountInfoRepository,
            IOutBackStoreRepository outBackStoreRepository)
       {
           _toolCategoryInfoRepository = toolCategoryInfoRepository;
           _toolInfoRepository = toolInfoRepository;
           _multiTableQueryRepository = multiTableQueryRepository;
            _inStoreRepository=inStoreRepository;
            _currentCountInfoRepository = currentCountInfoRepository;
            _outBackStoreRepository = outBackStoreRepository;
       }

        public List<t_ToolType> GetCategoryByClassify(int classifyType)
        {
            return _toolCategoryInfoRepository.GetCategoryByClassify(classifyType);
        }
        public long AddToolInfo(t_ToolInfo toolInfo, string OptionType)
        {
            _toolInfoRepository.Add(toolInfo);
            var entity = new t_InStore();
            entity.InStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.OptionPerson = toolInfo.OptionPerson;
            entity.ToolCode = toolInfo.ToolCode;
            entity.ToolName = toolInfo.ToolName;
            entity.TypeName = toolInfo.TypeName;
            entity.ChildTypeName = toolInfo.ChildTypeName;
            entity.OptionPerson = toolInfo.OptionPerson;
            _inStoreRepository.Add(entity);
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
        public List<t_ToolInfo> GetToolList(string blongValue, string categoryValue, string toolCode, string toolName, int pageIndex, int pageSize, out long totalCount)
        {
            return _toolInfoRepository.GetToolList(blongValue, categoryValue, toolCode, toolName,pageIndex,pageSize,out totalCount);
        }
        public t_ToolInfo GetToolByCode(string toolCode)
        {
            return _toolInfoRepository.GetToolByCode(toolCode);
        }
        public bool UpdateTool(t_ToolInfo entity)
        {
            return _toolInfoRepository.UpdateTool(entity);
        }

        public bool DelToolByCode(string ToolCode)
        {
            return _toolInfoRepository.DelToolByCode(ToolCode);
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

        public bool IsExistsInStoryByCode(string toolCode)
        {
            return _inStoreRepository.IsExistsInStoryByCode(toolCode);
        }

        public bool OutStore(t_ToolInfo entity, t_PersonInfo person, string userCode,string toDate,string describ)
        {
            _inStoreRepository.DeleteByCode(entity.ToolCode);
            var outBackStore = new t_OutBackStore();
            outBackStore.ToolCode = entity.ToolCode;
            outBackStore.ToolName = entity.ToolName;
            outBackStore.OutStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            outBackStore.PersonCode = person.PersonCode;
            outBackStore.PersonName = person.PersonName;

            outBackStore.UserTimeInfo = toDate;
            outBackStore.IsBack = "0";
            outBackStore.outdescribes = toDate;
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
            var entityInStory = new t_InStore();
            entityInStory.InStoreTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entityInStory.ToolCode = entity.ToolCode;
            entityInStory.ToolName = entity.ToolName;
            entityInStory.TypeName = entity.TypeName;
            entityInStory.ChildTypeName = entity.ChildTypeName;
            entityInStory.OptionPerson = opeartPerson;
            _inStoreRepository.Add(entityInStory);

            t_OutBackStore entityOut = _outBackStoreRepository.GetToolOutByCode(entity.ToolCode);
            entityOut.IsBack = "1";
            entityOut.BackTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entityOut.BackPesonCode = person.PersonCode;
            entityOut.BackPersonName = person.PersonName;
            entityOut.backdescribes = desc;
            _outBackStoreRepository.Update(entityOut);

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
            string sql = @"SELECT TOP "+pageSize+@" [ToolID]
                                  ,[TypeName]
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
                                  ,[OptionPerson]
                              FROM [cangku_manage_db].[dbo].[t_ToolInfo] WHERE 1=1";
            string sqlNotStr = "[ToolID] NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " [ToolID] FROM [dbo].[t_ToolInfo] WHERE 1=1 ";
            string sqlCount = "SELECT COUNT(*) FROM [dbo].[t_ToolInfo] WHERE IsAcTive=1 ";
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
            if (!string.IsNullOrWhiteSpace(toolInfo.Models))
            {
                string str = " AND Models LIKE @models ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("models", string.Format("%{0}%", toolInfo.Models));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.Location))
            {
                string str = " AND Location LIKE @location ";
                sql += str;
                sqlCount += str;
                sqlNotStr += str;
                parameters.Add("location", string.Format("%{0}%", toolInfo.Location));
            }
            sqlNotStr += ")";
            string sqlfinal = string.Format("{0} AND {1}", sql, sqlNotStr);
            return _multiTableQueryRepository.QueryList<ToolInfoForStockInfoEntity>(sqlfinal, parameters, out totalCount, sqlCount, false).ToList();
        }
       /// <summary>
       /// 总库存查询
       /// </summary>
       /// <returns></returns>
        public int GetCountInToolInfo(t_ToolInfo toolInfo)
        {
            string sql = "SELECT COUNT(1) FROM t_ToolInfo WHERE IsActive=1";
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
            if (!string.IsNullOrWhiteSpace(toolInfo.Models))
            {
                string str = " AND Models LIKE @models ";
                sql += str;
                parameters.Add("models", string.Format("%{0}%", toolInfo.Models));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.Location))
            {
                string str = " AND Location LIKE @location ";
                sql += str;
                parameters.Add("location", string.Format("%{0}%", toolInfo.Location));
            }

            return (int)_toolInfoRepository.QueryRecordCount(sql, parameters);
        }
       /// <summary>
       /// 获取导出的库存数据
       /// </summary>
       /// <param name="toolInfo"></param>
       /// <returns></returns>
        public List<ToolInfoForStockInfoEntity> GetToolInfoListForStock(t_ToolInfo toolInfo)
        {
            string sql = @"SELECT  [ToolID]
                                  ,[TypeName]
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
                                  ,[OptionPerson]
                              FROM [cangku_manage_db].[dbo].[t_ToolInfo] WHERE IsAcTive=1";
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
            if (!string.IsNullOrWhiteSpace(toolInfo.Models))
            {
                string str = " AND Models LIKE @models ";
                sql += str;
                parameters.Add("models", string.Format("%{0}%", toolInfo.Models));
            }
            if (!string.IsNullOrWhiteSpace(toolInfo.Location))
            {
                string str = " AND Location LIKE @location ";
                sql += str;
                parameters.Add("location", string.Format("%{0}%", toolInfo.Location));
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
                              FROM [cangku_manage_db].[dbo].[t_ToolInfo] WHERE 1=1";
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
        public bool UpdateToolRepared(string toolCode)
        {
            bool IsSuccess = false;
            t_ToolInfo toolInfo = GetToolByCode(toolCode);
            if (toolInfo == null)
            {
                return IsSuccess;
            }
            toolInfo.IsActive = "2";//2为送修状态
            return IsSuccess = UpdateTool(toolInfo);
        }

       /// <summary>
       /// 设置工具维修状态改为正常
       /// </summary>
       /// <param name="toolCode"></param>
       /// <returns></returns>
        public bool UpdateToolReparedIsActive(string toolCode)
        {
            bool IsSuccess = false;
            t_ToolInfo toolInfo = GetToolByCode(toolCode);
            if (toolInfo == null)
            {
                return IsSuccess;
            }
            toolInfo.IsActive = "1";//2为送修状态
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
    }
}
