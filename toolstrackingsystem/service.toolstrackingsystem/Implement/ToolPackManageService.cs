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
    public class ToolPackManageService:IToolPackManageService
    {
        private readonly IToolPackManageRepository _toolPackManageRepository;
        private readonly IMultiTableQueryRepository _multiTableQueryRepository;
        public ToolPackManageService(IToolPackManageRepository toolPackManageRepository, IMultiTableQueryRepository multiTableQueryRepository)
        {
            this._toolPackManageRepository = toolPackManageRepository;
            this._multiTableQueryRepository = multiTableQueryRepository;

        }
        public List<ToolInfoForPackEntity> GetToolInfoForPack(t_ToolInfo toolInfo)
        {
            string sql = "SELECT TypeName,ChildTypeName,ToolCode,ToolName,Models,Location,Remarks FROM t_ToolInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolInfo.PackCode))
            {
                sql += " AND PackCode = @packCode ";
                parameters.Add("packCode", toolInfo.PackCode);
            }
            if (!string.IsNullOrEmpty(toolInfo.PackName))
            {
                sql += " AND PackName = @packName ";
                parameters.Add("packName", toolInfo.PackName);
            }
            return _multiTableQueryRepository.QueryList<ToolInfoForPackEntity>(sql, parameters).ToList();
        }
        public List<t_ToolInfo> GetToolInfoInPack(t_ToolInfo toolInfo)
        {
            string sql = "SELECT * FROM t_ToolInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolInfo.PackCode))
            {
                sql += " AND PackCode = @packCode ";
                parameters.Add("packCode", toolInfo.PackCode);
            }
            if (!string.IsNullOrEmpty(toolInfo.PackName))
            {
                sql += " AND PackName = @packName ";
                parameters.Add("packName", toolInfo.PackName);
            }
            return _toolPackManageRepository.QueryList(sql,parameters).ToList();
        }
        public List<t_ToolInfo> GetToolInfoInPack(string packCode)
        {
            string sql = "SELECT * FROM t_ToolInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(packCode))
            {
                sql += " AND PackCode = @packCode ";
                parameters.Add("packCode", string.Format("%{0}%", packCode));
            }
            return _toolPackManageRepository.QueryList(sql, parameters).ToList();
        }
        public bool DeletePackInfo(string packCode)
        {
            bool IsSuccess = false;
            t_ToolInfo toolInfo = new t_ToolInfo();
            toolInfo.PackCode = packCode;
            //1.查询工具包里所有的工具信息
            List<t_ToolInfo> toolInfoList = new List<t_ToolInfo>();
            toolInfoList = GetToolInfoInPack(toolInfo);
            //2.把工具信息中packCode和packName置为空
            foreach (var item in toolInfoList)
            {
                item.PackCode = null;
                item.PackName = null;
                item.CarGroupInfo = null;
                //3.保存数据到数据库中
                if (!_toolPackManageRepository.Update(item))
                {
                    IsSuccess = false;
                    return IsSuccess;
                }
                else
                {
                    IsSuccess = true;
                }
            }
            return IsSuccess;
        }
        public t_ToolInfo GetToolInfoByToolCode(string toolCode)
        {
            string sql = "SELECT * FROM t_ToolInfo WHERE ToolCode=@toolCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode",toolCode);
            return _toolPackManageRepository.GetModel(sql,parameter);
        }
        /// <summary>
        /// 完成组包
        /// </summary>
        /// <returns></returns>
        public bool CompleteToolPack(List<ToolInfoForPackEntity> toolInfoList,string packCode,string packName,string carGroupInfo)
        {
            bool IsSuccess = false;
            //1.删除已有的包信息
            List<t_ToolInfo> list = new List<t_ToolInfo>();
            list = GetToolInfoInPack(packCode);
            foreach (var item in list)
            {
                item.PackCode = null;
                item.PackName = null;
                item.CarGroupInfo = null;
                if (!_toolPackManageRepository.Update(item))
                {
                    return IsSuccess;
                }
            }
            list = null;
            foreach (var item in toolInfoList)
            {
                t_ToolInfo toolInfo = new t_ToolInfo();
                toolInfo = GetToolInfoByToolCode(item.ToolCode);
                toolInfo.PackCode = packCode;
                toolInfo.PackName = packName;
                toolInfo.CarGroupInfo = carGroupInfo;
                //2.更新最新的包信息
                if (!_toolPackManageRepository.Update(toolInfo))
                {
                    return IsSuccess;
                }
            }
            IsSuccess = true;
            return IsSuccess;
        }
    }
}
