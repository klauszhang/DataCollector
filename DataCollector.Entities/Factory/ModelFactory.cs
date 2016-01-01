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
                UserId = userId,
                DeviceName = vm.DeviceName,

                //TODO 
                DeviceProfiles = null


            };
        }

        public KeyValueData Create(KeyValueDataViewModel vm, string currentUserId, UserDevice device)
        {
            // TODO
            return new KeyValueData
            {
                CreatedByUserId = currentUserId,
                CreatedOn = DateTime.UtcNow,
                Key = vm.Key,
                Value = vm.Value,
                UserDevice = device
            };
        }

        public List<KeyValueOutputViewModel> Create(List<KeyValueData> data)
        {
            List<KeyValueOutputViewModel> result = new List<KeyValueOutputViewModel>();
            foreach (var elem in data)
            {
                result.Add(new KeyValueOutputViewModel
                {
                    CreatedBy = elem.CreatedBy,
                    CreatedOn = elem.CreatedOn,
                    Id = elem.Id,
                    Key = elem.Key,
                    Value = elem.Value,
                    UserDevice = elem.UserDevice
                });
            }
            return result;
        }
    }
}
