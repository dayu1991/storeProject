using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public class OutBackStoreService : IOutBackStoreService
    {
        /// <summary>
        /// 获取超时未归还的工具信息
        /// </summary>
        /// <param name="toolCode"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public List<ViewEntity.toolstrackingsystem.NotBackToolEntity> GetNotBackToolInfoList(string toolCode, string personCode)
        {
            throw new NotImplementedException();
        }
    }
}
