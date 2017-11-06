using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewEntity.toolstrackingsystem;

namespace service.toolstrackingsystem
{
    public interface IOutBackStoreService
    {
        /// <summary>
        /// 获取超时未归还的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode,int pageIndex,int pageSize,out long Count);
        /// <summary>
        /// 获取超时未归还的导出工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode);
        /// <summary>
        /// 获取数据删除页面所需数据
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<OutBackInfoForDeleteEntity> GetOutBackInfoForDelete(string toolCode, string personCode, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 删除某条领用信息
        /// </summary>
        /// <param name="OutBackStoreID"></param>
        /// <returns></returns>
        bool DeleteOutBackInfo(string OutBackStoreID);
        /// <summary>
        /// 获取领用查询所需的领用工具分页信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        List<ToolBorrowEntity> GetToolBorrowList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo,int pageIndex,int pageSize,out long Count);
        /// <summary>
        /// 获取领用查询所需的领用工具导出信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        List<ToolBorrowEntity> GetToolBorrowList(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo);
        /// <summary>
        /// 获取领用查询所需的归还工具分页信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        List<ToolReturnEntity> GetToolReturnList(string toolCode, string PersonCode, string dateTimeFrom, string dateTimeTo, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 获取领用查询所需的归还工具导出信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <returns></returns>
        List<ToolReturnEntity> GetToolReturnList(string toolCode, string PersonCode, string dateTimeFrom, string dateTimeTo);
        /// <summary>
        /// 获取流水账分页信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<CurrentToolInfoEntity> GetCurrentToolInfoList(string toolCode, string packCode,string personCode, string dateTimeFrom, string dateTimeTo, int pageIndex, int pageSize, out long Count);
        /// <summary>
        /// 获取流水账信息(导出)
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <param name="dateTimeFrom"></param>
        /// <param name="dateTimeTo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<CurrentToolInfoEntity> GetCurrentToolInfoForExport(string toolCode, string personCode, string dateTimeFrom, string dateTimeTo);
        /// <summary>
        /// 查询未归还的工具
        /// </summary>
        /// <param name="toolCode"></param>
        /// <returns></returns>
        t_OutBackStore GetToolInfoNotBackByToolCode(string toolCode);
        /// <summary>
        /// 根据包编码获取未归还的工具信息
        /// </summary>
        /// <param name="packCode"></param>
        /// <returns></returns>
        List<t_OutBackStore> GetToolInfoNotBackByPackCode(string packCode);
    }
}
