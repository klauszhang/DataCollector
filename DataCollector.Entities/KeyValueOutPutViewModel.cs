using DataCollector.DomainModel;
using System;

namespace DataCollector.Entities
{
    public class KeyValueOutputViewModel
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }

        public DCUser CreatedBy { get; set; }
        public UserDevice UserDevice { get; set; }
    }
}
