using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class PersonManageRepository : RepositoryBase<t_PersonInfo>, IPersonManageRepository
    {
        public bool InsertPersonInfo(t_PersonInfo personInfo)
        {
            string sql = "INSERT INTO t_PersonInfo(PersonCode,PersonName,RFID,OptionPerson,IsReceive,Remarks)VALUES(@personCode,@personName,@personCode,'admin',@isReceive,@remarks)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("personCode",personInfo.PersonCode);
            parameters.Add("personName",personInfo.PersonName);
            parameters.Add("isReceive",personInfo.IsReceive);
            parameters.Add("remarks",personInfo.Remarks);
            return base.ExecuteSql(sql,parameters)>0;
        }


        public t_PersonInfo GetPersonInfoByPersonCode(string personCode)
        {
            string sql = "SELECT * FROM t_PersonInfo WHERE PersonCode=@personCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("personCode",personCode);
            return base.GetModel(sql,parameter);
        }

        public bool UpdatePersonInfo(t_PersonInfo personInfo)
        {
            string sql = "UPDATE t_PersonInfo SET PersonName=@personName,IsReceive=@isReceive,Remarks=@remarks WHERE PersonCode=@personCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("personCode", personInfo.PersonCode);
            parameter.Add("personName",personInfo.PersonName);
            parameter.Add("isReceive",personInfo.IsReceive);
            parameter.Add("remarks",@personInfo.Remarks);
            return base.ExecuteSql(sql,parameter)>0;
        }

        public bool DeletePersonInfo(string peronCode)
        {
            string sql = "DELETE FROM t_PersonInfo WHERE PersonCode=@personCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("personCode", peronCode);
            return base.ExecuteSql(sql, parameter) > 0;
        }
    }
}
