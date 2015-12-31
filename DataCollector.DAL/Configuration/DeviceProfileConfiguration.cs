using DataCollector.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.DAL.Configuration
{
    public class DeviceProfileConfiguration : EntityTypeConfiguration<DeviceProfile>
    {
        public DeviceProfileConfiguration()
        {
            Property(ud => ud.PropertyName)
                .HasMaxLength(40)
                .IsRequired();

            Property(ud => ud.PropertyValue)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
