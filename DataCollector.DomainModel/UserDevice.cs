using System.Collections.Generic;

namespace DataCollector.DomainModel
{
    public class UserDevice
    {
        public UserDevice()
        {
            DeviceProfiles = new List<DeviceProfile>();
        }
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string UserId { get; set; }

        public ICollection<DeviceProfile> DeviceProfiles { get; set; }
        public DCUser DCUser { get; set; }
    }
}
