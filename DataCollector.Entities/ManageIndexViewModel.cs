using DataCollector.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Entities
{
    public class ManageIndexViewModel
    {
        public DCUser DCUser { get; set; }
        public IEnumerable<UserDevice> Devices { get; set; }
    }
}
