using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataCollector.Entities
{
    public class DCUserViewModel:IdentityUser
    {

        public bool Deleted { get; set; }

    }
}
