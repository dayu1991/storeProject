using Dapper;
using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public class ToolRepairRecordRepository : RepositoryBase<t_ToolRepairRecord>, IToolRepairRecordRepository
    {
        public List<t_ToolRepairRecord> GetToolRepairRecordByToolCode(string toolCode, string typeName, int pageIndex, int pageSize, out long Count)
        {
            string sql = "SELECT TOP "+pageSize+@" trr.[ID]
      ,trr.[TypeName]
      ,trr.[ChildTypeName]
      ,trr.[PackCode]
      ,trr.[PackName]
      ,trr.[ToolCode]
      ,trr.[ToolName]
      ,trr.[RepairedTime]
      ,[RepairedPerson] = case when sui.UserName is null then tpi.PersonName else sui.UserName end
      ,trr.[ReturnedTime]
      ,[ReturnedPerson] = case when sui1.UserName is null then tpi1.PersonName else sui1.UserName end
      ,trr.[ReceivedTime]
      ,[ReceivedPerson]  = case when sui2.UserName is null then tpi2.PersonName else sui2.UserName end
      ,trr.[ReceivedBackTime]
      ,[ReceivedBackPerson]  = case when sui3.UserName is null then tpi3.PersonName else sui3.UserName end
      ,trr.[ToolStatus]
  FROM [dbo].[t_ToolRepairRecord] trr left join Sys_User_Info sui on trr.RepairedPerson = sui.UserCode left join t_PersonInfo tpi on trr.RepairedPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on trr.ReturnedPerson = sui1.UserCode left join t_PersonInfo tpi1 on trr.ReturnedPerson = tpi1.PersonCode
  left join Sys_User_Info sui2 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi2 on trr.ReturnedPerson = tpi2.PersonCode
  left join Sys_User_Info sui3 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi3 on trr.ReturnedPerson = tpi2.PersonCode WHERE 1=1 ";
            string sqlNot = " trr.[ID] not in (SELECT TOP"+(pageIndex-1)*pageSize+@" trr.[ID]
  FROM [dbo].[t_ToolRepairRecord] trr left join Sys_User_Info sui on trr.RepairedPerson = sui.UserCode left join t_PersonInfo tpi on trr.RepairedPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on trr.ReturnedPerson = sui1.UserCode left join t_PersonInfo tpi1 on trr.ReturnedPerson = tpi1.PersonCode
  left join Sys_User_Info sui2 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi2 on trr.ReturnedPerson = tpi2.PersonCode
  left join Sys_User_Info sui3 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi3 on trr.ReturnedPerson = tpi2.PersonCode WHERE 1=1 ";
            string sqlCount = @"SELECT COUNT(1) FROM [dbo].[t_ToolRepairRecord] trr left join Sys_User_Info sui on trr.RepairedPerson = sui.UserCode left join t_PersonInfo tpi on trr.RepairedPerson = tpi.PersonCode
  left join Sys_User_Info sui1 on trr.ReturnedPerson = sui1.UserCode left join t_PersonInfo tpi1 on trr.ReturnedPerson = tpi1.PersonCode
  left join Sys_User_Info sui2 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi2 on trr.ReturnedPerson = tpi2.PersonCode
  left join Sys_User_Info sui3 on trr.ReturnedPerson = sui2.UserCode left join t_PersonInfo tpi3 on trr.ReturnedPerson = tpi2.PersonCode WHERE 1=1 ";
            DynamicParameters parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(toolCode))
            {
                sql += " AND trr.ToolCode LIKE @toolCode ";
                sqlNot += " AND trr.ToolCode LIKE @toolCode ";
                sqlCount += " AND trr.ToolCode LIKE @toolCode ";
                parameter.Add("toolCode", string.Format("%{0}%",toolCode));
            }
            if (!string.IsNullOrEmpty(typeName))
            {
                sql += " AND trr.TypeName LIKE @typeName ";
                sqlNot += " AND trr.TypeName LIKE @typeName ";
                sqlCount += " AND trr.ToolCode LIKE @toolCode ";
                parameter.Add("typeName",string.Format("%{0}%",typeName));
            }
            sqlNot += ")";
            string sqlFinal = string.Format("{0} AND {1}",sql,sqlNot);
            return base.QueryList(sql,parameter,out Count,sqlCount,false).ToList();
        }

        /// <summary>
        /// 获取送修工具信息（未领回的工具（客户端已送修：0，服务端接受：1  服务端维修完成：2   已被客户端领取：3））     
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="isReceived"></param>
        /// <returns></returns>
        public t_ToolRepairRecord GetToolRepairByCodeNotReceived(string toolCode)
        { 
            
             string sql = "SELECT * FROM [t_ToolRepairRecord] where [ToolCode]=@ToolCode and [ToolStatus] in (0,1,2)";
            var sqlDy = new DynamicParameters();
            sqlDy.Add("ToolCode", toolCode);
            return GetModel(sql, sqlDy);            
        }
    }
}
