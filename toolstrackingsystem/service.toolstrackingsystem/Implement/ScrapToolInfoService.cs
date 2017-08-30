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
    public class ScrapToolInfoService : IScrapToolInfoService
    {
        private readonly IScrapToolInfoManageRepository _scrapToolInfoManageRepository;
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        private readonly IToolPackManageRepository _toolPackManageRepository;
        private readonly IInStoreRepository _inStoreRepository;
        public ScrapToolInfoService(IScrapToolInfoManageRepository scrapToolInfoManageRepository, IMultiTableQueryRepository multiTableQueryRepository, IToolPackManageRepository toolPackManageRepository,
            InStoreRepository inStoreRepository)
        {
            this._scrapToolInfoManageRepository = scrapToolInfoManageRepository;
            this._mutiTableQueryRepository = multiTableQueryRepository;
            this._toolPackManageRepository = toolPackManageRepository;
            this._inStoreRepository = inStoreRepository;
        }
        /// <summary>
        /// 通过工具编码精确查找工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public List<ToolInfoForScrapFrmEntity> GetToolInfoForScrapList(string toolCode,string childTypeName)
        {
            string sql = "SELECT TypeName,ChildTypeName,ToolCode,ToolName,PackCode,PackName,Models,Location,Remarks FROM t_ToolInfo WHERE 1=1 AND IsActive='1'";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                sql += " AND ToolCode LIKE @toolCode ";
                parameter.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrEmpty(childTypeName))
            {
                sql += " AND ChildTypeName = @childTypeName ";
                parameter.Add("childTypeName", childTypeName);
            }
            return _mutiTableQueryRepository.QueryList<ToolInfoForScrapFrmEntity>(sql, parameter).ToList();
        }
        public t_ToolInfo GetToolInfoByToolCode(string toolCode)
        {
            string sql = "SELECT * FROM t_ToolInfo WHERE ToolCode = @toolCode AND IsActive='1'";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode",toolCode);
            return _toolPackManageRepository.GetModel(sql,parameter);
        }
        /// <summary>
        /// 废除工具，返回废除的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="optionPerson"></param>
        /// <returns></returns>
        public t_ScrapToolInfo ScrapTool(string toolCode, string optionPerson)
        {
            bool IsSuccess = false;
            t_ScrapToolInfo scrapToolInfo = new t_ScrapToolInfo();
            t_ToolInfo toolInfo = new t_ToolInfo();
            toolInfo = GetToolInfoByToolCode(toolCode);
            //1.删除工具表中基础信息
            IsSuccess =_toolPackManageRepository.Delete(toolInfo);
            //2.清除库存中该工具的信息
            IsSuccess = _inStoreRepository.DeleteByCode(toolCode);
            //3.在作废信息表中插入作废的ToolInfo
            scrapToolInfo.TypeName = toolInfo.TypeName;
            scrapToolInfo.ChildTypeName = toolInfo.ChildTypeName;
            scrapToolInfo.ToolCode = toolInfo.ToolCode;
            scrapToolInfo.ToolName = toolInfo.ToolName;
            scrapToolInfo.PackCode = toolInfo.PackCode;
            scrapToolInfo.PackName = toolInfo.PackName;
            scrapToolInfo.ScrapTime = DateTime.Now.ToString();
            //scrapToolInfo.Remarks = toolInfo.Remarks;
            scrapToolInfo.OptionPerson = optionPerson;
            IsSuccess = _scrapToolInfoManageRepository.InsertScrapToolInfo(scrapToolInfo);
            if (IsSuccess)
            {
                return scrapToolInfo;
            }
            else {
                return null;
            }
        }
        /// <summary>
        /// 查找满足条件的废除的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public List<t_ScrapToolInfo> GetScrapToolInfoList(string toolCode, string childTypeName)
        {
            string sql = @"SELECT sti.[ScrapID]
      ,sti.[TypeName] 
      ,sti.[ChildTypeName]
      ,sti.[ToolCode]
      ,sti.[ToolName]
      ,sti.[PackCode]
      ,sti.[PackName]
      ,sti.[ScrapTime]
      ,sti.[Remarks]
      ,[OptionPerson] = 
	  case when sui.UserName is null then tpi.PersonName else sui.UserName end
      ,[RemarkPerson] = 
	  case when sui1.UserName is null then tpi1.PersonCode else sui1.UserName end
      ,sti.[RemarkTime]
  FROM [dbo].[t_ScrapToolInfo] sti left join Sys_User_Info sui on sti.OptionPerson = sui.UserCode left join t_PersonInfo tpi on sti.OptionPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on sti.RemarkPerson = sui1.UserCode left join t_PersonInfo tpi1 on sti.RemarkPerson = tpi1.PersonCode WHERE 1=1";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                sql += " AND sti.ToolCode LIKE @toolCode ";
                parameter.Add("toolCode", string.Format("%{0}%", toolCode));            
            }
            if (!string.IsNullOrEmpty(childTypeName))
            {
                sql += " AND sti.CchildTypeName = @childTypeName ";
                parameter.Add("childTypeName", childTypeName);
            }
            //return _mutiTableQueryRepository.QueryList<ScrapToolInfoEntity>(sql, parameter).ToList();
            return _scrapToolInfoManageRepository.QueryList(sql, parameter).ToList();
        }
        /// <summary>
        /// 查找满足条件的废除的工具信息(有分页)
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        public List<t_ScrapToolInfo> GetScrapToolInfoList(string toolCode, string childTypeName, int pageIndex, int pageSize, out long Count)
        {
            string sql = "SELECT TOP "+pageSize+ @" sti.[ScrapID]
      ,sti.[TypeName] 
      ,sti.[ChildTypeName]
      ,sti.[ToolCode]
      ,sti.[ToolName]
      ,sti.[PackCode]
      ,sti.[PackName]
      ,sti.[ScrapTime]
      ,sti.[Remarks]
      ,[OptionPerson] = 
	  case when sui.UserName is null then tpi.PersonName else sui.UserName end
      ,[RemarkPerson] = 
	  case when sui1.UserName is null then tpi1.PersonCode else sui1.UserName end
      ,sti.[RemarkTime]
  FROM [dbo].[t_ScrapToolInfo] sti left join Sys_User_Info sui on sti.OptionPerson = sui.UserCode left join t_PersonInfo tpi on sti.OptionPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on sti.RemarkPerson = sui1.UserCode left join t_PersonInfo tpi1 on sti.RemarkPerson = tpi1.PersonCode WHERE 1=1 ";
            string sqlNot = " sti.[ScrapID] not in (SELECT TOP " + (pageIndex - 1) * pageSize + @" sti.[ScrapID] FROM [dbo].[t_ScrapToolInfo] sti left join Sys_User_Info sui on sti.OptionPerson = sui.UserCode left join t_PersonInfo tpi on sti.OptionPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on sti.RemarkPerson = sui1.UserCode left join t_PersonInfo tpi1 on sti.RemarkPerson = tpi1.PersonCode WHERE 1=1 )";
            DynamicParameters parameter = new DynamicParameters();
            string sqlCount = @"SELECT COUNT(1) FROM [dbo].[t_ScrapToolInfo] sti left join Sys_User_Info sui on sti.OptionPerson = sui.UserCode left join t_PersonInfo tpi on sti.OptionPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on sti.RemarkPerson = sui1.UserCode left join t_PersonInfo tpi1 on sti.RemarkPerson = tpi1.PersonCode WHERE 1=1 ";
            if (!string.IsNullOrEmpty(toolCode))
            {
                sql += " AND sti.ToolCode LIKE @toolCode ";
                sqlNot += " AND sti.ToolCode LIKE @toolCode ";
                sqlCount += " AND sti.ToolCode LIKE @toolCode ";
                parameter.Add("toolCode", string.Format("%{0}%", toolCode));
            }
            if (!string.IsNullOrEmpty(childTypeName))
            {
                sql += " AND sti.ChildTypeName = @childTypeName ";
                sqlNot += " AND sti.ChildTypeName = @childTypeName ";
                sqlCount += " AND sti.ChildTypeName = @childTypeName ";
                parameter.Add("packCode", childTypeName);
            }
            sqlNot += ")";
            string sqlFinal = string.Format("{0} AND {1} ",sql,sqlNot);
            return _mutiTableQueryRepository.QueryList<t_ScrapToolInfo>(sql, parameter, out Count, sqlCount, false).ToList();
            //return _scrapToolInfoManageRepository.QueryList(sqlFinal, parameter, out Count,sqlCount,false).ToList();
        }
        /// <summary>
        /// 更新报废的工具备注
        /// </summary>
        /// <param name="scrapID"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool SetScrapToolRemark(string scrapID, string remark, string userCode)
        {
            string sql = "UPDATE t_ScrapToolInfo SET Remark = @remark,RemarkPerson=@remarkPerson,RemarkTime@remarkTime WHERE ScrapID=@scrapID";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("scrapID", scrapID);
            parameters.Add("remark", remark);
            parameters.Add("remarkPerson",userCode);
            parameters.Add("remarkTime", DateTime.Now.ToString());
            return _scrapToolInfoManageRepository.ExecuteSql(sql, parameters) > 0;
        }
    }
}
