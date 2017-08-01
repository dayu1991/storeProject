﻿using dbentity.toolstrackingsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlserver.toolstrackingsystem
{
    public interface IToolPrepairRecordRepository:IRepositoryBase<t_ToolPrepairRecord>
    {
        t_ToolPrepairRecord GetToolPrepairRecordByToolCode(string toolCode);
    }
}
