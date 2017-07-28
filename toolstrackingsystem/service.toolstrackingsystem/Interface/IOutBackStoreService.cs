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

    }
}
