using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class ToolPrepairRecordRepository : RepositoryBase<t_ToolRepairRecord>, IToolPrepairRecordRepository
    {
        public t_ToolRepairRecord GetToolPrepairRecordByToolCode(string toolCode)
        {
            string sql = "SELECT * FROM t_ToolPrepairRecord WHERE ToolCode=@toolCode";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("toolCode",toolCode);
            return base.GetModel(sql,parameter);
        }
    }
}
