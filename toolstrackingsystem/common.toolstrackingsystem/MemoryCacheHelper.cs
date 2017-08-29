﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace common.toolstrackingsystem
{
    public class MemoryCacheHelper
    {
        private static object clientName = MemoryCache.Default["clientName"];
        public static string GetConnectionStr() {
            if (clientName != null)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[clientName.ToString()].ConnectionString;
            }
            return System.Configuration.ConfigurationManager.ConnectionStrings["NanSuo"].ConnectionString;
        }
    }
}
