using DataCollector.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.DAL.Configuration
{
    public class KeyValueDataConfiguration:EntityTypeConfiguration<KeyValueData>
    {
        public KeyValueDataConfiguration()
        {
            Property(kv => kv.Key)
                .IsRequired()
                .HasMaxLength(40);

            Property(kv => kv.Value)
                .IsRequired()
                .HasMaxLength(100);

            Property(kv => kv.CreatedOn)
                .IsRequired();

            HasRequired(kv => kv.UserDevice)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
