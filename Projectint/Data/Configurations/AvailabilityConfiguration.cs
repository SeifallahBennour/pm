using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class AvailabilityConfiguration : EntityTypeConfiguration<Availability>
    {
        public AvailabilityConfiguration()
        {
            HasRequired<Doctor>(s => s.doctor).WithMany(s => s.listeAvailability).HasForeignKey(s => s.id);
        }
    }
}
