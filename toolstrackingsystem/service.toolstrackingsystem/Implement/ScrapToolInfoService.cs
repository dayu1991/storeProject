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
        public List<ToolInfoForScrapFrmEntity> GetToolInfoForScrapList(string toolCode)
        {
            string sql = "SELECT TypeName,ChildTypeName,ToolCode,ToolName,PackCode,PackName,Models,Location,Remarks FROM t_ToolInfo WHERE 1=1 AND IsActive='1' AND ToolCode=@toolCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode",toolCode);
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
            scrapToolInfo.ToolCode = toolInfo.ToolCode;
            scrapToolInfo.ToolName = toolInfo.ToolName;
            scrapToolInfo.PackCode = toolInfo.PackCode;
            scrapToolInfo.PackName = toolInfo.PackName;
            scrapToolInfo.ScrapTime = DateTime.Now.ToString();
            scrapToolInfo.Remarks = toolInfo.Remarks;
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
        public List<t_ScrapToolInfo> GetScrapToolInfoList(string toolCode)
        {
            string sql = "SELECT * FROM t_ScrapToolInfo WHERE 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                sql += " AND ToolCode LIKE @toolCode";
                parameter.Add("toolCode", string.Format("%{0}%", toolCode));            
            }
            //return _mutiTableQueryRepository.QueryList<ScrapToolInfoEntity>(sql, parameter).ToList();
            return _scrapToolInfoManageRepository.QueryList(sql, parameter).ToList();
        }
    }
}
