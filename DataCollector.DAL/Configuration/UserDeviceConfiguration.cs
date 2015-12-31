using DataCollector.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.DAL.Configuration
{
    public class UserDeviceConfiguration : EntityTypeConfiguration<UserDevice>
    {
        public UserDeviceConfiguration()
        {
            HasRequired(ud => ud.DCUser)
                .WithMany(du=>du.UserDevices)
                .HasForeignKey(ud=>ud.UserId)
                .WillCascadeOnDelete(false);

            HasMany(ud => ud.DeviceProfiles)
                .WithRequired();

            Property(du => du.UserId)
                .IsRequired();
        }
    }
}
