using DataCollector.DAL.Configuration;
using DataCollector.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.DAL
{
    public class DCDbContext:IdentityDbContext<DCUser>
    {
        public DCDbContext()
            :base("DCDatabase")
        {
        }

        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<KeyValueData> KeyValueData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserDeviceConfiguration());
            modelBuilder.Configurations.Add(new KeyValueDataConfiguration());
        }
    }
}
