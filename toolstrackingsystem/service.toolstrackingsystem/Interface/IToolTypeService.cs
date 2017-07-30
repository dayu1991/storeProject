﻿using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.toolstrackingsystem
{
    public interface IToolTypeService
    {
        /// <summary>
        /// 获取工具配属列表
        /// </summary>
        /// <returns></returns>
        List<t_ToolType> GetToolTypeList();
        /// <summary>
        /// 获取工具类别列表
        /// </summary>
        /// <returns></returns>
        List<t_ToolType> GetToolChildTypeList();
    }
}