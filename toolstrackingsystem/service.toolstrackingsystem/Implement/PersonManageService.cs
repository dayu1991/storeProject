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
    public class PersonManageService:IPersonManageService
    {
        private readonly IMultiTableQueryRepository _mutiTableQueryRepository;
        private readonly IPersonManageRepository _personManageRepository;
        public PersonManageService(IMultiTableQueryRepository multiTableQueryRepository, IPersonManageRepository personManageRepository)
        {
            this._mutiTableQueryRepository = multiTableQueryRepository;
            this._personManageRepository = personManageRepository;
        }
        public List<PersonInfoEntity> GetPersonInfoList(PersonInfoEntity personInfo)
        {
            string sql = "SELECT PersonCode,PersonName,IsReceive,Remarks FROM t_PersonInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(personInfo.PersonCode))
            {
                sql += " AND PersonCode LIKE @personCode ";
                parameters.Add("personCode",string.Format("%{0}%",personInfo.PersonCode));
            }
            if (!string.IsNullOrEmpty(personInfo.PersonName))
            {
                sql += " AND PersonName LIE @personName ";
                parameters.Add("personName",string.Format("%{0}%",personInfo.PersonName));
            }
            if (!string.IsNullOrEmpty(personInfo.IsReceive))
            {
                sql += " AND IsReceive=@isReceive";
                parameters.Add("isReceive",personInfo.IsReceive);
            }
            return _mutiTableQueryRepository.QueryList<PersonInfoEntity>(sql,parameters).ToList();
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<PersonInfoEntity> GetPersonInfoList(PersonInfoEntity personInfo, int pageIndex, int pageSize, out long Count)
        {
            string sql = "SELECT TOP "+pageSize;
            sql += " PersonCode,PersonName,IsReceive =case IsReceive when 1 then '是' when 0 then '否' end,Remarks FROM t_PersonInfo WHERE 1=1 ";
            sql += "AND PersonID NOT IN (SELECT TOP " + ((pageIndex - 1) * pageSize) + " PersonID FROM t_PersonInfo) ";
            string sqlCount = "SELECT COUNT(*) FROM t_PersonInfo WHERE 1=1 ";
            DynamicParameters parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(personInfo.PersonCode))
            {
                sql += " AND PersonCode LIKE @personCode ";
                sqlCount = " AND PersonCode LIKE @personCode ";
                parameters.Add("personCode", string.Format("%{0}%", personInfo.PersonCode));
            }
            if (!string.IsNullOrEmpty(personInfo.PersonName))
            {
                sql += " AND PersonName LIKE @personName ";
                sqlCount += " AND PersonName LIKE @personName ";
                parameters.Add("personName", string.Format("%{0}%", personInfo.PersonName));
            }
            if (!string.IsNullOrEmpty(personInfo.IsReceive))
            {
                sql += " AND IsReceive=@isReceive ";
                sqlCount +=  " AND IsReceive=@isReceive ";
                parameters.Add("isReceive", personInfo.IsReceive);
            }
            //sql += "LIMIT "+pageIndex+","+(pageIndex+pageSize);
            return _mutiTableQueryRepository.QueryList<PersonInfoEntity>(sql, parameters, out Count, sqlCount, false).ToList();
        }
    

        public bool InsertPersonInfo(dbentity.toolstrackingsystem.t_PersonInfo personInfo)
        {
            return _personManageRepository.InsertPersonInfo(personInfo);
        }
        public t_PersonInfo GetPersonInfo(string personCode)
        {
            return _personManageRepository.GetPersonInfoByPersonCode(personCode);
        }

        public bool UpdatePersonInfo(t_PersonInfo personInfo)
        {
            return _personManageRepository.UpdatePersonInfo(personInfo);
        }

        public bool DeletePersonInfo(string personCode)
        {
            return _personManageRepository.DeletePersonInfo(personCode);
        }
    }
}
