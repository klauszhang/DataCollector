using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DataCollector.DomainModel
{
    public class DCUser:IdentityUser
    {
        public ICollection<UserDevice> UserDevices { get; set; }
    }
}
