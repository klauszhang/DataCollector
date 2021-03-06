﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.DomainModel
{
    public class KeyValueData
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DCUser CreatedBy { get; set; }
        public UserDevice UserDevice { get; set; }
    }
}
