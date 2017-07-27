using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class ToolTypeRepository : RepositoryBase<t_ToolType>, IToolTypeRepository
    {
        /// <summary>
        /// 获取工具配属列表
        /// </summary>
        /// <returns></returns>
        public List<t_ToolType> GetToolTypeList()
        {
            string sql = "SELECT * FROM t_ToolType WHERE classification=1";
            DynamicParameters parameter = new DynamicParameters();
            return base.QueryList(sql,parameter).ToList();
        }

        /// <summary>
        /// 获取工具类别列表
        /// </summary>
        /// <returns></returns>
        public List<t_ToolType> GetToolChildTypeList()
        {
            string sql = "SELECT * FROM t_ToolType WHERE classification=2";
            DynamicParameters parameter = new DynamicParameters();
            return base.QueryList(sql, parameter).ToList();
        }
    }
}
