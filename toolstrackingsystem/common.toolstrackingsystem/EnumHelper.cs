using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.toolstrackingsystem
{
    public class EnumHelper
    {
        public enum MenuName {
            /// <summary>
            /// 领用工具
            /// </summary>
            领用工具,
            /// <summary>
            /// 归还工具
            /// </summary>
            归还工具,
            /// <summary>
            /// 工具包管理
            /// </summary>
            工具包管理,
            /// <summary>
            /// 送修工具接收
            /// </summary>
            送修工具接收,
            /// <summary>
            /// 送修工具待完成
            /// </summary>
            送修工具待完成,
            /// <summary>
            /// 送修工具领取
            /// </summary>
            送修工具领取,
            /// <summary>
            /// 报废工具补充说明
            /// </summary>
            报废工具补充说明,
            /// <summary>
            /// 送修查询
            /// </summary>
            送修查询
        }
        public enum DataBaseName { 
            东所 = 1,
            西所 = 2,
            南所 = 3,
            石家庄所 = 4,
            设备 = 5,
        }
        public enum DataBaseType { 
            DongSuo=1,
            XiSuo=2,
            NanSuo=3,
            ShiJiaZhuang=4,
            SheBei=5
        }
    }
}
