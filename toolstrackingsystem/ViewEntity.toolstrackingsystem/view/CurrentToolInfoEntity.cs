﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEntity.toolstrackingsystem
{
    public class CurrentToolInfoEntity
    {
        public string TypeName { get; set; }
        public string ChildTypeName { get; set; }
        public string PackCode { get; set; }
        public string PackName { get; set; }
        public string ToolCode { get; set; }
        public string ToolName { get; set; }
        public string Models { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
        public string InStoreTime { get; set; }
        public string OutStoreTime { get; set; }
        public string BackTime { get; set; }
        public string OptionType { get; set; }
        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string BackPesonCode { get; set; }
        public string BackPersonName { get; set; }
        public string describes { get; set; }
        public string OptionPerson { get; set; }

    }
}