using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCollector.DomainModel;
using System.Web;
using System.Security.Principal;

namespace DataCollector.Entities
{
    public class ModelFactory
    {
        public UserDevice Create(NewDeviceViewModel vm, string userId)
        {
            return new UserDevice
            {
                UserId=userId,
                DeviceName = vm.DeviceName,

                //TODO 
                DeviceProfiles = null


            };
        }
    }
}
