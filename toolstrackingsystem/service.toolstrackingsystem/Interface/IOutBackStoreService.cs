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
        List<NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode);
    }
}
